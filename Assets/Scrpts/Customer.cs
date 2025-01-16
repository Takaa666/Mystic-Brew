using UnityEngine;

public class Customer : MonoBehaviour
{
    public OrderList orderList; // Drag and drop OrderList here
    public Potion currentOrder; // Current potion order
    public GameObject spawnNotif; // Position for spawning notifications
    public RevenueManager revenueManager; // Referensi ke RevenueManager

    private GameObject currentNotif; // Current order notification
    private SpriteRenderer spriteRenderer; // Reference to SpriteRenderer
    public AudioSource sfx;
    public AudioClip clip;

    void Awake()
    {
        sfx.PlayOneShot(clip);
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
        revenueManager = GameObject.Find("RevenueManager").GetComponent<RevenueManager>();
        if (spriteRenderer != null)
        {
            // Set alpha to 0 at the start
            SetAlpha(0f);
        }
    }

    void Start()
    {
        if (currentOrder == null)
        {
            GenerateRandomOrder();
        }

        // Gradually fade in the customer
        FadeInCustomer();

        SpawnOrderNotification(); // Spawn the notification at the start
    }

    void GenerateRandomOrder()
    {
        if (orderList.availableOrders.Length > 0)
        {
            // Pick a random order from the list of available potions
            int randomIndex = Random.Range(0, orderList.availableOrders.Length);
            currentOrder = orderList.availableOrders[randomIndex];

            // Display this order in the UI or text
            DisplayOrder(currentOrder);
        }
    }

    void SpawnFeedback(GameObject feedbackPrefab)
    {
        if (spawnNotif != null && feedbackPrefab != null)
        {
            // Deactivate the order notification
            if (currentNotif != null)
            {
                currentNotif.SetActive(false);
            }

            // Spawn the feedback notification at the spawnNotif position
            GameObject feedback = Instantiate(feedbackPrefab, spawnNotif.transform.position, Quaternion.identity);
            feedback.transform.SetParent(spawnNotif.transform); // Optional: Organize in hierarchy
            Destroy(feedback, 2f); // Destroy the feedback notification after 2 seconds

            // Reactivate the order notification after feedback disappears
            Invoke(nameof(ReactivateOrderNotification), 2f);
        }
    }

    void ReactivateOrderNotification()
    {
        if (currentNotif != null)
        {
            currentNotif.SetActive(true);
        }
    }

    public void HandleCorrectOrder()
    {
        Debug.Log("Correct Order! Customer is happy.");
        if (revenueManager != null)
        {
            revenueManager.AddRevenue(currentOrder.price);
        }
        // Spawn thankYou notification
        SpawnFeedback(currentOrder.thankYou);

        // Wait for a few seconds, then start fade out
        Invoke(nameof(StartFadeOutAfterOrder), 1f); // 2-second delay before fade-out
    }
    void StartFadeOutAfterOrder()
    {
        FadeOutCustomer(); // Start fade-out after the delay
    }

    public void HandleWrongOrder()
    {
        Debug.Log("Wrong Order! Customer is unhappy.");

        // Spawn wrongOrder notification
        SpawnFeedback(currentOrder.wrongOrder);
    }

    public bool CheckOrder(Potion servedPotion)
    {
        if (servedPotion == currentOrder)
        {
            HandleCorrectOrder();
            return true;
        }
        else
        {
            HandleWrongOrder();
            return false;
        }
    }

    void DisplayOrder(Potion order)
    {
        // Example: display the name and image of the potion in the UI
        Debug.Log("Customer ordered: " + order.potionName);
    }

    void SpawnOrderNotification()
    {
        if (currentOrder != null && spawnNotif != null)
        {
            // Destroy existing notification if it exists
            if (currentNotif != null)
            {
                Destroy(currentNotif);
            }

            // Instantiate a new notification at the spawnNotif position
            currentNotif = Instantiate(currentOrder.potionOrderNotif, spawnNotif.transform.position, Quaternion.identity);
            currentNotif.transform.SetParent(spawnNotif.transform); // Optional: Keep it organized in hierarchy
        }
    }

    void FadeInCustomer()
    {
        StartCoroutine(FadeAlpha(0f, 1f, 1f)); // Fade in over 1 second
    }

    void FadeOutCustomer()
    {
        StartCoroutine(FadeAlpha(1f, 0f, 1f, true)); // Fade out over 1 second and destroy after
    }

    System.Collections.IEnumerator FadeAlpha(float startAlpha, float endAlpha, float duration, bool destroyOnComplete = false)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            SetAlpha(alpha);
            yield return null;
        }

        SetAlpha(endAlpha);

        if (destroyOnComplete)
        {
            Destroy(gameObject);
        }
    }

    void SetAlpha(float alpha)
    {
        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DragPotion dragPotion = collision.GetComponent<DragPotion>();
        if (dragPotion != null)
        {
            CheckOrder(dragPotion.potion);
        }

        if (collision.tag == "Potion")
        {
            Destroy(collision.gameObject);
        }
    }
}
