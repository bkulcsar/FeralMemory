using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableForClone : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform origParent = null;
    public Transform dropZoneToReturn = null;
    public bool dropOnParent = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (ErrorHandler.Error.activeSelf || ErrorHandler.Excellent.activeSelf)
        {
            return;
        }
        origParent = this.transform.parent;

        this.transform.SetParent(this.transform.parent.parent);
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        this.GetComponent<LayoutElement>().ignoreLayout = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (ErrorHandler.Error.activeSelf || ErrorHandler.Excellent.activeSelf)
        {
            return;
        }
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (ErrorHandler.Error.activeSelf || ErrorHandler.Excellent.activeSelf)
        {
            return;
        }

        if (dropOnParent)
        {
            this.transform.SetParent(origParent);
            dropOnParent = false;
        }
        else if (origParent != dropZoneToReturn && dropZoneToReturn != null)
        {
            this.transform.SetParent(dropZoneToReturn);
        }
        else
        {
            Destroy(this.gameObject);
            ApplicationModel.orderedAnimalsCount -= 1;
        }

        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
        this.GetComponent<LayoutElement>().ignoreLayout = false;
    }

}
