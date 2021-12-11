using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    public GameObject levelText;
    public GameObject infoText;

    public void Start()
    {
        StartCoroutine(ShowLevel());
    }

    public IEnumerator ShowLevel()
    {
        yield return new WaitForSeconds(1f);
        levelText.SetActive(true);
        yield return new WaitForSeconds(1f);
        infoText.SetActive(true);
        yield return new WaitForSeconds(4f);
        infoText.SetActive(false);
        levelText.SetActive(false);
    }
}
