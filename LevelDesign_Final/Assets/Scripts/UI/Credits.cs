using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject fade;

    void Start()
    {
        Time.timeScale = .05f;
        fade.SetActive(true);
        StartCoroutine(Wait());
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(.1f);
        fade.SetActive(false);
    }
}
