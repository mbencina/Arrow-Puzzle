using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceRandomization : MonoBehaviour
{
    // Variables
    public List<GameObject> pieces = new List<GameObject>();
    public GameObject canvas;

    public float leftMultiplier = 3.39f/2.61f;
    public float rightMultiplier = - 3.06f/2.61f;

    public float max = 20;
    public float min = -20;

    public float bubbleMax = 2;
    public float bubbleMin = -2;

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
            Vector3 place = GenerateVector();
            
            piece.transform.position = place;
            Debug.Log("Position " + place);
        }
    }

    /// <summary>
    /// Generates random vectors between given max and min values
    /// </summary>
    /// <returns>Random 3D vector</returns>
    public Vector3 GenerateVector ()
    {
        Vector3 place = new Vector3(Random.Range(min, max), Random.Range(0, max), Random.Range(min, max));
        if (place.x >= bubbleMin && place.x <= bubbleMax &&
            place.y >= bubbleMin && place.y <= bubbleMax &&
            place.z >= bubbleMin && place.z <= bubbleMax ||
            IsOnTable(place) == true)
        {
            GenerateVector();
        }
        return place
;    }

    /// <summary>
    /// Checks if puzzle piece is on or behind the table
    /// </summary>
    /// <param name="place">The current place of the puzzle piece</param>
    /// <returns>Truth value on if the piece is on or behind the table or not</returns>
    public bool IsOnTable (Vector3 place)
    {
        if (place.z <= 0 && System.Math.Abs(place.z) > System.Math.Abs(place.x))
        {
            Debug.Log("TRUE");
            return true;
        }
        Debug.Log("FALSE");
        return false;
    }
}
