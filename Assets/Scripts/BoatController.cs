using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoatController : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float thrustForce = 10f;
    public float turnTorque = 10f;
    public float maxSpeed = 12f;

    public bool isMoving = false;

    public AppleCounter appleCounter;

    public AudioSource appleFound;

    void Start()
    {
        // find reference to apple counter game object
        GameObject applecounterGO = GameObject.Find("AppleCounter");
        // get the text component
        appleCounter = applecounterGO.GetComponent<AppleCounter>();
    }

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

        if(v != 0 || h != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // find out what the duck collided with
        GameObject collidedWith = collision.gameObject;
        if ( collidedWith.CompareTag("Apple"))
        {
            // Identify which child collider was hit
            ContactPoint contact = collision.contacts[0];
            Collider childCollider = contact.thisCollider;
            
            Debug.Log(childCollider.name + " hit " + contact.otherCollider.name);

            // make sound
            appleFound.Play();

            // destroy apples collected
            Destroy(collidedWith);

            // updates apples left
            appleCounter.applesLeft -= 1;

            

        }
    }
}
