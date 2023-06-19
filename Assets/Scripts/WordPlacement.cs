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

    private Word _currentWord;

    public Word CurrentWord => _currentWord;

    public void AssignWord(Word word) 
    {
        _currentWord = word;
        _textField.text = word.word;
    }

    public void AssignWord(Word word, string sequenceNumber)
    {
        _currentWord = word;
        _textField.text = word.word;
        _sequenceNumber.text = sequenceNumber;
    }
}