using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
    }

    public void About()
    {
        SceneManager.LoadScene("About");
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
    }

    public void Play()
    {
        SceneManager.LoadScene("Level 1");
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level 2");
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();
    }
}
