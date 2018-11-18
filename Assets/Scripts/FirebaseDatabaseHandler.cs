using UnityEngine;
using System.Collections;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using System;
using System.Threading.Tasks;

public static class FirebaseDatabaseHandler
{
    static DatabaseReference reference;

    static FirebaseDatabaseHandler()
    {
        //Init db
        if (Application.isEditor)
        {
            FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://feralmemory.firebaseio.com/");
        }
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public static async Task<Boolean> WriteUser(UserDataJson userData, string userId)
    {
        bool ret = false;

        string json = JsonUtility.ToJson(userData);

        Task writeUserTask =  reference.Child("users").Child(userId).SetRawJsonValueAsync(json);

        await writeUserTask;

        if (writeUserTask.IsCompleted)
        {
            ret = true;
        }

        return ret;
    }

    public static async Task<UserDataJson> GetUserByUserId(string userId)
    {
        UserDataJson ret = null;

        try
        {
            Task<DataSnapshot> getUserTask = reference.Child("users").Child(userId).GetValueAsync();

            await getUserTask;

            if (getUserTask.IsCompleted && getUserTask.Result != null)
            {
                var userString = getUserTask.Result.GetRawJsonValue();

                ret = JsonUtility.FromJson<UserDataJson>(userString);
            }
        }
        catch (FirebaseException ex)
        {
            Debug.LogError(ex.Message);
        }
        
        return ret;
    }

    public static void SaveCloudUserData(string userId)
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            UserDataJson newCloudUserData = new UserDataJson();
            newCloudUserData.InitFromApplicationModel();
            FirebaseDatabaseHandler.WriteUser(newCloudUserData, userId).ContinueWith(task =>
            {
                if (task.Result)
                {
                    Debug.Log(String.Format("Write UserId: {0} to cloud succeed.", userId));
                }
                else
                {
                    Debug.LogError(String.Format("Write UserId: {0} to cloud failed.", userId));
                }
            });
        }   
    }

    public static void SyncUserData(UserDataBinary localUserData, UserDataJson cloudUserData)
    {
        if (localUserData == null && cloudUserData == null)
        {
            ApplicationModel.CurrentLevel = 1;
            ApplicationModel.CurrentBoneNumber = 0;
            Debug.Log("No user data found.");
            return;
        }
        else if (localUserData == null || (localUserData != null && cloudUserData != null && localUserData.ModifiedDatetimeBinary <= cloudUserData.ModifiedDatetimeBinary))
        {
            ApplicationModel.CurrentLevel = cloudUserData.Level;
            ApplicationModel.CurrentBoneNumber = cloudUserData.BoneNumber;
            ApplicationModel.SaveLocalUserData(FirebaseAuthHelper.Auth.CurrentUser.UserId);
            Debug.Log(String.Format("User data loaded from the cloud: {0}", FirebaseAuthHelper.Auth.CurrentUser.UserId));
        }
        else if (cloudUserData == null || (localUserData != null && cloudUserData != null && localUserData.ModifiedDatetimeBinary >= cloudUserData.ModifiedDatetimeBinary))
        {
            ApplicationModel.CurrentLevel = localUserData.Level;
            ApplicationModel.CurrentBoneNumber = localUserData.BoneNumber;
            Debug.Log(String.Format("User data loaded from the local file: {0}", localUserData.UserID));

            UserDataJson newCloudUserData = new UserDataJson();
            newCloudUserData.InitFromApplicationModel();
            FirebaseDatabaseHandler.WriteUser(newCloudUserData, FirebaseAuthHelper.Auth.CurrentUser.UserId).ContinueWith(task =>
            {
                if (task.Result)
                {
                    Debug.Log(String.Format("Write UserId: {0} to cloud succeed.", FirebaseAuthHelper.Auth.CurrentUser.UserId));
                }
                else
                {
                    Debug.LogError(String.Format("Write UserId: {0} to cloud failed.", FirebaseAuthHelper.Auth.CurrentUser.UserId));
                }
            });
        }
    }
}
