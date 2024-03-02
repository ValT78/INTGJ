using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonCoffre : MonoBehaviour
{
    [SerializeField] private OuvrirCoffre ouvrirCoffre; 

    public void BoutonAppuyé()
    {
        Debug.Log("Coffre");
        ouvrirCoffre.coffreDébloqué = true;
    }
}
