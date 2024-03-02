using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonCoffre : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crayon")) // il faut créer le tag "Crayon"
        {
            Debug.Log("Coffre ouvert");
        }
    }
}
