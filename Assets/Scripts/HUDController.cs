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

    public void RandomizeWords()
    {
        for (int i = 0; i < _placements.Count; i++)
        {
            string word = _gameManager.WordDictionaryManager.GetRandomWord();
            _placements[i].AssignWord(word);
        }
    }
}