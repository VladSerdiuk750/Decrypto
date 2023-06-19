using System.Collections.Generic;

public interface IWordDictionaryManager
{
    List<Word> UADictionary { get; }

    void LoadDictionary();

    Word GetRandomWord();
    
    void ClearCurrentWords();
}
