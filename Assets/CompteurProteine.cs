using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompteurProteine : MonoBehaviour
{
    TextMeshProUGUI textmeshpro;
    private PorterObjet player;
    void Start()
    {
        player=FindObjectOfType<PorterObjet>();
        textmeshpro=GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textmeshpro.text = "x" + player.GetForce();
    }
}
