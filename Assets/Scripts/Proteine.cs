using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class Proteine : MonoBehaviour
{
    [SerializeField] float vitesseRotation = 50f;

    private SoundManager soundManager;

    private void Start()
    {
        soundManager = SoundManager.Instance;
    }

    // Start is called before the first frame update
    private void Update()
    {
        transform.Rotate(Vector3.up, vitesseRotation * Time.deltaTime);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PorterObjet>(out var player))
        {
            player.PlusFort();
            soundManager.PlaySound(soundManager.depression);
            Destroy(this.gameObject);
        }
    }
}