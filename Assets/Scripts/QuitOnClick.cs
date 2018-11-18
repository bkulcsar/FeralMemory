using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitOnClick : MonoBehaviour {

    public QuitToEnum QuitTo;

    public void Quit()
    {
        switch (QuitTo)
        {
            case QuitToEnum.Desktop:
                FirebaseAuthHelper.Auth.SignOut();
                Application.Quit();
                break;
            case QuitToEnum.MainMenu:
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
                break;
            case QuitToEnum.LoginScene:
                FirebaseAuthHelper.Auth.SignOut();
                SceneManager.LoadScene("LoginScene", LoadSceneMode.Single);
                break;
            default:
                FirebaseAuthHelper.Auth.SignOut();
                Application.Quit();
                break;
        }
        
    }

    public enum QuitToEnum
    {
        Desktop,
        MainMenu,
        LoginScene
    }
}
