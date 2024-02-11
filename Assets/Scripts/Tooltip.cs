using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tooltip : MonoBehaviour
{
    #region Unity Properties
    [field: SerializeField]
    LineRenderer lineRenderer;

    [field: SerializeField]
    RectTransform panel;
    
    [field: SerializeField]
    TextMeshProUGUI textMesh;

    [field: SerializeField]
    VerticalBillboard verticalBillboard;

    [field: SerializeField]
    bool isStatic;
    #endregion

    #region Fields
    System.IDisposable lineDisposable;

    Vector3 nearestPointInWorld;

    Vector3 nearestVertexInLocal;
    #endregion

    #region Unity Methods
    /// <inheritdoc />
    protected virtual void OnDestroy() => this.lineDisposable?.Dispose();

    protected virtual void Start()
    {
        if (this.isStatic)
        {
            this.Show();
        }
    }
    #endregion

    #region Public Methods
    #region Initialization
    public void Initialize(Transform target, string text, bool isDrawLine = true, bool isLookCamera = false)
    {
        this.textMesh.text = text;

        if (isDrawLine)
        {
            this.nearestVertexInLocal = NearestVertexInLocal(target, this.transform.position);
            this.nearestPointInWorld = target.transform.TransformPoint(this.nearestVertexInLocal);
            this.DrawLine(this.nearestPointInWorld, this.verticalBillboard.transform.position);


            /*this.lineDisposable = this.transform.ObserveEveryValueChanged(x => x.position)
                .Subscribe(x =>
                    this.DrawLine(
                        target.transform.TransformPoint(this.nearestVertexInLocal),
                        this.verticalBillboard.transform.position));*/
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(this.panel);
        this.verticalBillboard.enabled = isLookCamera;
    }

    public void Initialize(Transform target, string text, Vector3 distance)
    {
        this.verticalBillboard.transform.position = this.nearestPointInWorld + distance;
        this.Initialize(target, text);
    }
    #endregion

    public void Hide() => this.gameObject.SetActive(false);

    public void Show()
    {
        this.gameObject.SetActive(true);
        LayoutRebuilder.ForceRebuildLayoutImmediate(this.panel);
    }
    #endregion

    #region Static Methods
    static Vector3 NearestVertexInLocal(Transform target, Vector3 point)
    {
        if (!target.TryGetComponent(out MeshFilter meshFilter))
        {
            meshFilter = target.GetComponentInChildren<MeshFilter>();
        }

        if (meshFilter == null)
        {
            return target.transform.position;
        }

        // Convert point to local space
        point = meshFilter.transform.InverseTransformPoint(point);

        var mesh = meshFilter.sharedMesh;
        var minDistanceSqr = Mathf.Infinity;
        var nearestVertex = Vector3.zero;

        // Scan all vertices to find nearest
        foreach (var vertex in mesh.vertices)
        {
            var diff = point - vertex;
            var distSqr = diff.sqrMagnitude;

            if (distSqr < minDistanceSqr)
            {
                minDistanceSqr = distSqr;
                nearestVertex = vertex;
            }
        }

        return nearestVertex;
    }
    #endregion

    #region Methods
    void DrawLine(Vector3 source, Vector3 target)
    {
        this.lineRenderer.positionCount = 2;
        this.lineRenderer.SetPosition(0, source);
        this.lineRenderer.SetPosition(1, target);
    }
    #endregion
}
