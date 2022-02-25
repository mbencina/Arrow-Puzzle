using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ArrowShooter : MonoBehaviour
{
    public GameObject arrow;
    void Start()
    {
        Debug.Log("Item script");
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);

        foreach (var item in devices) {
            Debug.Log(item.name + item.characteristics);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /* if (OVRInput.Get(OVRInput.Button.One)){
            Debug.Log("A button pressed");
        } */
    }
}
