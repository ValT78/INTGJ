using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonCoffre : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crayon")) // il faut créer le tag "Crayon"
        {
            // Ouvrir coffre
        }
    }
}
