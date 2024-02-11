using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zong.Sound;
using Zong.UI;

public class GrabbableObject : MonoBehaviour, IGrabbable
{
    #region Unity Properties
    [field: SerializeField]
    protected AudioSource audioSource;
    
    [field: SerializeField]
    private Tooltip Tooltip;
    #endregion
    public Transform GrabTransform {get; set;}
    public Rigidbody Rigidbody {get; set;}

    public static event HandleObjectCollected OnObjectCollected;
    public delegate void HandleObjectCollected(ItemData itemData);
    public static event HandleObjectDropped OnObjectDropped;
    public delegate void HandleObjectDropped(ItemData itemData);
    public ItemData StoneItemData;
    public void SetItemData() => StoneItemData = Resources.Load<ItemData>("StoneItemData");
    
    public bool IsPicked() => isPicked;
    private bool isPicked = false;
    private float lerpSpeed = 10f;

   
    #region Unity Methods
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        SetItemData();
    }
    private void FixedUpdate()
    {
        if (GrabTransform != null) 
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, GrabTransform.position, Time.deltaTime * lerpSpeed);
            Rigidbody.MovePosition(newPosition);
        }   
    }
    #endregion

    #region Public Methods
    public void Grab(Transform grabTransform) 
    {
        this.isPicked = true;
        this.GrabTransform = grabTransform;
        this.Rigidbody.useGravity = false;
        this.Tooltip.gameObject.SetActive(false);
        OnObjectCollected?.Invoke(StoneItemData);
        Singleton<UIManager>.Instance.EnableMainPanel();
        Singleton<SoundManager>.Instance.PlayItemPickupSound(audioSource);
    }
    public void Drop() 
    {
        this.isPicked = false;
        this.GrabTransform = null;
        this.Rigidbody.useGravity = true;
        //this.Tooltip.gameObject.SetActive(true);
        OnObjectDropped?.Invoke(StoneItemData);
        Singleton<SoundManager>.Instance.PlayItemDropSound(audioSource);
    }
    #endregion

}
