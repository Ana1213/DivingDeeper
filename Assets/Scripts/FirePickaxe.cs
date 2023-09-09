using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePickaxe : Pickaxe
{
    public override void Init(int price, Sprite spr)
    {
        base.Init(price, spr);
        pickaxeCooldown = 0.3f;
        pickaxePower = 1000;
        name = "Fire Pickaxe";
    }
}
