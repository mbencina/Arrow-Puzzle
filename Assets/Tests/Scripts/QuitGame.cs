using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menus
{
    public class QuitGame : MonoBehaviour
    {
        public void QuitGameOnClick()
        {
            Application.Quit();
            Debug.Log("Game is exiting");
        }
    }
}
