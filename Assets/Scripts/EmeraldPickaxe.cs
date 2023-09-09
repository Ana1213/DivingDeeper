using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmeraldPickaxe : Pickaxe
{
    public override void Init(int price, Sprite spr)
    {
        base.Init(price, spr);
        pickaxeCooldown = 0.5f;
        pickaxePower = 50;
        name = "Emerald Pickaxe";
    }
}
