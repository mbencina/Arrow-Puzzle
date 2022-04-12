using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InvokePanelScript : MonoBehaviour
{
    /// <summary>
    /// Panel where messages are displayed.
    /// </summary>
    public GameObject Panel;
    private Menus.PanelOpener open;

    /// <summary>
    /// Method to invoke PanelOpener script.
    /// </summary>
    public void InvokeMessage()
    {
        //Panel.GetComponent<Menus.PanelOpener>().OpenPanel();
        open =  Panel.GetComponent<Menus.PanelOpener>();
        bool isOpen = open.open;
        open.open = !isOpen;
        
    }
    
}