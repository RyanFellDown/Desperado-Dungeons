using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialougeTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    public void StartDialouge()
    {
        FindObjectOfType<DialougeManager>().OpenDialouge(messages, actors);
    }
}

[System.Serializable]
public class Message
{
    public int actorId;
    public string message;
}


[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}
