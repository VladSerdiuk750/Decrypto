using System.Collections.Generic;

public interface IWordDictionaryManager
{
    string GetRandomWord();

    void AssignDictionary(List<Word> words);

    void ShowAllWords();
}
