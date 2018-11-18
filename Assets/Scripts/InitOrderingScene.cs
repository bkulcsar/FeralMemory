using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class InitOrderingScene : MonoBehaviour
{
    public GameObject Background;
    public GameObject Animals;
    public GameObject ExitIcon;
    public GameObject Bone;
    public GameObject Header;
    public GameObject OrderCubes;

    Boolean first = true;

    // Use this for initialization
    void Start()
    {
        LoadTheme();
    }

    private void LoadTheme()
    {
        LevelStructure level = new LevelStructure();

        Background.GetComponent<Image>().sprite = ThemeCacheClass.BackgroundSprite;
        ExitIcon.GetComponent<Image>().sprite = ThemeCacheClass.ExitIconSprite;
        Bone.GetComponent<Image>().sprite = ThemeCacheClass.BoneSprite;
        Bone.GetComponentInChildren<Text>().text = ApplicationModel.CurrentBoneNumber.ToString();
        Header.GetComponent<Image>().sprite = ThemeCacheClass.HeaderSprite;

        int i = 0;
        foreach (Image image in Animals.GetComponentsInChildren<Image>())
        {
            //First is parent
            if (first)
            {
                first = false;
                continue;
            }

            image.sprite = ThemeCacheClass.AnimalList[i].Sprite;
            image.gameObject.name = ThemeCacheClass.AnimalList[i].Name;
            i++;
        }

        int k = 0;
        foreach (Image image in OrderCubes.GetComponentsInChildren<Image>(true))
        {
            image.gameObject.SetActive(true);
            image.gameObject.name = ApplicationModel.correctCardOrder[k];
            k++;
            if (k == level.AnimalsToOrderCount)
            {
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
