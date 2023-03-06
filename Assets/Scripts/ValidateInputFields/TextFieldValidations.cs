using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextFieldValidations : MonoBehaviour
{
    public List<TMP_InputField> InputFields;
    [SerializeField] private bool isFormInputFieldOkay = true;
    public List<GameObject> ErrorSigns;
    public void ValidateInputFields()
    {
        if (string.IsNullOrEmpty(InputFields[0].text))
        {
            isFormInputFieldOkay = false;
            ErrorSigns[0].gameObject.SetActive(true);
        }
        else
        {
            ErrorSigns[0].gameObject.SetActive(false);
        }
        if (isFormInputFieldOkay) UIManager.Instance.isFormValid = true;
        isFormInputFieldOkay = true;
    }
}
