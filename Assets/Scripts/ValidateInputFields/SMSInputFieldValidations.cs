using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SMSInputFieldValidations : InputFieldValidations
{
    // Regex pattern for validating phone number
    private string phonePattern = @"^\+?[0-9]{0,3}[ -]?\(?[0-9]{3}\)?[ -]?[0-9]{3}[ -]?[0-9]{4}$";

    public override void ValidateInputFields()
    {
        RegularExpressions.Add(phonePattern);
        ValidateFields();
    }
}