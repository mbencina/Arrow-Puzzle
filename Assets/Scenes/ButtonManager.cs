using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    /// <summary>
    /// Manages moving between scenes by pressing a button
    /// </summary>
    public class ButtonManager : MonoBehaviour
    {
        /// <summary>
        /// Executes the move between two scenes
        /// </summary>
        /// <param name="level">The name of the destination scene</param>
        public void ButtonMoveScene(string level)
        {
            SceneManager.LoadScene(level);
        }
    }
}
