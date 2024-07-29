using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] ColliderInteractable objective;
    Collider trigger;

    bool isFinished = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        trigger = transform.GetComponent<BoxCollider>();
        if(trigger != null) {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(objective == null) { return; }
        if(objective.GetStatus && !isFinished) {
            AudioManager._instance.PlayDoorOpenSound(transform.GetComponent<AudioSource>());
            isFinished = true;
            Destroy(transform.GetChild(0).gameObject);
            Destroy(transform.GetChild(1).gameObject);
        }
    }

    private void OnTriggerEnter(Collider col) {
        if(col.transform.tag == "Player") {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
