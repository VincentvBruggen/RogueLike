using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    private int health;

    private void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        SendMessage("GotHurt");
        print("damage taken");
        health -= damage;
    }

    public void Death()
    {
        SendMessage("Died");
        Destroy(gameObject);
    }

    public int GetHpStatus()
    {
        return health;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Death();
        }
    }
}
