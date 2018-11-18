using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();

        if (d == null)
        {
            var dForClone = eventData.pointerDrag.GetComponent<DragableForClone>();

            if (dForClone != null)
            {
                if (dForClone.origParent == this.transform)
                {
                    dForClone.dropOnParent = true;
                }
                else
                {
                    dForClone.dropZoneToReturn = this.transform;
                }
            }
        }
        else
        {
            var child = this.transform.childCount;
            if (child == 2)
            {
                return;
            }
            d.parentToReturn = this.transform;
            ApplicationModel.orderedAnimalsCount += 1;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
