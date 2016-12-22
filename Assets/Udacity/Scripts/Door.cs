using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
    // Create a boolean value called "locked" that can be checked in Update() 
    private bool locked;
    private Animator animator;
    private Animation anim;
    private AudioSource audioSource;
    public AudioClip DoorLocked;
    public AudioClip DoorUnlocked;

    void Start()
    {
        locked = true;
        animator = GetComponent<Animator>();
        anim = GetComponent<Animation>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update() {
        // If the door is unlocked and it is not fully raised
        // Animate the door raising up
        if (!locked)
        {
            StartCoroutine(WaitForAnimation());
        }
    }

    private IEnumerator WaitForAnimation()
    {
        do{yield return null;} while (audioSource.isPlaying);
        Destroy(gameObject);
    }

    public void Unlock()
    {
        if (Key.hasKey && locked)
        {
            print("Opening door");
            locked = false;
            audioSource.clip = DoorUnlocked;
            audioSource.Play();
            animator.SetBool("OpenDoor", true);
        }
        else
        {
            // You'll need to set "locked" to true here
            locked = true;
            audioSource.clip = DoorLocked;
            audioSource.Play();
        }
    }
}
