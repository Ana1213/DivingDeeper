using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaPickaxe : Pickaxe
{
    public override void Init(int price, Sprite spr)
    {
        base.Init(price, spr);
        pickaxeCooldown = 0.25f;
        pickaxePower = 1500;
        name = "Magma Pickaxe";
    }
}
