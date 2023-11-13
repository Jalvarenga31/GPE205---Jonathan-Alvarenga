using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTransition : MonoBehaviour
{
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            gameManager.ActivateTitleScreen();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameManager.ActivateMainMenu();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameManager.ActivateOptions();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameManager.ActivateCredits();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            gameManager.ActivateGameOver();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            gameManager.ActivateGamePlay();
        }
    }
}
