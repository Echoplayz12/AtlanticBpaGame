using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth
    {
        get; private set;
    }

    public Stat damage;

    public Stat weapon;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
            Debug.Log(transform.name + "Player current HP is at " + currentHealth);
        }

    }
    public void TakeDamage(int Damage)
    {
        Damage -= weapon.getValue();
        Damage = Mathf.Clamp(Damage, 0, maxHealth);
        currentHealth -= Damage;
        {
            Debug.Log(transform.name + " takes " + Damage + " damage.");
            if (currentHealth < 0)
            {
                Die();
            }
        }
    }
    public virtual void Die()
    {
        //Die animation or rangdoll
        Debug.Log(transform.name + " has " + " Died!");
    }
}
