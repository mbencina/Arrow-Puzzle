using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace Shooting
{
    /// <summary>
    /// A script that is used to grab an object after an arrow hit and to move the object.
    /// </summary>
    public class Raycast : MonoBehaviour
    {
        /// <summary>
        /// Reference to controller:
        /// </summary>
        public GameObject Controller;

        /// <summary>
        /// Maximum raycast distance:
        /// </summary>
        public float maximumDistance = 50;

        /// <summary>
        /// Reference to the crosshair object:
        /// </summary>
        public Transform Crosshair;
        // Reference to the gun i.e. bow:
        public Transform Gun;

        /// <summary>
        /// Add the controller input here:
        /// </summary>
        public InputActionReference testReference = null;

        /// <summary>
        /// The object that is moved:
        /// </summary>
        private Transform MoveObject;

        /// <summary>
        /// The object's collider:
        /// </summary>
        private Collider MoveCollider;

        /// <summary>
        /// State of the object that is moved - moving or not:
        /// </summary>
        private bool moving = false;

        /// <summary>
        /// State of the control button.
        /// </summary>
        private bool toggle = true;

        /// <summary>
        /// We know when arrow has hit a puzzle piece
        /// </summary>
        public bool arrowHit = false;

        /// <summary>
        /// The puzzle piece that was hit
        /// </summary>
        public RaycastHit pieceHit;

        /// <summary>
        /// Reference to the shooting script
        /// </summary>
        public Shooting.NewShooting shootingScript;

        /// <summary>
        /// Distance of crosshair
        /// </summary>
        public float crosshairDistance = 3.0f;

        private void Awake() {
            testReference.action.started += DoAction;
        }

        private void OnDestroy() {
            testReference.action.started -= DoAction;
        }

        /// <summary>
        /// Make dragging on and off (parametert toggle) when controller button is clicked:
        /// </summary>
        private void DoAction(InputAction.CallbackContext ctx)
        {
            if (!toggle) {
                toggle = true;
            } else {
                toggle = false;
            }
        }

        /// <summary>
        /// Moves and rotates the object at the end of the raycast.
        /// </summary>

        // objectToMove is the object moved, position the new position and ctrl a refrence to the controller.
        void move(Transform objectToMove, Vector3 pos, GameObject ctrl) {
            // Change position:
            objectToMove.position = pos;

            // Get rotation from crosshair:
            float xRot = ctrl.transform.localRotation.eulerAngles.x;
            float yRot = ctrl.transform.localRotation.eulerAngles.y;
            float zRot = ctrl.transform.localRotation.eulerAngles.z;

            // Rotate the object at the end of raycast (piece):
            objectToMove.rotation = Quaternion.Euler(xRot,yRot,zRot);
        }
 
        /// <summary>
        /// Update is called once per frame. The crosshair is moved along the controller. If the crosshair points at an object, 
        /// the crosshair is on top of the object, otherwise determined amount of units in front of the controller.
        /// Grabs the object after an arrow hit or releases the object if the controller is released.
        /// </summary>
        void Update() {
            RaycastHit Hit;

            if (Physics.Raycast(Gun.transform.position, -Gun.transform.right, out Hit, maximumDistance)) {
                // Move the crosshair:
                Crosshair.transform.position = Hit.point;
            } else {
                // Move the crosshair to a point that is crosshairDistance amount of units in fron tof the bow:
                Crosshair.transform.position = Controller.transform.position + Controller.transform.forward * crosshairDistance;
            }

                // Debug: Position - Name - Draw ray:
                //Debug.Log(Hit.transform.position);
                //Debug.Log(Hit.transform.name);
                //Debug.DrawRay(Gun.transform.position, -Gun.transform.right, Color.green);
                // If the controller is toggled, the moving not enabled and hit is a puzzle piece:
            if (!moving) {
                if (arrowHit) { // Change true to the correct signal from controller
                    // Turn off collider
                    MoveCollider = pieceHit.collider;
                    pieceHit.collider.enabled = false;
                    // Set state to moving
                    moving = true;
                    // Picke the obejct to move
                    MoveObject = pieceHit.transform;
                    toggle = true;

                    //Debug.Log("moving: "+ moving.ToString());
                    //Debug.Log(MoveObject.name);

                    // If the controller is toggled, the piece picked for moving, 
                    // the object is moved along the raycast:
                    move(MoveObject, Crosshair.transform.position, Controller);
                }
            // If raycast has nothing to hit, simply move the crosshair and if the piece is moving, the piece:
            } else {
                // If the controller is toggled, the piece picked for moving, 
                // the object is moved along the raycast:
                move(MoveObject, Crosshair.transform.position, Controller);

                // If controller is not toggled, the collider is set on again 
                // and the state set to not moving. Finally, the object to move
                // is set to null:
                if (!toggle) { // Change false to input signal showing the controller is not toggled.
                    MoveCollider.enabled = true;
                    MoveCollider = null;
                    MoveObject = null;
                    moving = false;
                    toggle = true;

                    arrowHit = false;
                    shootingScript.shootAnother = true;
                }
            } 
        }
    }
}
