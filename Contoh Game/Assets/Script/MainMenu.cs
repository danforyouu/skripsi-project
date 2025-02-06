using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play ()
    {
        SceneManager.LoadScene("Level");
    }

    public void Level_1 ()
    {
        SceneManager.LoadScene("Lv1");
    }

    public void Level_2 ()
    {
        SceneManager.LoadScene("Lv2");
    }

    public void Level_3 ()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void Level_4 ()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void Back ()
    {
        SceneManager.LoadScene ("MainMenu");
    }
    public void Quit ()
    {
        Application.Quit();
        Debug.Log("Keluar aplikasi");
    }
}
