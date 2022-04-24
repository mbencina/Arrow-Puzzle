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

        // reference to right hand controller
        public Transform RightHand;

        // adjustable maximal distance before arrow spawns again in hand
        public int maxDist = 8;

        // reference to arrow
        public GameObject arrow;

        // reference to fake arrow
        public GameObject fakeArrow;

        // reference to raycastTest script
        public raycastTest outScript;

        // is manipulated by raycasttest script,  so we know we are done with puzzle placement
        public bool shootAnother = true;

        // adjustable arrow speed
        public float arrowSpeed = 10.0f;

        private Vector3 direction = new Vector3(0, 0, 1);
        private Vector3 initialPosition = new Vector3(0, 0, 0);
        private bool arrowFlying = false;
        private bool puzzleHit = false;
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
            
                direction = Gun.transform.forward; // -Gun.transform.right
                arrow.transform.rotation = Quaternion.LookRotation(direction);
                // Debug.Log("direction: " + Gun.transform.forward);
                // Debug.Log(-Gun.transform.right);
                gameObject.transform.position = RightHand.transform.position;
                fakeArrow.SetActive(false);
                arrow.SetActive(true);
                // TODO adjust real arrow location to fake arrows location - test!

                if (Physics.Raycast(Gun.transform.position, Gun.transform.forward, out Hit, 50) && Hit.transform.name.Contains("Plane")) //  && Hit.transform.name.Contains("Plane")
                {
                    puzzleHit = true;
                    outScript.pieceHit = Hit;
                }
                // Sound for when the array is released 
                releaseSound.Play(0);
                arrowFlying = true;
                shootAnother = false;
            }
        }

        void Update()
        {
            // flying arrows
            if (arrowFlying) {
                gameObject.transform.Translate(direction * arrowSpeed * Time.deltaTime);
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

                        // Sound for when the arrow hits a piece
                        hitSound.Play(0);
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
}
