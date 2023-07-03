using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;

public class CodeManager
{
    private Code _code;

    GameManager _gameManager;

    public Code Code => _code;

    private List<int> _availableNumbers;

    public CodeManager()
    {
        _code = new Code();
        _availableNumbers = new List<int>();
    }

    /// <summary>
    /// Funcion which create a list of random allowed numbers
    /// </summary>
    /// <param name="amountOfNumbers"></param>
    public void GenerateCode(int amountOfNumbers)
    {
        // set the availiable numbers
        SetAvailableNumbers(amountOfNumbers); 

        for (int i = 0; i < amountOfNumbers; i++) 
        {
            //get a random number from the available list of numbers
            int randomNumberOfCode = _availableNumbers[UnityEngine.Random.Range(0, _availableNumbers.Count)];

            //add this number to our list of code 
            Code.CodeList.Add(randomNumberOfCode);
            //remove it from availiables to avoid getting the same number
            _availableNumbers.Remove(randomNumberOfCode);
        }
    }

    /// <summary>
    /// Fuction which create a list of available numbers(from 1 to the highest availible number in order of increase)
    /// </summary>
    public void SetAvailableNumbers(int amountOfNumbers)
    {
        for(int i = 1; i <= amountOfNumbers + 1; i++ )
        {
            _availableNumbers.Add(i);
        }
    }

    public string GetCode()
    {
        return string.Join(", ", Code.CodeList);
    }
}