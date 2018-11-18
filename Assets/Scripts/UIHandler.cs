using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using Firebase.Auth;
using System;

public class UIHandler : MonoBehaviour
{
    public Text message;

    private static Text messageStatic;

    // Use this for initialization
    void Start()
    {
        messageStatic = message;
    }

    private static void LoginSucceed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public static void SetMessage(string _message, Color color)
    {
        messageStatic.text = _message;
        messageStatic.color = color;
    }

    public static void HandleLoginResult(Task<FirebaseUser> _result)
    {
        if (_result.IsCanceled)
        {
            Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
            SetMessage("Login failed. Please retry.", Color.red);
            return;
        }
        else if (_result.IsFaulted)
        {
            if (_result.Exception != null)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + _result.Exception);
                if (_result.Exception.InnerExceptions.Count > 0)
                {
                    Debug.LogError("InnerException: " + _result.Exception.InnerExceptions[0].Message);
                }
            }
            SetMessage("Login failed. Incorrect e-mail or password!", Color.red);
            return;
        }
        else if (_result.IsCompleted == true && _result.Exception == null)
        {
            //LoginSucceed();
        }
        
    }

    public static void HandleSignUpResult(Task<FirebaseUser> _result)
    {
        if (_result.IsCanceled)
        {
            Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
            SetMessage("Sign up failed. Please retry.", Color.red);
            return;
        }
        else if (_result.IsFaulted)
        {
            if (_result.Exception != null)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + _result.Exception);
                if (_result.Exception.InnerExceptions.Count > 0)
                {
                    Debug.LogError("InnerException: " + _result.Exception.InnerExceptions[0].Message);
                }
            }
            SetMessage("Sign up failed. E-mail already exists!", Color.red);
            return;
        }
        else if (_result.IsCompleted == true && _result.Exception == null)
        {
            //LoginSucceed();
        }      
    }

}
