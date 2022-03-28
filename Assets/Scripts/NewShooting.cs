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

    private Vector3 direction = new Vector3(-1, 0, 0);
    private Vector3 initialPosition = new Vector3(0, 0, 0);
    private bool arrowFlying = false;
    private bool puzzleHit = false;
    private RaycastHit Hit;
    private bool testActive = false;

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
            
            direction = -Gun.transform.right; // -Gun.transform.right

            // Debug.Log(-Gun.transform.right);

            if (Physics.Raycast(Gun.transform.position, -Gun.transform.right, out Hit, maxDist)) // Gun.transform.position, -Gun.transform.right, out Hit, maxDist
            {
                puzzleHit = true;
                testObj.SetActive(testActive);
                testActive = !testActive;
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
                // TODO distanci pa če puzzle hit
                float distObj = Vector3.Distance(initialPosition, Hit.transform.position);
                if (distArr > distObj) {
                    // object hit with arrow
                    // TODO implement / move logic
                    Debug.Log("object hit!");
                    gameObject.transform.position = new Vector3(0, 0, 0); // this should be controller position
                    arrowFlying = false;
                    puzzleHit = false;
                }
            }

            // remove arrow that is too far
            if (distArr > maxDist) {
                gameObject.transform.position = new Vector3(0, 0, 0); // this should be controller position
                arrowFlying = false;
            }
        }
        // Debug.Log("something"); //this works
    }
    // TODO when we will hit a piece we will respawn arrow but we will disable it;
    // when piece is placed we enable the arrow again
}
