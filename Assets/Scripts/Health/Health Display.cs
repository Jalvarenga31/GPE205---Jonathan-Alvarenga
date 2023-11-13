using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Health health;
    void Start()
    {
        
    }

    void Update()
    {
        health.HealthDisplayed();
        health.LifeDisplayed();
        
    }
}
