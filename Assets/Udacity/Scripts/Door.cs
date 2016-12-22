using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
    // Create a boolean value called "locked" that can be checked in Update() 
    private bool locked;
    public Animation anim;

    void Start()
    {
        locked = true;
        anim = GetComponent<Animation>();
    }

    void Update() {
        // If the door is unlocked and it is not fully raised
        // Animate the door raising up
        if (!locked)
        {
            if (!anim.isPlaying) anim.Play();
            Destroy(gameObject);
        }
    }

    public void Unlock()
    {
        if (Key.hasKey && locked)
        {
            print("Opening door");
            locked = false;
        }
        else
            // You'll need to set "locked" to true here
            locked = true;
    }
}
