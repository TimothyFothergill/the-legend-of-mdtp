using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    private void OnTriggerEnter() {
        PlayerMovement._instance.isJumping = false;
    }

    private void OnTriggerExit() {
        PlayerMovement._instance.isJumping = true;
    }

}
