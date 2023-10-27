using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class Spotted : MonoBehaviour
{
    public float ShowTime = 3f;

    void Start()
    {
        Destroy(gameObject, ShowTime);
    }


}
