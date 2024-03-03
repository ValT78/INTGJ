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

    [SerializeField] private GameObject noWheyUI;
    [SerializeField] private GameObject howPorter;
    [SerializeField] private GameObject betterUI;

    // Start is called before the first frame update
    void Start()
    {
        porter = false;
        force = 0;
        soundManager = SoundManager.Instance;
        foreach(UIMove ui in FindObjectsOfType<UIMove>())
        {
            if(ui.id == 0)
            {
                noWheyUI = ui.gameObject;
                ui.gameObject.SetActive(false);
            }
            else if(ui.id == 1)
            {
                howPorter = ui.gameObject;
                ui.gameObject.SetActive(false);
            }
            else if(ui.id == 2)
            {
                betterUI = ui.gameObject;
                ui.gameObject.SetActive(false);
            }   
        }
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
                    if (objetPorte.TryGetComponent<Rigidbody>(out var rigidbody))
                    {
                        rigidbody.useGravity = true;
                        rigidbody.isKinematic = false;
                    }
                    else
                    {
                        objetPorte.GetComponent<gravity>().enabled = true;
                    }
                    objetPorte.layer = LayerMask.NameToLayer("Default");
                    objetPorte.GetComponent<Collider>().enabled = true;

                    objetPorte = null;


                }

            }
            else
            {

                if (objetPorte != null)
                {
                    if (objetPorte.GetComponentInChildren<ObjetAPorter>().poids <= force)
                    {
                        porter = true;
                        objetPorte.transform.SetParent(this.transform);
                        objetPorte.layer = LayerMask.NameToLayer("Ignore Raycast");
                        objetPorte.GetComponent<Collider>().enabled = false;
                        if (objetPorte.TryGetComponent<Rigidbody>(out var rigidbody))
                        {
                            rigidbody.useGravity = false;
                            rigidbody.isKinematic = true;
                        }
                        else
                        {
                            objetPorte.GetComponent<gravity>().enabled = false;
                        }
                    }
                }
            }

        }
    }
       
    
    public void PlusFort()
    {
        force += 1;
        if (soundManager != null)
        {
            if (force == 1)
                soundManager.nextLoop = soundManager.bzz2;
            else if (force == 2)
                soundManager.nextLoop = soundManager.bzz3;
            else if (force == 3)
                soundManager.nextLoop = soundManager.bzz4;
            else if (force == 4)
                soundManager.nextLoop = soundManager.bzz5;
        }
        this.transform.localScale = this.transform.localScale + Vector3.one*agrandissement;
        betterUI.SetActive(true);
    }
    public int GetForce()
    {
        return (force);
    }
    
    public void ShowUI(int poids)
    {
        if(poids <= force) howPorter.SetActive(true);
        else noWheyUI.SetActive(true);
    }

}
