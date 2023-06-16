using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordPlacement : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textField;

    [SerializeField]
    private TextMeshProUGUI _sequenceNumber;

    public void AssignWord(string word) 
    {
        _textField.text = word;
    }

    public void AssignWord(string word, string sequenceNumber)
    {
        _textField.text = word;
        _sequenceNumber.text = sequenceNumber;
    }
}