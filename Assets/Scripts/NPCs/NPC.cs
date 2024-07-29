using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] NPCharacter character;
    [SerializeField] List<GameObject> objectiveGameObjects;
    bool objectiveComplete = false;
    public bool initialTalk = false;
    public string firstDialogue;
    public string secondDialogue;
    public string iconPath;

    void Start() {
        if(initialTalk) {
            StartCoroutine(InitialTalk());
        }
    }

    private void OnTriggerEnter(Collider col) {
        if(col.transform.tag == "Player") {
            ActiveNPC._instance.SetActiveNPC(this);
            UIManager._instance.TogglePromptInteractiveNPC();
        }
    }

    private void OnTriggerExit(Collider col) {
        if(col.transform.tag == "Player") {
            UIManager._instance.TogglePromptInteractiveNPC(closing: true);
            ActiveNPC._instance.UnsetActiveNPC();
            PlayerMovement._instance.ToggleTalking(false);
        }
    }

    private void OnTriggerStay(Collider col) {
        if(col.transform.tag == "Player") {
            if(Input.GetKeyUp(KeyCode.E) && !UIManager._instance.DialogueActive) {
                if(objectiveGameObjects.Count > 0) {
                    foreach(GameObject obj in objectiveGameObjects) {
                        var objective = obj.GetComponent<IObjective>();
                        if(objective.GetStatus && !objectiveComplete) {
                            objectiveComplete = true;
                            string characterToUpdate = character.ToString() + "_COMPLETE";
                            PlayerMovement._instance.ToggleTalking(true);
                            // int updatedChar = (int)System.Enum.Parse(typeof(NPCharacter), characterToUpdate);
                            UIManager._instance.ToggleDialogueInteractive(active: true, textToDisplay: ActiveNPC._instance.active.secondDialogue, imageToDisplay: ActiveNPC._instance.active.iconPath);
                        } else {
                            PlayerMovement._instance.ToggleTalking(true);
                            UIManager._instance.ToggleDialogueInteractive(active: true, textToDisplay: ActiveNPC._instance.active.firstDialogue, imageToDisplay: ActiveNPC._instance.active.iconPath);
                        }
                    }
                } else {
                    PlayerMovement._instance.ToggleTalking(true);
                    UIManager._instance.ToggleDialogueInteractive(active: true, textToDisplay: ActiveNPC._instance.active.firstDialogue, imageToDisplay: ActiveNPC._instance.active.iconPath);
                }
            }
        }
    }

    private IEnumerator InitialTalk() {
        yield return new WaitForSeconds(0.5f);
        PlayerMovement._instance.ToggleTalking(true);
        UIManager._instance.ToggleDialogueInteractive(active: true, textToDisplay: firstDialogue, imageToDisplay: iconPath);
    }
}

public enum NPCharacter {
    KING_MARCUS                 = 0,
    INFRASTRUCTURE              = 1,
    BUILD_AND_DEPLOY            = 2,
    DDCOPS                      = 3,
    PLATDOCS                    = 4,
    PLATOPS                     = 5,
    PLATSEC                     = 6,
    PLATUCD                     = 7,
    PLATUI                      = 8,
    TELEMETRY                   = 9,
    KING_MARCUS_FINAL           = 10,
    ENGINEER_INFRA              = 11,
    ENGINEER_B_AND_D            = 12,
    ENGINEER_DDCOPS             = 13,
    ENGINEER_PLATDOCS           = 14,
    ENGINEER_PLATOPS            = 15,
    ENGINEER_PLATSEC            = 16,
    ENGINEER_PLATUCD            = 17,
    ENGINEER_PLATUI             = 18,
    ENGINEER_TELEMETRY          = 19,
    INFRASTRUCTURE_COMPLETE     = 20,
    BUILD_AND_DEPLOY_COMPLETE   = 21,
    DDCOPS_COMPLETE             = 22,
    PLATDOCS_COMPLETE           = 23,
    PLATOPS_COMPLETE            = 24,
    PLATSEC_COMPLETE            = 25,
    PLATUCD_COMPLETE            = 26,
    PLATUI_COMPLETE             = 27,
    TELEMETRY_COMPLETE          = 28,
}
