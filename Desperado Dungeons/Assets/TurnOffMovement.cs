using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class TurnOffMovement : MonoBehaviour
{
    public void StopMoving()
    {
        GetComponent<AIPath>().enabled = false;
    }
}
