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

    private IWordDictionaryManager _wordDictionaryManager;

    public IWordDictionaryManager WordDictionaryManager => _wordDictionaryManager; 

    /// <summary>
    /// Confirm status field 
    /// </summary>
    private PlacementsConfirmStatus _confirmStatus = PlacementsConfirmStatus.None;

    /// <summary>
    /// Getter property for confirm status 
    /// </summary>
    public PlacementsConfirmStatus ConfirmStatus
    {
        get => _confirmStatus;
        set
        {
            if (value != _confirmStatus && value != PlacementsConfirmStatus.None) { _confirmStatus = value; }
        }
    }

    public event Action OnPlacementStatusConfirmed;

    public GameManager()
    {
        _wordDictionaryManager = new WordDictionaryManager();
    }

    private void Start()
    {
        _wordDictionaryManager.LoadDictionary();
    }

    public void OnStatusConfirmed()
    {
        OnPlacementStatusConfirmed?.Invoke();
    }    
}

public enum PlacementsConfirmStatus
{
    None,
    UnConfirm,
    Confirm
}