using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
    private List<Item> itemList;
    private int maxInventory;
    private int currentInventory;

    public playerInventory(int max )
    {
        itemList = new List<Item>();
        maxInventory = max;
        currentInventory = 0;
    }

    public void addItem(Item item)
    {
        if( currentInventory < maxInventory)
        {
            itemList.Add(item);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
