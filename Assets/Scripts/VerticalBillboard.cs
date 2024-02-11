
using UnityEngine;

public class VerticalBillboard : MonoBehaviour
{
    #region Fields
    Transform cam;
    #endregion

    #region Properties
    public Transform Camera
    {
        get => this.cam != null ? this.cam : (this.cam = UnityEngine.Camera.main.transform);
        protected set => this.cam = value;
    }
    #endregion

    #region Unity Methods
    /// <inheritdoc />
    protected virtual void Update()
    {
        this.transform.LookAt(this.Camera.position, Vector3.up);
    }
    #endregion
}
