using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField]
    private TextMeshProUGUI _levelText;
    [SerializeField]
    private TextMeshProUGUI _priceHolder;
    [SerializeField]
    private int[] _costPerLevel;

    private int _level;

    private int CurrentCost
    {
        get 
        {
            // Data Validation solves error we get when we hit the final 3rd upgrade
            //length of our level array is 3
            //0 1 2

            int length = _costPerLevel.Length;

            if (length == 0 ) 
            {
                return 0;
            }

            int index = Mathf.Clamp(_level,0,length - 1);

            return _costPerLevel[index];
        }
    }

    private void Start()
    {
        UpdateUI();
    }
    public void OnUpgradeClicked()
    {
        int currentCost = CurrentCost;
        bool purchasedUpgrade = _gameManager.TryPurchaseUpgrade(currentCost);
        if (purchasedUpgrade)
        {
            _level++;
            UpdateUI();
        }

    }
    private void UpdateUI()
    {
        _levelText.text = _level.ToString();
        _priceHolder.text = CurrentCost.ToString();
    }
}
