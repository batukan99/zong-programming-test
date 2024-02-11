using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zong.Inventory 
{
    public class InventoryManager : MonoBehaviour
    {
        #region Unity Properties
        [field: SerializeField]
        private Transform slotsParentTransform;
        #endregion   
        public List<Slot> inventorySlots;

        #region Unity Methods
        private void Awake()
        {
           InitializeInventory();
        }
        private void OnEnable()
        {
            Inventory.OnInventoryChanged += UpdateInventory;
        }
        private void OnDestroy()
        {
            Inventory.OnInventoryChanged -= UpdateInventory;   
        }
        #endregion

        #region Public Methods
        public void InitializeInventory()
        {
            foreach (Transform child in slotsParentTransform)
            {
                inventorySlots.Add(child.GetComponent<Slot>());
            }
        }
        public void ClearInventory()
        {
            for(int i = 0; i < inventorySlots.Count; i++)
            {
                inventorySlots[i].ClearSlot();
            }
        }
        public void UpdateInventory(List<Item> inventory)
        {
            ClearInventory();
            for(int i = 0; i < inventory.Count; i++)
            {
                inventorySlots[i].DrawSlot(inventory[i]);
            }
        }
        #endregion
    }

}
