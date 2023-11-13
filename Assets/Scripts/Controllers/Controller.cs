using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public abstract class Controller : MonoBehaviour
{
    public Pawn pawn;
    public float score;
    
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }
    // Update is called once per frame
    public virtual void Update()
    {
    }

    
    public abstract void ProcessInputs();

    public virtual void AddToScore(float scoreToAdd)
    {
        score += scoreToAdd;
    }
    
}