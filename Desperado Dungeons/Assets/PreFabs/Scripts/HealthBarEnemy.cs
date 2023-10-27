using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Camera healthCamera;
    [SerializeField] private Transform target;
    //[SerializeField] private Vector3 correctPosition;


    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        healthCamera = FindAnyObjectByType<Camera>();
        transform.rotation = healthCamera.transform.rotation;
        target.position = target.position;
    }
}
