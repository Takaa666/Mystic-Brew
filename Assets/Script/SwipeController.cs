using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeController : MonoBehaviour
{
    [SerializeField] int maxPage; // Maximum number of pages
    int currentPage; // Current page index
    Vector3 targetPos; // Target position for sliding
    [SerializeField] Vector3 pageStep; // Step to move between pages
    [SerializeField] RectTransform levelPageRect; // The RectTransform of the content to move

    [SerializeField] float tweenTime; // Time for the transition animation
    [SerializeField] LeanTweenType tweenType; // Easing type for the animation

    [SerializeField] Button next, previous;
    public void Awake()
    {
        currentPage = 1; // Initialize to the first page
        targetPos = levelPageRect.localPosition; // Set the initial target position
        UpdateArrowButton();
    }

    public void Next()
    {
        if (currentPage < maxPage)
        {
            currentPage++; // Increment page index
            targetPos += pageStep; // Update the target position
            MovePage(); // Move to the new position
        }
    }

    public void Previous()
    {
        if (currentPage > 1)
        {
            currentPage--; // Decrement page index
            targetPos -= pageStep; // Update the target position
            MovePage(); // Move to the new position
        }
    }

    void MovePage()
    {
        // Use LeanTween to move the RectTransform smoothly
        LeanTween.moveLocal(levelPageRect.gameObject, targetPos, tweenTime).setEase(tweenType);
        UpdateArrowButton();
    }

    void UpdateArrowButton()
    {
        next.interactable = true;
        previous.interactable = true;
        if(currentPage == 1) previous.interactable=false;
        else if (currentPage == maxPage) next.interactable=false;
    }
}
