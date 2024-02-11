
using UnityEngine;

public interface IGrabbable
{
    public Transform GrabTransform {get; set;}
    public Rigidbody Rigidbody {get; set;}
    public void Grab(Transform grabTransform);
    public void Drop();
}
