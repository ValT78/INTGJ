using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonCoffre : MonoBehaviour
{
    [SerializeField] private OuvrirCoffre ouvrirCoffre; 

    public void BoutonAppuy�()
    {
        Debug.Log("Coffre");
        ouvrirCoffre.coffreD�bloqu� = true;
    }
}
