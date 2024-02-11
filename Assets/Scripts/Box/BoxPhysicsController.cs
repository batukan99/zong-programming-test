
using UnityEngine;

namespace Zong.Boxes
{
    public class BoxPhysicsController : MonoBehaviour
    {
        #region Unity Properties
        [field: SerializeField]
        private Box Box;
        #endregion

        #region Unity Methods
        private void Awake()
        {
            
        }

        private void OnCollisionEnter(Collision other) 
        {
            GrabbableObject grabbable;
            if (other.gameObject.TryGetComponent<GrabbableObject>(out grabbable))
            {
                if (!grabbable.IsPicked())
                {
                    Box.OnObjectPlaced(grabbable);
                }
            }
        }
        #endregion
    }

}
