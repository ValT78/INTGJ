using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiverCode : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ButtonNum>(out ButtonNum buttonNum))
        {
            buttonNum.BoutonAppuyé();
        }
    }
}
