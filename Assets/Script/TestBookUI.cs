using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestBookUI : MonoBehaviour
{

    public Button manaPotion;
    public Button hpPotion;
    public Button strongPotion;
    public Button speedPotion;
    public Button icePotion;
    public Button hotPotion;

    public GameObject mana;
    public GameObject hp;
    public GameObject strong;
    public GameObject speed;
    public GameObject ice;
    public GameObject hot;

    public GameObject bungaMerah;
    public GameObject jamurApi;
    public GameObject manaPotion1;
    public GameObject healthPotion;

    public GameObject bungaBiru;
    public GameObject jamurEs;
    public GameObject taringOrc;
    public GameObject buluWolf;
    public GameObject slimeMerah;
    public GameObject slimeBiru;

    public GameObject bungaIjo;
    public GameObject jamurIjo;
    public GameObject buluWolfKanan;
    public GameObject jamurApi1;
    public GameObject jamurBiru;

    public GameObject manaText;
    public GameObject manaDesc;
    public GameObject healthText;
    public GameObject healthDesc;
    public GameObject strongText;
    public GameObject strongDesc;
    public GameObject speedText;
    public GameObject speedDesc;
    public GameObject iceText;
    public GameObject iceDesc;
    public GameObject hotText;
    public GameObject hotDesc;

    private void Start()
    {
        mana.SetActive(false);
        hp.SetActive(false);
        strong.SetActive(false);
        speed.SetActive(false);
        ice.SetActive(false);
        hot.SetActive(false);

        jamurApi.SetActive(false);
        jamurBiru.SetActive(false);

        bungaMerah.SetActive(false);
        manaPotion1.SetActive(false);
        healthPotion.SetActive(false);

        bungaBiru.SetActive(false);
        jamurEs.SetActive(false);
        taringOrc.SetActive(false);
        buluWolf.SetActive(false);
        slimeMerah.SetActive(false);
        slimeBiru.SetActive(false);

        bungaIjo.SetActive(false);
        jamurIjo.SetActive(false);
        buluWolfKanan.SetActive(false);
        jamurApi1.SetActive(false);
        jamurBiru.SetActive(false);

        healthText.SetActive(false);
        healthDesc.SetActive(false);
        strongText.SetActive(false);
        strongDesc.SetActive(false);
        speedText.SetActive(false);
        speedDesc.SetActive(false);
        iceText.SetActive(false);
        iceDesc.SetActive(false);
        hotText.SetActive(false);
        hotDesc.SetActive(false);

        // Tambahkan listener pada button masing-masing potion
        hpPotion.onClick.AddListener(HpPotionButton);
        manaPotion.onClick.AddListener(ManaPotionButton);
        strongPotion.onClick.AddListener(StrongPotionButton);
        speedPotion.onClick.AddListener(SpeedPotionButton);
        icePotion.onClick.AddListener(IcePotionButton);
        hotPotion.onClick.AddListener(HotPotionButton);
        mana.SetActive(true);
        jamurApi.SetActive(true);
        jamurEs.SetActive(true);
        jamurIjo.SetActive(true);
        manaText.SetActive(true);
        manaDesc.SetActive(true);
    }

    public void ManaPotionButton()
    {
        hp.SetActive(false);
        strong.SetActive(false);
        speed.SetActive(false);
        ice.SetActive(false);
        hot.SetActive(false);

        mana.SetActive(true);
        jamurApi.SetActive(true);
        jamurEs.SetActive(true);
        jamurIjo.SetActive(true);

        bungaMerah.SetActive(false);
        manaPotion1.SetActive(false);
        healthPotion.SetActive(false);

        bungaBiru.SetActive(false);
        taringOrc.SetActive(false);
        buluWolf.SetActive(false);
        slimeMerah.SetActive(false);
        slimeBiru.SetActive(false);

        bungaIjo.SetActive(false);
        buluWolfKanan.SetActive(false);
        jamurApi1.SetActive(false);
        jamurBiru.SetActive(false);

        manaText.SetActive(true);
        manaDesc.SetActive(true);
        healthText.SetActive(false);
        healthDesc.SetActive(false);
        strongText.SetActive(false);
        strongDesc.SetActive(false);
        speedText.SetActive(false);
        speedDesc.SetActive(false);
        iceText.SetActive(false);
        iceDesc.SetActive(false);
        hotText.SetActive(false);
        hotDesc.SetActive(false);
    }

    public void HpPotionButton()
    {
        mana.SetActive(false);
        strong.SetActive(false);
        speed.SetActive(false);
        ice.SetActive(false);
        hot.SetActive(false);

        jamurApi.SetActive(false);
        jamurBiru.SetActive(false);

        bungaMerah.SetActive(false);
        manaPotion1.SetActive(false);
        healthPotion.SetActive(false);

        jamurEs.SetActive(false);
        taringOrc.SetActive(false);
        buluWolf.SetActive(false);
        slimeMerah.SetActive(false);
        slimeBiru.SetActive(false);

        jamurIjo.SetActive(false);
        buluWolfKanan.SetActive(false);
        jamurApi1.SetActive(false);

        hp.SetActive(true);
        bungaMerah.SetActive(true);
        bungaBiru.SetActive(true);
        bungaIjo.SetActive(true);

        manaText.SetActive(false);
        manaDesc.SetActive(false);
        healthText.SetActive(true);
        healthDesc.SetActive(true);
        strongText.SetActive(false);
        strongDesc.SetActive(false);
        speedText.SetActive(false);
        speedDesc.SetActive(false);
        iceText.SetActive(false);
        iceDesc.SetActive(false);
        hotText.SetActive(false);
        hotDesc.SetActive(false);
    }

    public void StrongPotionButton()
    {
        mana.SetActive(false);
        hp.SetActive(false);
        speed.SetActive(false);
        ice.SetActive(false);
        hot.SetActive(false);

        jamurApi.SetActive(false);
        jamurBiru.SetActive(false);

        bungaMerah.SetActive(false);
        healthPotion.SetActive(false);

        bungaBiru.SetActive(false);
        jamurEs.SetActive(false);
        buluWolf.SetActive(false);
        slimeMerah.SetActive(false);
        slimeBiru.SetActive(false);

        bungaIjo.SetActive(false);
        jamurIjo.SetActive(false);
        jamurApi1.SetActive(false);

        manaPotion1.SetActive(true);
        taringOrc.SetActive(true);
        buluWolfKanan.SetActive(true);
        strong.SetActive(true);

        manaText.SetActive(false);
        manaDesc.SetActive(false);
        healthText.SetActive(false);
        healthDesc.SetActive(false);
        strongText.SetActive(true);
        strongDesc.SetActive(true);
        speedText.SetActive(false);
        speedDesc.SetActive(false);
        iceText.SetActive(false);
        iceDesc.SetActive(false);
        hotText.SetActive(false);
        hotDesc.SetActive(false);
    }

    public void SpeedPotionButton()
    {
        mana.SetActive(false);
        hp.SetActive(false);
        strong.SetActive(false);
        ice.SetActive(false);
        hot.SetActive(false);

        jamurApi.SetActive(false);
        jamurBiru.SetActive(false);

        bungaMerah.SetActive(false);
        healthPotion.SetActive(false);

        bungaBiru.SetActive(false);
        jamurEs.SetActive(false);
        taringOrc.SetActive(false);
        buluWolfKanan.SetActive(false);
        slimeMerah.SetActive(false);
        slimeBiru.SetActive(false);

        jamurIjo.SetActive(false);
        jamurApi1.SetActive(false);

        speed.SetActive(true);
        manaPotion1.SetActive(true);
        buluWolf.SetActive(true);
        bungaIjo.SetActive(true);

        manaText.SetActive(false);
        manaDesc.SetActive(false);
        healthText.SetActive(false);
        healthDesc.SetActive(false);
        strongText.SetActive(false);
        strongDesc.SetActive(false);
        speedText.SetActive(true);
        speedDesc.SetActive(true);
        iceText.SetActive(false);
        iceDesc.SetActive(false);
        hotText.SetActive(false);
        hotDesc.SetActive(false);
    }

    public void IcePotionButton()
    {
        mana.SetActive(false);
        hp.SetActive(false);
        strong.SetActive(false);
        speed.SetActive(false);
        hot.SetActive(false);

        jamurApi.SetActive(false);
        bungaMerah.SetActive(false);
        manaPotion1.SetActive(false);

        bungaBiru.SetActive(false);
        jamurEs.SetActive(false);
        taringOrc.SetActive(false);
        buluWolf.SetActive(false);
        slimeMerah.SetActive(false);

        bungaIjo.SetActive(false);
        jamurIjo.SetActive(false);
        buluWolfKanan.SetActive(false);
        jamurApi1.SetActive(false);

        ice.SetActive(true);
        healthPotion.SetActive(true);
        slimeBiru.SetActive(true);
        jamurBiru.SetActive(true);

        manaText.SetActive(false);
        manaDesc.SetActive(false);
        healthText.SetActive(false);
        healthDesc.SetActive(false);
        strongText.SetActive(false);
        strongDesc.SetActive(false);
        speedText.SetActive(false);
        speedDesc.SetActive(false);
        iceText.SetActive(true);
        iceDesc.SetActive(true);
        hotText.SetActive(false);
        hotDesc.SetActive(false);
    }

    public void HotPotionButton()
    {
        // Menonaktifkan semua GameObject
        mana.SetActive(false);
        hp.SetActive(false);
        strong.SetActive(false);
        speed.SetActive(false);
        ice.SetActive(false);

        jamurApi.SetActive(false);
        bungaMerah.SetActive(false);
        manaPotion1.SetActive(false);

        bungaBiru.SetActive(false);
        jamurEs.SetActive(false);
        taringOrc.SetActive(false);
        buluWolf.SetActive(false);
        slimeBiru.SetActive(false);

        bungaIjo.SetActive(false);
        jamurIjo.SetActive(false);
        buluWolfKanan.SetActive(false);
        jamurBiru.SetActive(false);

        // Mengaktifkan hanya GameObject yang diinginkan
        hot.SetActive(true);
        healthPotion.SetActive(true);
        slimeMerah.SetActive(true);
        jamurApi1.SetActive(true);

        manaText.SetActive(false);
        manaDesc.SetActive(false);
        healthText.SetActive(false);
        healthDesc.SetActive(false);
        strongText.SetActive(false);
        strongDesc.SetActive(false);
        speedText.SetActive(false);
        speedDesc.SetActive(false);
        iceText.SetActive(false);
        iceDesc.SetActive(false);
        hotText.SetActive(true);
        hotDesc.SetActive(true);
    }
}
