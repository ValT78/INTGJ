using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float killHeight;
    [SerializeField] private RectTransform ui;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ui.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        if(ui.position.y > killHeight)
        {
            Destroy(gameObject);
        }
    }
}
