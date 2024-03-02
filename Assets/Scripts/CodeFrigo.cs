using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeFrigo : MonoBehaviour
{
    [SerializeField] private List<int> codeDeverrouillage = new List<int>() {1, 2, 3};
    [SerializeField] private List<int> codeTouche = new List<int>();

    [SerializeField] private OuvertureObjet ouvertureObjet;

    public void ToucheBouton(int valeur) // appelée à chaque fois qu'un bouton est touché
    {
        codeTouche.Add(valeur);

        if (CodeCorrect())
        {
            ouvertureObjet.frigoDébloqué = true;
        }
    }

    private bool CodeCorrect()
    {
        if (codeTouche.Count != codeDeverrouillage.Count)
        {
            return false;
        }

        for (int i = 0; i < codeTouche.Count; i++)
        {
            if (codeTouche[i] != codeDeverrouillage[i])
            {
                return false; // La touche actuelle ne correspond pas au code, retourne faux
            }
        }

        return true;
    }

    public void Reset()
    {
        codeTouche.Clear();
    }


}
