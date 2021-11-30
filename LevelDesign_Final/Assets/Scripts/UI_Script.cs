using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour
{
    static public int collectedNum = 0;
    static public int health = 100;

    private GameObject[] collectables;
    public Slider collectorSlider;
    public Slider healthBar;

    void Start()
    {
        collectables = GameObject.FindGameObjectsWithTag("Collectable");
        collectorSlider.maxValue = collectables.Length;
        collectorSlider.value = collectedNum;

        healthBar.value = health;
    }

    void Update()
    {
        collectorSlider.value = collectedNum;
        healthBar.value = health;
    }
}
