using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShopButton : MonoBehaviour
{
    [SerializeField] GameObject shopBG;
    static public bool isOpened = false;
    public void Click()
    {
        isOpened = !isOpened;
        shopBG.SetActive(isOpened);
    }
}
