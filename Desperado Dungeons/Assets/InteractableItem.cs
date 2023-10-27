using Unity.Burst.CompilerServices;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{

    //Currently working on interactable from E02, once done can move onto item pickup
    //and then move onto inventory UI stuff

    public float radius = 3f; //distance player needs to be from item to pickup


    void Update()
    {
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
