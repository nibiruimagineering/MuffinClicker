using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent<int> OnTotalMuffinsChanged;
    public UnityEvent<int> OnMuffinsPerSecondChanged;


    [Range(0f, 1f)]
    [SerializeField]
    private float _critChance = 0.01f;
    private int _muffinsPerClick = 1;
    private int _totalMuffins = 0;
    private int _muffinsPerSecond = 0;


    private int TotalMuffins
    {
        get
        {
            return _totalMuffins;
        }
        set 
        {
            _totalMuffins = value;
            OnTotalMuffinsChanged.Invoke(_totalMuffins);
        }
    }

    private int MuffinsPerSecond
    { 
        get 
        { 
            return _muffinsPerSecond;
        } 
        set
        {
            _muffinsPerSecond = value;
            OnMuffinsPerSecondChanged.Invoke(_muffinsPerSecond);
        }
    }



    public int AddMuffins()
    {
        // Crit Logic
        int addedMuffins = 0;
        if (Random.value <= _critChance)
        {
            addedMuffins = _muffinsPerClick * 10;
        }
        else
        {
            addedMuffins = _muffinsPerClick;
        }
        TotalMuffins += addedMuffins;

        return addedMuffins;
    }

    public bool TryPurchaseUpgrade(int currentCost, int level)
    {
        if (TotalMuffins >= currentCost)
        {
            // Purchase
            TotalMuffins -= currentCost;
            level++;
            _muffinsPerClick = 1 + level * 2;
            return true;
        }
        return false;
    }

    public bool TryPurchaseSugarRush(int currentCost, int level)
    {
        if (TotalMuffins >= currentCost)
        {
            TotalMuffins -= currentCost;
            level++;
            MuffinsPersecondTimer(level);
            InvokeRepeating("MuffinsPersecondTimer", 1.0f, 1.0f);

            return true;
        }
        return false;
    }

    private void Start()
    {
        TotalMuffins = 0;
        MuffinsPerSecond = 0;

    }

    private void Update()
    {

       Debug.Log(string.Format("Muffins Per Second = {0}", _muffinsPerSecond));

    }

   private void MuffinsPersecondTimer(int level)
    {
        MuffinsPerSecond = 1 + level;
        //TotalMuffins += MuffinsPerSecond;
    }
}
