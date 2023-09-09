using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hp, maxHp;
    [SerializeField] float speed;
    [SerializeField] int attackDamage;
    [SerializeField] float sightDistance;
    [SerializeField] float stopDistance;

    [SerializeField] Rigidbody2D rb;

    bool canWalk = true;
    protected virtual void Walk()
    {
        Transform plrPos = PlayerController.instance.transform;
        float distance = Vector2.Distance(plrPos.position, transform.position);

        if(distance <= stopDistance)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        if (canWalk)
        {
            if (distance <= sightDistance)
            {
                Vector2 angle = (plrPos.position - transform.position).normalized;
                rb.velocity = angle * speed;

            }
            else{
                rb.velocity = Vector2.zero;
            }
           
            WalkCooldown();
        }
        
    }

    async void WalkCooldown()
    {
        canWalk = false;
        await Task.Delay(500);
        canWalk = true;

    }
    private void FixedUpdate()
    {
        Walk();
    }

}
