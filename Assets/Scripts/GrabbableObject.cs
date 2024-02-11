using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour, IGrabbable
{
    [field: SerializeField]
    private Tooltip Tooltip;
    public Transform GrabTransform {get; set;}
    public Rigidbody Rigidbody {get; set;}
    private float lerpSpeed = 10f;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    public void Grab(Transform grabTransform) 
    {
        this.GrabTransform = grabTransform;
        this.Rigidbody.useGravity = false;
        this.Tooltip.gameObject.SetActive(false);
    }
    public void Drop() 
    {
        this.GrabTransform = null;
        this.Rigidbody.useGravity = true;
        this.Tooltip.gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (GrabTransform != null) 
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, GrabTransform.position, Time.deltaTime * lerpSpeed);
            Rigidbody.MovePosition(newPosition);
        }   
    }
}
