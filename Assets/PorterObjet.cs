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
        if (Input.GetMouseButtonUp(0))
        {
            if (porter)
            {
                porter = false;
                objetPorte.transform.SetParent(null);
                objetPorte= null;
            }
            else
            {
                
                if (objetPorte != null)
                {
                    if (objetPorte.GetComponent<ObjetAPorter>().poids <= force)
                    {
                        porter = true;
                        objetPorte.transform.SetParent(this.transform);
                    }
                }
            }
        }
        if(!porter && objetPorte != null )
        {
            if(objetPorte.GetComponent<ObjetAPorter>().poids <= force)
            {
                print("portez avec clique gauche");
            }
            else { print("vous avez besoin de plus de force"); }
            
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
