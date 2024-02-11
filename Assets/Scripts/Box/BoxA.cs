using UnityEngine;
using EasyUI.Toast;
using Zong.Sound;
using Zong.Particle;

namespace Zong.Boxes
{
    public class BoxA : Box
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
            var message = grabbable.name.ToString() + " is dropped in BoxA";
            Toast.Show(message, 1.5f);
            Singleton<SoundManager>.Instance.PlayBoxASound(audioSource);
            Singleton<ParticleManager>.Instance.CreateSparkParticle(grabbable.transform);
        }
        #endregion

    }

}