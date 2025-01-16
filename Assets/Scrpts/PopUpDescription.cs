using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpDescription : MonoBehaviour
{
    public GameObject desc;
    private void Start()
    {
        desc.SetActive(false);
    }

    public void On()
    {
        desc.SetActive(true);
    }

    public void Of()
    {
        desc.SetActive(false);
    }
}
