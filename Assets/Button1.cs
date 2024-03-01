using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : MonoBehaviour
{
    [SerializeField] private CodeFrigo codeFrigo;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crayon")) // il faut créer le tag "Crayon"
        {
            Debug.Log("1");
            codeFrigo.ToucheBouton(1);
        }
    }

}
