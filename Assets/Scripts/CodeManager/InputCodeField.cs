using TMPro;
using UnityEngine;

public class InputCodeField : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputCode;

    public int GetEnteredCode()
    {
        int number;
        if(!string.IsNullOrEmpty(_inputCode.text))
        {
            if (int.TryParse(_inputCode.text, out number))
            {
                return number;
            }
            else
            {
                return 0;
            }
        }
        else return 0;
    }
}

