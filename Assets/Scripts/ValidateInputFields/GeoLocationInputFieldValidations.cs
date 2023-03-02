using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GeoLocationInputFieldValidations : MonoBehaviour
{
    public List<TMP_InputField> InputFields; // Reference to the InputField component

    [SerializeField] private bool isFormInputFieldOkay = true;

    public void ValidateInputFields()
    {
        foreach (var input in InputFields)
        {
            isFormInputFieldOkay = (isFormInputFieldOkay) && Validate(input.text);
        }
        if (isFormInputFieldOkay) UIManager.Instance.isFormValid = true;
        isFormInputFieldOkay = true;
    }
    public bool Validate(string input)
    {
        if (!string.IsNullOrEmpty(input)) return true;
        return false;
    }
}
