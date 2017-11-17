using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool blocked = false;
    public GameObject openPanel = null;
    public KeyCode openButton = KeyCode.F;

    private Animator animator;
    private bool _isInsideTrigger = false;

    void Start ()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = true;
            openPanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = false;
            openPanel.SetActive(false);
        }
    }
    
    void Update()
    {
        if (_isInsideTrigger)
        {
            if (Input.GetKeyDown(openButton))
            {
                Toggle();
            }
        }
    }

    void Toggle ()
    {
        if (IsOpened())
            Close();
        else
            Open();
    }

    void Close ()
    {
        if (IsBlocked())
            BlockAlert();
        else
            animator.SetBool("opened", false);
    }

    void Open ()
    {
        if (IsBlocked())
            BlockAlert();
        else
            animator.SetBool("opened", true);
    }

    bool IsOpened ()
    {
        return animator.GetBool("opened");
    }

    bool IsBlocked ()
    {
        return blocked;
    }

    void BlockAlert ()
    {
        Debug.Log("Door is blocked");
    }
}