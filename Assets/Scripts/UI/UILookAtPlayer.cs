using UnityEngine;

public class UILookAtPlayer : MonoBehaviour
{

    Camera cam;

    void Start() {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        if(cam.isActiveAndEnabled) {
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        }
    }
}
