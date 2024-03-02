using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetAPorter : MonoBehaviour
{
    public int poids;
    // Start is called before the first frame update


    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<PorterObjet>(out var porterObjet)){
            if (porterObjet.objetPorte == null)
            {
                porterObjet.objetPorte = gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PorterObjet>(out var porterObjet))
        {if (porterObjet.objetPorte==gameObject && porterObjet.porter==false)
            porterObjet.objetPorte = null;

        }

    }
}
