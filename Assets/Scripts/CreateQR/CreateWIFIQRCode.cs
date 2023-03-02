using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateWIFIQRCode : CreateQRCode
{
    public List<string> Tags = new List<string> { "S:", "T:", "P:", "H:"};

    public void GenerateTextToConvert()
    {
        if (UIManager.Instance.isFormValid) GenerateText();
    }
    public override string GenerateText()
    {
        Lastresult += "WIFI:";
        for (int i = 0; i < inputFields.Count; i++)
        {
            if (inputFields[i].text != null)
            {
                Lastresult += (Tags[i] + inputFields[i].text + ";");
            }
        }
        Lastresult += ";";
        Debug.Log(Lastresult);
        return Lastresult;
    }
}
