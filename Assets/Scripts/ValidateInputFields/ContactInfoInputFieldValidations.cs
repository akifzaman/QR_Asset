using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class ContactInfoInputFieldValidations : MonoBehaviour
{
    public List<TMP_InputField> InputFields; // Reference to the InputField component

    [SerializeField] private bool isFormInputFieldOkay = true;
    // Regex pattern for validating email addresses
    private string namePattern = @"^[A-Za-z]+((\s)?((\'|\-|\.)?([A-Za-z])+))*$";
    private string phonePattern = @"^\+?[0-9]{0,3}[ -]?\(?[0-9]{3}\)?[ -]?[0-9]{3}[ -]?[0-9]{4}$";
    private string urlPattern = @"^(https?://)?(www\.)?([a-zA-Z0-9]+)\.([a-zA-Z]{2,})(\.[a-zA-Z]{2,})?$";
    private string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    public List<string> RegularExpressions;

    public void Start()
    {
        RegularExpressions.Add(namePattern);
        RegularExpressions.Add(phonePattern);
        RegularExpressions.Add(urlPattern);
        RegularExpressions.Add(emailPattern);
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
