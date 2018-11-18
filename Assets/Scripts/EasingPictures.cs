using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EasingPictures : MonoBehaviour {

    LevelStructure level;
    public GameObject Animals;
    List<Image> animalList = new List<Image>();
    float floatingSec;
    float waitSec;
    List<Image> shuffledAnimals;
    float canvasPosX;
    float canvasPosY;
    float canvasCenterX;
    Image animal;
    
    Vector2 startPos;

    // Use this for initialization
    IEnumerator Start ()
    {
        level = new LevelStructure();
        floatingSec = level.FloatingSec;
        waitSec = level.WaitSec;
        InitAnimals();

        ApplicationModel.correctCardOrder = new string[level.AnimalsToOrderCount];
        var rnd = new System.Random();

        for (int i = 0; i <= level.AnimalsToOrderCount - 1; i++)
        {
            animal = shuffledAnimals[rnd.Next(0, 4)];
            ApplicationModel.correctCardOrder[i] = animal.name;
 
            StartCoroutine(SmoothMove(startPos, new Vector2(canvasCenterX, canvasPosY), animal.rectTransform, floatingSec));
            yield return new WaitForSeconds(floatingSec + waitSec);
            StartCoroutine(SmoothMove(animal.rectTransform.position, new Vector2(-(animal.rectTransform.rect.width + canvasPosX), canvasPosY), animal.rectTransform, floatingSec));
            yield return new WaitForSeconds(floatingSec);

            if (i == level.AnimalsToOrderCount - 1)
            {
                LoadOrderingScene();
            }
        }  
    }

    private void LoadOrderingScene()
    {
        SceneManager.LoadScene("OrderingScene");
    }

    private void InitAnimals()
    {
        Animals.SetActive(true);

        canvasPosX = Animals.GetComponentInParent<Canvas>().transform.position.x;
        canvasPosY = Animals.GetComponentInParent<Canvas>().transform.position.y;
        canvasCenterX = Animals.GetComponentInParent<Canvas>().pixelRect.width / 2;

        foreach (Image image in Animals.GetComponentsInChildren<Image>())
        {
            image.gameObject.SetActive(true);
            image.rectTransform.position = new Vector2(2 * canvasCenterX + canvasPosX, image.rectTransform.position.y);
            
            animalList.Add(image);
        }
        startPos = animalList[0].rectTransform.position;

        var rnd = new System.Random();
        shuffledAnimals = animalList.OrderBy(item => rnd.Next()).ToList<Image>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator SmoothMove(Vector2 startPos, Vector2 endPos, RectTransform animal, float seconds)
    {
        float t = 0.0F;

        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            animal.position = Vector2.Lerp(startPos, endPos, Mathf.SmoothStep(0.0F, 1.0F, Mathf.SmoothStep(0.0F, 1.0F, t)));

            yield return null;
        }
    }
}
