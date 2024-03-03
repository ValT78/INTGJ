using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScript : MonoBehaviour
{
    [SerializeField] private Transform taon;
    [SerializeField] private Transform taonMaman;
    [SerializeField] private Transform taonPapa;
    [SerializeField] private Vector3 speed;
    [SerializeField] private float maxX;
    [SerializeField] private GameObject apiculteur;

    private SoundManager soundManager;

    private float time_count = 0;
    private float another_time_count = 0;

    public float talking_time = 0.1f;

    void Start()
    {
        soundManager = SoundManager.Instance;
        soundManager.musicSource.Stop();
        soundManager.PlayMusic(soundManager.musicDebut);

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (taon.position.x < maxX)
        {
            taon.position += speed * Time.fixedDeltaTime;
            taonMaman.position += speed * Time.fixedDeltaTime;
            taonPapa.position += speed * Time.fixedDeltaTime;

        }
        else
        {
            apiculteur.SetActive(true);
            if (apiculteur.transform.position.y < 0.65f)
            {
                apiculteur.transform.position += new Vector3(0, 1f, 0) * Time.fixedDeltaTime;
            }
            else
            {
                time_count += Time.fixedDeltaTime;
            }

        }

        if (time_count > 3f)
        {
            SceneManager.LoadScene("Appart");
        }

    }
}
