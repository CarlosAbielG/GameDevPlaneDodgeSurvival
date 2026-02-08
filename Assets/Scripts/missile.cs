using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_missile : MonoBehaviour
{
    private GameObject player;

    private Rigidbody2D rb;
    private float timer = 0f;

    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speed;//controlls the speed of the missile

        float rot = Mathf.Atan2(-direction.y, - direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot+90);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 4f)//destroys after 10 secs 
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)//destroys on contact
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
