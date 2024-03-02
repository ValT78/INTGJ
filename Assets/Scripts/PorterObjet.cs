using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorterObjet : MonoBehaviour
{
    private int force;
    [SerializeField] private float agrandissement;

    [HideInInspector] public GameObject objetPorte;
    [HideInInspector] public bool porter;

    private SoundManager soundManager;
 
    // Start is called before the first frame update
    void Start()
    {
        porter = false;
        force = 0;
        soundManager = SoundManager.Instance;
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
                    objetPorte.GetComponent<Rigidbody>().isKinematic = false;
                    objetPorte.layer = LayerMask.NameToLayer("Default");
                    objetPorte.GetComponent<Collider>().enabled = true;
                    
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
                        objetPorte.layer = LayerMask.NameToLayer("Ignore Raycast");
                        objetPorte.GetComponent<Collider>().enabled = false;
                        objetPorte.GetComponent<Rigidbody>().isKinematic = true;
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
       
    
    public void PlusFort()
    {
        force += 1;
        if (soundManager != null)
        {
            if (force == 1)
                soundManager.nextLoop = soundManager.bzz3;
            else if (force == 2)
                soundManager.nextLoop = soundManager.bzz4;
            else if (force == 3)
                soundManager.nextLoop = soundManager.bzz4;
            else if (force == 4)
                soundManager.nextLoop = soundManager.bzz5;
        }
        this.transform.localScale = this.transform.localScale + Vector3.one*agrandissement;
    }
    public int GetForce()
    {
        return (force);
    }
    
    
}
