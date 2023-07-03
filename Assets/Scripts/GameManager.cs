using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Singleton]
public class GameManager : MonoBehaviour, ISingleton
{
    [SerializeField]
    private HUDController _controller;
    
    /// <summary>
    /// WordManager field
    /// </summary>
    private IWordDictionaryManager _wordDictionaryManager;

    public IWordDictionaryManager WordDictionaryManager => _wordDictionaryManager; 

    private PlacementsConfirmStatus _confirmStatus = PlacementsConfirmStatus.None;

    public PlacementsConfirmStatus ConfirmStatus
    {
        get => _confirmStatus;
        set
        {
            if (value != _confirmStatus && value != PlacementsConfirmStatus.None) { _confirmStatus = value; }
        }
    }

    /// <summary>
    /// CodeManager field
    /// </summary>
    private CodeManager _codeManager;

    public CodeManager CodeManager => _codeManager;

    /// <summary>
    /// Event field 
    /// </summary>
    public event Action<bool> OnConfirmStatusChanged;

    public GameManager()
    {
        _wordDictionaryManager = new WordDictionaryManager();
        _codeManager = new CodeManager();
    }

    private void Start()
    {
        _wordDictionaryManager.LoadDictionary();
    }

    public void OnStatusConfirmed()
    {
        OnConfirmStatusChanged?.Invoke(false);
    }

    public void OnStatusUnConfirmed()
    {
        OnConfirmStatusChanged?.Invoke(true);
    }
}

public enum PlacementsConfirmStatus
{
    None,
    UnConfirm,
    Confirm
}