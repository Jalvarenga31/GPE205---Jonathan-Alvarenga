using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float CurrentHealth;
    public float MaxHealth;
    public float PointsPerKill;
    public float CurrentScore;
    private Pawn Tank;
    
    protected bool IsDead;
    public Text Healthcount;
    public Text LifeCounter;
    GameManager gameManager;
    public AudioSource DieSound;



    private void Awake()
    {
        Tank = GetComponent<Pawn>();
    }

    void Start()
    {
        CurrentHealth = MaxHealth;
        IsDead = false;
        DieSound = GetComponent<AudioSource>();
    }


    void Update()
    {
        
    }

    public void TakeDamage(float amount, Pawn source)
    {
        CurrentHealth = CurrentHealth - amount;
        Debug.Log(source.name + " did " + amount + " damage to " +  gameObject.name);
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        if (CurrentHealth <= 0)
        {
            LoseLife(source);
            IsDead = true;
        }
        else
        {
            IsDead = false;
        }
    }

    public void LoseLife(Pawn source)
    {
        if (Tank.CurrentLives >= 0) 
        {
            Tank.CurrentLives--;
            Debug.Log("Lost a life!");

            GameManager.instance.Respawn(gameObject.GetComponent<Controller>());
            CurrentHealth = MaxHealth;
            IsDead = false;

        }
        else
        {
            Die(source);     
        }

    }

    public void Heal(float amount, Pawn source)
    {
        CurrentHealth += amount;
        Debug.Log(source.name + " did " + amount + " healing to " + gameObject.name);
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
    }

    public void HealthUp(float amount, Pawn source)
    {
        MaxHealth += amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
    }

    public void Die(Pawn source)
    {
        DieSound.Play();
        Destroy(gameObject);
        Destroy(gameObject.GetComponent<Pawn>());
        Destroy(gameObject.GetComponent<Controller>());
        gameManager.ActivateGameOver();
        Debug.Log("Died!");
        source.controller.AddToScore(PointsPerKill);
    }

    public void HealthDisplayed()
    {   
       Healthcount.text = "Health: " + CurrentHealth;
    }

    public void LifeDisplayed()
    {
        LifeCounter.text = "Lives: " + Tank.CurrentLives;
       
    }

    

}

