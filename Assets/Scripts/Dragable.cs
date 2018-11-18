using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturn = null;
    public Transform origParent = null;
    GameObject clone;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (ErrorHandler.Error.activeSelf || ErrorHandler.Excellent.activeSelf)
        {
            return;
        }
        parentToReturn = this.transform.parent;
        origParent = this.transform.parent;
        
        //Clone part
        clone = Instantiate(this.gameObject, this.transform);
        eventData.selectedObject = clone;
        clone.transform.SetParent(this.transform.parent.parent);
        clone.GetComponent<CanvasGroup>().blocksRaycasts = false;
        clone.GetComponent<LayoutElement>().ignoreLayout = true;
        clone.gameObject.name = this.gameObject.name;
        clone.AddComponent<DragableForClone>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (ErrorHandler.Error.activeSelf || ErrorHandler.Excellent.activeSelf)
        {
            return;
        }
        clone.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (ErrorHandler.Error.activeSelf || ErrorHandler.Excellent.activeSelf)
        {
            return;
        }
        if (origParent != parentToReturn)
        {
            clone.transform.SetParent(parentToReturn);
            Destroy(clone.GetComponent<Dragable>());
        }
        else
        {
            Destroy(clone.gameObject);
        }
        
        clone.GetComponent<CanvasGroup>().blocksRaycasts = true;
        clone.GetComponent<LayoutElement>().ignoreLayout = false;

        LevelStructure level = new LevelStructure();

        if (origParent != parentToReturn && ApplicationModel.orderedAnimalsCount == level.AnimalsToOrderCount)
        {
            if (!CheckAnimalOrder())
            {
                ErrorHandler.Error.SetActive(true);
            }
            else
            {
                ApplicationModel.CurrentLevel++;
                ApplicationModel.CurrentBoneNumber++;

                if (FirebaseAuthHelper.Auth.CurrentUser != null)
                {
                    ApplicationModel.SaveLocalUserData(FirebaseAuthHelper.Auth.CurrentUser.UserId);
                    FirebaseDatabaseHandler.SaveCloudUserData(FirebaseAuthHelper.Auth.CurrentUser.UserId);
                }
                else
                {
                    ApplicationModel.SaveLocalUserData("notRegisteredUser");
                }            

                ErrorHandler.Excellent.SetActive(true);
            }
            ApplicationModel.orderedAnimalsCount = 0;
        }
    }

    private Boolean CheckAnimalOrder()
    {
        Boolean ret = true;

        foreach (DropZone dropZone in this.transform.parent.parent.GetComponentsInChildren<DropZone>())
        {
            if (dropZone.name != dropZone.transform.GetChild(1).name)
            {
                ret = false;
                dropZone.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.gray;
            }
        }

        return ret;
    }
}
