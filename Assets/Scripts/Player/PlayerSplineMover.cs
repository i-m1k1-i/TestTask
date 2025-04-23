using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UIElements;

public class PlayerSplineMover : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SplineContainer splineContainer;
    [SerializeField] private InputReader inputReader;

    [Header("Movement Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lateralSpeed = 3f;
    [SerializeField] private float maxLateralOffset = 2f;
    [SerializeField] private float startPositionOnSpline = 0.01f;
    [SerializeField] private bool stop = true;

    private float t = 0f;
    private float xOffset = 0f;
    private float3 tangent;

    public Vector3 Tangent => (Vector3)tangent;

    public void Stop()
    {
        stop = true;
    }

    public void Go()
    {
        stop = false;
    }

    private void OnEnable()
    {
        startPositionOnSpline = FindTFromPosition(transform.localPosition);
        t = startPositionOnSpline;
    }

    private void Update()
    {
        HandleMove();
    }

    public void HandleMove()
    {
        if (stop)
            return;
        if (splineContainer == null)
            return;

        float splineLength = splineContainer.Spline.GetLength();
        t += (speed / splineLength) * Time.deltaTime;
        t = Mathf.Clamp01(t);

        splineContainer.Spline.Evaluate(t, out float3 pos, out tangent, out _);
        Vector3 position = (Vector3)pos;

        Vector3 right = Vector3.Cross(Vector3.up, tangent).normalized;

        xOffset += inputReader.MoveInput * lateralSpeed * Time.deltaTime;
        xOffset = Mathf.Clamp(xOffset, -maxLateralOffset, maxLateralOffset);

        transform.localPosition = position + right * xOffset;
        transform.forward = tangent;
    }

    private float FindTFromPosition(Vector3 position)
    {
        var spline = splineContainer.Spline;

        SplineUtility.GetNearestPoint(spline, (float3)position, out float3 nearest, out float t);

        return t;
    }
}
