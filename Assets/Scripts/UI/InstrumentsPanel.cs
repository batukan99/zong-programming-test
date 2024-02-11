using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zong.Inventory;

namespace Zong.UI
{
    public class InstrumentsPanel : Panel
    {
        
        #region Public Methods
        public override void PreparePanel()
        {
            base.PreparePanel();
            Cursor.visible = true;
        }
        public override void ClosePanel()
        {
            base.ClosePanel();
            Singleton<UIManager>.Instance.EnableMainPanel();
        }
        #endregion
    }
}
