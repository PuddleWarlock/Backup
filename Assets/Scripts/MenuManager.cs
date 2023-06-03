using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuManager : MonoBehaviour
{
    public void Mode1Select()
    {   
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    
    public void NoPlay()
    {
        Application.Quit();
    }

    public void BtnHovered()
    {
        transform.parent.GetComponent<TextMeshPro>().color = Color.yellow;
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
    }
    public void BtnNotHovered()
    {
        transform.parent.GetComponent<TextMeshPro>().color = Color.white;
    }
    
    public void Back2Menu()
    {   
        
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        FindObjectOfType<Player>().transform.rotation = Quaternion.LookRotation(new Vector3(0,0,1));
    }

    public void SwapHover(HoverEnterEventArgs meow)
    {
        meow.interactorObject.transform.GetComponent<XRRayInteractor>().allowHoveredActivate = true;
    }
    public void AntiSwapHover(HoverExitEventArgs meow)
    {
        meow.interactorObject.transform.GetComponent<XRRayInteractor>().allowHoveredActivate = false;
    }
}
