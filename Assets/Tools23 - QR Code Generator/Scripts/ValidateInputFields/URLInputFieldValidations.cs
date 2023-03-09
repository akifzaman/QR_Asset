namespace QRCodeGenerator23
{
    public class URLInputFieldValidations : InputFieldValidations
    {
        // Regex pattern for validating URL
        private string urlPattern =
            @"^((https?|ftp)://)?(www\.)?([a-zA-Z0-9_\-]+)(\.[a-zA-Z]{2,})(\.[a-zA-Z]{2,})?(/[\w\-\./\?\%\&=]*)?$";

        public override void ValidateInputFields()
        {
            RegularExpressions.Add(urlPattern);
            ValidateFields();
        }
    }
}