using Unity.VisualScripting;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    bool hasPlayed = false;
    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player" && !hasPlayed) {
            hasPlayed = true;
            AudioManager._instance.PlayFanfareSound(transform.GetComponent<AudioSource>());
        }
    }
}
