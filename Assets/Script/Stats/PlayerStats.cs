using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerStats : MonoBehaviour
{
    public Image HealthBar;

    public float maxHealth;
    public float currentHealth
    {
        get; private set;
    }

    public Stat weapon;

    public Stat heal;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(weapon.getValue());
            Debug.Log(transform.name + "Player current HP is at " + currentHealth);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Heal(heal.getValue());
            Debug.Log(transform.name + "Player current HP is at " + currentHealth);
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public virtual void TakeDamage(float Damage)
    {
        Damage = weapon.getValue();
        Damage = Mathf.Clamp(Damage, 0, currentHealth);
        currentHealth -= Damage;
        HealthBar.fillAmount = currentHealth / maxHealth;

        Debug.Log(transform.name + " takes " + Damage + " damage.");      
    }    
    public void Heal(float healAmt)
    {
        //healing demo, 
        healAmt = Mathf.Clamp(healAmt, 0, currentHealth);
        currentHealth += healAmt;
        Debug.Log(transform.name + "+ " + healAmt);
        HealthBar.fillAmount = currentHealth / maxHealth;

        if (currentHealth == 100)
        {
            Debug.Log(transform.name + " is full health." + " You are prim and proper now.");
        }
    }
    public virtual void Die()
    {
        //Die animation or rangdoll
        Debug.Log(transform.name + " has " + " Died!");
        SceneManager.LoadScene(1);
    }

}
