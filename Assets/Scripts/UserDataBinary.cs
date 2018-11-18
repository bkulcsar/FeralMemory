using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class UserDataBinary
{
    public int    Level { get; set; }
    public int    BoneNumber { get; set; }
    public string UserID { get; set; }
    public long   ModifiedDatetimeBinary { get; set; }

    public UserDataBinary()
    {
        ModifiedDatetimeBinary = DateTime.Now.ToBinary();
        if (FirebaseAuthHelper.Auth.CurrentUser != null)
        {
            UserID = FirebaseAuthHelper.Auth.CurrentUser.UserId;
        }
        else
        {
            UserID = "notRegisteredUser";
        }
    }

    public void InitFromApplicationModel()
    {
        Level = ApplicationModel.CurrentLevel;
        BoneNumber = ApplicationModel.CurrentBoneNumber;
    }
    
}
