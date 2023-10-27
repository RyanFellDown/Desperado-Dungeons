using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{

    [SerializeField]
    private GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(character, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
