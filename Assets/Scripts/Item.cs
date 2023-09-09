using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Item
{
    public int price;
    public bool isBuyed;
    protected string name;
    public Sprite itemSpr;
    public virtual void Init(int price, Sprite spr)
    {
        this.price = price;
        itemSpr = spr;
    }

    public string GetName()
    {
        return name;
    }

}
