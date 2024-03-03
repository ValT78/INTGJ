using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float killHeight;
    [SerializeField] private RectTransform ui;
    public int id;
    // Start is called before the first frame update
    void OnEnable()
    {
        ui.position = new Vector3(ui.position.x, 253f, ui.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        ui.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        if(ui.position.y > killHeight)
        {
            gameObject.SetActive(false);
        }
    }
}
