using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Zong.UI
{
    public class MainPanel : Panel
    {
        public TextMeshProUGUI scoreText;

        #region Public Methods
        public override void PreparePanel()
        {
            base.PreparePanel();
            SetScoreText(15);
            Cursor.visible = true;
        }
        public override void ClosePanel()
        {
            base.ClosePanel();
            Cursor.visible = false;
        }
        public void EnableWeaponsPanel()
        {
            Singleton<UIManager>.Instance.EnableWeaponsPanel();
        }
        public void EnableInstrumentsPanel()
        {
            Singleton<UIManager>.Instance.EnableInstrumentsPanel();
        }

        public void SetScoreText(int score)
        {
            scoreText.text = score.ToString();
        }
        #endregion
        
    }
}
