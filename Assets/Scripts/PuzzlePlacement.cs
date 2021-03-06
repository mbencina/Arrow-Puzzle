using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PuzzlePieces
{
    public class PuzzlePlacement : MonoBehaviour
    {
        GameObject puzzle;
        public GameObject pos;
        float Distance;
        public Text CounterText;
        public int counter;
        Rigidbody rb;
        public bool snapped;
        void Start()
        {
            puzzle = this.gameObject;
            rb = puzzle.GetComponent<Rigidbody>();
            counter = PlayerPrefs.GetInt("CounterText", 0);
            CounterText.text = counter.ToString();
            
        }

        // Update is called once per frame
        void Update()
        {
            for(int i = 0; i < 6; i++)
            {
                for(int j=0; j < 4; j++)
                {
                    //calculating distance between the puzzle piece current position and the reference game object position
                    Distance = Vector3.Distance(puzzle.transform.position, 
                        new Vector3(pos.transform.position.x + i * 0.01f + 1.35f, pos.transform.position.y - 0.8f - j * 0.01f, pos.transform.position.z));
                   
                    //if distance is less than 4, the reference position becomes the position of the puzzle
                    if (true)
                    {
                        pos.transform.localScale = puzzle.transform.localScale;
                        rb.isKinematic = true;
                        puzzle.transform.position = pos.transform.position;
                        puzzle.transform.position = new Vector3(puzzle.transform.position.x + i * 0.01f + 1.35f, puzzle.transform.position.y - 0.8f - j * 0.01f, puzzle.transform.position.z);
                        puzzle.transform.eulerAngles = new Vector3(0, -66, 0);
                        if (!snapped)
                        {
                            counter = PlayerPrefs.GetInt("CounterText", 0);
                            counter++;
                            PlayerPrefs.SetInt("CounterText", counter);
                            CounterText.text = counter.ToString();
                        }
                        snapped = true;
                    }
                }
            }

        }

    }
}