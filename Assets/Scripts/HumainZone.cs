using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumainZone : MonoBehaviour
{
    [SerializeField] private GameObject proteine;
    [SerializeField] private Vector3 offset;

    private SoundManager soundManager;

    void Start()
    {
        soundManager = SoundManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pique()
    {
        soundManager.PlaySound(soundManager.piqure);
        print("zone piqué");
        Instantiate(proteine, this.transform.position+offset, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
