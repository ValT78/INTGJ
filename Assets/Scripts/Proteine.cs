using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Proteine : MonoBehaviour
{
    [SerializeField] float vitesseRotation = 50f;

    // Start is called before the first frame update
    private void Update()
    {
        transform.Rotate(Vector3.back, vitesseRotation * Time.deltaTime);
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