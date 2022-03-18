using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrowObject;
    public float spawningInterval = 2f; // seconds to wait before spawning the next arrow
    public int numberToSpawn = 10; // maximum number of arrows to spawn
    Vector3 direction = new Vector3(-1, 0, 0);
    List<Vector3> directionList = new List<Vector3>();
    List<GameObject> ArrowList = new List<GameObject>();

    //HELI Rotation variables:
    Vector3 startingPoint = new Vector3(0.5f, 0, 0.5f);
    Vector3 target = new Vector3(40, 20, 40);

    //public GameObject crosshair;
    //HELI

    private WaitForSeconds spawningDelay;

    void Start()
    {
        spawningDelay = new WaitForSeconds(spawningInterval);

        // start the coroutine for spawning
        StartCoroutine(SpawnArrows());
    }

    void Update()
    {

        // flying arrows
        for (int i = 0; i < ArrowList.Count; i++)
        {
            //ArrowList[i].transform.Translate(directionList[i] * 5f * Time.deltaTime); 

            //HELI
            // Moving the array towards the target point.
            ArrowList[i].transform.position = Vector3.MoveTowards(ArrowList[i].transform.position, target, Time.deltaTime * 10f);
            //HELI
        }
    }

    public IEnumerator SpawnArrows()
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            //ArrowList.Add(Instantiate(arrowObject, transform.position, Quaternion.Euler(90, 90, 0)));
            //directionList.Add(direction);
            // TODO if we want to use the bottom one we need to adjust Quaternion rotation
            // directionList.Add(direction + new Vector3(0, Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f)));

            //HELI

            /* When using the crosshair, change "target" to crosshair.transform.position:
             * target = crosshair.transform.position 
             * This is not tested yet, but it's my first idea*/

            // Adding another arrow to ArrowList
            ArrowList.Add(Instantiate(arrowObject, transform.position, Quaternion.Euler(90, 90, 0)));
            // Adding the direction of the current arrow to directionList
            directionList.Add(direction + target);

            Debug.Log("Target " + target);
            // Creting two Vectors to held count the rotation
            Vector3 vector1 = new Vector3(target.x, startingPoint.y, startingPoint.z);
            Vector3 vector2 = new Vector3(target.x, target.y, startingPoint.z);

            // Counting the rotation angle (degrees)
            float zRotation = Vector3.Angle(vector1, vector2);
            float yRotation = Vector3.Angle(vector2, target);

            Debug.Log("Z = " + zRotation + " Y = " + yRotation);

            // Checking if the sign of zRotation os correct 
            if (target.x < 0)
            {
                zRotation /= -1;
            }
            //Rotating the current arrow
            ArrowList[i].transform.Rotate(new Vector3(0, -1 * yRotation, (3 * zRotation) / 2), Space.Self);

            // Just for test purposes changing the sing of the x cordinate of target.
            target.x *= -1;

            //HELI


            yield return spawningDelay;
        }

        yield return null;
    }

    //HELI
    //HELI
}
