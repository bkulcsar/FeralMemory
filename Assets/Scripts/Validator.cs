using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public static class Validator
{
    public static bool ValidateEmail(string _email)
    {
        bool ret = true;

        string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
        Regex regexEmail = new Regex(validEmailPattern, RegexOptions.IgnoreCase);

        ret = regexEmail.IsMatch(_email) && !string.IsNullOrEmpty(_email);

        return ret;
    }

    public static bool ValidatePassword(string _password)
    {
        bool ret = true;

        const int MIN_LENGTH = 6;
        const int MAX_LENGTH = 15;

        string validPasswordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{" + MIN_LENGTH.ToString() + "," + MAX_LENGTH.ToString() + "}$";
        Regex regexPassword = new Regex(validPasswordPattern);

        if (!string.IsNullOrEmpty(_password))
        {
            ret = regexPassword.IsMatch(_password);
        }
        else
        {
            ret = false;
        }

        return ret;
    }

    
}
