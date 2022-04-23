using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InvokePanel : MonoBehaviour
{
    /// <summary>
    /// Panel where messages are displayed.
    /// </summary>
    public GameObject Panel;
    private InGameMenu.PanelOpener open;

    /// <summary>
    /// Method to invoke PanelOpener script.
    /// </summary>
    public void InvokeMessage()
    {
        Panel.GetComponent<InGameMenu.PanelOpener>().OpenPanel();
        /*open = Panel.GetComponent<Menus.PanelOpener>();
        bool isOpen = open.open;
        open.open = !isOpen;*/
        
    }

}
