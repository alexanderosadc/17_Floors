using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canControl = true;

	void Start ()
    {
		
	}

    public bool CanControl
    {
        get
        {
            return canControl;
        }
    }

    public void DisableControl()
    {
        canControl = false;
    }

    public void EnableControl()
    {
        canControl = true;
    }
}
