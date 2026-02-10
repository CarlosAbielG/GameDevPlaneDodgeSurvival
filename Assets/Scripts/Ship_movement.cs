using UnityEngine;

public class Ship_movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float lifeTime;

    private Rigidbody2D rb;
    [SerializeField]
    private float timer = 0f;

    Vector2 moveDirection;

    Transform target;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    
        if(target)
        {
            Vector3 direction = target.transform.position - transform.position;
            rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speed;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0,0,angle-90);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
