using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMenuCanvas : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Credits;

    public void SwitchCanvas(string name)
    {
        if (name == "Menu")
        {
            Menu.SetActive(true);
            Credits.SetActive(false);
        }
        else if (name == "Credits")
        {
            Menu.SetActive(false);
            Credits.SetActive(true);
        }
    }
}
