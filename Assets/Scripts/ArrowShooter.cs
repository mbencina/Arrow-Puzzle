using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArrowShooter : MonoBehaviour
{
    public InputActionReference testReference = null;
    public int maxDist = 8;

    //private Vector3 direction = new Vector3(-1, 0, 0);
    private Vector3 initialPosition = new Vector3(0, 0, 0);
    private bool arrowFlying = false;

    //HELI
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
        if (arrowFlying) {
            bool resetArrow = false;
            //gameObject.transform.Translate(direction * 5.0f * Time.deltaTime);

            //HELI
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 5.0f);

            // Creting two Vectors to held count the rotation
            Vector3 vector1 = new Vector3(target.x, initialPosition.y, initialPosition.z);
            Vector3 vector2 = new Vector3(target.x, target.y, initialPosition.z);

            // Counting the rotation angle (degrees)
            float zRotation = Vector3.Angle(vector1, vector2);
            float yRotation = Vector3.Angle(vector2, target);

            // Checking if the sign of zRotation os correct 
            if (target.x < 0)
            {
                zRotation /= -1;
            }
            //Rotating the current arrow
            transform.Rotate(new Vector3(0, -1 * yRotation, (3 * zRotation) / 2), Space.Self);

            // Just for test purposes changing the sing of the x cordinate of target.
            target.x *= -1;
            //HELI

            float dist = Vector3.Distance(initialPosition, gameObject.transform.position);
            // Debug.Log(dist);
            if (dist > maxDist) {
                resetArrow = true;
            }
            
            // remove arrow that is too far
            if (resetArrow) {
                gameObject.transform.position = new Vector3(0, 0, 0); // this should be controller position
                arrowFlying = false;
            }
        }
        // Debug.Log("something"); //this works
    }
    // TODO when we will hit a piece we will respawn arrow but we will disable it;
    // when piece is placed we enable the arrow again
}
