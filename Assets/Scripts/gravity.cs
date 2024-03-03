using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class gravity : MonoBehaviour {
    [SerializeField] float vitesse;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (!(Physics.Raycast(GetComponent<Renderer>().bounds.min, UnityEngine.Vector3.down, out RaycastHit hit, 0.05f)))
        {
            this.transform.position = this.transform.position + UnityEngine.Vector3.down * Time.deltaTime * vitesse;
        }
    }
}
