using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject player;
    public float speed = 0.1f; 
    private int speedToFollow = 1;
    private float speedFinal;
    private bool follow = true;
    private float distance;
    Player playerScript;
    
    void Start()
    {
        playerScript = FindObjectOfType<Player>();
    }

    void Update()
    {
        CheckDistance();
        speedFinal = speed * speedToFollow;
        distance = Vector3.Distance(player.transform.position, transform.position);
    }

    void FixedUpdate()
    {
        if (follow)
        {
            FollowAtPlayer();
        }
    }
    
    public void CheckDistance()
    {
        if (distance <= (playerScript.health / 10))
        {
            speedToFollow = 1;
        }
        else
        {
            speedToFollow = 0;
        }
    }
    
    public void FollowAtPlayer()
    {
        Vector3 directionToPlayer = (player.transform.position - this.transform.position).normalized;
        rb.AddForce(directionToPlayer * speedFinal, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject == player)
        {
        follow = false;
        }
    }
}