using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goofyScript : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1f;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        transform.Rotate(0, rotationSpeed*Time.fixedDeltaTime, 0);
    }
}
