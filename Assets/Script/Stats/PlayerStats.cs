using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Stat maxHealth;
    public Stat currentHealth
    {
        get; private set;
    }

    public Stat damage;

    public Stat weapon;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

}
