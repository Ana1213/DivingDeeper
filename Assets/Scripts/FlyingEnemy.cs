using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    

    protected override void Walk(Transform plrPos)
    {
        Vector2 angle = (plrPos.position - transform.position).normalized;
       


        //Debug.Log(angle);
        rb.velocity = angle * speed;
    }
}
