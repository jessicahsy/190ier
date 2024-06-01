using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallCollision : MonoBehaviour
{
    int bounce_num=0;
    public float hitForce = 2f;
    private Vector3 initialPosition;
    
    public ScoreManager scoreManager;
    int last_bounce_court=0;
    bool hit=false;


    private XRGrabInteractable grabInteractable;
    private bool grabbed = false;
    
    public AudioSource source;
    public AudioClip moveBackwards, greatJob, ballHitsBeforeNet, ballHitsOutsideLine;

    private Rigidbody ballRigidbody;

    void Start() {
        grabInteractable = GetComponent<XRGrabInteractable>();
        ballRigidbody = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    void Update() {
        if (grabInteractable.isSelected) { // User picks up the ball, then AI agent instructs them to move backwards
            if (!grabbed) {
                Debug.Log("Grabbed");
                source.clip = moveBackwards;
                source.Play();
                grabbed = true;
            }
        } else {
            if (grabbed) {
                Debug.Log("Released");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // tags for areas
        // out1 for P2 hit P1 court out of bounds
        // out2 for P1 hit P2 court out of bounds
        // in2 for P1 hit P2 court first bounce in
        // in1 for P2 hit P1 court first bounce in
        if (collision.gameObject.CompareTag("racket")){
            hit=true;
            Vector3 hitDirection = collision.contacts[0].point - transform.position;
            hitDirection = hitDirection.normalized;
            ballRigidbody.AddForce(hitDirection * hitForce, ForceMode.Impulse);
            Debug.Log("Ball hit with force: " + hitForce);
        }//
        if (hit){    
            if ((collision.gameObject.CompareTag("in2")) ||(collision.gameObject.CompareTag("in1"))){
                bounce_num++;//bounce num in court
                if (collision.gameObject.CompareTag("in2")){
                    Debug.Log("ball inside court lines");
                    source.clip = greatJob;
                    source.Play();
                    last_bounce_court=2;
                }else{
                    last_bounce_court=1;
                }
            }
            else
            {//out of bound
                if (collision.gameObject.CompareTag("out1"))
                {
                    source.clip = ballHitsOutsideLine;
                    source.Play();
                    scoreManager.AddPointToPlayer1();
                    ResetBounce();
                    StartCoroutine(Respawn());
                }
                else if (collision.gameObject.CompareTag("out2"))
                {
                    source.clip = ballHitsOutsideLine;
                    source.Play();
                    scoreManager.AddPointToPlayer2();
                    ResetBounce();
                    StartCoroutine(Respawn());
                }
            }
            if (bounce_num>1){//assume first ball was in and not player hitting their own court
                if (last_bounce_court==1){
                    source.clip = ballHitsBeforeNet;
                    source.Play();
                    scoreManager.AddPointToPlayer2();
                    ResetBounce();
                    StartCoroutine(Respawn());
                }else{
                    scoreManager.AddPointToPlayer1();
                    ResetBounce();
                    StartCoroutine(Respawn());
                }
            }
        }

    }
    public void ResetBounce()
    {
        bounce_num = 0;
        hit=false;
        //sleep(3);
    }
    
    public IEnumerator Respawn() {
        yield return new WaitForSeconds(2);
        transform.position = initialPosition;

        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
    }
}
