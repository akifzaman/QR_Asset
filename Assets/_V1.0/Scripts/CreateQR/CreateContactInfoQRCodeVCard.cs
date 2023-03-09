using System;
using System.Collections.Generic;
using UnityEngine;

//This script can be used if the Contact QR code needs to be generated from VCard
public class CreateContactInfoQRCodeVCard : CreateQRCode
{
    public List<string> Tags = new List<string> { "N:", "ORG:", "TEL:", "URL:", "EMAIL:", "ADR:", "NOTE:" };
    public void GenerateTextToConvert()
    {
        if(UIManager.Instance.isFormValid) GenerateText();
    }
    public override string GenerateText()
    {
       
        Lastresult += "BEGIN:VCARD";
        Lastresult += (Environment.NewLine + "VERSION:3.0");
        for (int i = 0; i < inputFields.Count; i++)
        {
            if (inputFields[i].text != null)
            {
                Lastresult += (Environment.NewLine + Tags[i] + inputFields[i].text);
            }
        }
        Lastresult += (Environment.NewLine + "END:VCARD");
        Debug.Log(Lastresult);
        return Lastresult;
    }
}