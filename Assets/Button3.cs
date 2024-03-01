using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3 : MonoBehaviour
{
    [SerializeField] private CodeFrigo codeFrigo;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crayon")) // il faut cr�er le tag "Crayon"
        {
            Debug.Log("3");
            codeFrigo.ToucheBouton(3);
        }
    }
}
