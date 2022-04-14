using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePlacement : MonoBehaviour
{
    GameObject puzzle;
    public GameObject pos;
    //public GameObject parent;
    float Distance;

    Rigidbody rb;
    
    public bool snapped;

    public GameObject Panel;
    private Menus.PanelOpener panelOpener;
    // Start is called before the first frame update
    void Start()
    {
        puzzle = this.gameObject;
        rb = puzzle.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 6; i++)
        {
            for(int j=0; j < 4; j++)
            {
                Distance = Vector3.Distance(puzzle.transform.position, 
                    new Vector3(pos.transform.position.x + i * 0.01f + 1.35f, 
                    pos.transform.position.y - 0.8f - j * 0.01f, pos.transform.position.z));
                //Debug.Log(i + "i "+j+" j "+Distance+"dist");
                if (true)
                {
                    pos.transform.localScale = puzzle.transform.localScale;
                    rb.isKinematic = true;
                    puzzle.transform.position = pos.transform.position;
                    puzzle.transform.position = new Vector3(puzzle.transform.position.x + i * 0.01f + 1.35f, puzzle.transform.position.y - 0.8f - j * 0.01f, puzzle.transform.position.z);
                    puzzle.transform.eulerAngles = new Vector3(0, -66, 0);
                    snapped = true;
                    //Panel.GetComponent<Menus.PanelOpener>().OpenPanel();
                    
                    
                    
                }
            }
        }

    }

}
