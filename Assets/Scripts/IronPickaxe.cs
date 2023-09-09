using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronPickaxe : Pickaxe
{
    public override void Init(int price, Sprite  spr)
    {
        base.Init(price, spr);
        pickaxePower = 10;
        pickaxeCooldown = 0.5f;
        name = "Iron Pickaxe";
    }
}