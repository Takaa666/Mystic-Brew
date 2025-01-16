using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlay : MonoBehaviour
{
    public UIAutoAnimation uIAutoAnimation;
    public float delayBeforeDestroy = 2.0f; // Durasi jeda sebelum menghancurkan GameObject

    // Start is called before the first frame update
    void Start()
    {
        uIAutoAnimation.ExitAnimation();
        StartCoroutine(DestroyAfterDelay());
    }

    // Coroutine untuk menghancurkan GameObject setelah jeda
    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeDestroy);
        Destroy(gameObject);
    }
}
