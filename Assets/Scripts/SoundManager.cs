using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [Header("Sources")]

    public AudioSource musicSource;
    public AudioSource effectSource;
    public AudioSource effectSourceRepeat;


    [Header("Musics")]

    public AudioClip bzz1;
    public AudioClip bzz2;
    public AudioClip bzz3;
    public AudioClip bzz4;
    public AudioClip bzz5;

    public AudioClip musicDebut;
    public AudioClip musicCliffHanger;

    [Header("Sound effects")]

    public AudioClip depression;
    public AudioClip morse;
    public AudioClip openDoor;
    public AudioClip dialToilette;
    public AudioClip dialApiculteur;
    public AudioClip piqure;
    public AudioClip chest;
    public AudioClip anvil;
    public AudioClip bee;
    public AudioClip bouton;
    public AudioClip convAigu;
    public AudioClip convGrave;
    public AudioClip convMoyen;



    [Header("Audio Mixer")]

    public AudioMixer mixer;


    private int requestedSceneMusic;
    private int requestedSceneEffect;
    public AudioClip nextLoop;


    #region Singleton
    public static SoundManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        musicSource.loop = true;
        effectSource.loop = false;
        effectSourceRepeat.loop = true;
        

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (scene.isLoaded && scene.buildIndex == 1)
        {
            print(SceneManager.GetActiveScene().buildIndex);
            nextLoop = bzz1;
            StartCoroutine(PlayNextLoop());
        }
    }

    public AudioClip GetCurrentMusic()
    {
        return musicSource.clip;
    }

    #region Sound control

    public void PlaySound(AudioClip clip, float delay = 0)
    {
        if (delay > 0)
        {
            StartCoroutine(PlaySoundAfterTime(clip, delay));
            return;
        }
        effectSource.PlayOneShot(clip);
    }

    /// <summary>
    /// Play a sound on loop
    /// </summary>
    /// <param name="clip">The clip to play in loop</param>
    /// <param name="forceRestart">If true, the sound will restart and play in loop. If false, the sound won't restart if it's the same.</param>
    public void PlaySoundLoop(AudioClip clip, bool forceRestart = false)
    {
        effectSourceRepeat.loop = true;
        if (!forceRestart && clip == effectSourceRepeat.clip)
        {
            if (!effectSourceRepeat.isPlaying)
                effectSourceRepeat.Play();
            return;
        }

        effectSourceRepeat.clip = clip;
        effectSourceRepeat.Play();
    }

    /// <summary>
    /// Stops the looping sound
    /// </summary>
    /// <param name="forceStop">Forces immediate stop, otherwise waits for the last iteration.</param>
    public void StopSoundLoop(bool forceStop = false)
    {
        effectSourceRepeat.loop = false;
        if (forceStop)
            effectSourceRepeat.Stop();
    }

    public void PlayMusic(AudioClip clip, float delay = 0, bool forceRestart = false)
    {
        if (delay > 0)
        {
            StartCoroutine(PlayMusicAfterTime(clip, delay, forceRestart));
            return;
        }

        if (!forceRestart && clip == musicSource.clip)
        {
            if (!musicSource.isPlaying)
                musicSource.Play();
            return;
        }

        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    #endregion

    private IEnumerator PlaySoundAfterTime(AudioClip clip, float delay)
    {
        requestedSceneEffect = SceneManager.GetActiveScene().buildIndex;

        yield return new WaitForSeconds(delay);

        if (requestedSceneEffect != SceneManager.GetActiveScene().buildIndex)
            yield break;

        PlaySound(clip);
    }
    private IEnumerator PlayMusicAfterTime(AudioClip clip, float delay, bool forceRestart)
    {
        requestedSceneMusic = SceneManager.GetActiveScene().buildIndex;

        if (delay > 0)
            yield return new WaitForSeconds(delay);

        if (requestedSceneMusic != SceneManager.GetActiveScene().buildIndex)
            yield break;

        PlayMusic(clip, forceRestart: forceRestart);
    }

    private IEnumerator PlayNextLoop()
    {
        if (nextLoop != null)
        {
            musicSource.clip = nextLoop;
            musicSource.Play();
            yield return new WaitForSeconds(musicSource.clip.length);
            StartCoroutine(PlayNextLoop());
        }
    }   



}
