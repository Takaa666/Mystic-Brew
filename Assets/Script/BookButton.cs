using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookButton : MonoBehaviour
{
    public Button bookButton;
    public Button close;
    public GameObject book;
    // Start is called before the first frame update
    void Start()
    {
        bookButton.onClick.AddListener(OpenBook);
        close.onClick.AddListener(CloseBook);
        book.SetActive(false);
    }

    public void OpenBook()
    {
        book.SetActive(true);
    }

    public void CloseBook()
    {
        book.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
