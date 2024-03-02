using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorterObjet : MonoBehaviour
{
    private int force;

    [HideInInspector] public GameObject objetPorte;
    private bool porter;
    
 
    // Start is called before the first frame update
    void Start()
    {
        porter = false;
        force = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (porter)
            {
                porter = false;
                if (objetPorte != null)
                {
                    objetPorte.transform.SetParent(null);
                    objetPorte.GetComponent<Rigidbody>().useGravity = true;
                    objetPorte.layer = LayerMask.NameToLayer("Default");
                    objetPorte = null;

                }

            }
            else
            {

                if (objetPorte != null)
                {
                    if (objetPorte.GetComponent<ObjetAPorter>().poids <= force)
                    {
                        porter = true;
                        objetPorte.transform.SetParent(this.transform);
                        objetPorte.GetComponent<Rigidbody>().useGravity = false;
                        objetPorte.layer = LayerMask.NameToLayer("IgnoreRaycast");
                    }
                }
            }
        }
        if (!porter && objetPorte != null)
        {
            if (objetPorte.GetComponent<ObjetAPorter>().poids <= force)
            {
                print("portez avec clique gauche");
            }
            else { print("vous avez besoin de plus de force"); }

        }
    }
    public void Eloignement(GameObject objet) 
    {
        if (porter) {
            porter = false;
            objet.transform.SetParent(null);
            objet.GetComponent<Rigidbody>().useGravity = true;
            objet.layer = LayerMask.NameToLayer("Default");
        }
    }
       
    
    public void PlusFort()
    {
        force += 1;
    }
    public int GetForce()
    {
        return (force);
    }
    
    
}
