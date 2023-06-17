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

    public GameManager()
    {
        _wordDictionaryManager = new WordDictionaryManager();
    }

    private void Start()
    {
        LoadDictionary();
    }

    private void LoadDictionary()
    {
        TextAsset dictionary = Resources.Load<TextAsset>("Dictionary_UA");
        _wordDictionaryManager.AssignDictionary(JsonUtility.FromJson<WordDictionary>(dictionary.text).dictionary);
        _wordDictionaryManager.ShowAllWords();
    }
}
