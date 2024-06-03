using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AIAgent2 : MonoBehaviour
{
    int bounce_num=0;
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
        if (hit){    
            if ((collision.gameObject.CompareTag("in2")) ||(collision.gameObject.CompareTag("in1"))){
                if (collision.gameObject.CompareTag("in2")){
                    Debug.Log("ball inside court lines");
                    source.clip = greatJob;
                    source.Play();
                }
            }
            else
            {//out of bound
                if (collision.gameObject.CompareTag("out1")||collision.gameObject.CompareTag("out2"))
                {
                    source.clip = ballHitsOutsideLine;
                    source.Play();
                }
            }
            if (bounce_num>1){//assume first ball was in and not player hitting their own court
                if (last_bounce_court==1){
                    source.clip = ballHitsBeforeNet;
                    source.Play();
                }
            }
        }
    }
}
