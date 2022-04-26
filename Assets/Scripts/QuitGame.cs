using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menus
{
    /// <summary>
    /// Quitting the game on button click
    /// </summary>
    public class QuitGame : MonoBehaviour
    {
        /// <summary>
        /// Ends the game when triggered
        /// </summary>
        public void QuitGameOnClick()
        {
            Application.Quit();
            Debug.Log("Game is exiting");
        }
    }
}
