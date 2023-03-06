//using System.Collections;
//using System.Collections.Generic;
//using System.Text.RegularExpressions;
//using TMPro;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.UI;

//public class EmailAddressInputFieldValidations : MonoBehaviour
//{
//    public List<TMP_InputField> InputFields; // Reference to the InputField component

//    [SerializeField] private bool isFormInputFieldOkay = true;
//    // Regex pattern for validating email addresses
//    private string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
//    public List<string> RegularExpressions;

//    public void Start()
//    {
//        RegularExpressions.Add(emailPattern);
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

public class EmailAddressInputFieldValidations : InputFieldValidations
{
    // Regex pattern for validating email addresses
    private string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    public override void ValidateInputFields()
    {
        RegularExpressions.Add(emailPattern);
        ValidateFields();
    }
}

