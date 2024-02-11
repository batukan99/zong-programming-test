using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickupController : MonoBehaviour
{
    #region Unity Properties
    [field: SerializeField]
    private InputActionProperty InteractInputAction;
    [field: SerializeField]
    private Transform cameraTransform;

    [field: SerializeField]
    private Transform grabPointTransform;

    [field: SerializeField]
    private LayerMask grabLayerMask;
    #endregion
    private CharacterController characterController => GetComponent<CharacterController>();
    private IGrabbable grabbable;
    private float grabDistance = 2f;

    #region Unity Methods	
    private void Start()
    {
        InteractInputAction.action.performed += this.OnInteractAction;
    }

    #endregion

    #region Private Methods
    private void OnInteractAction(InputAction.CallbackContext actionID)
    {
        if(grabbable == null) 
        {
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit raycastHit, grabDistance, grabLayerMask)) 
            {
                if (raycastHit.transform.TryGetComponent(out grabbable)) 
                {
                    grabbable.Grab(grabPointTransform, characterController);
                }
            }
        }
        else 
        {
            grabbable.Drop();
            grabbable = null;
        }
    }
    #endregion
}
