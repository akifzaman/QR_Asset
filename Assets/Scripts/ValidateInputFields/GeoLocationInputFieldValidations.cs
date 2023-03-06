using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class GeoLocationInputFieldValidations : MonoBehaviour
{
    public List<TMP_InputField> InputFields; // Reference to the InputField component
    public List<GameObject> ErrorSigns;

    [SerializeField] private bool isFormInputFieldOkay = true;

    public void ValidateInputFields()
    {
        for (int i = 0; i < InputFields.Count; i++)
        {
            isFormInputFieldOkay = (isFormInputFieldOkay) && Validate(InputFields[i].text);
            if (!isFormInputFieldOkay)
            {
                ErrorSigns[i].gameObject.SetActive(true);
                break;
            }
            else
            {
                ErrorSigns[i].gameObject.SetActive(false);
            }
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
