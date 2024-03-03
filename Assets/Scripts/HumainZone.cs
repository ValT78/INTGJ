using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumainZone : MonoBehaviour
{
    [SerializeField] private GameObject proteine;
    [SerializeField] private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pique()
    {
        print("zone piqué");
        Instantiate(proteine, this.transform.position+offset, Quaternion.identity);
    }
}
