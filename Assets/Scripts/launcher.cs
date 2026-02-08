using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_shooting : MonoBehaviour
{
    public GameObject missile;
    public Transform missilePos;

    private float timer;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if(Vector2.Distance(transform.position, player.transform.position)<35)
        {
            shoot();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(timer >= 4f && distance < 15f)
        {
            timer = 0f;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(missile, missilePos.position, Quaternion.identity);
    }
}
