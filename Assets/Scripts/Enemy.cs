using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] protected int hp, maxHp;
    [SerializeField] protected float speed;
    [SerializeField] protected int attackDamage;
    [SerializeField] protected float sightDistance;
    [SerializeField] protected float stopDistance;

    [SerializeField] protected Rigidbody2D rb;

    protected bool canWalk = true;
    protected virtual void SightPlayer()
    {

        Transform plrPos = PlayerController.instance.transform;
        float distance = Vector2.Distance(plrPos.position, transform.position);

        if (distance <= stopDistance)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }
        if (canWalk)
        {
            if (distance <= sightDistance)
            {
                Walk(plrPos);

            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            WalkCooldown(100);
        }


    }
    protected virtual void Walk(Transform plrPos)
    {




    }
    protected async void WalkCooldown(int cooldown)
    {
        canWalk = false;
        await Task.Delay(cooldown);
        canWalk = true;

    }
    protected virtual void FixedUpdate()
    {
        SightPlayer();
    }

}
