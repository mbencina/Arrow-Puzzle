using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceRandomization : MonoBehaviour
{
    // Variables
    public List<GameObject> pieces = new List<GameObject>();
    public GameObject canvas;

    public Vector3 vector = new Vector3 (0,0,0);

    public int max = 6;
    public int min = -6;

    public int bubbleMax = 1;
    public int bubbleMin = -1;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Randomize the position of the puzzle pieces
    /// </summary>
    public void RandomizePosition ()
    {
        foreach(GameObject piece in pieces)
        {
            Debug.Log("NEW");
            GenerateVector();
            
            piece.transform.position = vector;
            Debug.Log("Vector " + vector);
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
            place.z >= bubbleMin && place.z <= bubbleMax ||
            IsOnTable(place) == true)
        {
            GenerateVector();
        }
        else
        {
            vector = place;
        }
;    }

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