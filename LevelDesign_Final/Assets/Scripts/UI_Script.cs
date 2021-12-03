﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour
{
    static public int collectedNum = 0;
    static public float health = 100.0f;
    static public bool hit;

    private GameObject[] collectables;
    private bool isPaused;
    private bool pressAllowed;
    public GameObject pauseMenu;
    public GameObject gameOverScreen;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public Image hurtImage;
    public Slider collectorSlider;
    public Slider healthBar;

    void Start()
    {
        collectables = GameObject.FindGameObjectsWithTag("Collectable");
        collectorSlider.maxValue = collectables.Length;
        collectorSlider.value = collectedNum;
        pressAllowed = true;

        healthBar.value = health;
    }

    void Update()
    {
        collectorSlider.value = collectedNum;
        healthBar.value = health;

        if (pressAllowed)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
            }

            if (isPaused)
            {
                ActivateMenu();
            }
            else
            {
                DeactivateMenu();
            }
        }
        else
        {
            //Nothing
        }

        if (hit)
        {
            hurtImage.color = flashColor;
        }
        else
        {
            hurtImage.color = Color.Lerp(hurtImage.color, Color.clear, 10f * Time.deltaTime);
        }

        CheckForDeath();
    }

    void CheckForDeath()
    {
        if(health <= 0)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
            AudioListener.pause = false;
            PlayerController.DisableMouseLook();
            pressAllowed = false;
        }
    }

    void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseMenu.SetActive(true);
        PlayerController.DisableMouseLook();
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenu.SetActive(false);
        isPaused = false;
    }
}
