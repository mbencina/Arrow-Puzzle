using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterTest : MonoBehaviour
{
    private List<GameObject> pieces = new List<GameObject>();
    public Transform puzzle;
    public GameObject Panel;

    int snapped = 0;
    int counter = 0;

    private void Start()
    {
        CreateList();
    }

    // Update is called once per frame
    /*void Update()
    {
        foreach (GameObject g in pieces)
        {
            if (g.GetComponent<PuzzlePlacement>().snapped)
            {
                snapped++;
            }
        }

        Debug.Log("Snapped: " + snapped);
        //if (show)
        if (snapped == 12)
        {
            Panel.GetComponent<Menus.PanelOpener>().OpenPanel();
        }
        snapped = 0;
    }*/

    public void CreateList()
    {
        foreach (Transform child in puzzle)
        {
            if (child.gameObject.CompareTag("PuzzlePiece"))

            {
                pieces.Add(child.gameObject);
            }
        }
        int size = pieces.Count;
    }

    public void MarkSnapped()
    {
        pieces[counter].GetComponent<PuzzlePieces.PuzzlePlacement>().snapped = true;
        counter++;
        Debug.Log("Counter: " + counter);
    }

}
