//using System.Collections;
//using System.Collections.Generic;
//using System.Text.RegularExpressions;
//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;

//public class SMSInputFieldValidations : MonoBehaviour
//{
//    public List<TMP_InputField> InputFields; // Reference to the InputField component

//    [SerializeField] private bool isFormInputFieldOkay = true;
//    // Regex pattern for validating phone number
//    private string phonePattern = @"^\+?[0-9]{0,3}[ -]?\(?[0-9]{3}\)?[ -]?[0-9]{3}[ -]?[0-9]{4}$";
//    public List<string> RegularExpressions;

//    public void Start()
//    {
//        RegularExpressions.Add(phonePattern);
//    }
//    public void ValidateInputFields()
//    {
//        for (int i = 0; i < InputFields.Count; i++)
//        {
//            isFormInputFieldOkay = (isFormInputFieldOkay) && Regex.IsMatch(InputFields[i].text, RegularExpressions[i]);
//            if (!isFormInputFieldOkay) break;
//        }
//        if (isFormInputFieldOkay) UIManager.Instance.isFormValid = true;
//        isFormInputFieldOkay = true;
//    }
//}

using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
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