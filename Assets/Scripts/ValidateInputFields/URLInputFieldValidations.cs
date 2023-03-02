using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class URLInputFieldValidations : MonoBehaviour
{
    public List<TMP_InputField> InputFields; // Reference to the InputField component

    [SerializeField] private bool isFormInputFieldOkay = true;
    // Regex pattern for validating email addresses
    private string urlPattern = @"^((https?|ftp)://)?(www\.)?([a-zA-Z0-9_\-]+)(\.[a-zA-Z]{2,})(\.[a-zA-Z]{2,})?(/[\w\-\./\?\%\&=]*)?$";

    public List<string> RegularExpressions;

    public void Start()
    {
        RegularExpressions.Add(urlPattern);
    }
    public void ValidateInputFields()
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