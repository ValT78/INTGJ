using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DéclenchementCinématiqueFin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Serrure"))
        {
            Debug.Log("Fenêtre ouverte !");
            // Déclenchement animation de fin
        }
    }
}
