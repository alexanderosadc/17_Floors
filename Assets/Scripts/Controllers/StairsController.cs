using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsController : MonoBehaviour
{
    public int direction = -1;
    private int floor;

    private void Start()
    {
        floor = SceneController.GetCurrentFloor();

        floor += direction;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneController.GoTo("Floor_" + floor);

            PutPlayerNearStairs();
        }
    }

    void PutPlayerNearStairs ()
    {
        //
    }
}
