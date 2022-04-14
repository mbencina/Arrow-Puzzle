using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCongratulations : MonoBehaviour
{
    public GameObject Panel;
    GameObject [] snaps;
    bool show;
    // Start is called before the first frame update
    void Start()
    {
        snaps = GameObject.FindGameObjectsWithTag("PuzzlePiece");
        show = false;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject g in snaps)
        {
            if (!g.GetComponent<PuzzlePlacement>().snapped)
            {
                show = false;
            }
            else
            {
                show = true;
            }
        }
        if (show)
        {
            Panel.GetComponent<Menus.PanelOpener>().OpenPanel();
        }
    }
}
