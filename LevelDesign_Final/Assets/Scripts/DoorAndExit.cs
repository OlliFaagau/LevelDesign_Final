using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAndExit : MonoBehaviour
{
    public GameObject door;

    public GameObject noticePanel;

    public SceneChanger sceneScript;

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Collectable").Length == 0)
        {
            door.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Door")
        {
            noticePanel.SetActive(true);
        }
        if(col.gameObject.tag == "Exit")
        {
            sceneScript.Level2();
        }
    }

    void OnCollisionExit()
    {
        noticePanel.SetActive(false);
    }
}
