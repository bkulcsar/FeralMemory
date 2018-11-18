using UnityEngine;
using System.Collections;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System.Collections.Generic;
using System;

public static class FirebaseAuthHelper
{
    public static FirebaseAuth Auth { get; private set; }
    static Dictionary<string, FirebaseUser> userByAuth;

    public static async Task  SignUpAsync(string email, string password)
    {
        try
        {
            Task<FirebaseUser> signUpTask = Auth.CreateUserWithEmailAndPasswordAsync(email, password);
            await signUpTask;

            UIHandler.HandleSignUpResult(signUpTask);
        }
        catch (FirebaseException ex)
        {
            UIHandler.SetMessage(ex.Message, Color.red);
        }
    }

    static FirebaseAuthHelper()
    {
        //Init auth
        Auth = FirebaseAuth.DefaultInstance;
        userByAuth = new Dictionary<string, FirebaseUser>();

        Auth.StateChanged += Auth_StateChanged;
    }

    public static async Task LoginAsync(string email, string password)
    {
        try
        {
            var signInTask = Auth.SignInWithEmailAndPasswordAsync(email, password);
            
            await signInTask;

            UIHandler.HandleLoginResult(signInTask);
        }
        catch (FirebaseException ex)
        {
            UIHandler.SetMessage(ex.Message, Color.red);
        }      
    }

    private static void Auth_StateChanged(object sender, EventArgs e)
    {
        FirebaseAuth senderAuth = sender as FirebaseAuth;
        FirebaseUser user = null;

        if (senderAuth != null) FirebaseAuthHelper.userByAuth.TryGetValue(senderAuth.App.Name, out user);

        if (senderAuth == FirebaseAuthHelper.Auth && senderAuth.CurrentUser != user)
        {
            bool signedIn = user != senderAuth.CurrentUser && senderAuth.CurrentUser != null;

            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
              
                ApplicationModel.CurrentLevel = 1;
                ApplicationModel.CurrentBoneNumber = 0;
            }

            user = senderAuth.CurrentUser;
            FirebaseAuthHelper.userByAuth[senderAuth.App.Name] = user;

            if (signedIn)
            {
                LoggedIn();
                Debug.Log("Signed in " + user.UserId);

                FirebaseDatabaseHandler.GetUserByUserId(user.UserId).ContinueWith(task =>
                {
                    var localUserData = ApplicationModel.LoadLocalUserData(Auth.CurrentUser.UserId);

                    FirebaseDatabaseHandler.SyncUserData(localUserData, task.Result);
                });
            }
        }
    }

    private static void LoggedIn()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
