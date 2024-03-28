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
    [SerializeField]
    private float _costPowerScale = 1.5f;



    private int _level;

    private int CurrentCost
    {
        get 
        {
            return 5 + Mathf.RoundToInt(Mathf.Pow(_level, _costPowerScale));
        }
    }

    private void Start()
    {
        UpdateUI();
    }
    public void OnUpgradeClicked()
    {
        int currentCost = CurrentCost;
        bool purchasedUpgrade = _gameManager.TryPurchaseUpgrade(currentCost, _level);
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

    public void TotalMuffinsChanged(int totalMuffin)
    {
        bool canAfford = totalMuffin >= CurrentCost;
        _priceHolder.color = canAfford ? Color.green : Color.red;
    }
}
