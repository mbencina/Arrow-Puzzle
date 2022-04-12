using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArrowShooter : MonoBehaviour
{
    // Reference to the crosshair object:
    public Transform Crosshair;

    public InputActionReference testReference = null;
    public int maxDist = 8;

    //private Vector3 direction = new Vector3(-1, 0, 0);
    private Vector3 initialPosition = new Vector3(0, 0, 0);
    private bool arrowFlying = false;

    //HELI
    public GameObject crosshair;
    Vector3 target = new Vector3(40, 20, 40);
    //HELI

    private void Awake()
    {
        testReference.action.started += DoAction;
    }

    private void OnDestroy()
    {
        testReference.action.started -= DoAction;
    }

    private void DoAction(InputAction.CallbackContext ctx)
    {
        arrowFlying = true;
    }

    void Update()
    {
        // flying arrows
        if (arrowFlying)
        {
            bool resetArrow = false;
            gameObject.transform.Translate(Crosshair.position * 5.0f * Time.deltaTime);

            float dist = Vector3.Distance(initialPosition, gameObject.transform.position);
            // Debug.Log(dist);
            if (dist > maxDist)
            {
                resetArrow = true;
            }

            // remove arrow that is too far
            if (resetArrow)
            {
                gameObject.transform.position = new Vector3(0, 0, 0); // this should be controller position
                arrowFlying = false;
            }
        }
        // Debug.Log("something"); //this works
    }
    // TODO when we will hit a piece we will respawn arrow but we will disable it;
    // when piece is placed we enable the arrow again
}

