public class ContactInfoInputFieldValidations : InputFieldValidations
{
    // Regex pattern for validating contact information
    private string namePattern = @"^[A-Za-z]+((\s)?((\'|\-|\.)?([A-Za-z])+))*$";
    private string phonePattern = @"^\+?[0-9]{0,3}[ -]?\(?[0-9]{3}\)?[ -]?[0-9]{3}[ -]?[0-9]{4}$";
    private string urlPattern = @"^((https?|ftp)://)?(www\.)?([a-zA-Z0-9_\-]+)(\.[a-zA-Z]{2,})(\.[a-zA-Z]{2,})?(/[\w\-\./\?\%\&=]*)?$";
    private string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    public override void ValidateInputFields()
    {
        RegularExpressions.Add(namePattern);
        RegularExpressions.Add(phonePattern);
        RegularExpressions.Add(urlPattern);
        RegularExpressions.Add(emailPattern);
        ValidateFields();
    }
}

