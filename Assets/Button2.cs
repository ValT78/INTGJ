using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour
{
    [SerializeField] private CodeFrigo codeFrigo;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crayon")) // il faut créer le tag "Crayon"
        {
            Debug.Log("2");
            codeFrigo.ToucheBouton(2);
        }
    }
}
