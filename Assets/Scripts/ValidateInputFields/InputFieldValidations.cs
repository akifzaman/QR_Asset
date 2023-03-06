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
    public List<GameObject> ErrorSigns;
    public abstract void ValidateInputFields();

    protected void ValidateFields()
    {
        for (int i = 0; i < InputFields.Count; i++)
        {
            isFormInputFieldOkay = (isFormInputFieldOkay) && Regex.IsMatch(InputFields[i].text, RegularExpressions[i]);
            if (!isFormInputFieldOkay)
            {
                ErrorSigns[i].gameObject.SetActive(true);
                //break;
            }
            else
            {
                ErrorSigns[i].gameObject.SetActive(false);
            }
        }
        if (isFormInputFieldOkay) UIManager.Instance.isFormValid = true;
        isFormInputFieldOkay = true;
    }
}