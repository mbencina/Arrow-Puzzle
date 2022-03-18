using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class raycastTest : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Maximum raycast distance:
    public float maximumDistance = 50;

    // Reference to the crosshair object:
    public Transform Crosshair;
    // Reference to the gun i.e. bow:
    public Transform Gun;

    // Add the controller input here:
    public InputActionReference testReference = null;

    // The object that is moved:
    private Transform MoveObject;
    // The objects collider:
    private Collider MoveCollider;

    // State of the object that is moved - moving or not:
    private bool moving = false;
    // Function that moves the transform to given position.

    private bool toggle = false;

    private void Awake() {
        testReference.action.started += DoAction;
    }

    private void OnDestroy() {
        testReference.action.started -= DoAction;
    }

    private void DoAction(InputAction.CallbackContext ctx)
    {
        if (!toggle) {
            toggle = true;
        } else {
            toggle = false;
        }
    }

    // Moves the object at the end of the raycast:
    void move(Transform objectToMove, Vector3 pos, Transform Crosshair) {
        // Change position:
        objectToMove.position = pos;

        // Get rotation from crosshair:
        float xRot = Crosshair.localRotation.eulerAngles.x;
        float yRot = Crosshair.localRotation.eulerAngles.y;
        float zRot = Crosshair.localRotation.eulerAngles.z;

        // Rotate the object at the end of raycast (piece):
        objectToMove.Rotate(xRot, yRot, zRot, Space.Self);
    }
 
    // Update is called once per frame
    void Update() {
        RaycastHit Hit;

        if (Physics.Raycast(Gun.transform.position, -Gun.transform.right, out Hit, maximumDistance))
        {
                // Move the crosshair:
                Crosshair.transform.position = Hit.point;

                // Debug: Position - Name - Draw ray:
                Debug.Log(Hit.transform.position);
                Debug.Log(Hit.transform.name);
                Debug.DrawRay(Gun.transform.position, -Gun.transform.right, Color.green);
                // If the controller is toggled, the moving not enabled and hit is a puzzle piece:
                
                if (toggle && !moving && Hit.transform.name.Contains("Plane")) { // Change true to the correct signal from controller
                    // Turn off collider
                    MoveCollider = Hit.collider;
                    Hit.collider.enabled = false;
                    // Set state to moving
                    moving = true;
                    // Picke the obejct to move
                    MoveObject = Hit.transform;
                    
                } 
                // If the controller is toggled, the piece picked for moving, 
                // the object is moved along the raycast:
                if (toggle && moving) {
                    move(MoveObject, Hit.point, Crosshair);
                }

                // If controller is not toggled, the collider is set on again 
                // and the state set to not moving. Finally, the object to move
                // is set to null:
                if (!toggle && moving) { // Change false to input signal showing the controller is not toggled.
                    MoveCollider.enabled = true;
                    MoveCollider = null;
                    MoveObject = null;
                    moving = false;
                }
        }
        
    }
}
