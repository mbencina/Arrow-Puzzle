using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menus
{

    /// <summary>
    /// Defines how and when the panel with the congratulations-message is opened
    /// </summary>
    public class PanelOpener : MonoBehaviour
    {
        /// <summary>
        /// Panel for displaying congratulation messages, in english
        /// </summary>
        public GameObject enPanel;
        /// <summary>
        /// Panel for displaying congratulation messages, in finnish
        /// </summary>
        public GameObject fiPanel;
        /// <summary>
        /// Truth value for when to open the panel
        /// </summary>
        public bool open = false;
        /// <summary>
        /// The audio that plays when the puzzle is completed
        /// </summary>
        public new AudioSource audio;

        /// <summary>
        /// Quit button in english
        /// </summary>
        public GameObject enQuit;
        /// <summary>
        /// Quit buttin in finnish
        /// </summary>
        public GameObject fiQuit;

        private GameObject Panel;

        /// <summary>
        /// Defines which language the in-game menu should be in
        /// </summary>
        public void Start()
        {
            // Fetching the current language of the game via PlayerPrefs
            string language = PlayerPrefs.GetString("language");

            if (language == "english")
            {
                // In english
                enQuit.SetActive(true);
                fiQuit.SetActive(false);
                Panel = enPanel;
            }
            else if (language == "finnish")
            {
                // In finnish
                enQuit.SetActive(false);
                fiQuit.SetActive(true);
                Panel = fiPanel;
            }

        }

        /// <summary>
        /// Opens the panel where the congratulation message is displayed
        /// </summary>
        public void OpenPanel()
        {
            open = true;
            if (Panel != null)
            {
                //bool isActive = Panel.activeSelf;
                //Debug.Log("Panel " + isActive);
                Panel.SetActive(true);
                audio.Play(0);
            }
        }
    }
}
