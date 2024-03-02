using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] Rigidbody rb;
    [SerializeField] float speedMovement;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        rb.velocity = direction * speedMovement;
    }
}
