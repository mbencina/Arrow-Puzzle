using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokePanelScript : MonoBehaviour
{
    public GameObject Panel;
    private Menus.PanelOpener open;

    public void InvokeMessage()
    {
        //Panel.GetComponent<Menus.PanelOpener>().OpenPanel();
        open =  Panel.GetComponent<Menus.PanelOpener>();
        bool isOpen = open.open;
        open.open = !isOpen;
        
    }
    
}
