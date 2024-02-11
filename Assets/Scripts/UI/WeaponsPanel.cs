
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zong.UI
{
    public class WeaponsPanel : Panel
    {
        #region Public Methods
        public override void ClosePanel()
        {
            base.ClosePanel();
            Singleton<UIManager>.Instance.EnableMainPanel();
        }
        #endregion
    }
}
