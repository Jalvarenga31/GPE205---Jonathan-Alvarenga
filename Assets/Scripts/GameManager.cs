using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform playerSpawnTransform;

    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;

    public List<PlayerController> players;
    
    private void Start()
    {
        SpawnPlayer();
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
    }
}
