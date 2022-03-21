using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceRandomization : MonoBehaviour
{
    // Variables
    public List<GameObject> pieces = new List<GameObject>();
    public GameObject canvas;

    //public GameObject parent;
    public Vector3 vector = new Vector3 (0,0,0);

    public float max = 6.0f;
    public float min = -6.0f;

    public float bubbleMax = 1.0f;
    public float bubbleMin = -1.0f;

    public bool flag = false;

    // Start is called before the first frame update
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
        Vector3 place = new Vector3(Random.Range(min, max), Random.Range(0, max), Random.Range(min, max));
        if (place.x >= bubbleMin && place.x <= bubbleMax &&
            place.y >= bubbleMin && place.y <= bubbleMax &&
            place.z >= bubbleMin && place.z <= bubbleMax || // Checking if the piece is too close to the player
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
        if (place.z <= 0 && System.Math.Abs(place.z) >= System.Math.Abs(place.x))
        {
            Debug.Log("TRUE");
            return true;
        }
        Debug.Log("FALSE");
        return false;
    }
}