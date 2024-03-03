using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apiculteur : MonoBehaviour
{
    [SerializeField] private GameObject apiculteur;
    [SerializeField] private float squashTime;
    [SerializeField] private float endScale;
    private float startScale;

    private void Start()
    {
        startScale = apiculteur.transform.localScale.x;
    }
    public IEnumerator SmoothSquash()
    {
        float t = 0;
        while (t < squashTime)
        {
            t += Time.deltaTime;
            apiculteur.transform.localScale = new Vector3(apiculteur.transform.localScale.x, Mathf.Lerp(startScale, endScale, t / squashTime), apiculteur.transform.localScale.z);
            yield return null;
        }
    }
}
