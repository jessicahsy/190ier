using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int segmentCount = 20; // Number of segments in the line
    public float segmentScale = 0.5f; // Distance between segments
    public Transform racketTrans;
    public float speed = 2f; // Estimated speed for the trajectory calculation
    private int frameCounter = 0;

    private Racket racketObj;
    // private racket = GameObject.Find("tennis_bat1");
    // private bool isPreviewActive = false; // Changed default to false
    // private bool isRacketHeld = false;

    private void Start()
    {
        // racketTrans = racket.transform; // Replace "Racket" with the name of your racket object
        racketTrans = GameObject.Find("tennis_bat1").transform;
        racketObj = GameObject.Find("tennis_bat1").GetComponent<Racket>();
        lineRenderer = GetComponent<LineRenderer>();
        if (racketTrans == null)
        {
            Debug.LogError("Racket transform is not assigned.");
        }
    }

    private void Update()
    {

        frameCounter++;

        if (racketTrans != null && frameCounter % 10 == 0 && racketObj.grabInteractable.isSelected)
        {
            UpdateTrajectory();
        }
        else if (racketTrans == null || !racketObj.grabInteractable.isSelected)
        {
            lineRenderer.positionCount = 0; // Hide the line if conditions are not met
        }
    }

    public void UpdateTrajectory()
    {
        // racket = GameObject.Find("tennis_bat1").transform; // Replace "Racket" with the name of your racket object

        Vector3[] segments = new Vector3[2]; // Only need 2 points for a line
        Vector3 direction = racketTrans.TransformDirection(Vector3.forward);
        direction.y = 0; // Remove the y component to keep the trajectory flat

        float lineLength = 20f; // Set this to the desired length of the line

        segments[0] = racketTrans.position - direction * lineLength; // Start point
        segments[0].y = 0;

        segments[1] = racketTrans.position + direction * lineLength; // End point
        segments[1].y = 0;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(segments);
    }

    // public void HideTrajectory()
    // {
    //     isPreviewActive = false;
    //     lineRenderer.positionCount = 0;
    // }

    // public void ShowTrajectory()
    // {
    //     if (isRacketHeld) // Only show trajectory if racket is held
    //     {
    //         isPreviewActive = true;
    //     }
    // }

    // public void SetRacketHeld(bool held)
    // {
    //     isRacketHeld = held;
    //     if (!held)
    //     {
    //         HideTrajectory(); // Hide trajectory if racket is released
    //     }
    // }
}
