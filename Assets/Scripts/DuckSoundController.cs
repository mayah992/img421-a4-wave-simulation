using Unity.VisualScripting;
using UnityEngine;

public class DuckSoundController : MonoBehaviour
{
    public AudioSource Quack;
    public AudioSource Swim;
    private BoatController boat;

    void Start()
    {
        boat = GetComponentInParent<BoatController>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            PlayQuack();
        }

        if(boat.isMoving == true)
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