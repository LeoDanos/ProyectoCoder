using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesLvl2 : Enemies
{
    public void Start()
    {
        speed = 0.125f; 
        //follow = 0;
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

    public override void Follow()
    {
        switch (follow)
        {
            case 0:
                FollowAtPlayer();
                break;
            case 1:
                FollowAtPlayer();
                speed = 0.1f;
                break;
            default:
                break;
        }
    }

}
