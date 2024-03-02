using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuvertureObjet : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAxis = Vector3.up; // Axe de rotation
    [SerializeField] private float rotationSpeed = 50f; // Vitesse de rotation en degr�s par seconde
    [SerializeField] private int targetAngle = 90;
    private float totalAngleRotated = 0;
    void Update()
    {
        if (totalAngleRotated < targetAngle)
        {
            transform.RotateAround(transform.position, rotationAxis, rotationSpeed * Time.deltaTime);
            totalAngleRotated += Time.deltaTime * rotationSpeed;
        }
    }
            
    
}
