using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllPotionContainer : MonoBehaviour
{
    public SpriteRenderer cauldronSpriteRenderer;
    public List<Bahan> currentIngredients = new List<Bahan>();
    public Potion[] allPotions;
    public Transform potionSpawnPoint;
    public GameObject actionButtonsPrefab;

    private bool potionCreated = false;
    private bool combinationFailed = false;
    private Potion createdPotion;
    private GameObject spawnedPotion;

    private GameObject actionButtonsInstance; // Instance tombol aksi

    public SwitchLocation switchLocation; // Reference ke SwitchLocation script
    public GameObject spawnMejaDepan;

    public AudioSource sfx;
    public AudioClip clip;
    public void AddIngredient(Bahan ingredient)
    {
        currentIngredients.Add(ingredient);
        CheckCombination();
    }

    private void CheckCombination()
    {
        bool matchFound = false;

        foreach (Potion potion in allPotions)
        {
            if (IsCombinationMatch(potion.ingredients))
            {
                sfx.PlayOneShot(clip);
                createdPotion = potion;
                ClearContainer();
                matchFound = true;
                potionCreated = true;
                cauldronSpriteRenderer.color = Color.magenta;
                break;
            }
        }

        if (!matchFound)
        {
            bool lengthMatchFound = false;
            foreach (Potion potion in allPotions)
            {
                if (currentIngredients.Count == potion.ingredients.Length)
                {
                    lengthMatchFound = true;
                    break;
                }
            }

            if (lengthMatchFound)
            {
                cauldronSpriteRenderer.color = Color.black;
                combinationFailed = true;
                Debug.Log("Combination failed! The cauldron turned black.");
            }
            else
            {
                cauldronSpriteRenderer.color = Color.white;
            }
        }
    }

    private bool IsCombinationMatch(Bahan[] requiredIngredients)
    {
        if (currentIngredients.Count != requiredIngredients.Length)
        {
            return false;
        }

        foreach (Bahan requiredIngredient in requiredIngredients)
        {
            if (!currentIngredients.Contains(requiredIngredient))
            {
                return false;
            }
        }

        return true;
    }

    private void ClearContainer()
    {
        currentIngredients.Clear();
        combinationFailed = false;
        cauldronSpriteRenderer.color = Color.white;
    }

    private void SpawnPotion()
    {
        if (createdPotion != null && createdPotion.potionPrefab != null)
        {
            spawnedPotion = Instantiate(
                createdPotion.potionPrefab,
                potionSpawnPoint.position,
                potionSpawnPoint.rotation
            );

            Debug.Log("Potion spawned: " + createdPotion.potionName);

            // Tampilkan tombol aksi
            ShowActionButtons();
        }
        else
        {
            Debug.LogWarning("No potion prefab assigned for the created potion!");
        }
    }

    private void ShowActionButtons()
    {
        actionButtonsInstance = Instantiate(actionButtonsPrefab);
        Button moveButton = actionButtonsInstance.transform.Find("MoveButton").GetComponent<Button>();
        Button destroyButton = actionButtonsInstance.transform.Find("DestroyButton").GetComponent<Button>();

        moveButton.onClick.AddListener(() => MovePotionToTable());
        destroyButton.onClick.AddListener(() => DestroyPotion());
    }

    private void MovePotionToTable()
    {
        if (spawnMejaDepan != null && spawnedPotion != null)
        {
            Debug.Log("Potion moved to the table.");
            spawnedPotion.transform.position = spawnMejaDepan.transform.position;
            Destroy(actionButtonsInstance);
            actionButtonsInstance = null;
        }
        else
        {
            Debug.LogWarning("Either spawnMejaDepan or spawnedPotion is not assigned.");
        }
    }

    private void DestroyPotion()
    {
        Debug.Log("Potion destroyed.");
        Destroy(actionButtonsInstance);
        Destroy(spawnedPotion);
        spawnedPotion = null;
    }

    private void Update()
    {
        if (switchLocation != null)
        {
            if (!switchLocation.frontDeskCanvas.activeSelf && actionButtonsInstance != null)
            {
                actionButtonsInstance.SetActive(true);
            }
            else if (switchLocation.frontDeskCanvas.activeSelf && actionButtonsInstance != null)
            {
                actionButtonsInstance.SetActive(false);
            }
        }
    }

    private void OnMouseDown()
    {
        if (combinationFailed)
        {
            Debug.Log("Combination failed. Resetting cauldron color to blue.");
            cauldronSpriteRenderer.color = Color.blue;
            combinationFailed = false;
            ClearContainer();
        }
        else if (potionCreated)
        {
            Debug.Log("Potion created. Spawning potion and resetting cauldron color to blue.");
            SpawnPotion();
            cauldronSpriteRenderer.color = Color.blue;
            potionCreated = false;
        }
    }
}
