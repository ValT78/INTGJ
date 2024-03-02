using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNum : MonoBehaviour
{
    [SerializeField] private CodeFrigo codeFrigo;
    [SerializeField] private int num;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crayon")) // il faut créer le tag "Crayon"
        {
            Debug.Log(num);
            codeFrigo.ToucheBouton(num);
        }
    }
}
