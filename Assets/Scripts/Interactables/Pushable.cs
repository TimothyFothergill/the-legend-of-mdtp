using UnityEngine;

public class Pushable : MonoBehaviour
{
    public float pushForce = 5f; // The force applied to the object
    public float rayDistance = 2f; // The distance of the raycast
    private bool isPlayerInRange = false; // To check if the player is in range
    private Transform player; // To store the player transform

    void Update()
    {
        // Check if the player is in range and presses the "E" key
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Push();
        }
    }

    private void Push()
    {
        // Calculate the push direction
        Vector3 pushDirection = (transform.position - player.position).normalized;
        pushDirection.y = 0; // Ensure the push direction is horizontal

        // Get the Rigidbody component
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Apply force to the object in the calculated direction
            rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }

    // For visualization in the Unity Editor
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * rayDistance;
        Gizmos.DrawRay(transform.position, forward);
    }

    void OnTriggerEnter(Collider col) {
        if(col.transform.tag == "Player") {
            UIManager._instance.TogglePromptInteractiveInteractable();
            isPlayerInRange = true;
            player = col.transform;
        }
    }

    void OnTriggerExit(Collider col) {
        if(col.transform.tag == "Player") {
            UIManager._instance.TogglePromptInteractiveInteractable();
            isPlayerInRange = false;
            player = col.transform;
        }
    }

    void OnTriggerStay(Collider col) {
        if(col.transform.tag == "Player") {
            if(Input.GetKeyUp(KeyCode.E)) {
                
            }
        }
    }

}
