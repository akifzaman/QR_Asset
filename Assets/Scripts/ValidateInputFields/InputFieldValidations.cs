using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class InputFieldValidations : MonoBehaviour
{
    public List<TMP_InputField> InputFields; // Reference to the InputField component

    [SerializeField] protected bool isFormInputFieldOkay = true;
    public List<string> RegularExpressions;

    public abstract void ValidateInputFields();

    protected void ValidateFields()
    {
        for (int i = 0; i < InputFields.Count; i++)
        {
            isFormInputFieldOkay = (isFormInputFieldOkay) && Regex.IsMatch(InputFields[i].text, RegularExpressions[i]);
            if (!isFormInputFieldOkay) break;
        }
        if (isFormInputFieldOkay) UIManager.Instance.isFormValid = true;
        isFormInputFieldOkay = true;
    }
}