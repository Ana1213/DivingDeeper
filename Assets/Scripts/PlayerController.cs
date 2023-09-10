using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int cash;
    [SerializeField] TextMeshProUGUI depthText;
    public static PlayerController instance;

    public int depth;

    GameObject canvas;
    TextMeshProUGUI cashText;
    float lastY = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        canvas = GameObject.FindGameObjectWithTag("Canvas");
        cashText = canvas.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        depth = (int)(Mathf.Floor((transform.position.y - 2.025959f)) / 2 + 0.5f);
        if (depthText && lastY != depth)
        {
            depthText.text = "Depth: " + depth;
            Debug.Log("A");
        }

        lastY = depth;
    }

    public int AddCash(int quantity)
    {
        cash += quantity;
        cashText.text = "Cash: " + cash;
        Debug.Log(cash);
        return cash;
    }

    public int TakeCash(int quantity)
    {
        if (cash - quantity < 0) return -1;


        cash -= quantity;

        cashText.text = "Cash: " + cash;
        Debug.Log(cash);
        return cash;
    }

}
