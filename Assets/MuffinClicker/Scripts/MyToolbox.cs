using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 1.Generates Random Vector2 float values for Text Reward Popup.
/// </summary>
public static class MyToolbox
{
    /// <summary>
    /// Vector2 Random Values
    /// </summary>
    /// <param name="xMin">x Min</param>
    /// <param name="xMax">x Max</param>
    /// <param name="yMin">y Min</param>
    /// <param name="yMax">y Max</param>
    /// <returns></returns>
    // Public Method to generate Vector 2 X and Y coordniates
    public static Vector2 GetRandomVector2(float xMin, float xMax, float yMin, float yMax)
    { 
        Vector2 value = new Vector2();
        value.x = Random.Range(xMin, xMax);
        value.y = Random.Range(yMin, yMax);
        return value;
    }
}
