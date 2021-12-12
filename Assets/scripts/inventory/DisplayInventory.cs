using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject currentItem;
    public GameObject player;
    public int selectedObject;
    public int start;
    public int SpaceBetween;
    public int numberOf;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();

        if (Input.GetKey(KeyCode.Alpha1))
        {
            selectedObject = 1;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            selectedObject = 2;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            selectedObject = 3;
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            selectedObject = 4;
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            selectedObject = 5;
        }
    }

    public void CreateDisplay()
    {
        for( int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if(itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
        //var otherObj = Instantiate(currentItem, Vector3.zero, Quaternion.identity, transform);
        //otherObj.GetComponent<RectTransform>().localPosition = GetPosition(selectedObject);
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(start + (SpaceBetween * (i % numberOf)), 0f, 0f);
    }
}
