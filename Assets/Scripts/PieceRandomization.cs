<<<<<<< HEAD

=======
>>>>>>> d9d94f460282436e24019bdd7aff38b01b961672
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
namespace PuzzlePieces
{
=======
namespace PuzzlePieces { 
>>>>>>> d9d94f460282436e24019bdd7aff38b01b961672

    /// <summary>
    /// Defines the scattering of the puzzle pieces at the beginning of the game.
    /// </summary>
    public class PieceRandomization : MonoBehaviour
    {
        // Variables
        private List<GameObject> pieces = new List<GameObject>();

<<<<<<< HEAD
        private Vector3 vector = new Vector3(0, 0, 0);

=======
        private Vector3 vector = new Vector3 (0,0,0);
    
>>>>>>> d9d94f460282436e24019bdd7aff38b01b961672
        /// <summary>
        /// An array of variables that define the area where the puzzle pieces can be set
        /// </summary>
        public float[] limitValues = { 6.0f, -6.0f, 1.0f, -1.0f };


<<<<<<< HEAD
=======

>>>>>>> d9d94f460282436e24019bdd7aff38b01b961672
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
<<<<<<< HEAD
        public void CreateList()
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.CompareTag("PuzzlePiece"))
=======
        public void CreateList ()
        {
            foreach (Transform child in transform)
            {   
                if (child.gameObject.CompareTag("PuzzlePiece")) 
>>>>>>> d9d94f460282436e24019bdd7aff38b01b961672
                {
                    pieces.Add(child.gameObject);
                }
            }
            int size = pieces.Count;
        }

        /// <summary>
        /// Randomize the position of the puzzle pieces
        /// </summary>
<<<<<<< HEAD
        public void RandomizePosition()
        {
            foreach (GameObject piece in pieces)
=======
        public void RandomizePosition ()
        {
            foreach(GameObject piece in pieces)
>>>>>>> d9d94f460282436e24019bdd7aff38b01b961672
            {
                //piece.transform.SetParent(null);
                Debug.Log("NEW");
                GenerateVector();
<<<<<<< HEAD

=======
            
>>>>>>> d9d94f460282436e24019bdd7aff38b01b961672
                piece.transform.position = vector;

                RotatePiece(piece);
            }
        }

        /// <summary>
        /// Generates random vectors between given max and min values
        /// </summary>
<<<<<<< HEAD
        public void GenerateVector()
=======
        public void GenerateVector ()
>>>>>>> d9d94f460282436e24019bdd7aff38b01b961672
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
<<<<<<< HEAD
        public bool IsOnTable(Vector3 place)
        {
            ;
            if (place.z > 0 && place.x < 0 ||
                System.Math.Abs(place.y) * 1.25 >= System.Math.Abs(place.x) &&
                System.Math.Abs(place.y) * 1.25 >= System.Math.Abs(place.z))
=======
        public bool IsOnTable (Vector3 place)
        {;
            if (place.z <= 0 && System.Math.Abs(place.z) >= System.Math.Abs(place.x) ||
                System.Math.Abs(place.y) >= System.Math.Abs(place.x) &&
                System.Math.Abs(place.y) >= System.Math.Abs(place.z))
>>>>>>> d9d94f460282436e24019bdd7aff38b01b961672
            {
                return true;
            }
            return false;
        }

<<<<<<< HEAD
        /// <summary>
        /// Determines the initial rotation of the puzzle pieces at the start of the game
        /// </summary>
        /// <param name="piece"></param>
=======
>>>>>>> d9d94f460282436e24019bdd7aff38b01b961672
        public void RotatePiece(GameObject piece)
        {
            Debug.Log("PIECE: " + piece);
            Debug.Log(vector);
<<<<<<< HEAD
            
=======
            /*Vector3 direction = player.position - piece.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            piece.transform.rotation = rotation;
            */
>>>>>>> d9d94f460282436e24019bdd7aff38b01b961672
            if (vector.z >= 0)
            {
                if (vector.x > 0 && System.Math.Abs(vector.x) > System.Math.Abs(vector.z) * 2)
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
                else if (vector.x < 0 && System.Math.Abs(vector.x) > System.Math.Abs(vector.z) * 2)
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
            else if (vector.z < 0)
            {
                if (vector.x > 0 && System.Math.Abs(vector.x) > System.Math.Abs(vector.z) * 2)
                {
                    float xRot = piece.transform.localRotation.eulerAngles.x;
                    float zRot = piece.transform.localRotation.eulerAngles.z;
                    piece.transform.rotation = Quaternion.Euler(xRot, 90, zRot);
                }
                else if (vector.x > 0 && System.Math.Abs(vector.x) >= System.Math.Abs(vector.z))
                {
                    float xRot = piece.transform.localRotation.eulerAngles.x;
                    float zRot = piece.transform.localRotation.eulerAngles.z;
                    piece.transform.rotation = Quaternion.Euler(xRot, 135, zRot);
                }
                else if (vector.x < 0 && System.Math.Abs(vector.x) > System.Math.Abs(vector.z) * 2)
                {
                    float xRot = piece.transform.localRotation.eulerAngles.x;
                    float zRot = piece.transform.localRotation.eulerAngles.z;
                    piece.transform.rotation = Quaternion.Euler(xRot, -90, zRot);
                }
                else if (vector.x < 0 && System.Math.Abs(vector.x) >= System.Math.Abs(vector.z))
                {
                    float xRot = piece.transform.localRotation.eulerAngles.x;
                    float zRot = piece.transform.localRotation.eulerAngles.z;
                    piece.transform.rotation = Quaternion.Euler(xRot, -135, zRot);
                }
            }
        }
    }
}