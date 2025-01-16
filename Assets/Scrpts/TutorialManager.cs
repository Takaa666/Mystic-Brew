using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject welcome;
    public GameObject book;
    public GameObject kitchen;

    public GameObject kitchenTutorial;
    public GameObject mortar;
    public GameObject fail;
    public GameObject berhasil;
    public GameObject end;
    public GameObject customerSpaawner;
    public GameObject canvas;

    public void Book()
    {
        Destroy(welcome);
        book.SetActive(true);
    }

    public void Kitchen()
    {
        Destroy(book);
        kitchen.SetActive(true);
    }

    public void EndFrontDesk()
    {
        Destroy(kitchen);
    }

    public void KitchenTutorial()
    {
        kitchenTutorial.SetActive(true);
    }
    public void Mortar()
    {
        Destroy(kitchenTutorial);
        mortar.SetActive(true);
    }
    public void Fail()
    {
        Destroy(mortar);
        fail.SetActive(true);
    }
    public void Berhasil()
    {
        Destroy(fail);
        berhasil.SetActive(true);
    }
    public void End()
    {
        Destroy(berhasil);
        end.SetActive(true);
    }
    public void Finish()
    {
        Destroy(end);
        Destroy(canvas);
        customerSpaawner.SetActive(true);
        Destroy(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        welcome.SetActive(true);
        book.SetActive(false);
        kitchen.SetActive(false);
        customerSpaawner.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
