using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumainZone : MonoBehaviour
{
    [SerializeField] private GameObject proteine;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Animator animator;

    public bool anima;

    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(anim());
        anima = false;
    }
    public void pique()
    {
        print("zone piqué");
        StartCoroutine(Explosion());
        animator.SetTrigger("Mort");

    }
    private IEnumerator Explosion()
    {
        yield return new WaitForSeconds(2.6f);
        Instantiate(proteine, this.transform.position + offset, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private IEnumerator anim()
    {
        yield return new WaitForSeconds(4);
        anima = !anima;
        animator.SetBool("anima",anima);
        StartCoroutine(anim());
    }
}
