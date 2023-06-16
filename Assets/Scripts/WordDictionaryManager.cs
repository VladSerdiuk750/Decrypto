using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WordDictionaryManager : IWordDictionaryManager
{
    private List<string> _uaDictionary;

    public WordDictionaryManager()
    {
        _uaDictionary = new List<string>()
        {
            "������", "����", "�����", "������", "������", "�����", "��������"
        };
    }

    public string GetRandomWord()
    {
        return _uaDictionary[Random.Range(0, _uaDictionary.Count)];
    }
}
