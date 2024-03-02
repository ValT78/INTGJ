using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    [SerializeField] private CodeFrigo codeFrigo;
    [SerializeField] private AudioSource audioSource;

    public void BoutonAppuy�()
    {
        audioSource.Play();
        Debug.Log("Reset");
        codeFrigo.Reset();
    }
}
