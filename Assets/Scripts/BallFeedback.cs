using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFeedback : MonoBehaviour
{
    public AudioSource source;
    public AudioClip fx_floor,fx_swing,fx_racket,fx_net;

    public float speedThreshold = 5.0f;//plays sound only if speed reaches threshold
    private bool isBallReleased = false;

    public Rigidbody racketRb;
    private Rigidbody ballRb;
    private float cooldownTime = 0.5f;
    private float nextPlayTime = 0f;
    private float yPositionThreshold = 0.0f;
    private bool isRacketGrabbed=false;
    private bool inAir=true;
    //should only play fx_floor if ball bounces into air. if enter new collider and just rolling
    //no sound should play
    //realized this does not matter as we want ball to respawn after point is added

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        //FX_SWING NOT WORKING
        if (racketRb.velocity.magnitude > speedThreshold && !source.isPlaying&& isRacketGrabbed){
            source.clip=fx_swing;
            source.Play();//play swing sound
        }
        
        if (transform.position.y > yPositionThreshold)
        {
            inAir = true;
        }

    }
    void OnCollisionEnter(Collision collision){

        //FX_FLOOR
        if ((collision.gameObject.CompareTag("in1")||
        (collision.gameObject.CompareTag("in2")||
        (collision.gameObject.CompareTag("out1"))||
        (collision.gameObject.CompareTag("out2"))))
        &&Time.time >= nextPlayTime
        &&inAir==true
        ){
            source.clip=fx_floor;
            source.Play();
            nextPlayTime = Time.time + cooldownTime;
            inAir = false;
        
        }
        //FX_RACKET
        if (collision.gameObject.CompareTag("racket")){
            source.clip=fx_racket;
            source.Play();
        }
        //FX_NET
        if (collision.gameObject.CompareTag("net")){
            source.clip=fx_net;
            source.Play();
        }

        
    }
    public void StopFxFloor()
    {
        if (source.clip == fx_floor && source.isPlaying)
        {
            source.Stop();
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        // Check if the racket is grabbed
        if (other.CompareTag("racket"))
        {
            isRacketGrabbed = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        // Check if the racket is released
        if (other.CompareTag("racket"))
        {
            isRacketGrabbed = false;
        }
    }
}
