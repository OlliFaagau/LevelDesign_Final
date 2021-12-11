using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{
    public UI_Script uiScript;
    public Animation fadeOut;

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Collectable").Length == 0)
        {
            fadeOut.Play();
            uiScript.StartCoroutine(uiScript.Wait());
        }
    }
}
