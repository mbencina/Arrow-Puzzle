using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzlePlacement5 : MonoBehaviour
{
    public GameObject Puzzle1;
    public GameObject Pos1;
    public float Distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(Puzzle1.transform.position, Pos1.transform.position);
        if(Distance>2){
            Puzzle1.transform.position = Pos1.transform.position;
        }

    }

}
