using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class GroundEnemy : Enemy
{

    [SerializeField] protected float jumpPower;
    [SerializeField] protected LayerMask block;

    
    bool jump;
    bool canJump = true;
    [SerializeField]int dir = 1;


    private void Update()
    {
        RaycastHit2D bottomRaycast = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, block);
        RaycastHit2D frontRaycast = Physics2D.Raycast(transform.position, Vector2.right * dir, 1, block);
        if (frontRaycast && bottomRaycast && canJump)
        {
            jump = true;

        }

       

        
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (jump)
        {
            Jump();
        }
      
    }
    protected override void Walk(Transform plrPos)
    {
        Vector2 angle = (plrPos.position - transform.position);
        angle = new Vector2(angle.x, 0);


        
        rb.velocity = new Vector2(angle.x * speed, rb.velocity.y);


        if(angle.x < 0)
        {
            dir = -1;
        }else if(angle.x > 0)
        {
            dir = 1;
        }
       
    }

    async void JumpCooldown()
    {
        canJump = false;
        await Task.Delay(750);

        canJump = true;
    }
    void Jump()
    {
        JumpCooldown();
        jump = false;
        Vector2 force = new Vector2(0, jumpPower);

        rb.AddForce(force, ForceMode2D.Impulse);
        Debug.Log("Jumped");

    }


}
