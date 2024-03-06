using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaonMovement : MonoBehaviour
{
    [SerializeField] private float speed; // Vitesse de déplacement de l'objet volant
    [SerializeField] private float rotationSpeed; // Vitesse de rotation de l'objet volant
    [SerializeField] private float cameraDistance; // Distance de la caméra derrière l'objet volant
    [SerializeField] private float cameraSmoothTime; // Temps de lissage du mouvement de la caméra
    [SerializeField] private float maxCameraRotationX; // Angle maximal de rotation de la caméra autour de l'axe vertical
    [SerializeField] private float minCameraRotationX; // Angle minimal de rotation de la caméra autour de l'axe vertical
    [SerializeField] private float cameraHeight; // Angle maximal de rotation de la caméra autour de l'axe horizontal
    [SerializeField] private float obstacleDistance; // Distance à laquelle un obstacle peut bloquer le mouvement


    /// <summary>
    ///  [SerializeField] private Camera 
    /// </summary>

    [SerializeField] private Rigidbody rb;
    private Vector3 cameraVelocity = Vector3.zero;
    private int layerMask;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        
        Rotation();
        
        if (Input.GetButton("Vertical"))
        {
            Movement();
        }


        CameraMovement();
    }

    private void Rotation()
    {
        // Rotation de l'objet volant en fonction de la souris
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rotationEuler = new(transform.rotation.eulerAngles.x - mouseY * rotationSpeed, transform.rotation.eulerAngles.y + mouseX * rotationSpeed, 0f);

        if (transform.rotation.eulerAngles.x - mouseY * rotationSpeed < 360 - maxCameraRotationX && transform.rotation.eulerAngles.x - mouseY * rotationSpeed>180)
        {
            rotationEuler.x = 360 - maxCameraRotationX;
        }
        else if (transform.rotation.eulerAngles.x - mouseY * rotationSpeed > maxCameraRotationX && transform.rotation.eulerAngles.x - mouseY * rotationSpeed < 180)
        {
            rotationEuler.x = maxCameraRotationX;
        }


        transform.rotation = Quaternion.Euler(rotationEuler);
    }

    void Movement()
    {
        // Mouvement de l'objet volant
        Vector3 moveDirection = transform.forward * speed;

        if (!Physics.Raycast(transform.position + 0.01f*transform.forward, transform.forward, out _, obstacleDistance))
        {
            transform.position += moveDirection * Time.deltaTime;
           // rb.MovePosition(transform.position + moveDirection * Time.deltaTime);
        }
        
    }
    private void CameraMovement()
    {
        // Déplacement de la caméra de manière lissée
        Vector3 cameraTargetPosition = transform.position - transform.forward * cameraDistance;

        if (Physics.Raycast(transform.position, -transform.forward, out RaycastHit cameraHit, cameraDistance*1.1f))
        {
            // Si un obstacle est détecté, ajuster la position de la caméra
            cameraTargetPosition = cameraHit.point;
            Debug.Log("Collider detected");
        }
        cameraTargetPosition += transform.up * cameraHeight;
        Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, cameraTargetPosition, ref cameraVelocity, cameraSmoothTime);

        //Camera.main.transform.LookAt(transform.position);
    }
}
