using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Racket : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public bool grabbed = false;
    //public TrajectoryLine trajectoryLine;

    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabInteractable == null) {
            Debug.LogError("Grab Interactable is not assigned to the racket object.");
        }
        if (grabInteractable.isSelected) { // User picks up the ball, then AI agent instructs them to move backwards
            if (!grabbed) {
                Debug.Log("Racket Grabbed");
                grabbed = true;
                //trajectoryLine.UpdateTrajectory();
            }
        } else {
            if (grabbed) {
                Debug.Log("Racket Released");
                grabbed = false;
            }
        }
    }
}
