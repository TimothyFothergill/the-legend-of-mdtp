using UnityEngine;

public class ActiveNPC : MonoBehaviour
{
    public NPC active = null;

    public static ActiveNPC _instance {get; private set;}
    void Awake() {
        if(_instance != null && _instance != this) {Destroy(this);}else{_instance = this;}
    }

    public void SetActiveNPC(NPC npc) => active = npc;
    public void UnsetActiveNPC() => active = null;

}
