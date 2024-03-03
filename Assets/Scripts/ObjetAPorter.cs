using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetAPorter : MonoBehaviour
{
    public int poids;

    // Start is called before the first frame update

    [SerializeField] private Outline outline;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<PorterObjet>(out var porterObjet)){
            outline.OutlineColor = Color.green;

            if (porterObjet.objetPorte == null)
            {
                porterObjet.objetPorte = gameObject.transform.parent.gameObject;
                porterObjet.ShowUI(poids);

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PorterObjet>(out var porterObjet))
        {
            outline.OutlineColor = Color.white;
            if (porterObjet.objetPorte == gameObject.transform.parent.gameObject && porterObjet.porter == false)
            {
                porterObjet.objetPorte = null;
            }
        }
    }
}
