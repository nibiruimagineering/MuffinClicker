using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
/// <summary>
/// 1. OnMuffinClicked() Create Clones of the text reward prefab.
/// </summary>
public class MuffinClicker : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField]
    private TextMeshProUGUI _textRewardPrefab;
    [SerializeField]
    private float _xMin = -150f, _xMax = 190f,_yMin = 150f, _yMax = 150f ;

    // OnButton Click even - Muffin Button
    public void OnMuffinClicked()
    {
        int addedMuffins = _gameManager.AddMuffins();
        CreateTextRewardPrefab(addedMuffins);
    }

    private void CreateTextRewardPrefab(int addedMuffins)
    {
        TextMeshProUGUI textRewardClone = Instantiate(_textRewardPrefab, transform);
        Vector2 randomVector = MyToolbox.GetRandomVector2(_xMin, _xMax, _yMin, _yMax);
        textRewardClone.transform.localPosition = randomVector;
        textRewardClone.text = $"+ {addedMuffins}";
    }
}
