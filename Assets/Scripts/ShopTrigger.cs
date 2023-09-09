using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    Transform shopButton;
    Transform shopBG;

    private void Start()
    {
        shopBG = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(2);
        shopButton = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            shopButton.gameObject.SetActive(true);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            shopButton.gameObject.SetActive(false);
            shopBG.gameObject.SetActive(false);
            OpenShopButton.isOpened = false;
        }
    }
}
