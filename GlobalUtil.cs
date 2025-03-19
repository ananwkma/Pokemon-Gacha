using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalUtil : MonoBehaviour
{
    public static void SetTextColor(string hexColor, TMP_Text textToChangeColor)
    {
        Color newColor;
        if (ColorUtility.TryParseHtmlString(hexColor, out newColor))
        {
            textToChangeColor.color = newColor;
        }
        else
        {
            Debug.LogError("Invalid hex color: " + hexColor);
        }
    }
}
