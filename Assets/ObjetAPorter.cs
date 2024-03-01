using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetAPorter : MonoBehaviour
{
    PorterObjet taon;
    // Start is called before the first frame update
    void Start()
    {
        taon=GameObject.FindWithTag("Player").GetComponent<PorterObjet>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")){
            taon.objetPorte = gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        taon.objetPorte = null;
    }
}
