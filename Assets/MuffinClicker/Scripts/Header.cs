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

    /// <summary>
    /// Updates total muffins text
    /// </summary>
    /// <param name="counterParam">The total muffins</param>
    public void UpdateTotalMuffins(int counterParam)
    {
        //if (counterParam == 1)
        //{
        //    _totalMuffinsText.text = $"{counterParam} muffin";
        //}
        //else 
        //{
        //    _totalMuffinsText.text = $"{counterParam} muffins";
        //}
        // Conditional expression
        _totalMuffinsText.text = counterParam == 1 ? "1 muffin" : $"{counterParam} muffins";
    }
}
