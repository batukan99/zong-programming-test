using UnityEngine;
using EasyUI.Toast;
using Zong.Sound;
using Zong.Particle;

namespace Zong.Boxes
{
    public class BoxB : Box
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
            var message = grabbable.name.ToString() + " is dropped in BoxB";
            Toast.Show(message, 1.5f);
            Singleton<SoundManager>.Instance.PlayBoxBSound(audioSource);
            Singleton<ParticleManager>.Instance.CreateEtheralParticle(grabbable.transform);
        }
        #endregion

    }

}