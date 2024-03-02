using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiquerHumain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 3f))
            {
                // Vérifier si l'objet détecté est celui que vous voulez
                if (hitInfo.collider.TryGetComponent<HumainZone>(out var humainzone))
                {
                    humainzone.pique();
                }
            }
        }
    }
    }

