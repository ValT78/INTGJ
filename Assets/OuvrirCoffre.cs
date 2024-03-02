using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuvrirCoffre : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAxis = Vector3.back; // Axe de rotation
    [SerializeField] private float rotationSpeed = 50f; // Vitesse de rotation en degr�s par seconde
    [SerializeField] private int targetAngle = 90;

    [SerializeField] public bool coffreD�bloqu� = false;

    private float totalAngleRotated = 0;


    void Update()
    {
        if (totalAngleRotated < targetAngle && coffreD�bloqu�)
        {
            transform.RotateAround(transform.position, rotationAxis, rotationSpeed * Time.deltaTime);
            totalAngleRotated += Time.deltaTime * rotationSpeed;
        }
    }
}
