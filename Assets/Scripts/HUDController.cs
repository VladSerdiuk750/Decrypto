using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField]
    private List<WordPlacement> _placements;

    private GameManager _gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = Singleton<GameManager>.instance;
    }

    public void RandomizeAllWords()
    {
        _gameManager.WordDictionaryManager.ClearCurrentWords();

        Word currentword; 

        foreach (var item in _placements)
        {
            currentword = _gameManager.WordDictionaryManager.GetRandomWord();
            item.AssignWord(currentword);
        }
    }
}