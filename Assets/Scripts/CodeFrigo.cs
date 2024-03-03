using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodeFrigo : MonoBehaviour
{
    [SerializeField] private List<int> codeDeverrouillage;
    [SerializeField] private List<int> codeTouche = new List<int>();

    [SerializeField] private OuvertureObjet ouvertureObjet;

    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private AudioSource audioSource;

    public void ToucheBouton(int valeur) // appelée à chaque fois qu'un bouton est touché
    {
        codeTouche.Add(valeur);

        textMeshProUGUI.color = Color.black;
        textMeshProUGUI.text = string.Join(" ", codeTouche);

        if (CodeCorrect())
        {
            ouvertureObjet.frigoDébloqué = true;
            audioSource.Play();

            textMeshProUGUI.color = Color.green;
            textMeshProUGUI.text = "Code Correct !";
        }

        else if (codeTouche.Count >= 3)
        {
            codeTouche.Clear();
            textMeshProUGUI.color = Color.red;
            textMeshProUGUI.text = "Code incorrect ! Réessayez !";
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
        textMeshProUGUI.color = Color.black;
        textMeshProUGUI.text = "000";
    }


}
