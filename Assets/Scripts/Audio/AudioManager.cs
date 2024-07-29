using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager _instance {get; private set;}

    public AudioClip gameMusic;
    public AudioClip creditsMusic;
    public AudioClip resetSound;
    public AudioClip dramaticSound;
    public AudioClip fanfareSound;
    public AudioClip doorSound;
    bool isMute = false;
    AudioSource source;

    void Awake() {
        if(_instance != null && _instance != this) {Destroy(this);}else{_instance = this;}
    }

    void Start() {
        source = GetComponent<AudioSource>();
    }

    void Update() {
        if(Input.GetKeyUp(KeyCode.M)) {
            if(isMute) {
                source.volume = 1;
                isMute = false;
            } else {
                source.volume = 0;
                isMute = true;
            }
        }
        if(!source.clip != gameMusic) {
            if(source.clip == doorSound) {
                StartCoroutine(WaitSecondsAndPlay(2));
            }
            if(source.clip == resetSound) {
                StartCoroutine(WaitSecondsAndPlay(2));
            }
            if(source.clip == fanfareSound) {
                StartCoroutine(WaitSecondsAndPlay(10));
            }
        }
    }

    IEnumerator WaitSecondsAndPlay(int i = 10) {
        yield return new WaitForSeconds(i);
        PlayGameMusic();
        source.Play();
    }

    public void PlayGameCredits()   => source.clip = creditsMusic;
    public void PlayResetSound()    => source.clip = resetSound;
    public void PlayDramaticSound() => source.clip = dramaticSound;
    public void PlayFanfareSound()  => source.clip = fanfareSound;
    public void PlayGameMusic()     => source.clip = gameMusic;
    public void PlayDoorOpenSound(AudioSource doorSource) => doorSource.Play();
    
}
