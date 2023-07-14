using TMPro;
using UnityEngine;

public class InputCodeField : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputCode;

    public int GetEnteredCode()
    {
        int number = 0;
       
        if (!string.IsNullOrEmpty(_inputCode.text))
        { 
            int.TryParse(_inputCode.text, out number);
        }

        return number;
    }
}

