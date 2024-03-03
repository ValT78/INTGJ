using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anviil : MonoBehaviour
{
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject enclume;
    private SoundManager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out Apiculteur apiculteur))
        {
            StartCoroutine(apiculteur.SmoothSquash());
            Instantiate(key, apiculteur.transform.position, Quaternion.identity);
            soundManager.PlaySound(soundManager.anvil);
            Destroy(enclume);
        }
    }
}
