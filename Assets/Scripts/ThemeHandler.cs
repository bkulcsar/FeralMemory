using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeHandler : MonoBehaviour {

    public GameObject ForestTheme;
    public GameObject JungleTheme;
    public GameObject FarmTheme;
    public GameObject WaterTheme;
    public GameObject MountainTheme;
    public GameObject SafariTheme;

    // Use this for initialization
    void Start ()
    {
        LevelStructure level = new LevelStructure();

        switch (level.Theme)
        {
            case ThemeEnum.Forest:
                ForestTheme.SetActive(true);
                ForestTheme.GetComponentInChildren<Text>().text = ApplicationModel.CurrentBoneNumber.ToString();
                break;
            case ThemeEnum.Jungle:
                JungleTheme.SetActive(true);
                JungleTheme.GetComponentInChildren<Text>().text = ApplicationModel.CurrentBoneNumber.ToString();
                break;
            case ThemeEnum.Farm:
                FarmTheme.SetActive(true);
                FarmTheme.GetComponentInChildren<Text>().text = ApplicationModel.CurrentBoneNumber.ToString();
                break;
            case ThemeEnum.Mountain:
                MountainTheme.SetActive(true);
                MountainTheme.GetComponentInChildren<Text>().text = ApplicationModel.CurrentBoneNumber.ToString();
                break;
            case ThemeEnum.Water:
                WaterTheme.SetActive(true);
                WaterTheme.GetComponentInChildren<Text>().text = ApplicationModel.CurrentBoneNumber.ToString();
                break;
            case ThemeEnum.Safari:
                SafariTheme.SetActive(true);
                SafariTheme.GetComponentInChildren<Text>().text = ApplicationModel.CurrentBoneNumber.ToString();
                break;
                
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
