using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform playerSpawnTransform;
    public Transform enemySpawnTransform;
    public Transform powerUpSpawnTransform;
    public Transform enemySpawn2Transform;
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;
    public GameObject tankEnemyPrefab;
    public GameObject tankEnemy2Prefab;
    public GameObject powerUpPrefab;

    public List<PlayerController> players;
    
    
    private void Start()
    {
        //SpawnPlayer();
        //SpawnEnemyAI();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnPlayer()
    {
        // Spawn the Player Controller at (0,0,0) with no rotation
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        // Spawn the Pawn and connect it to the Controller
        GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;

        // Get the Player Controller component and Pawn component. 
        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newPawnObj.AddComponent<NoiseMaker>();
        newPawn.noiseMaker = newPawnObj.GetComponent<NoiseMaker>();
        newPawn.noiseMakerVolume = 3;
        newController.pawn = newPawn;

        newPawnObj.AddComponent<PowerupManager>();
    }

    public void SpawnEnemyAI()
    {
        GameObject newEnemy1Obj = Instantiate(tankEnemyPrefab, enemySpawnTransform.position, enemySpawnTransform.rotation) as GameObject;
        GameObject newEnemy2Obj = Instantiate(tankEnemy2Prefab, enemySpawn2Transform.position, enemySpawn2Transform.rotation) as GameObject;
    }

    public void SpawnPowerup()
    {
        GameObject newPowerupObj = Instantiate(powerUpPrefab, powerUpSpawnTransform.position, powerUpSpawnTransform.rotation) as GameObject;
    }

}
