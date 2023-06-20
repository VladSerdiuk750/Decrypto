using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;
using System.Net.Mail;

public class WordPlacement : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textField;

    [SerializeField]
    private TextMeshProUGUI _sequenceNumber;

    [SerializeField]
    private TextMeshProUGUI _Id;


    private Word _currentWord;

    public Word CurrentWord => _currentWord; 

    private GameManager _gameManager;

    void Start()
    {
        _gameManager = Singleton<GameManager>.instance;
    }

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

    public void AssignId(Word word)
    {
        _Id.text = word.id.ToString();
    }

    public void RandomTargetWord()
    {
        AssignWord(_gameManager.WordDictionaryManager.GetRandomWord(_currentWord));
        AssignId(_currentWord);
    }

     
}