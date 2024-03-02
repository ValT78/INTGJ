using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonCoffre : MonoBehaviour
{
    [SerializeField] private OuvrirCoffre ouvrirCoffre;
    [SerializeField] private AudioSource audioSource;

    public void BoutonAppuyé()
    {
        Debug.Log("Coffre");
        ouvrirCoffre.coffreDébloqué = true;
        audioSource.Play();
    }
}
