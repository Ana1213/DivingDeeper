using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public Item selectedItem;
    public void Click()
    {
        if (selectedItem != null)
        {
            if (selectedItem.isBuyed == false)
            {
                BuyItem();
            }
            else
            {
                EquipItem();
            }
        }
    }


    public void BuyItem()
    {

        if (PlayerController.instance.TakeCash(selectedItem.price) == -1) return;

        if (selectedItem is Pickaxe)
        {
            Pickaxe pickaxe = selectedItem as Pickaxe;
            MineHability.instance.miningPower = pickaxe.pickaxePower;
            MineHability.instance.miningCooldown = pickaxe.pickaxeCooldown;
            MineHability.instance.ChangeSprite(selectedItem.itemSpr);

        }
        
        selectedItem.isBuyed = true;

    }

    public void EquipItem()
    {
        if (selectedItem is Pickaxe)
        {
            Pickaxe pickaxe = selectedItem as Pickaxe;
            MineHability.instance.miningPower = pickaxe.pickaxePower;
            MineHability.instance.ChangeSprite(selectedItem.itemSpr);
        }
    }
}
