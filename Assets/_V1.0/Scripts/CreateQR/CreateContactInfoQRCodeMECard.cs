using System.Collections.Generic;
using UnityEngine;

namespace QRCodeGenerator23
{
    public class CreateContactInfoQRCodeMECard : CreateQRCode
    {
        public List<string> Tags = new List<string> { "N:", "ORG:", "TEL:", "URL:", "EMAIL:", "ADR:", "NOTE:" };

        public void GenerateTextToConvert()
        {
            if (UIManager.Instance.isFormValid) GenerateText();
        }

        //The QR generation depends on the result of the GenerateText() method
        public override string GenerateText()
        {

            Lastresult += "MECARD:";
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
}
