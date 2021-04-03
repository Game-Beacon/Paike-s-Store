using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    void Start()
    {
        if (!PlayerPrefs.HasKey("anh"))
        {
            PlayerPrefs.SetString("anh", "1");
            PlayerPrefs.SetInt("day", 0);
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
