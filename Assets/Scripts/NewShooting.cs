using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewShooting : MonoBehaviour
{
    public InputActionReference inputAction = null;
    // Reference to the gun i.e. bow:
    public Transform Gun;
    public Transform RightHand;
    public int maxDist = 8;
    public GameObject arrow;
    public GameObject fakeArrow;
    public raycastTest outScript;
    public bool shootAnother = true; // sent by other script TODO uporabi; pa še nek toggle k lah izklop bow & arrow more bit

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
        
        if (!arrowFlying && shootAnother) {
            
            direction = Gun.transform.forward; // -Gun.transform.right
            arrow.transform.rotation = Quaternion.LookRotation(direction);
            // Debug.Log("direction: " + Gun.transform.forward);
            // Debug.Log(-Gun.transform.right);
            arrow.transform.position = RightHand.transform.position;
            fakeArrow.SetActive(false);
            arrow.SetActive(true);
            // TODO adjust real arrow location to fake arrows location - test!

            if (Physics.Raycast(Gun.transform.position, Gun.transform.forward, out Hit, maxDist) && Hit.transform.name.Contains("Plane"))
            {
                puzzleHit = true;
                outScript.pieceHit = Hit;
            }
            arrowFlying = true;
            shootAnother = false;
        }
    }

    void Update()
    {
        // flying arrows
        if (arrowFlying) {
            gameObject.transform.Translate(direction * 5.0f * Time.deltaTime);
            float distArr = Vector3.Distance(RightHand.transform.position, gameObject.transform.position);
            // Debug.Log(dist);

            if (puzzleHit) {
                float distObj = Vector3.Distance(RightHand.transform.position, Hit.transform.position);
                if (distArr > distObj) {
                    // object hit with arrow
                    // Debug.Log("object hit!");
                    gameObject.transform.position = new Vector3(0, 0, 0); // this should be controller position
                    arrow.SetActive(false);
                    shootAnother = false;
                    // fakeArrow.SetActive(true); // TODO remove while moving puzzle piece; enable when piece is placed; add public var to know when it stops;
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
                shootAnother = true;
            }
        }

        if (shootAnother) {
            fakeArrow.SetActive(true);
        }
    }
}
