using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PanelController : MonoBehaviour
{
    private GraphicRaycaster graphicRaycaster;
    private EventSystem eventSystem;
    public GameObject emptyItemUI;

    void Start()
    {
        if (graphicRaycaster == null)
            graphicRaycaster = FindObjectOfType<GraphicRaycaster>();

        if (eventSystem == null)
            eventSystem = FindObjectOfType<EventSystem>();
    }

    public void CheckOverlap(GameObject draggedObject)
    {
        UI_Item draggedItem = draggedObject.GetComponent<UI_Item>();

        PointerEventData pointerData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerData, results);

        UI_Item droppedItem = null;
        if (results.Count > 0)
        {
            if (draggedObject == results[0].gameObject)
            {
                if (results.Count > 1)
                {
                    droppedItem = results[1].gameObject.GetComponent<UI_Item>();
                }
            }

            else
            {
                droppedItem = results[0].gameObject.GetComponent<UI_Item>();
            }
            
            Debug.Log("Týklanan UI Elemaný: " + droppedItem.name);
        }

        if (droppedItem == null) return;

        string foundRecipeId = ItemDatabase.Instance.checkForRecipe(draggedItem.item.itemId, droppedItem.item.itemId);

        if (foundRecipeId == null) return;

        Debug.Log(ItemDatabase.Instance.getItemDataById(foundRecipeId));

        Instantiate(emptyItemUI, droppedItem.transform.position, Quaternion.identity, transform).GetComponent<UI_Item>().GenerateItem(foundRecipeId);
        Destroy(droppedItem.gameObject);
        Destroy(draggedItem.gameObject);
    }

}
