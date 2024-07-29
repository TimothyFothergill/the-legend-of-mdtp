using UnityEngine;

public class Elevator : MonoBehaviour
{

    Animator animator;
    Camera cam;
    Camera elevatorCam;
    Vector3 camInitialPosition;
    Quaternion camInitialRotation;

    void Start()
    {
        animator = GetComponent<Animator>();
        elevatorCam = transform.GetChild(2).GetComponent<Camera>();
        elevatorCam.enabled = false;
    }

    void Update()
    {
        // use normalizedTime here, as this is a float that represents whether the animation has completed
        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) {
            animator.SetBool("ElevatorGoingUp", !animator.GetBool("ElevatorGoingUp"));
        }
    }

    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player") {
            col.transform.parent = transform;
            cam = col.transform.GetChild(5).GetComponent<Camera>();
            cam.enabled = false;
            elevatorCam.enabled = true;
        }
    }

    private void OnTriggerExit(Collider col) {
        if(col.gameObject.tag == "Player") {
            col.transform.parent = null;
            cam.enabled = true;
            elevatorCam.enabled = false;
        }
    }
}
