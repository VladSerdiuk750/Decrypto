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

    public CodeManager()
    {
        _code = new Code();
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
            int randomNumberOfCode = Code.EnableNumbers[UnityEngine.Random.Range(0, Code.EnableNumbers.Count)];

            //add this number to our list of code 
            Code.CodeList.Add(randomNumberOfCode);
            //remove it from availiables to avoid getting the same number
            Code.EnableNumbers.Remove(randomNumberOfCode);
        }
    }

    /// <summary>
    /// Fuction which create a list of available numbers(from 1 to the highest availible number in order of increase)
    /// </summary>
    public void SetAvailableNumbers(int amountOfNumbers)
    {
        for(int i = 1; i <= amountOfNumbers + 1; i++ )
        {
            Code.EnableNumbers.Add(i);

            Debug.Log("Enables numbers: " + Code.EnableNumbers[i - 1]);
        }
    }

    public string getCode()
    {
        return string.Join(", ", Code.CodeList);
    }
}