using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CluePlacement : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;

    public void DisableEditing()
    {
        _inputField.interactable = false;
    }
}
