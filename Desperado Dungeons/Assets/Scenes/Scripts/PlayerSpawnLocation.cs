using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnLocation : MonoBehaviour
{
    private Playable_Character_Script player;
    private CameraController newCamera;

    private void Start()
    {
        player = FindObjectOfType<Playable_Character_Script>();
        player.transform.position = transform.position;

        newCamera = FindObjectOfType<CameraController>();
        newCamera.transform.position = new Vector3(transform.position.x, transform.position.y, newCamera.transform.position.z);
    }

    private void Update()
    {
        
    }
}
