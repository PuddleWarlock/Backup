using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Mode1Select()
    {
        SceneManager.LoadScene(1);
    }
    
    public void NoPlay()
    {
        Application.Quit();
    }
}
