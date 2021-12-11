using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public Animation fadeOut;
    public UI_Script uiScript;

    public void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Collectable").Length == 0)
        {
            fadeOut.Play();
            uiScript.StartCoroutine(uiScript.Wait());
        }
    }
}
