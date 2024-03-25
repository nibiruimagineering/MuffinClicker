using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Handles transform movement
/// Handles gameObject Destruction after 9 seconds
/// </summary>
public class DessertDrop : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = -100f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, _moveSpeed * Time.deltaTime, 0);
        Destroy(gameObject, 9);
    }
}
