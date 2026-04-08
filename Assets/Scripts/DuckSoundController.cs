using Unity.VisualScripting;
using UnityEngine;

public class DuckSoundController : MonoBehaviour
{
    public AudioSource Quack;
    public AudioSource Swim;
    private GameObject Duck;

    void Start()
    {
        Duck = this.transform.parent.GameObject();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            PlayQuack();
        }
        
        Rigidbody duckRigidBody = Duck.GetComponent<Rigidbody>();
        Vector3 force = duckRigidBody.GetAccumulatedForce();
        Vector3 torque = duckRigidBody.GetAccumulatedTorque();

        if(!force.Equals(0) && !torque.Equals(0))
        {
            PlaySwim();
        }
        else
        {
            StopSwim();
        }
    }
  
    public void PlayQuack()
    {
        if (!Quack.isPlaying)
        {
            Quack.Play();
        }
    }
    
    public void PlaySwim()
    {
        if (!Swim.isPlaying)
        {
            Swim.Play();
        }
    }
    public void StopSwim()
    {
        if (Swim.isPlaying)
        {
            Swim.Stop();
        }
    }
}