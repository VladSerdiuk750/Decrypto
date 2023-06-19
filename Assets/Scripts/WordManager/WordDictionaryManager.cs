using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WordDictionaryManager : IWordDictionaryManager
{
    private List<Word> _uaDictionary;

    private readonly string _uaDictionaryPath = "Dictionary_UA";

    public List<Word> UADictionary => _uaDictionary;

    private List<Word> _currentWords;

    public WordDictionaryManager()
    {
        _currentWords = new List<Word>();
    }

    public void LoadDictionary()
    {
        TextAsset dictionary = Resources.Load<TextAsset>(_uaDictionaryPath);
        _uaDictionary = JsonUtility.FromJson<WordDictionary>(dictionary.text).dictionary;
    }

    public Word GetRandomWord()
    {
        Word result = _uaDictionary[Random.Range(0, _uaDictionary.Count)];
        do
        {
           result = _uaDictionary[Random.Range(0, _uaDictionary.Count)];
        } while (IsWordRepeated(result));

        _currentWords.Add(result);
        return result;
    }

    private bool IsWordRepeated(Word word)
    {
        foreach (var currentWord in _currentWords)
        {
            if(word.id == currentWord.id)
            {
                 return true;
            }
        }

        return false;
    }

    public void ClearCurrentWords()
    {
        _currentWords.Clear();
    }
}
