using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PuzzlePieces { 

    /// <summary>
    /// Defines the scattering of the puzzle pieces at the beginning of the game.
    /// </summary>
    public class PieceRandomization : MonoBehaviour
    {
        // Variables
        private List<GameObject> pieces = new List<GameObject>();

        private Vector3 vector = new Vector3 (0,0,0);
    
        /// <summary>
        /// An array of variables that define the area where the puzzle pieces can be set
        /// </summary>
        public float[] limitValues = { 6.0f, -6.0f, 1.0f, -1.0f };

        /// <summary>
        /// Starts the puzzle piece scattering
        /// </summary>
        void Start()
        {
            CreateList();
            RandomizePosition();

        }

        /// <summary>
        /// Creating a list of the puzzle pieces
        /// </summary>
        /// 
        public void CreateList ()
        {
            foreach (Transform child in transform)
            {   
                if (child.gameObject.CompareTag("PuzzlePiece")) 
                {
                    pieces.Add(child.gameObject);
                }
            }
            int size = pieces.Count;
        }

        /// <summary>
        /// Randomize the position of the puzzle pieces
        /// </summary>
        public void RandomizePosition ()
        {
            foreach(GameObject piece in pieces)
            {
                //piece.transform.SetParent(null);
                Debug.Log("NEW");
                GenerateVector();
                RotatePiece(piece);
            
                piece.transform.position = vector;
                Debug.Log("Vector " + vector);
                Debug.Log("Position " + transform.TransformPoint(vector));
            }
        }

        /// <summary>
        /// Generates random vectors between given max and min values
        /// </summary>
        public void GenerateVector ()
        {
            Vector3 place = new Vector3(Random.Range(limitValues[1], limitValues[0]), Random.Range(0, limitValues[0]), Random.Range(limitValues[1], limitValues[0]));
            if (place.x >= limitValues[3] && place.x <= limitValues[2] &&
                place.y >= limitValues[3] && place.y <= limitValues[2] &&
                place.z >= limitValues[3] && place.z <= limitValues[2] || // Checking if the piece is too close to the player
                IsOnTable(place) == true)  // Checking if the piece is on of behind the canvas
            {
                GenerateVector();
            }
            else
            {
                vector = place;
            }
        }

        /// <summary>
        /// Checks if puzzle piece is on or behind the table
        /// </summary>
        /// <param name="place">The current place of the puzzle piece</param>
        /// <returns>Truth value on if the piece is on or behind the table or not</returns>
        public bool IsOnTable (Vector3 place)
        {
            Debug.Log("ABS " + System.Math.Abs(place.z) + " " + System.Math.Abs(place.x));
            if (place.z <= 0 && System.Math.Abs(place.z) >= System.Math.Abs(place.x) ||
                System.Math.Abs(place.y) >= System.Math.Abs(place.x) &&
                System.Math.Abs(place.y) >= System.Math.Abs(place.z))
            {
                Debug.Log("TRUE");
                return true;
            }
            Debug.Log("FALSE");
            return false;
        }

        public void RotatePiece(GameObject piece)
        {
            if (vector.x > 0 && System.Math.Abs(vector.x) >= System.Math.Abs(vector.z) * 2)
            {
                float xRot = piece.transform.localRotation.eulerAngles.x;
                float zRot = piece.transform.localRotation.eulerAngles.z;
                piece.transform.rotation = Quaternion.Euler(xRot, 90, zRot);
            }
            else if (vector.x > 0 && System.Math.Abs(vector.x) >= System.Math.Abs(vector.z))
            {
                float xRot = piece.transform.localRotation.eulerAngles.x;
                float zRot = piece.transform.localRotation.eulerAngles.z;
                piece.transform.rotation = Quaternion.Euler(xRot, 45, zRot);
            }
            else if (vector.x < 0 && System.Math.Abs(vector.x) >= System.Math.Abs(vector.z) * 2)
            {
                float xRot = piece.transform.localRotation.eulerAngles.x;
                float zRot = piece.transform.localRotation.eulerAngles.z;
                piece.transform.rotation = Quaternion.Euler(xRot, -90, zRot);
            }
            else if (vector.x < 0 && System.Math.Abs(vector.x) >= System.Math.Abs(vector.z))
            {
                float xRot = piece.transform.localRotation.eulerAngles.x;
                float zRot = piece.transform.localRotation.eulerAngles.z;
                piece.transform.rotation = Quaternion.Euler(xRot, -45, zRot);
            }
        }
    }
}