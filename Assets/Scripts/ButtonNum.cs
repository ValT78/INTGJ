using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNum : MonoBehaviour
{
    [SerializeField] private CodeFrigo codeFrigo;
    [SerializeField] private int num;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bouton touch�");

        if (collision.gameObject.CompareTag("Crayon")) // il faut cr�er le tag "Crayon"
        {
            Debug.Log(num);
            codeFrigo.ToucheBouton(num);
        }
    }

    public void BoutonAppuy�()
    {
        Debug.Log(num);
        codeFrigo.ToucheBouton(num);
    }

}
