using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anviil : MonoBehaviour
{
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject enclume;
    private SoundManager soundManager;
    [SerializeField] GameObject spawnclef;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out Apiculteur apiculteur))
        {
            
            StartCoroutine(apiculteur.SmoothSquash());
            Instantiate(key, new Vector3(10.74f, 6.77f, 24.29f), Quaternion.identity);
            soundManager.PlaySound(soundManager.anvil);
            StartCoroutine(Destruction());
        }
    }

    IEnumerator Destruction()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(enclume);
    }
}
