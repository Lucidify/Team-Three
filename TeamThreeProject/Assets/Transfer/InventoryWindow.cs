using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryWindow : MonoBehaviour
{
    public int startingPosX;
    public int startingPosY;
    public int slotCountPerPage;
    public int slotCountLength;
    public GameObject itemSlotPrefab;
    public ToggleGroup itemSlotToggleGroup;

    private int xPos;
    private int yPos;
    private GameObject itemSlot;
    private int itemSlotCount;

    void Start()
    {
        CreateInventorySlotsInWindow();
    }

    void Update()
    {

    }

    private void CreateInventorySlotsInWindow()
    {
        xPos = startingPosX;
        yPos = startingPosY;
        for (int i = 0; i < slotCountPerPage; i++)
        {
            itemSlot = (GameObject)Instantiate(itemSlotPrefab);
            itemSlot.name = "Empty";
            itemSlot.GetComponent<Toggle>().group = itemSlotToggleGroup;
            itemSlot.transform.SetParent(this.gameObject.transform);
            itemSlot.GetComponent<RectTransform>().localPosition = new Vector3(xPos, yPos, 0);
            xPos += (int)itemSlot.GetComponent<RectTransform>().rect.width;
            itemSlotCount++;
            if (itemSlotCount % slotCountLength == 0)
            {
                itemSlotCount = 0;
                yPos -= (int)itemSlot.GetComponent<RectTransform>().rect.width;
                xPos = startingPosX;
            }

        }
    }
}
