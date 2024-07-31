using UnityEngine;

public class Resettable : MonoBehaviour
{

    public GameObject objectToReset;
    Vector3 objectResetPosition;
    Vector3 playerLevel2Position;

    void Start()
    {
        objectResetPosition = objectToReset.transform.position;
        playerLevel2Position = new Vector3(22.7f, 0, 0);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider col) {
        if(col.gameObject == objectToReset) {
            if(col.gameObject.tag == "Player") {
                AudioManager._instance.PlayResetSound(transform.GetComponent<AudioSource>());
                objectToReset.transform.position = playerLevel2Position;
            } else {
                AudioManager._instance.PlayResetSound(transform.GetComponent<AudioSource>());
                objectToReset.transform.position = objectResetPosition;
            }
        }
    }
}
