using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFeedback : MonoBehaviour
{
    public AudioSource source;
    public AudioClip fx_floor,fx_swing;

    public float speedThreshold = 5.0f;//plays sound only if speed reaches threshold
    private Rigidbody rb;
    private float cooldownTime = 0.5f;
    private float nextPlayTime = 0f;
    private float yPositionThreshold = -2.2f;
    private float yPositionTolerance = 0.2f;

    private bool inAir=true;//should only play fx_floor if ball bounces into air. if enter new collider and just rolling
    //no sound should play
    //realized this does not matter as we want ball to respawn after point is added
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > speedThreshold && !source.isPlaying){
            source.clip=fx_swing;
            source.Play();//play swing sound
        }
    }
    void OnCollisionEnter(Collision collision){
        if ((collision.gameObject.CompareTag("in1")||
        (collision.gameObject.CompareTag("in2")||
        (collision.gameObject.CompareTag("out1"))||
        (collision.gameObject.CompareTag("out2"))))
        &&Time.time >= nextPlayTime
        //&&inAir==true
        ){
            source.clip=fx_floor;
            source.Play();
            nextPlayTime = Time.time + cooldownTime;
            //inAir=false;
        }
        
    }
}
