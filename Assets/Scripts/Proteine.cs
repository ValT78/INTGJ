using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Proteine : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PorterObjet>(out var player))
        {
            player.PlusFort();
            Destroy(this.gameObject);
        }
    }
}