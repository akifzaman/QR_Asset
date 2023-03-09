using TMPro;
using UnityEngine;

public class CreateURLQRCode : CreateQRCode
{
    public TMP_InputField URLInputField;
    public void GenerateTextToConvert()
    {
        if (UIManager.Instance.isFormValid) GenerateText();
    }
    public override string GenerateText()
    {
        Lastresult += ("http://" + URLInputField.text);
        Debug.Log(Lastresult);
        return Lastresult;
    }
}
