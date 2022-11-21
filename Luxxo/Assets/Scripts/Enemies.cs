using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject player;
    protected float speed = 0.1f; 
    protected int speedToFollow = 1;
    protected float speedFinal;
    //private bool follow = true;
    public int follow = 0;
    protected float distance;
    protected Player playerScript;
    
    public void Start()
    {
        playerScript = FindObjectOfType<Player>();
    }

    public void Update()
    {
        CheckDistance();
        speedFinal = speed * speedToFollow;
        distance = Vector3.Distance(player.transform.position, transform.position);
    }

    public void FixedUpdate()
    {
        Follow();
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

    public virtual void Follow()
    {
        if (follow == 0)
        {
            FollowAtPlayer();
        }
    }
    
    public void FollowAtPlayer()
    {
        Vector3 directionToPlayer = (player.transform.position - this.transform.position).normalized;
        rb.AddForce(directionToPlayer * speedFinal, ForceMode.Impulse);
    }

    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject == player)
        {
        follow += 1;
        }
    }
}