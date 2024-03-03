using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningScript : MonoBehaviour
{
    [SerializeField] private Transform taon;
    [SerializeField] private Transform taonMaman;
    [SerializeField] private Transform taonPapa;
    [SerializeField] private Vector3 speed;
    [SerializeField] private float maxX;
    [SerializeField] private GameObject apiculteur;

    private SoundManager soundManager;

    void Start()
    {
        soundManager = SoundManager.Instance;
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
        }

    }
}
