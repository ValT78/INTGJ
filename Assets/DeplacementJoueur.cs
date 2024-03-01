using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementJoueur : MonoBehaviour
{
    // Vitesse de d�placement du joueur
    public float vitesse = 5f;

    void Update()
    {
        // Obtenez les entr�es des touches fl�ch�es
        float deplacementHorizontal = Input.GetAxis("Horizontal");
        float deplacementVertical = Input.GetAxis("Vertical");

        // Calculez le vecteur de d�placement en fonction des entr�es des touches fl�ch�es
        Vector3 deplacement = new Vector3(deplacementHorizontal, 0f, deplacementVertical) * vitesse * Time.deltaTime;

        // Appliquez le d�placement au joueur
        transform.Translate(deplacement);
    }
}
