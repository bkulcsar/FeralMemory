using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization;


public class UserDataJson
{
    public int  Level;
    public int  BoneNumber;
    public long ModifiedDatetimeBinary;

    public UserDataJson()
    {
        ModifiedDatetimeBinary = DateTime.Now.ToBinary();
    }

    public void InitFromApplicationModel()
    {
        Level = ApplicationModel.CurrentLevel;
        BoneNumber = ApplicationModel.CurrentBoneNumber;
    }
}
