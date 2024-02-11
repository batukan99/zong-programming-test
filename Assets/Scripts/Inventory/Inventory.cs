using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zong.Inventory
{
    public class Inventory : MonoBehaviour
    {
        public static event Action<List<Item>> OnInventoryChanged;
        public List<Item> inventory = new();
        private Dictionary<ItemData, Item> itemDictionary = new();

        #region Unity Methods
        private void OnEnable()
        {
            GrabbableObject.OnObjectCollected += Add;
            GrabbableObject.OnObjectDropped += Remove;
        }
        private void OnDisable()
        {
            GrabbableObject.OnObjectCollected -= Add;
            GrabbableObject.OnObjectDropped -= Remove;
        }
        #endregion

        #region Public Methods
        public void Add(ItemData itemData)
        {
            
            Item newItem = new Item(itemData);
            print(newItem);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            OnInventoryChanged?.Invoke(inventory);
        }

        public void Remove(ItemData itemData)
        {
            if(itemDictionary.TryGetValue(itemData, out Item item))
            {
                inventory.Remove(item);
                itemDictionary.Remove(itemData);
                OnInventoryChanged?.Invoke(inventory);
            }
        }
        #endregion
        
    }
}