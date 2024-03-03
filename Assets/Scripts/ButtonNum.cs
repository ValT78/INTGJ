using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNum : MonoBehaviour
{
    [SerializeField] private CodeFrigo codeFrigo;
    [SerializeField] private int num;

    private SoundManager soundManager;

    private void Start()
    {
        soundManager = SoundManager.Instance;
    }

    public void BoutonAppuyé()
    {
        Debug.Log(num);
        codeFrigo.ToucheBouton(num);
        soundManager.PlaySound(soundManager.bouton);
    }

}
