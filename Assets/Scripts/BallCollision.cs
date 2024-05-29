using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallCollision : MonoBehaviour
{
    int bounce_num=0;
    
    public ScoreManager scoreManager;
    int last_bounce_court=0;
    bool hit=false;


    private XRGrabInteractable grabInteractable;
    private bool grabbed = false;
    
    public AudioSource source;
    public AudioClip moveBackwards;

    void Start() {
        grabInteractable = GetComponent<XRGrabInteractable>();
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
        }//
        if (hit){    
            if ((collision.gameObject.CompareTag("in2")) ||(collision.gameObject.CompareTag("in2"))){
                bounce_num++;//bounce num in court
                if (collision.gameObject.CompareTag("in2")){
                    last_bounce_court=2;
                }else{
                    last_bounce_court=1;
                }
            }
            else
            {//out of bound
                if (collision.gameObject.CompareTag("out1"))
                {
                    scoreManager.AddPointToPlayer1();
                    ResetBounce();
                }
                else if (collision.gameObject.CompareTag("out2"))
                {
                    scoreManager.AddPointToPlayer2();
                    ResetBounce();
                }
            }
            if (bounce_num>1){//assume first ball was in and not player hitting their own court
                if (last_bounce_court==1){
                    scoreManager.AddPointToPlayer2();
                    ResetBounce();
                }else{
                    scoreManager.AddPointToPlayer1();
                    ResetBounce();
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
}
