using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menus
{ 

    /// <summary>
    /// Switches which canvas is shown when pressing certaing buttons
    /// </summary>
    public class SwitchMenuCanvas : MonoBehaviour
    {
        /// <summary>
        /// Main menu canvas
        /// </summary>
        public GameObject Menu;
        /// <summary>
        /// Credits canvas
        /// </summary>
        public GameObject Credits;
        /// <summary>
        /// Tutorial canvas
        /// </summary>
        public GameObject Tutorial;

        /// <summary>
        /// Switches the canvas that is shown in the menu
        /// </summary>
        /// <param name="name">The name of the canvas that is activated</param>
        /// 
        public void Start()
        {
            PlayerPrefs.SetInt("CounterText",0);
        }
        public void SwitchCanvas(string name)
        {
            // If menu should be shown.
            if (name == "Menu")
            {
                Menu.SetActive(true);
                Credits.SetActive(false);
                Tutorial.SetActive(false);
            }
            // If credits should be shown.
            else if (name == "Credits")
            {
                Menu.SetActive(false);
                Credits.SetActive(true);
                Tutorial.SetActive(false);
            }
            // If tutorial should be shown.
            else if (name == "Tutorial")
            {
                Menu.SetActive(false);
                Credits.SetActive(false);
                Tutorial.SetActive(true);
            }
        }
    }
}