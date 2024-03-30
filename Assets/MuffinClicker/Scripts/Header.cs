using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
/// <summary>
/// Updates header children UI elements.
/// </summary>
public class Header : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _totalMuffinsText;

    [SerializeField]
    private TextMeshProUGUI _muffinsPerSecond;


    /// <summary>
    /// Updates total muffins text
    /// </summary>
    /// <param name="counterParam">The total muffins</param>
    public void UpdateTotalMuffins(int counterParam)
    {

        _totalMuffinsText.text = counterParam == 1 ? "1 muffin" : $"{counterParam} muffins";
    }

    public void UpdateMuffinsPerSecond(int muffinsPerSecond)
    {
        _muffinsPerSecond.text = muffinsPerSecond == 0 ? "muffin/seconds" : $"{muffinsPerSecond} muffins/seconds";
    }

}
