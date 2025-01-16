using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BahanToBubuk : MonoBehaviour
{
    public GameObject bubuk;
    public int clickCount = 0;
    private bool isTouchingCobek = false;

    public float spawnX = 0f;
    public float spawnY = 0f;
    public float spawnZ = 0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cobek"))
        {
            isTouchingCobek = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("M"))
        {
            isTouchingCobek = true;

            // Memastikan posisi menjadi sama dengan posisi "Cobek"
            transform.position = collision.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cobek"))
        {
            isTouchingCobek = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cobek"))
        {
            isTouchingCobek = false;
        }
    }

    private void CounterPenumbuk()
    {
        if (isTouchingCobek)
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}
