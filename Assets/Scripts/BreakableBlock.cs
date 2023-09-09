using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour
{
    public int hardness = 100;
    public int blockLife;
    public int value = 5;

    private void Awake()
    {
        blockLife = hardness;
    }
    public void BreakBlock(int damage)
    {
        blockLife -= damage;
        Debug.Log(blockLife);

        if(blockLife <= 0)
        {
            PlayerController.instance.AddCash(value);
            Destroy(this.gameObject);
        }
    }
}
