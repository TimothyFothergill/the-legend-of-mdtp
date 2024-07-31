using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager _instance {get; private set;}

    [SerializeField] GameObject prompter;
    [SerializeField] GameObject prompterInteractive;
    [SerializeField] Canvas dialogue;
    TextMeshProUGUI dialogueTextMeshProUGUI;
    Image dialogueImage;

    void Awake() {
        if(_instance != null && _instance != this) {Destroy(this);}else{_instance = this;}
        Debug.Log("UIManager initiated");
    }

    void Start()
    {
        prompter.gameObject.SetActive(false);
        prompterInteractive.gameObject.SetActive(false);
        dialogueImage           = dialogue.transform.GetChild(1).GetComponent<Image>();
        dialogueTextMeshProUGUI = dialogue.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        dialogue.gameObject.SetActive(false);
    }

    void Update() {
        if(dialogue.gameObject.activeSelf) {
            if(Input.GetKeyDown(KeyCode.E) && PlayerMovement._instance.talking) {
                ToggleDialogueInteractive(active: false);
                PlayerMovement._instance.ToggleTalking(false);
            }
        }
    }

    public void TogglePromptInteractiveNPC(bool closing = false) { 
        if(closing) {
            prompter.gameObject.SetActive(false);
        } else {
            prompter.gameObject.SetActive(!prompter.gameObject.activeSelf);
        }
    }

    public void TogglePromptInteractiveInteractable(bool closing = false) { 
        if(closing) {
            prompterInteractive.gameObject.SetActive(false);
        } else {
            prompterInteractive.gameObject.SetActive(!prompterInteractive.gameObject.activeSelf);
        }
    }
    
    public void ToggleDialogueInteractive(string textToDisplay = "", string imageToDisplay = "", bool active = false) {
        dialogue.gameObject.SetActive(active);
        if(active) {
            dialogue.gameObject.SetActive(true); dialogueTextMeshProUGUI.text=textToDisplay; dialogueImage.sprite = Resources.Load<Sprite>(imageToDisplay);
            // switch(dialogueSelection) {
            //     case 0  : dialogue.gameObject.SetActive(true); dialogueTextMeshProUGUI.text="Welcome to your new job in MDTP. Well, you've joined us at a bad time, I'm afraid. The teams are under attack! Help them! Your King, Marcus, decree-th it so."; dialogueImage.sprite = Resources.Load<Sprite>("DialogueImages/00"); break;
            //     case 1  : dialogue.gameObject.SetActive(true); dialogueTextMeshProUGUI.text="Hey, we're Infrastructure. We're trying to hold the fort down, but it's tricky. We're under a cyber attack! If only we had a strong firewall..."; dialogueImage.sprite = Resources.Load<Sprite>("DialogueImages/01"); break;
            //     case 2  : dialogue.gameObject.SetActive(true); dialogueTextMeshProUGUI.text="I heard what you did for Infrastructure, perhaps you can help us? Can you get Jenkins back in the container?"; dialogueImage.sprite = Resources.Load<Sprite>("DialogueImages/02"); break;
            //     case 10 : dialogue.gameObject.SetActive(true); dialogueTextMeshProUGUI.text="You've solved the puzzles in this very short demo. Congratulations, but who broke it all? Well it was I, King Marcus!! Muwahaha!"; dialogueImage.sprite = Resources.Load<Sprite>("DialogueImages/01"); AudioManager._instance.PlayDramaticSound(); break;
            //     case 11 : dialogue.gameObject.SetActive(true); dialogueTextMeshProUGUI.text="Hey I'd love to help with the firewall issue, but I'm PUSHING a change to fix these Blue Screens of Death. We don't even use Windows, how'd this happen?!"; dialogueImage.sprite = Resources.Load<Sprite>("DialogueImages/11"); break;
            //     case 20 : dialogue.gameObject.SetActive(true); dialogueTextMeshProUGUI.text="Wow, I didn't think a firewall was literally just a wall on fire! Great work. That's innovative thinking right there."; dialogueImage.sprite = Resources.Load<Sprite>("DialogueImages/00"); break;
            //     case 21 : dialogue.gameObject.SetActive(true); dialogueTextMeshProUGUI.text="Oh how the mighty Jenkins has fallen... Back into its Docker Container! Thanks, you've saved the day!"; dialogueImage.sprite = Resources.Load<Sprite>("DialogueImages/01"); break;
            //     default : dialogue.gameObject.SetActive(true); dialogueTextMeshProUGUI.text="Hey, Tim here. This is awkward. How did you get this dialogue..? Shoo!"; dialogueImage.sprite = Resources.Load<Sprite>("DialogueImages/00"); break;
            // }
        }
    }

    public bool DialogueActive => dialogue.gameObject.activeSelf;


}
