using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Drag : MonoBehaviour
{
    public Bahan foodItem; // Objek FoodItem yang akan dipasang ke GameObject
    public HoverInfoPopup hoverInfoPopup;  // Reference to the HoverInfoPopup script

    private Vector3 originalPosition;
    private bool isDragging;
    private bool isOverContainer;
    private bool isMouseOver;
    private AllPotionContainer currentContainer;
    private GameObject objectWithTagM;
    public int clickCount = 0;
    public GameObject bubuk;
    public float spawnX = 0f;
    public float spawnY = 0f;
    public float spawnZ = 0f;



    private void Start()
    {
        if (foodItem != null)
        {
            // Set sprite GameObject sesuai icon FoodItem
            GetComponent<SpriteRenderer>().sprite = foodItem.icon;
        }
    }
    private void OnMouseEnter()
    {
        isMouseOver = true;
        // Show popup only if not dragging
        if (hoverInfoPopup != null && foodItem != null && !isDragging)
        {
            Vector3 worldPosition = transform.position;
            hoverInfoPopup.ShowPopupBahan(foodItem, worldPosition);
        }
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
        // Hide popup when mouse exits the object
        if (hoverInfoPopup != null)
        {
            hoverInfoPopup.HidePopup();
        }
    }
    private void OnMouseDown()
    {
        // Simpan posisi awal saat pertama di-klik
        originalPosition = transform.position;
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            // Pindahkan objek mengikuti posisi mouse
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, originalPosition.z);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        if (isMouseOver && hoverInfoPopup != null)
        {
            Vector3 worldPosition = transform.position;
            hoverInfoPopup.ShowPopupBahan(foodItem, worldPosition);
        }
        // Jika objek berada di dalam container, hancurkan objek
        if (isOverContainer)
        {
            currentContainer.AddIngredient(foodItem);
            Destroy(gameObject);
        }
        else
        {
            // Jika posisi drop tidak valid, kembalikan ke posisi awal.
            //transform.position = originalPosition;
        }
    }

    public void OnCursorEnter()
    {
        GameManager.instance.DisplayItemInfo(foodItem.itemName, transform.position);
    }

    public void OnCursorExit()
    {
        GameManager.instance.DestroyItemInfo();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Jika objek memasuki area dengan tag "Container", set isOverContainer menjadi true
        if (collision.CompareTag("Container"))
        {
            isOverContainer = true;
            currentContainer = collision.GetComponent<AllPotionContainer>();
        }
        if (collision.CompareTag("M"))
        {
            objectWithTagM = collision.gameObject;
        }
        if (collision.CompareTag("Cobek"))
        {
            clickCount++;

            // Jika bunga biru dihaluskan (setelah klik tertentu), spawn prefab bunga biru halus di posisi xyz yang ditentukan
            if (clickCount == 6)
            {
                // Tentukan posisi spawn menggunakan koordinat xyz
                Vector3 spawnPosition = new Vector3(spawnX, spawnY, spawnZ);

                // Spawn prefab bunga biru halus pada posisi spawnPosition
                GameObject bungaBiruHalus = Instantiate(bubuk, spawnPosition, Quaternion.identity);


                // Hapus game object bunga biru kasar saat ini
                Destroy(gameObject);

                clickCount = 0;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("M") && !isDragging)
        {
            // Update posisi objek menjadi sama dengan objek dengan tag "M"
            transform.position = collision.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Jika objek keluar dari area dengan tag "Container", set isOverContainer menjadi false
        if (collision.CompareTag("Container"))
        {
            isOverContainer = false;
            currentContainer = null;
        }
        if (collision.CompareTag("M"))
        {
            objectWithTagM = null;
        }
    }
}
