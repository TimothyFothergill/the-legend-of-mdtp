using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed = 1.0f;
    private Vector3 startPosition;
    private bool movingToTarget = true;
    private float journeyLength;
    private float startTime;

    void Start()
    {
        startPosition = transform.localPosition;
        journeyLength = Vector3.Distance(startPosition, targetPosition);
        startTime = Time.time;
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;

        if (movingToTarget)
        {
            transform.localPosition = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(targetPosition, startPosition, fractionOfJourney);
        }

        if (fractionOfJourney >= 1.0f)
        {
            movingToTarget = !movingToTarget;
            startTime = Time.time;  // Resets the start time for the next journey
        }
    }

    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player") {
            col.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider col) {
        if(col.gameObject.tag == "Player") {
            col.transform.parent = null;
        }
    }
}