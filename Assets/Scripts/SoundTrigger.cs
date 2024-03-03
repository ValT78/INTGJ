using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    private Transform player; // Référence au transform du joueur
    [SerializeField] private float triggerDistance; // Distance à partir de laquelle le son doit être déclenché
    [SerializeField] private float uiDistance; // Distance à partir de laquelle le son doit être déclenché
    [SerializeField] private AudioClip soundEffect; // Effet sonore à jouer
    private SoundManager soundManager; // Référence au SoundManager
    private bool hasPlayed = false; // Variable pour s'assurer que le son ne se joue qu'une fois

    [SerializeField] private GameObject UISting;

    private void Start()
    {
        player = FindObjectOfType<TaonMovement>().transform; // Trouver le transform du joueur
        soundManager = FindObjectOfType<SoundManager>();

        if (soundManager && soundEffect == soundManager.dialToilette)
        {
            foreach (UIMove ui in FindObjectsOfType<UIMove>())
            {
                if (ui.id == 3)
                {
                    UISting = ui.gameObject;

                    ui.gameObject.SetActive(false);
                }
            }
        }
    }

    void Update()
    {
        if (player == null) return; // Sortir de la fonction si le transform du joueur est null

        // Calculer la distance entre l'objet et le joueur
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si le joueur est à une distance inférieure ou égale à la distance de déclenchement et que le son n'a pas encore été joué
        if (!hasPlayed && distanceToPlayer <= triggerDistance && soundManager && !soundManager.effectSource.isPlaying)
        {
            // Jouer l'effet sonore
            if(soundEffect != null)
            {
                soundManager.StopMusic();
                soundManager.PlaySound(soundEffect);
                
            }
            if(UISting != null && distanceToPlayer < uiDistance)
            {
                UISting.SetActive(true);
            }   
            // Marquer que le son a été joué
            hasPlayed = true;
        }
        // Si le joueur est en dehors de la distance de déclenchement, réinitialiser la variable hasPlayed
        else if (distanceToPlayer > triggerDistance)
        {
            hasPlayed = false;
        }
    }
}
