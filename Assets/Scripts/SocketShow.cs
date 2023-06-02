using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketShow : MonoBehaviour
{
    public void ShowMessage(HoverEnterEventArgs args)
    {
        /*if (args.interactableObject.transform.GetComponent<XRSocketInteractor>().hasSelection)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        };*/
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void HideMessage()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
