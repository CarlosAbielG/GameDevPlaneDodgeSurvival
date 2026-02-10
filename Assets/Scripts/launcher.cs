using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_shooting : MonoBehaviour
{
    public GameObject missile;
    public Transform missilePos;

    [SerializeField]
    private float shootInterval = 4f;
    [SerializeField]
    private float shootDistance = 15f;
    [SerializeField]
    private float initialShootDistance = 35f;

    private float timer;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if(Vector2.Distance(transform.position, player.transform.position)<initialShootDistance)
        {
            shoot();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(timer >= shootInterval && distance < shootDistance)
        {
            timer = 0f;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(missile, missilePos.position, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
{
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, shootDistance);

    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(transform.position, initialShootDistance);
}

}
