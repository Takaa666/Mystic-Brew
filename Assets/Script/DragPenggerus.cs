using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPenggerus : MonoBehaviour
{
    private Vector3 originalPosition;
    private bool isDragging;
    private void OnMouseDown()
    {
        
        originalPosition = transform.position;
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, originalPosition.z);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
