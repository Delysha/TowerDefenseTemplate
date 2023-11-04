using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;

    public int Currency;
    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        Currency = 100;
    }

    public void IncreaseCurrency(int amount)
    {
        Currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= Currency) 
        {
            Currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("you do not have enough");
            return false;
        }
    }

}
