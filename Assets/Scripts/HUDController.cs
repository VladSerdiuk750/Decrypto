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

    [SerializeField]
    private TextMeshProUGUI _codeField;

    [SerializeField]
    private GameObject _displayCodeButton;

    [SerializeField]
    private TextMeshProUGUI _discriptionOfDisplayCodeButton;

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

        _randomizeButton.SetActive(false);
        _confirmButton.SetActive(true);
        _gameManager.ConfirmStatus = PlacementsConfirmStatus.UnConfirm; 
        _gameManager.OnStatusUnConfirmed();
    }

    public void ConfirmWords()
    {
        _gameManager.ConfirmStatus = PlacementsConfirmStatus.Confirm;
        _gameManager.OnStatusConfirmed();
        _confirmButton.SetActive(false);
        SetUpCode();
        _displayCodeButton.SetActive(true);
    }

    public void SetUpCode()
    {
        _gameManager.CodeManager.GenerateCode(_placements.Count - 1);
        _codeField.text = _gameManager.CodeManager.GetCode();
    }

    public void DisplayCode()
    {
        if(_codeField.gameObject.activeSelf)
        {
            _codeField.gameObject.SetActive(false);
            _discriptionOfDisplayCodeButton.text = "Показати код";
        }
        else
        {
            _codeField.gameObject.SetActive(true);
            _discriptionOfDisplayCodeButton.text = "Приховати код";
        }
    }
}