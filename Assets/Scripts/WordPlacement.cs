using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;


public class WordPlacement : MonoBehaviour
{
    /// <summary>
    /// Main word textfield object
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI _textField;

    /// <summary>
    /// Sequence number textfield object 
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI _sequenceNumber;

    /// <summary>
    /// Id textfield object
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI _id;

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
        _id.text = word.id.ToString();
    }

    public void RandomTargetWord()
    {
        AssignWord(_gameManager.WordDictionaryManager.GetRandomWord(_currentWord));
    }
}