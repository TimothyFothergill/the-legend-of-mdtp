using UnityEngine;

public class ColliderInteractable : MonoBehaviour, IObjective {

    [SerializeField] GameObject objective;
    bool completed = false;

    public bool GetStatus => completed;

    private void OnTriggerEnter(Collider col) {
        if(col.gameObject == objective) {
            completed = true;
        }
    }

}
