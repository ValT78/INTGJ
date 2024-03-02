using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetAPorter : MonoBehaviour
{
    PorterObjet taon;
    public int poids;
    // Start is called before the first frame update
    void Start()
    {
        taon=GameObject.FindWithTag("Player").GetComponent<PorterObjet>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")){
            if (taon.objetPorte == null)
            {
                taon.objetPorte = gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {if (taon.objetPorte==gameObject)
            taon.Eloignement(taon.objetPorte);
            taon.objetPorte = null;
        }

    }
}
