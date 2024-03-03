using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    [SerializeField] private CodeFrigo codeFrigo;

    private SoundManager soundManager;

    private void Start()
    {
        soundManager = SoundManager.Instance;
    }

    public void BoutonAppuyé()
    {
        Debug.Log("Reset");
        codeFrigo.Reset();
        soundManager.PlaySound(soundManager.bouton);

    }
}
