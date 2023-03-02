using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreatePhoneNumberQRCode : CreateQRCode
{
    public TMP_InputField PhoneNumberInputField;
    public void GenerateTextToConvert()
    {
        if (UIManager.Instance.isFormValid) GenerateText();
    }
    public override string GenerateText()
    {
        Lastresult += ("tel:" + PhoneNumberInputField.text);
        Debug.Log(Lastresult);
        return Lastresult;
    }
}
