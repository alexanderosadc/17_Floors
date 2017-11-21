using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool acting = false;

	void Start ()
    {
		
	}

    public bool isActing
    {
        get
        {
            return acting;
        }
    }
}
