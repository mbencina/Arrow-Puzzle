using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Shooting
{
    public class NewShooting : MonoBehaviour
    {
        // input action of VR controller
        public InputActionReference inputAction = null;
        
        // reference to the gun i.e. bow:
        public Transform Gun;

        // reference to right hand controller (actually left hand in the end)
        public Transform RightHand;

        // adjustable maximal distance before arrow spawns again in hand
        public int maxDist = 8;

        // reference to arrow
        public GameObject arrow;

        // reference to fake arrow
        public GameObject fakeArrow;

        // reference to raycastTest script
        public Raycast outScript;

        // is manipulated by raycasttest script,  so we know we are done with puzzle placement
        public bool shootAnother = true;

        // adjustable arrow speed
        public float arrowSpeed = 10.0f;

        // direction in which the arrow is shot
        private Vector3 direction = new Vector3(0, 0, 1);

        // whether the arrow is in the air flying or not
        private bool arrowFlying = false;

        // is true if the arrow will hit a puzzle
        private bool puzzleHit = false;

        // RaycastHit object
        private RaycastHit Hit;

        // Audio sources
        public AudioSource hitSound;
        public AudioSource releaseSound;
 
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
            
                // setting arrow direction to raycast of bow at the moment of shooting
                direction = Gun.transform.forward;
                // correctly rotate the arrow
                arrow.transform.rotation = Quaternion.LookRotation(direction);

                // technicalities to make the arrow shoot look better
                gameObject.transform.position = RightHand.transform.position;
                fakeArrow.SetActive(false);
                arrow.SetActive(true);

                // this way we find out early if we'll hit a puzzle since arrow ignores gravity
                if (Physics.Raycast(Gun.transform.position, Gun.transform.forward, out Hit, 50) && Hit.transform.name.Contains("Plane"))
                {
                    puzzleHit = true;
                    outScript.pieceHit = Hit;
                }

                // Sound for when the arrow is released 
                releaseSound.Play(0);
                arrowFlying = true;
                shootAnother = false;
            }
        }

        void Update()
        {
            // if arrow is flying we update its position
            if (arrowFlying) {
                gameObject.transform.Translate(direction * arrowSpeed * Time.deltaTime);
                float distArr = Vector3.Distance(RightHand.transform.position, gameObject.transform.position);

                if (puzzleHit) {
                    float distObj = Vector3.Distance(RightHand.transform.position, Hit.transform.position);

                    // this is how we check if arrow has hit a puzlle piece
                    if (distArr > distObj) {
                        // object hit with arrow
                        gameObject.transform.position = new Vector3(0, 0, 0);
                        arrow.SetActive(false);
                        shootAnother = false;
                        arrowFlying = false;
                        puzzleHit = false;

                        // Sound for when the arrow hits a piece
                        hitSound.Play(0);
                        // here we let other script know we have hit something
                        outScript.arrowHit = true;
                    }
                }

                // remove arrow that is too far
                if (distArr > maxDist) {
                    gameObject.transform.position = new Vector3(0, 0, 0);
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
}
