using UnityEngine;

public class death : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
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
