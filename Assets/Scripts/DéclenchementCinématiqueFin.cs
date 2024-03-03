using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DéclenchementCinématiqueFin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Serrure"))
        {
            Debug.Log("Fenêtre ouverte !");
            // Déclenchement animation de fin
            SceneManager.LoadScene("Ending");
        }
    }
}
