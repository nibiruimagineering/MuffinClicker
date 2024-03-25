using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 1.Spin Transformations
/// 2.Pulse Transformations
/// </summary>
public class SpinPulseTransform : MonoBehaviour
{
    [SerializeField]
    private Transform[] _spinLights;
    [SerializeField]
    private float[] _spinSpeeds;
    [SerializeField]
    private float _waveSpeed, _waveAmplitude, _waveOffset;

    // Update is called once per frame
    private void Update()
    {
        for (int i = 0; i < _spinLights.Length; i++)
        {
            //Rotation
            Vector3 myRotation = new Vector3();
            myRotation.z = _spinSpeeds[i] * Time.deltaTime;
            _spinLights[i].Rotate(myRotation);

            //Wave
            float wave = Mathf.Sin(Time.time * _waveSpeed) * _waveAmplitude + _waveOffset;
            Vector3 waveScale = new Vector3(wave, wave, wave);
            _spinLights[i].localScale = waveScale;
        }
    }
}
