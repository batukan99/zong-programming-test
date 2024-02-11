using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Zong.Inventory 
{
    public class Slot : MonoBehaviour
    {
        [field: SerializeField]
        private Image icon;

        #region Public Methods
        public void ClearSlot()
        {
            icon.enabled = false;
        }
        public void DrawSlot(Item item)
        {
            if(item == null)
            {
                ClearSlot();
                return;
            }

            icon.enabled = true;
            icon.sprite = item.ItemData.icon;
        }
        #endregion
        
    }

}
