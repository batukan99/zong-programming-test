using UnityEngine;

namespace Zong.Boxes
{
    public class Box : MonoBehaviour
    {
        #region Unity Properties
        [field: SerializeField]
        protected AudioSource audioSource;
        #endregion
        #region Unity Methods
        private void Awake()
        {
            
        }

        #endregion
        #region Public Methods
        public virtual void OnObjectPlaced(GrabbableObject grabbable) 
        {
        }
        #endregion

    }

}