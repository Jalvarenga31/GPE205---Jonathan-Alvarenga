using UnityEngine;

public class StartMultiplayer : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        gameManager.MapGenerate();
        gameManager.Multiplayer();
    }

}
