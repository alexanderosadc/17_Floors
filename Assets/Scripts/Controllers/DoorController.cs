using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool blocked = false;

    Animator animator;

    void Start ()
    {
        animator = GetComponent<Animator>();
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            toggle();
        }
    }

    void toggle ()
    {
        if (isOpened())
            close();
        else
            open();
    }

    void close()
    {
        if (isBlocked())
            Debug.Log("Door is blocked");
        else
            animator.SetBool("opened", false);
    }

    void open()
    {
        if (isBlocked())
            Debug.Log("Door is blocked");
        else
            animator.SetBool("opened", true);
    }

    bool isOpened()
    {
        return animator.GetBool("opened");
    }

    bool isBlocked()
    {
        return blocked;
    }
}
