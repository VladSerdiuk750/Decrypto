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
    private GameObject _confirmCluesButton;

    [SerializeField]
    private TextMeshProUGUI _codeField;

    [SerializeField] 
    private GameObject _cluesPlacement;

    [SerializeField]
    private List<CluePlacement> _clueList;

    [SerializeField]
    private GameObject _codeSelection;
    
    [SerializeField]
    private List<InputCodeField> _codeInputList;

    private GameManager _gameManager;
   
    void Start()
    {
        _gameManager = Singleton<GameManager>.instance;
    }

    public void RandomizeAllWords()
    {
        _gameManager.WordDictionaryManager.ClearCurrentWords();
        foreach (var item in _placements)
        {
            Word currentWord = _gameManager.WordDictionaryManager.GetRandomWord();
            item.AssignWord(currentWord);
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
        _codeField.gameObject.SetActive(true);
        _cluesPlacement.SetActive(true);    
    }

    private void SetUpCode()
    {
        _gameManager.CodeManager.GenerateCode(_placements.Count - 1);
        _codeField.text = "Код: " + _gameManager.CodeManager.GetCode();
    }

    private void CheckCode()
    {
        for (int i = 0; i < _codeInputList.Count; i++)
        {
            if (_gameManager.CodeManager.Code.CodeList[i] != _codeInputList[i].GetEnteredCode())
            {
                Debug.Log("HUDController | CheckCode | Code is not correct");
            }
           else
            {
                Debug.Log("HUDController | CheckCode | Code is correct");
            }
        }
    }

    public void ConfirmClues()
    {
        _codeField.gameObject.SetActive(false);
        _confirmCluesButton.SetActive(false);
        foreach(CluePlacement clue in _clueList)
        {
            clue.DisableEditing();
        }
        _codeSelection.SetActive(true);
    }

    public void ConfirmAnswer()
    {
        foreach(InputCodeField code in _codeInputList)
        {
            code.DisableEditing();
        }

        CheckCode();
    }
}