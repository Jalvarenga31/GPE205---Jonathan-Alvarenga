using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform playerSpawnTransform;
    public Transform playerSpawn2Transform;
    public Transform powerUpSpawnTransform;
    public GameObject playerControllerPrefab;
    public GameObject playerController2Prefab;
    public GameObject AIControllerPrefab;
    public GameObject tankPawnPrefab;
    public GameObject tankPawn2Prefab;
    public GameObject tankPawn1Prefab;
    public GameObject powerUpPrefab;
    public GameObject enemyTankPawnPrefab;
    public GameObject AIGaurdControllerPrefab;
    public GameObject cameraPlayer1;
    public GameObject cameraPlayer2;
    public float AmountOfLives;

    public pawnSpawnPoint[] spawnPoints;
    public GaurdSpawnPoint[] spawnPoints2;
    public PlayerSpawnpoints[] spawnPoints3;
    public List<PlayerController> players;

    public MapGenerator mapGenerator;
    private int Rows;
    private int Columns;

    public GameObject TitleScreenStateObject;
    public GameObject MainMenuStateObject;
    public GameObject OptionsStateObject;
    public GameObject CreditsStateObject;
    public GameObject GamePlayStateObject;
    public GameObject GameOverStateObject;
    public GameObject MenuMusicStateObject;
    public GameObject GameMusicStateObject;


    private void Start()
    {
        DeactivateAllStates();
        ActivateTitleScreen();
        ActivateMenuMusic();

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

    public void MapGenerate()
    {
        mapGenerator = GetComponent<MapGenerator>();
        mapGenerator.GenerateMap();
        Rows = mapGenerator.cols;
        Columns = mapGenerator.rows;

        spawnPoints = FindObjectsOfType<pawnSpawnPoint>();
        foreach (pawnSpawnPoint p in spawnPoints)
        {
            Debug.Log(p.gameObject.name);
        }

        spawnPoints2 = FindObjectsOfType<GaurdSpawnPoint>();
        foreach (GaurdSpawnPoint p in spawnPoints2)
        {
            Debug.Log(p.gameObject.name);
        }

        spawnPoints3 = FindObjectsOfType<PlayerSpawnpoints>();
        foreach (PlayerSpawnpoints p in spawnPoints3)
        {
            Debug.Log(p.gameObject.name);
        }


        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                SpawnEnemyPatrolAI(spawnPoints[Random.Range(0, spawnPoints.Length)]);
                SpawnGaurdEnemy(spawnPoints2[Random.Range(0, spawnPoints2.Length)]);
            }
        }

    }

    public void SinglePlayer()
    {
        SpawnPlayer(spawnPoints3[Random.Range(0, spawnPoints3.Length)]);
    }

    public void Multiplayer()
    {
        SpawnPlayerOne(spawnPoints3[Random.Range(0, spawnPoints3.Length)]);
        SpawnPlayerTwo(spawnPoints3[Random.Range(0, spawnPoints3.Length)]);
    }


    public void SpawnPlayer(PlayerSpawnpoints spawnpoint)
    {

        // Spawn the Player Controller at (0,0,0) with no rotation
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        // Spawn the Pawn and connect it to the Controller
        GameObject newPawnObj = Instantiate(tankPawnPrefab, spawnpoint.transform.position, spawnpoint.transform.rotation) as GameObject;

        // Get the Player Controller component and Pawn component. 
        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newPawnObj.AddComponent<NoiseMaker>();
        newPawn.noiseMaker = newPawnObj.GetComponent<NoiseMaker>();
        newPawn.noiseMakerVolume = 3;
        newController.pawn = newPawn;

        newPawnObj.AddComponent<PowerupManager>();

        newController.pawn = newPawn;
        newPawn.controller = newController;



    }

    public void SpawnPlayerOne(PlayerSpawnpoints spawnpoint)
    {
        // Spawn the Player Controller at (0,0,0) with no rotation
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        // Spawn the Pawn and connect it to the Controller
        GameObject newPawnObj = Instantiate(tankPawn1Prefab, spawnpoint.transform.position, spawnpoint.transform.rotation) as GameObject;

        // Get the Player Controller component and Pawn component. 
        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newPawnObj.AddComponent<NoiseMaker>();
        newPawn.noiseMaker = newPawnObj.GetComponent<NoiseMaker>();
        newPawn.noiseMakerVolume = 3;
        newController.pawn = newPawn;

        newPawnObj.AddComponent<PowerupManager>();

        newController.pawn = newPawn;
        newPawn.controller = newController;

    }

    public void SpawnPlayerTwo(PlayerSpawnpoints spawnpoint)
    {
        // Spawn the Player Controller at (0,0,0) with no rotation
        GameObject newPlayerObj = Instantiate(playerController2Prefab, Vector3.zero, Quaternion.identity) as GameObject;

        // Spawn the Pawn and connect it to the Controller
        GameObject newPawnObj = Instantiate(tankPawn2Prefab, spawnpoint.transform.position, spawnpoint.transform.rotation) as GameObject;

        // Get the Player Controller component and Pawn component. 
        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newPawnObj.AddComponent<NoiseMaker>();
        newPawn.noiseMaker = newPawnObj.GetComponent<NoiseMaker>();
        newPawn.noiseMakerVolume = 3;
        newController.pawn = newPawn;

        newPawnObj.AddComponent<PowerupManager>();

        newController.pawn = newPawn;
        newPawn.controller = newController;

    }

    public void SpawnGaurdEnemy(GaurdSpawnPoint spawnPoint)
    {
        GameObject newEnemy1Obj = Instantiate(AIGaurdControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        GameObject newEnemy2Obj = Instantiate(enemyTankPawnPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;

        Controller newController = newEnemy1Obj.GetComponent<Controller>();
        Pawn newPawn = newEnemy2Obj.GetComponent<Pawn>();

        newEnemy1Obj.AddComponent<PowerupManager>();
        newController.pawn = newPawn;
    }

    public void SpawnEnemyPatrolAI(pawnSpawnPoint spawnPoint)
    {
        GameObject newEnemy1Obj = Instantiate(AIControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        GameObject newEnemy2Obj = Instantiate(enemyTankPawnPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;

        Controller newController = newEnemy1Obj.GetComponent<Controller>();
        Pawn newPawn = newEnemy2Obj.GetComponent<Pawn>();

        newEnemy1Obj.AddComponent<PowerupManager>();
        newController.pawn = newPawn;

        newEnemy1Obj.GetComponent<AIController>().waypoints[0] = spawnPoint.transform;
        newEnemy1Obj.GetComponent<AIController>().waypoints[1] = spawnPoint.nextWaypoint.transform;
        newEnemy1Obj.GetComponent<AIController>().waypoints[2] = spawnPoint.nextWaypoint.nextWaypoint.transform;
        newEnemy1Obj.GetComponent<AIController>().waypoints[3] = spawnPoint.nextWaypoint.nextWaypoint.nextWaypoint.transform;
    }

    public void SpawnPowerup()
    {
        GameObject newPowerupObj = Instantiate(powerUpPrefab, powerUpSpawnTransform.position, powerUpSpawnTransform.rotation) as GameObject;
    }

    public void DeactivateAllStates()
    {
        TitleScreenStateObject.SetActive(false);
        MainMenuStateObject.SetActive(false);
        OptionsStateObject.SetActive(false);
        CreditsStateObject.SetActive(false);
        GamePlayStateObject.SetActive(false);
        GameOverStateObject.SetActive(false);
        GameMusicStateObject.SetActive(false);
    }

    public void ActivateTitleScreen()
    {
        DeactivateAllStates();
        TitleScreenStateObject.SetActive(true);
    }
    public void ActivateMainMenu()
    {
        DeactivateAllStates();
        MainMenuStateObject.SetActive(true);
    }
    public void ActivateOptions()
    {
        DeactivateAllStates();
        OptionsStateObject.SetActive(true);
    }
    public void ActivateCredits()
    {
        DeactivateAllStates();
        CreditsStateObject.SetActive(true);
    }
    public void ActivateGamePlay()
    {
        DeactivateAllStates();
        GamePlayStateObject.SetActive(true);
    }
    public void ActivateGameOver()
    {
        DeactivateAllStates();
        GameOverStateObject.SetActive(true);
    }

    public void ActivateMenuMusic()
    {
        MenuMusicStateObject.SetActive(true);
    }

    public void ActivateGameMusic()
    {
        DeactivateAllStates();
        MenuMusicStateObject.SetActive(false);
        GameMusicStateObject.SetActive(true);
    }
    public void Respawn(Controller Tank)
    {
        if (Tank.pawn != null && Tank.pawn.CurrentLives > 0)
        {
            Transform spawnTransform = Tank.pawn.GetComponent<GameObject>().transform;

            spawnTransform = playerSpawnTransform.transform;

            Tank.transform.position = Vector3.zero;
            Tank.transform.rotation = Quaternion.identity;


        }
    }
}


