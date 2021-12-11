using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutPage : MonoBehaviour
{
    public GameObject page1, page2, page3, page4;
    public GameObject fade;

    void Start()
    {
        fade.SetActive(true);
        StartCoroutine(Wait());
    }

    public void DisplayPage1()
    {
        ClearPages();
        page1.SetActive(true);
    }

    public void DisplayPage2()
    {
        ClearPages();
        page2.SetActive(true);
    }

    public void DisplayPage3()
    {
        ClearPages();
        page3.SetActive(true);
    }
    
    public void DisplayPage4()
    {
        ClearPages();
        page4.SetActive(true);
    }

    public void ClearPages()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        fade.SetActive(false);
    }
}
