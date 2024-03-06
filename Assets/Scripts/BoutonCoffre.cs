using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonCoffre : MonoBehaviour
{
    [SerializeField] private OuvrirCoffre ouvrirCoffre;
    private SoundManager soundManager;

    private void Start()
    {
        soundManager = SoundManager.Instance;
    }
    public void BoutonAppuyé()
    {
        Debug.Log("Coffre");
        ouvrirCoffre.coffreDébloqué = true;
        if(soundManager != null)
        soundManager.PlaySound(soundManager.chest);
    }
}
