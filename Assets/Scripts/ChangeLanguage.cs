using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menus
{ 
    /// <summary>
    /// Changes the language of the game
    /// </summary>
    public class ChangeLanguage : MonoBehaviour
    {
        /// <summary>
        /// The canvas which is the parent of the language button.
        /// </summary>
        public Transform MenuCanvas;

        // Truth values to indicade which language is used.
        private bool english = true;
        private bool finnish = false;

        // Lists of buttons in english and finnish.
        private List<GameObject> enList = new List<GameObject>();
        private List<GameObject> fiList = new List<GameObject>();

        /// <summary>
        /// Initiates list creation and a PlayerPref for 
        /// language settings for the whole game.
        /// </summary>
        public void Start()
        {
            CreateList();

            PlayerPrefs.SetString("language", "english");
        }

        /// <summary>
        /// Filling up the list of buttons both in english and in finnish.
        /// </summary>
        public void CreateList()
        {
            foreach (Transform child in MenuCanvas)
            {
                // Adding etha gameobject to the correct list.
                if (child.gameObject.CompareTag("English"))
                {
                    // Gameobject is in english.
                    enList.Add(child.gameObject);
                }
                else if (child.gameObject.CompareTag("Finnish"))
                {
                    // Gameobject is in finnish.
                    fiList.Add(child.gameObject);
                }
            }
        }

        /// <summary>
        /// Executing the actual language change.
        /// </summary>
        /// <param name="language">Indicades which language is activated.</param>
        public void SwitchLanguage(string language)
        {
            // Checking which language is in question and changing other. values accordingly
            if (language == "english")
            {
                english = true;
                finnish = false;
                PlayerPrefs.SetString("language", "english");
            }
            else if (language == "finnish")
            {
                english = false;
                finnish = true;
                PlayerPrefs.SetString("language", "finnish");
            }

            // Setting the gameobjects in the two list to active or non-active
            // according to the the given language-variable.
            foreach (GameObject button in enList)
            {
                button.SetActive(english);
            }
            foreach (GameObject button in fiList)
            {
                button.SetActive(finnish);
            }

            // Saving the modifications done to the PlayerPrefs.
            PlayerPrefs.Save();
        }
    }
}