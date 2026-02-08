using UnityEngine;

public class enemy_death : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Die();
        }
    }

    // Update is called once per frame
    void Die()
    {
        Destroy(gameObject);
    }
}
