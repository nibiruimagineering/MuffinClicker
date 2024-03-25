using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Profiling;
using UnityEngine;
using UnityEngine.UI;

public class SweetRain : MonoBehaviour
{
    [SerializeField]
    private Texture2D[] _sweetRain;
    [SerializeField]
    RawImage _dessertimg;
    [SerializeField]
    private float _xMin, _xMax, _yMin, _yMax;
    private float _secondsBetweenSpawn = 1;
    private float _elapsedTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        CreateSweets();
    }
    // Update is called once per frame
    void Update()
    {
       SweetSpawnerTime();
    }
    private void CreateSweets()
    {
        RawImage dessertImgPrefab = Instantiate(_dessertimg, transform);
        Vector2 randomVector = MyToolbox.GetRandomVector2(_xMin, _xMax, _yMin, _yMax);
        dessertImgPrefab.transform.localPosition = randomVector;

        int sweetRainLength = _sweetRain.Length; // returns the value of 25
        int randomIndex = Random.Range(0, sweetRainLength); // inclusive min start at 0 exclusive max end at 24
        Texture2D randomTexture = _sweetRain[randomIndex];
        dessertImgPrefab.texture = randomTexture;
    }
    private void SweetSpawnerTime()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn)
        {
            _elapsedTime = 0;
            CreateSweets();
        }
    }

}
