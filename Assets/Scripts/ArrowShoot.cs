using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    public GameObject arrow;
    Vector3 direction = new Vector3(-1, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        //arrow = GameObject.Find("Arrow").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        // arrow.transform() +=  * 10.0f;
        // transform.position = Vector3.forward;
        transform.Translate(direction * 1.5f * Time.deltaTime);
    }
}
