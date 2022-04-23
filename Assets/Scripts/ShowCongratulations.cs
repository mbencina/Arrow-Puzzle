using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGameMenu
{ 
    /// <summary>
    /// Counts when the congratulations-message is shown
    /// </summary>
    public class ShowCongratulations : MonoBehaviour
    {   
        /// <summary>
        /// Panel that had the message on it
        /// </summary>
        public GameObject Panel;
        // List of the puzzle pieces
        GameObject [] snaps;
        // counter to indicade when to show the message
        int counter;

        /// <summary>
        /// Creating the list of puzzle pieces when the game starts
        /// </summary>
        void Start()
        {
            snaps = GameObject.FindGameObjectsWithTag("PuzzlePiece");
        }

        /// <summary>
        /// Checking in every frame whether the congratulations 
        /// message should be shown
        /// </summary>
        void Update()
        {
            // Going through the list of pieces
            foreach (GameObject g in snaps)
            {
                // Checking if the piece is snapped to the frame
                if (g.GetComponent<PuzzlePlacement>().snapped)
                {
                    counter++;
                }
            }
            // Checking if the message should be shonwn
            if (counter == 12)
            {
                // Calling OpenPanel-method to show the congratulations-message
                Panel.GetComponent<Menus.PanelOpener>().OpenPanel();
            }
            // Reseting the counter for the next frame
            counter = 0;
        }
    }
}