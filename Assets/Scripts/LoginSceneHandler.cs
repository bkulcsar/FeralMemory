using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoginSceneHandler : MonoBehaviour
{
    public Transform loadingCircle;
    public InputField email;
    public InputField password;
    public Text message;

    static string emailValidationFailed = "Please enter a valid e-mail address format!";
    static string passwordValidationFailed = "Please enter a valid password format. Valid password's minimum length is 6, and contains uppercase, lowecase and digit.";

    public void Start()
    {
        ApplicationModel.PersistentDataPath = Application.persistentDataPath;
    }

    public void LoginButtonOnClick()
    {
        StartCoroutine(Login());

        if (!Validator.ValidateEmail(email.text))
        {
            message.text = emailValidationFailed;
        }
        else if (!Validator.ValidatePassword(password.text))
        {
            message.text = passwordValidationFailed;
        }
        else
        {     
            StartCoroutine(Login());
            //Dispatcher.RunOnMainThread(async () => await FirebaseAuthHelper.LoginAsync(email.text, password.text));   
        }
    }

    public void ContinueWithoutLoginOnClick()
    {      
        var player = ApplicationModel.LoadLocalUserData("notRegisteredUser");

        if (player != null)
        {
            ApplicationModel.CurrentLevel = player.Level;
            ApplicationModel.CurrentBoneNumber = player.BoneNumber;
        }
        else
        {
            ApplicationModel.CurrentLevel = 1;
            ApplicationModel.CurrentBoneNumber = 0;
        }

        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator Login()
    {
        var loadingCircleInstance = Instantiate(loadingCircle);
        yield return FirebaseAuthHelper.LoginAsync(email.text, password.text);
        Destroy(loadingCircleInstance.gameObject);
    }
}
