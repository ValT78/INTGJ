using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumainZone : MonoBehaviour
{
    [SerializeField] private GameObject proteine;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Animator animator;

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
        StartCoroutine(Explosion());
        animator.SetTrigger("Mort");

    }
    private IEnumerator Explosion()
    {
        yield return new WaitForSeconds(2);
        Instantiate(proteine, this.transform.position + offset, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
