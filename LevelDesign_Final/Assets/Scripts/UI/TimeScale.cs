using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    public AudioSource music;
    public GameObject fade;
    
    void Start()
    {
        fade.SetActive(true);
        music.Play();
        Time.timeScale = 1f;
        StartCoroutine(Wait());
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.3f);
        fade.SetActive(false);
    }
}
