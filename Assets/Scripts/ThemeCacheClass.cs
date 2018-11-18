using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ThemeCacheClass : MonoBehaviour
{
    public GameObject Background;
    public GameObject Animals;
    public GameObject ExitIcon;
    public GameObject Bone;
    public GameObject Header;

    public static Sprite BackgroundSprite{ get; private set; }
    public static List<Animal> AnimalList { get; private set; }
    public static Sprite ExitIconSprite { get; private set; }
    public static Sprite BoneSprite { get; private set; }
    public static Sprite HeaderSprite { get; private set; }

    List<Animal> localAnimalList = new List<Animal>();

    Animal animal;


    // Use this for initialization
    void Start()
    {
        BackgroundSprite = Background.GetComponent<Image>().sprite;
        ExitIconSprite = ExitIcon.GetComponent<Image>().sprite;
        BoneSprite = Bone.GetComponent<Image>().sprite;
        HeaderSprite = Header.GetComponent<Image>().sprite;


        foreach (Image image in Animals.GetComponentsInChildren<Image>())
        {
            animal = new Animal();
            animal.Sprite = image.sprite;
            animal.Name = image.gameObject.name;

            localAnimalList.Add(animal);
        }
        AnimalList = localAnimalList;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
