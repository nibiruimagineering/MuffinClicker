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

    private void Start()
    {
        UpdateUI();
    }
    public void OnUpgradeClicked()
    {
        int currentCost = _costPerLevel[_level];
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
        _priceHolder.text = _costPerLevel[_level].ToString();
    }
}
