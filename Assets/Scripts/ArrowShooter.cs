using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArrowShooter : MonoBehaviour
{

    public GameObject LeftController;
    public GameObject RightController;
     
    // Reference to the crosshair object:
    public Transform Crosshair;

    public InputActionReference testReference = null;
    public int maxDist = 8;

    private Vector3 direction = new Vector3(-1, 0, 0);
    private Vector3 initialPosition = new Vector3(0, 0, 0);
    private bool arrowFlying = false;

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
        // A direction between the right controller and the crosshair:
        Vector3 dir = (Crosshair.localPosition-RightController.transform.position).normalized;
        // Angular difference between the arrow and the shooting direction:
        Quaternion q = Quaternion.FromToRotation(gameObject.transform.forward, dir);
        Debug.Log(q);
        Debug.Log("Rotation");

        // Get the x, y and angle differences:
        float xRot = gameObject.transform.rotation.eulerAngles.x + q.eulerAngles.x;
        float yRot = gameObject.transform.rotation.eulerAngles.y + q.eulerAngles.y + 90;
        float zRot = gameObject.transform.rotation.eulerAngles.z + q.eulerAngles.z;

        // Rotate the angle of arrow towards the crosshair:
        gameObject.transform.rotation = Quaternion.Euler(xRot,yRot,zRot);

        // flying arrows
        if (arrowFlying) {
            bool resetArrow = false;
            
            // Move arrow forward:
            gameObject.transform.Translate(-gameObject.transform.forward * 5f * Time.deltaTime);
            float dist = Vector3.Distance(initialPosition, gameObject.transform.position);
            
            Debug.Log("Shooting");
            Debug.Log(dir);
            Debug.Log(Crosshair.position);
            Debug.Log(RightController.transform.position);
            Debug.Log(dist);
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
