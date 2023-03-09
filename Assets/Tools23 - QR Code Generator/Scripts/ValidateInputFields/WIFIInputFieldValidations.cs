using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QRCodeGenerator23
{
    public class WIFIInputFieldValidations : MonoBehaviour
    {
        public List<TMP_InputField> InputFields; // Reference to the InputField component
        private string[] networkTypeOptions = { "WPA", "WEP", "No Encryption" };

        [SerializeField] private bool isFormInputFieldOkay = true;

        // Regex pattern for validating WIFI credentials
        private string ssidPattern = @"^[a-zA-Z0-9_$@-]{1,32}$";
        private string networkPattern = @"^(WPA|WEP|No Encryption)$";
        private string passwordPattern = @"^[a-zA-Z0-9_$@-]{1,32}$";
        private string hiddenPattern = @"^(true|false)$";
        public List<string> RegularExpressions;
        public List<GameObject> ErrorSigns;
        public TMP_Dropdown dropdown;
        public Toggle toggle;


        public void Start()
        {
            dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
            toggle.onValueChanged.AddListener(OnToggleValueChanged);
            InputFields[1].text = "WPA";
            InputFields[3].text = "false";
            RegularExpressions.Add(ssidPattern);
            RegularExpressions.Add(networkPattern);
            RegularExpressions.Add(passwordPattern);
            RegularExpressions.Add(hiddenPattern);
        }

        public void ValidateInputFields()
        {
            if (InputFields[1].text == "No Encryption")
            {
                for (int i = 0; i < InputFields.Count; i++)
                {
                    if (i == 1)
                    {
                        continue;
                    }

                    string ss = Regex.Replace(InputFields[i].text, @"\s", "");
                    isFormInputFieldOkay = (isFormInputFieldOkay) && Regex.IsMatch(ss, RegularExpressions[i]);
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
            }
            else
            {
                for (int i = 0; i < InputFields.Count; i++)
                {
                    string ss = Regex.Replace(InputFields[i].text, @"\s", "");
                    isFormInputFieldOkay = (isFormInputFieldOkay) && Regex.IsMatch(ss, RegularExpressions[i]);
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
            }

            if (isFormInputFieldOkay) UIManager.Instance.isFormValid = true;
            isFormInputFieldOkay = true;
        }

        private void OnDropdownValueChanged(int value)
        {
            InputFields[1].text = networkTypeOptions[value].ToString();
            if (InputFields[1].text == "No Encryption") UIManager.Instance.isWIFINoEncryptionEnabled = true;
            else
            {
                UIManager.Instance.isWIFINoEncryptionEnabled = false;
            }
        }

        public void OnToggleValueChanged(bool value)
        {
            InputFields[3].text = value.ToString().ToLower();
        }
    }
}
