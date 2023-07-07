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
    private TextMeshProUGUI _descriptionCodeButton;

    private GameManager _gameManager;

    private string _showCodeText = "�������� ���";

    private string _hideCodeText = "��������� ���";
   
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
        _displayCodeButton.SetActive(true);
    }

    private void SetUpCode()
    {
        _gameManager.CodeManager.GenerateCode(_placements.Count - 1);
        _codeField.text = _gameManager.CodeManager.GetCode();
    }

    public void DisplayCode()
    {
        bool isCodeHidden = !_codeField.gameObject.activeSelf;

        _codeField.gameObject.SetActive(isCodeHidden);
        _descriptionCodeButton.text = isCodeHidden? _hideCodeText: _showCodeText;
    }
}