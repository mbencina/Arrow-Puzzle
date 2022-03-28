using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewShooting : MonoBehaviour
{
    public InputActionReference inputAction = null;
    // Reference to the gun i.e. bow:
    public Transform Gun;
    public int maxDist = 8;
    public GameObject testObj;
    public GameObject arrow;
    public GameObject fakeArrow;
    public raycastTest outScript;

    private Vector3 direction = new Vector3(0, 0, 1);
    private Vector3 initialPosition = new Vector3(0, 0, 0);
    private bool arrowFlying = false;
    private bool puzzleHit = false;
    private RaycastHit Hit;

    private void Awake()
    {
        inputAction.action.started += DoAction;
    }

    private void OnDestroy()
    {
        inputAction.action.started -= DoAction;
    }

    private void DoAction(InputAction.CallbackContext ctx)
    {
        
        if (!arrowFlying) {
            
            direction = Gun.transform.forward; // -Gun.transform.right
            arrow.transform.rotation = Quaternion.LookRotation(direction);
            // Debug.Log("direction: " + Gun.transform.forward);
            // Debug.Log(-Gun.transform.right);
            fakeArrow.SetActive(false);
            arrow.SetActive(true);
            // TODO adjust real arrow location to fake arrows location - test!

            if (Physics.Raycast(Gun.transform.position, Gun.transform.forward, out Hit, maxDist)) // Gun.transform.position, -Gun.transform.right, out Hit, maxDist
            {
                puzzleHit = true;
                outScript.pieceHit = Hit;
            }
        }
        
        arrowFlying = true;
    }

    void Update()
    {
        // flying arrows
        if (arrowFlying) {
            gameObject.transform.Translate(direction * 5.0f * Time.deltaTime);
            float distArr = Vector3.Distance(initialPosition, gameObject.transform.position);
            // Debug.Log(dist);
            

            if (puzzleHit) {
                float distObj = Vector3.Distance(initialPosition, Hit.transform.position);
                if (distArr > distObj) {
                    // object hit with arrow
                    // Debug.Log("object hit!");
                    gameObject.transform.position = new Vector3(0, 0, 0); // this should be controller position
                    arrow.SetActive(false);
                    fakeArrow.SetActive(true); // TODO remove while moving puzzle piece; enable when piece is placed; add public var to know when it stops;
                    arrowFlying = false;
                    puzzleHit = false;

                    // here we let other script know we have hit something
                    outScript.arrowHit = true;
                }
            }

            // remove arrow that is too far
            if (distArr > maxDist) {
                gameObject.transform.position = new Vector3(0, 0, 0); // this should be controller position
                arrow.SetActive(false);
                fakeArrow.SetActive(true);
                arrowFlying = false;
            }
        }
    }
}
