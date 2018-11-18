using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SignUpSceneHandler : MonoBehaviour
{
    public Transform loadingCircle;
    public InputField email;
    public InputField password;
    public InputField reEnterPassword;
    public Text message;

    static readonly string emailValidationFailed = "Please enter a valid e-mail address format!";
    static readonly string passwordValidationFailed = "Please enter a valid password format. Valid password's minimum length is 6, and contains uppercase, lowecase and digit.";
    static readonly string passwordsDoNotMatch = "The enetered passwords are not the same!";

    public void ConfirmButtonOnClick()
    {
        if (!Validator.ValidateEmail(email.text))
        {
            message.text = emailValidationFailed;
        }
        else if (!Validator.ValidatePassword(password.text))
        {
            message.text = passwordValidationFailed;
        }
        else if (password.text != reEnterPassword.text)
        {
            message.text = passwordsDoNotMatch;
        }
        else
        {
            StartCoroutine(SignUp());
            //Dispatcher.RunOnMainThread(async () => await FirebaseAuthHelper.SignUpAsync(email.text, password.text));
        }
    }

    IEnumerator SignUp()
    {
        var loadingCircleInstance = Instantiate(loadingCircle);
        yield return FirebaseAuthHelper.SignUpAsync(email.text, password.text);
        Destroy(loadingCircleInstance.gameObject);
    }

}
