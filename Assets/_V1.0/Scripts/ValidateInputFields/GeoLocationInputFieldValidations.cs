using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace QRCodeGenerator23
{
    public class GeoLocationInputFieldValidations : MonoBehaviour
    {
        public List<TMP_InputField> InputFields;
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
                    Handheld.Vibrate();
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
}
