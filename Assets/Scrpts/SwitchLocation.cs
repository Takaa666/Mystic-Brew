using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLocation : MonoBehaviour
{
    public GameObject frontDeskCanvas; // Canvas Front Desk
    public GameObject kitchenCanvas;   // Canvas Dapur

    public GameObject frontDeskCamera; // Camera untuk Front Desk
    public GameObject kitchenCamera;   // Camera untuk Dapur

    public GameObject actionButtons;   // Reference ke action buttons
    public UIAutoAnimation uIAutoAnimation;

    public float delayAfterEntrance = 2.0f; // Jeda dalam detik setelah EntranceAnimation

    void Start()
    {
        uIAutoAnimation.ExitAnimation();
        // Set awal
        //ShowFrontDesk();
    }

    // Method untuk membuka canvas dapur pada display 2
    public void ShowKitchen()
    {
        StartCoroutine(SwitchToKitchen());
    }

    // Coroutine untuk membuka canvas dapur dengan jeda
    private IEnumerator SwitchToKitchen()
    {
        uIAutoAnimation.EntranceAnimation();
        yield return new WaitForSeconds(delayAfterEntrance);

        frontDeskCamera.SetActive(false);
        frontDeskCanvas.SetActive(false);

        kitchenCanvas.SetActive(true);
        kitchenCamera.SetActive(true);

        uIAutoAnimation.ExitAnimation();

        // Tampilkan action buttons
        if (actionButtons != null)
        {
            actionButtons.SetActive(true);
        }
    }

    // Method untuk membuka canvas front desk pada display 1
    public void ShowFrontDesk()
    {
        StartCoroutine(SwitchToFrontDesk());
    }

    // Coroutine untuk membuka canvas front desk dengan jeda
    private IEnumerator SwitchToFrontDesk()
    {
        uIAutoAnimation.EntranceAnimation();
        yield return new WaitForSeconds(delayAfterEntrance);

        kitchenCanvas.SetActive(false);
        kitchenCamera.SetActive(false);

        frontDeskCanvas.SetActive(true);
        frontDeskCamera.SetActive(true);

        uIAutoAnimation.ExitAnimation();

        // Sembunyikan action buttons
        if (actionButtons != null)
        {
            actionButtons.SetActive(false);
        }
    }
}
