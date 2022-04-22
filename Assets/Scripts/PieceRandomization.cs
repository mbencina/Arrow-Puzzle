using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PuzzlePieces
{
    /// <summary>
    /// Defines the scattering of the puzzle pieces at the beginning of the game.
    /// </summary>
    public class PieceRandomization : MonoBehaviour
    {
        // List of the puzzle pieces
        private List<GameObject> pieces = new List<GameObject>();

        // Vector for setting the new positions of the pieces
        private Vector3 vector = new Vector3(0, 0, 0);

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
        public void CreateList()
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
        public void RandomizePosition()
        {
            foreach (GameObject piece in pieces)
            {
                // Generating a position
                GenerateVector();

                //Debug.Log("PIECE: " + piece);
                //Debug.Log(vector);

                // Setting the piece to a new position
                piece.transform.localPosition = new Vector3(vector.x, vector.y, vector.z);

                // Rotating the piece to face the player
                RotatePiece(piece);
                // Setting the piece in its place
                piece.GetComponent<Rigidbody>().isKinematic = true;
            }
        }

        /// <summary>
        /// Generates random vectors between given max and min values
        /// </summary>
        public void GenerateVector()

        {
            // Creating a random vector
            Vector3 place = new Vector3(Random.Range(limitValues[1], limitValues[0]), Random.Range(0, limitValues[0]), Random.Range(limitValues[1], limitValues[0]));
            // Checking if the place is inside the wanted area
            if (place.x >= limitValues[3] && place.x <= limitValues[2] &&
                place.y >= limitValues[3] && place.y <= limitValues[2] &&
                place.z >= limitValues[3] && place.z <= limitValues[2] || // Checking if the piece is too close to the player
                IsOnCanvas(place) == true)  // Checking if the piece is on of behind the canvas
            {
                // Generating a new vector
                GenerateVector();
            }
            else
            {
                // Setting the public vector to indicate the place
                vector = place;
            }
        }

        /// <summary>
        /// Checks if puzzle piece is on or behind the table
        /// </summary>
        /// <param name="place">The current place of the puzzle piece</param>
        /// <returns>Truth value on if the piece is on or behind the table or not</returns>
        public bool IsOnCanvas(Vector3 place)
        {
            // Checking if the piece is to high or on or behind the canvas
            if (place.z <= 0 && place.x >= 0 ||
                System.Math.Abs(place.y) * 1.25 >= System.Math.Abs(place.x) &&
                System.Math.Abs(place.y) * 1.25 >= System.Math.Abs(place.z))

            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines the initial rotation of the puzzle pieces at the start of the game
        /// </summary>
        /// <param name="piece"></param>
        public void RotatePiece(GameObject piece)
        {

            //Debug.Log("PIECE: " + piece);
            //Debug.Log(vector);

            // The pieces infront of the player
            if (vector.z >= 0)
            {
                // On the right side of the player
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
                // On the left side of the player
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
            // The pieces behind the player
            else if (vector.z < 0)
            {
                // On the right side of the player
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
                // On the left side of the player
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