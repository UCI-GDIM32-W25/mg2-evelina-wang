using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Points : MonoBehaviour

{
     [SerializeField] private TMP_Text _text;
     private void Reset()
    {
        _text = GetComponent<TMP_Text>();
    }
 private void Update()
    {
         _text.text = $"points: {Coin.TotalScore} ";
    }
}