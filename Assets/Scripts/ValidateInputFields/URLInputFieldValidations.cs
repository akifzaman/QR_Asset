using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class URLInputFieldValidations : InputFieldValidations
{
    // Regex pattern for validating phone number
    private string urlPattern = @"^((https?|ftp)://)?(www\.)?([a-zA-Z0-9_\-]+)(\.[a-zA-Z]{2,})(\.[a-zA-Z]{2,})?(/[\w\-\./\?\%\&=]*)?$";

    public override void ValidateInputFields()
    {
        RegularExpressions.Add(urlPattern);
        ValidateFields();
    }
}