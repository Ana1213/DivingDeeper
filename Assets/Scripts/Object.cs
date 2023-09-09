using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{

    public virtual void Collect()
    {

    }


    public virtual void Collision(Collider2D collision)
    {
        if (collision.tag == "Player")
            Collect();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collision(collision);
    }
}
