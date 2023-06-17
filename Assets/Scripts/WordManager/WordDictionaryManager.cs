using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WordDictionaryManager : IWordDictionaryManager
{
    private List<Word> _uaDictionary;

    public WordDictionaryManager()
    {

    }

    public string GetRandomWord()
    {
        return null; //_uaDictionary[Random.Range(0, _uaDictionary.Count)];
    }

    public void AssignDictionary(List<Word> words)
    {
        _uaDictionary = words;
    }

    public void ShowAllWords()
    {
        if(_uaDictionary != null &&  _uaDictionary.Count > 0)
        {
            foreach(Word word in _uaDictionary)
            {
                Debug.Log("Id " + word.id.ToString());
                Debug.Log("Word " + word.word.ToString());
            }
        }
    }
}
