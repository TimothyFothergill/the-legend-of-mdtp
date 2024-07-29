using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement _instance {get; private set;}

    float speed = 1.5f;
    float runSpeed = 3.5f;
    Animator animator;
    bool isTalking;

    public bool isJumping = false;

    void Awake() {
        if(_instance != null && _instance != this) {Destroy(this);}else{_instance = this;}
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTalking) { return; }
        if(Input.GetAxisRaw("Horizontal") != 0) {
            animator.SetBool("isWalking", true);
            transform.Rotate(0,Input.GetAxisRaw("Horizontal") * 100 * Time.deltaTime,0,Space.World);
        }
        if(Input.GetAxisRaw("Vertical") != 0) {
            animator.SetBool("isWalking", true);
            if(Input.GetAxisRaw("Run") != 0) {
                transform.Translate(Input.GetAxisRaw("Vertical") * runSpeed * Time.deltaTime * transform.forward,Space.World);
            } else {
                transform.Translate(Input.GetAxisRaw("Vertical") * speed * Time.deltaTime * transform.forward,Space.World);
            }
        }
        if(Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0) {
            animator.SetBool("isWalking", false);
            transform.Rotate(0,0,0,Space.World);
        }
        if(Input.GetAxisRaw("Jump") != 0 && !isJumping) {
            Debug.Log("Jumping");
            isJumping = true;
            transform.GetComponent<Rigidbody>().AddForce(Input.GetAxisRaw("Jump") * 400 * Time.deltaTime * transform.up, ForceMode.Impulse);
        }
        
    }

    public void ToggleTalking(bool talking) => isTalking = talking;
    public bool talking => isTalking;
}
