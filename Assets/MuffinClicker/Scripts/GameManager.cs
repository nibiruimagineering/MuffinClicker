using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/// <summary>
/// 1.Handles the OnMuffin "button click".
/// 2.Keeps track of our total muffins.
/// 3.Handles "Crit" logic.
/// 4.Update Header to display total muffins.
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Header _header;
    [Range(0f, 1f)]
    [SerializeField]
    private float _critChance = 0.01f;

    private int _muffinsPerClick = 1;
    private int _totalMuffins = 0;

    private int TotalMuffins
    {
        get
        {
            return _totalMuffins;
        }
        set 
        {
            _totalMuffins = value;
            _header.UpdateTotalMuffins(TotalMuffins);
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

    private void Start()
    {
        _header.UpdateTotalMuffins(0);
    }
}
