using UnityEngine;
using EasyUI.Toast;
using Zong.Sound;
using Zong.Commands;

namespace Zong.Boxes
{
    public class BoxC : Box
    {
        #region Unity Properties

        #endregion
        #region Unity Methods
        private void Awake()
        {
            
        }

        #endregion
        #region Public Methods
        public override void OnObjectPlaced(GrabbableObject grabbable) 
        {
            base.OnObjectPlaced(grabbable);
            var message = "Go Back to Event 2";
            Toast.Show(message, 1.5f);
            Singleton<SoundManager>.Instance.PlayBoxCSound(audioSource);
            Singleton<CommandManager>.Instance.OnPopCommand();
        }
        #endregion

    }

}