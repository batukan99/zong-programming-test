
using UnityEngine;
using DG.Tweening;
using Zong.Sound;

namespace Zong.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Panel : MonoBehaviour
    {
    
        private CanvasGroup canvasGroup;

        #region Unity Methods
        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
        #endregion

        #region Public Methods
        public virtual void PreparePanel()
        {
            Singleton<SoundManager>.Instance.PlayPanelOpenSound();
        }
        public virtual void ClosePanel()
        {
            SetActiveSmooth(false, 0.25f);
            Singleton<SoundManager>.Instance.PlayPanelCloseSound();
        }
        public void SetActiveImmediately(bool isActive)
        {
            if (canvasGroup == null)
            {
                canvasGroup = GetComponent<CanvasGroup>();
                Debug.Log("Panel's canvas group reference was null.");
            }

            canvasGroup.DOKill();

            canvasGroup.alpha = isActive ? 1f : 0f;
            gameObject.SetActive(isActive);
        }

        public void SetActiveSmooth(bool isActive, float duration = 0.3f)
        {
            canvasGroup.DOKill();

            if (isActive)
            {
                gameObject.SetActive(true);
                canvasGroup.DOFade(1f, duration);
            }
            else
            {
                canvasGroup.DOFade(0f, duration).OnComplete(() => gameObject.SetActive(false));
            }
        }
        #endregion
    }
}

