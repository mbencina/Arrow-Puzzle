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
        for(int i = 0; i < ArrowList.Count; i++) {
            ArrowList[i].transform.Translate(directionList[i] * 5.0f * Time.deltaTime);
        }
    }

    public IEnumerator SpawnArrows()
    {
        for(int i = 0; i < numberToSpawn; i++) {
            ArrowList.Add(Instantiate(arrowObject, transform.position, Quaternion.Euler(90, 90, 0)));
            directionList.Add(direction);
            // TODO if we want to use the bottom one we need to adjust Quaternion rotation
            // directionList.Add(direction + new Vector3(0, Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f))); 
            yield return spawningDelay;
        }

        yield return null;
    }
}
