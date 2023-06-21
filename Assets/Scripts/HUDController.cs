using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField]
    private List<WordPlacement> _placements;
    
    [SerializeField]
    private GameObject _randomizeButton;

    [SerializeField]
    private GameObject _confirmButton;

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = Singleton<GameManager>.instance;
    }

    public void RandomizeAllWords()
    {
        foreach (var item in _placements)
        {
            _gameManager.WordDictionaryManager.ClearCurrentWords();
            Word currentword;
            currentword = _gameManager.WordDictionaryManager.GetRandomWord();
            item.AssignWord(currentword);
        }

        _randomizeButton.SetActive(false);
        _confirmButton.SetActive(true);
        _gameManager.ConfirmStatus = PlacementsConfirmStatus.UnConfirm; 
    }

    public void ConfirmWords()
    {
        _gameManager.ConfirmStatus = PlacementsConfirmStatus.Confirm;
        _gameManager.OnStatusConfirmed();
        _confirmButton.SetActive(false);
    }
}