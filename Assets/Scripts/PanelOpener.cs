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

        public GameObject enQuit;
        public GameObject fiQuit;

        private GameObject Panel;

        public void Start()
        {
            string language = PlayerPrefs.GetString("language");

            if (language == "english")
            {
                enQuit.SetActive(true);
                fiQuit.SetActive(false);
                Panel = enPanel;
            }
            else if (language == "finnish")
            {
                enQuit.SetActive(false);
                fiQuit.SetActive(true);
                Panel = fiPanel;
            }

        }

        /// <summary>
        /// Checks on every frame if the panel needs to be opened
        /// </summary>
        /*private void Update()
        {
            if (open == true)
            {
                OpenPanel();
                open = false;
            }
        }*/

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

                if (open)
                {
                    audio.Play(0);
                }
            }
        }

        /// <summary>
        /// Triggers OpenPanel-method after a short wait.
        /// </summary>
        /// <returns></returns>
        public IEnumerator ClosePanel()
        {
            yield return new WaitForSeconds(3.0f);
            OpenPanel();
        }
    }
}
