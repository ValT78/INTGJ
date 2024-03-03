using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNum : MonoBehaviour
{
    [SerializeField] private CodeFrigo codeFrigo;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private int num;

    public void BoutonAppuyé()
    {
        Debug.Log(num);
        codeFrigo.ToucheBouton(num);
        audioSource.Play();
    }

}
