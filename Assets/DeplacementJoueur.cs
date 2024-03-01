using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementJoueur : MonoBehaviour
{
    // Vitesse de déplacement du joueur
    public float vitesse = 5f;

    void Update()
    {
        // Obtenez les entrées des touches fléchées
        float deplacementHorizontal = Input.GetAxis("Horizontal");
        float deplacementVertical = Input.GetAxis("Vertical");

        // Calculez le vecteur de déplacement en fonction des entrées des touches fléchées
        Vector3 deplacement = new Vector3(deplacementHorizontal, 0f, deplacementVertical) * vitesse * Time.deltaTime;

        // Appliquez le déplacement au joueur
        transform.Translate(deplacement);
    }
}
