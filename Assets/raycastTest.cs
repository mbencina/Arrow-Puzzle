using UnityEngine;

public class raycastTest : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    public Transform Crosshair;
    public Transform Gun;

    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;

        if (Physics.Raycast(Gun.transform.position, -Gun.transform.right, out Hit))
        {

                Crosshair.transform.position = Hit.point;
                Debug.Log(Hit.transform.position);
                Debug.Log(Hit.transform.name);
                Debug.DrawRay(Gun.transform.position, -Gun.transform.right, Color.green);

        }

    }
}
