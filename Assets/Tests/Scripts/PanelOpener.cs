using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menus { 

    public class PanelOpener : MonoBehaviour
    {
        /// <summary>
        /// Panel for displaying congratulation messages
        /// </summary>
        public GameObject Panel;
        /// <summary>
        /// Truth value for when to open the panel
        /// </summary>
        public bool open = false;
        /// <summary>
        /// The audio that plays when the puzzle is completed
        /// </summary>
        public new AudioSource audio;

        /*private void Start()
        {
           StartCoroutine(ShowMessage());
        }*/

        private void Update()
        {
            if (open)
            {
                OpenPanel();
                open = false;
            }
        }

        public IEnumerator ShowMessage()
        {
            for (int i = 0; i < 10; i++)
            {
                /* yield return new WaitForSecondsRealtime(3);
                 OpenPanel();

                 yield return new WaitForSecondsRealtime(2);
                 OpenPanel();*/

                yield return new WaitForSecondsRealtime(2);

                if (i == 2 || i == 4 || i == 6 || i == 8)
                {
                    open = true;
                }
                else
                {
                    open = false;
                }

                if (open)
                {
                    OpenPanel();
                }
            }
        }

        /// <summary>
        /// Opens the panel where the congratulation message is displayed
        /// </summary>
        public void OpenPanel()
        {
            if (Panel != null && open == true)
            {
                bool isActive = Panel.activeSelf;
                Debug.Log("Panel " + isActive);
                Panel.SetActive(!isActive);
                
                //audio.Play(0);
               
            }

        }
    }
}
