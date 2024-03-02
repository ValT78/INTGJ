using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorterObjet : MonoBehaviour
{
    [HideInInspector] public GameObject objetPorte;
    private bool porter;
 
    // Start is called before the first frame update
    void Start()
    {
        porter = false;
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
                    porter = true;
                    objetPorte.transform.SetParent(this.transform);
                }
            }
        }

      
       
    }
    
}