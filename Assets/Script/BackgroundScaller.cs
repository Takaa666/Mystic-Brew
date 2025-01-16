using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundScaller : MonoBehaviour
{
    private int currentScreenWidth;
    private int currentScreenHeight;

    void Start()
    {
        // Simpan resolusi awal
        currentScreenWidth = Screen.width;
        currentScreenHeight = Screen.height;

        FitBackgroundToCamera(); // Skalakan background saat awal
    }

    void Update()
    {
        // Periksa jika resolusi layar berubah
        if (Screen.width != currentScreenWidth || Screen.height != currentScreenHeight)
        {
            currentScreenWidth = Screen.width;
            currentScreenHeight = Screen.height;

            FitBackgroundToCamera(); // Perbarui ukuran background
        }
    }

    void FitBackgroundToCamera()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        // Ukuran sprite dalam dunia
        float spriteWidth = sr.sprite.bounds.size.x;
        float spriteHeight = sr.sprite.bounds.size.y;

        // Ukuran layar dalam unit dunia
        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        // Hitung skala untuk menyesuaikan kamera
        Vector3 scale = transform.localScale;
        scale.x = worldScreenWidth / spriteWidth;
        scale.y = worldScreenHeight / spriteHeight;
        transform.localScale = scale;
    }
}
