using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickaxesShopButton : MonoBehaviour
{ 
    public string itemName;
    public int price;
    public Sprite itemSpr;

    public TextMeshProUGUI buyButtonText;
    public BuyButton buyButton;

    Type type;
    Item item;

    private void Start()
    {
        type = Type.GetType(itemName);
        item = (Item)Activator.CreateInstance(type);
    }
    public void Click()
    {
       
        item.Init(price, itemSpr );
        buyButton.selectedItem = item;
        
        Debug.Log(item.price);


        
        if (item.isBuyed == false)
        {
            buyButtonText.text = "Buy " + item.GetName() + "- $" + item.price ;
        }
        else
        {
            buyButtonText.text = "Equip " + item.GetName();
        }
    }
}
