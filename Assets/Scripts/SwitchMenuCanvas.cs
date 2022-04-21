using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMenuCanvas : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Credits;
    public GameObject Tutorial;

    public void SwitchCanvas(string name)
    {
        if (name == "Menu")
        {
            Menu.SetActive(true);
            Credits.SetActive(false);
            Tutorial.SetActive(false);
        }
        else if (name == "Credits")
        {
            Menu.SetActive(false);
            Credits.SetActive(true);
            Tutorial.SetActive(false);
        }
        else if (name == "Tutorial")
        {
            Menu.SetActive(false);
            Credits.SetActive(false);
            Tutorial.SetActive(true);
        }
    }
}
