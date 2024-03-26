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
    private int[] _costPerLevel;

    private int _level;
    public void OnUpgradeClicked()
    {
        int currentCost = _costPerLevel[_level];
        bool purchasedUpgrade = _gameManager.TryPurchaseUpgrade(currentCost);
        if (purchasedUpgrade)
        {
            _level++;
            _levelText.text = _level.ToString();
        }

    }
}
