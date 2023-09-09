using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPickaxe : Pickaxe
{
    public override void Init(int price, Sprite spr)
    {
        base.Init(price, spr);
        pickaxePower = 5;
        name = "Weak Pickaxe";

        pickaxeCooldown = 0.5f;
    }
}
