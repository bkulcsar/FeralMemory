using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using System;

public static class ApplicationModel
{ 
    public static int orderedAnimalsCount;
    public static string[] correctCardOrder;
    public static bool lastAnimal = false;

    public static string PersistentDataPath { get; set; }
    public static int CurrentBoneNumber { get; set; }
    public static int CurrentLevel { get; set; }

    public static void SaveLocalUserData(string userId)
    {
        BinaryFormatter bf = new BinaryFormatter();
        List<UserDataBinary> playerDataList;
        FileStream file = File.Open(PersistentDataPath + "/PlayerData.dat", FileMode.OpenOrCreate);

        if (file.Length > 0)
        {
            playerDataList = (List<UserDataBinary>)bf.Deserialize(file);
        }
        else
        {
            playerDataList = new List<UserDataBinary>();
        }      
        
        bool found = false;

        foreach (UserDataBinary player in playerDataList)
        {
            if (player.UserID == userId)
            {
                player.BoneNumber = ApplicationModel.CurrentBoneNumber;
                player.Level = ApplicationModel.CurrentLevel;
                player.ModifiedDatetimeBinary = DateTime.Now.ToBinary();
                Debug.Log(String.Format("Local user data saved: {0}", player.UserID));
                found = true;
                break;
            }
        }
        if (!found)
        {
            UserDataBinary newPlayer = new UserDataBinary();
            newPlayer.InitFromApplicationModel();
            Debug.Log(String.Format("Local user data saved to new file: {0}", newPlayer.UserID));
            playerDataList.Add(newPlayer);
        }

        bf.Serialize(file, playerDataList);
        file.Close();
    }

    public static UserDataBinary LoadLocalUserData(string userId)
    {
        UserDataBinary ret = null;

        if (File.Exists(PersistentDataPath + "/PlayerData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(PersistentDataPath + "/playerData.dat", FileMode.Open);
            List<UserDataBinary> playerDatalist = (List<UserDataBinary>)bf.Deserialize(file);
            file.Close();

            foreach (UserDataBinary player in playerDatalist)
            {
                if (player.UserID == userId)
                {
                    ret = player;
                    Debug.Log(String.Format("Local user data loaded: {0}", ret.UserID));
                    break;
                }
            }
        }

        return ret;
    }   
}
