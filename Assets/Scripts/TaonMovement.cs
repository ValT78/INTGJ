using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaonMovement : MonoBehaviour
{
    [SerializeField] private float speed; // Vitesse de d�placement de l'objet volant
    [SerializeField] private float rotationSpeed; // Vitesse de rotation de l'objet volant
    [SerializeField] private float cameraDistance; // Distance de la cam�ra derri�re l'objet volant
    [SerializeField] private float cameraSmoothTime; // Temps de lissage du mouvement de la cam�ra
    [SerializeField] private float maxCameraRotationX; // Angle maximal de rotation de la cam�ra autour de l'axe vertical
    [SerializeField] private float cameraHeight; // Angle maximal de rotation de la cam�ra autour de l'axe horizontal
    [SerializeField] private float obstacleDistance; // Distance � laquelle un obstacle peut bloquer le mouvement

    [SerializeField] private Rigidbody rb;
    private Vector3 cameraVelocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        

        // Rotation de l'objet volant en fonction de la souris
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(-mouseY * rotationSpeed, mouseX * rotationSpeed, 0f));

        // Limiter la rotation verticale de l'objet volant
        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.y = Mathf.Clamp(currentRotation.y, 0, 360f);
/*        currentRotation.x = Mathf.Clamp(currentRotation.x, -maxCameraRotationX, maxCameraRotationX);
*/        transform.localEulerAngles = currentRotation;

        // Mouvement de l'objet volant
        Vector3 moveDirection = transform.forward * speed;
        ;
        if (!Physics.Raycast(transform.position, transform.forward, out _, obstacleDistance))
        {
            rb.MovePosition(rb.position + moveDirection * Time.deltaTime);
        }

        // D�placement de la cam�ra de mani�re liss�e
        Vector3 cameraTargetPosition = transform.position - transform.forward * cameraDistance;

        if (Physics.Raycast(transform.position, -transform.forward, out RaycastHit cameraHit, cameraDistance))
        {
            // Si un obstacle est d�tect�, ajuster la position de la cam�ra
            cameraTargetPosition = cameraHit.point;
        }
        cameraTargetPosition += transform.up * cameraHeight;
        Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, cameraTargetPosition, ref cameraVelocity, cameraSmoothTime);

        // Rotation de la cam�ra limit�e autour de l'axe vertical
        /*Vector3 cameraEulerAngles = Camera.main.transform.localEulerAngles;
        cameraEulerAngles.x = Mathf.Clamp(cameraEulerAngles.x, -maxCameraRotationY, maxCameraRotationY);
        Camera.main.transform.localEulerAngles = cameraEulerAngles;*/

        Camera.main.transform.LookAt(transform.position);
    }
}