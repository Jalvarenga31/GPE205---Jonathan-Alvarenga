using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankSpawner : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        gameManager.SpawnEnemyAI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
