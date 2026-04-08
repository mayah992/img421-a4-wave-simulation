using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoatController : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float thrustForce = 10f;
    public float turnTorque = 10f;
    public float maxSpeed = 12f;

    void Awake()
    {
        if (!rigidbody) rigidbody = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        //Debug.Log("v = " + v + ", h = " + h);

        rigidbody.AddForce(transform.forward * v * thrustForce);
        rigidbody.AddTorque(Vector3.up * h * turnTorque);
    }
}
