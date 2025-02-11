using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatesHover : MonoBehaviour
{
    [SerializeField] private Image ratesInfo;

    void OnMouseOver() {
        ratesInfo.enabled = true;
    }

    void OnMouseExit() {
        ratesInfo.enabled = false;
    }

    void Start () {
        if (ratesInfo) ratesInfo.enabled = false;
    }
}
