using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Zong.Inventory
{
    [Serializable]
    public class Item
    {
        public ItemData ItemData;
        public Item(ItemData item)
        {
            this.ItemData = item;
        }
    }

}
