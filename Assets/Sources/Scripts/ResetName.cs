using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResetName : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void ResetTextValue(TextMeshProUGUI value) => _text.text = value.text;
}
