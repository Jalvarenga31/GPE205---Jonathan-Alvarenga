using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float CurrentHealth;
    public float MaxHealth;


    
    void Start()
    {
        CurrentHealth = MaxHealth;
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
        Destroy(gameObject);
        Debug.Log("Died!");
    }
}
