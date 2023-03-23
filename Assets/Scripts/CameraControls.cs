using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    private Vector3 touchStart;

    [SerializeField] private float zoomMin;
    [SerializeField] private float zoomMax;

    [SerializeField] private float cameraDragXClampDistance;
    [SerializeField] private float cameraDragYClampDistance;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Zoom(difference * 0.01f);
        }
        else if (Input.GetMouseButton(0))
        {
            AdjustCameraDrag();
        }
    }

    private void AdjustCameraDrag()
    {
        Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newPosition = new Vector3(Mathf.Clamp(Camera.main.transform.position.x + direction.x, -GetCurrentXDragClamp(), GetCurrentXDragClamp()),
            Mathf.Clamp(Camera.main.transform.position.y + direction.y, -GetCurrentYDragClamp(), GetCurrentYDragClamp()),
            Camera.main.transform.position.z);
        Camera.main.transform.position = newPosition;
    }

    private float GetCurrentXDragClamp()
    {
        float differenceBetweenZoomMinMax = zoomMax - zoomMin;
        float currentAdjustedZoom = Camera.main.orthographicSize - zoomMin;
        float zoomPercent = currentAdjustedZoom / differenceBetweenZoomMinMax;

        float currentDragClamp = cameraDragXClampDistance - (cameraDragXClampDistance * zoomPercent);

        return currentDragClamp;

    }

    private float GetCurrentYDragClamp()
    {
        float differenceBetweenZoomMinMax = zoomMax - zoomMin;
        float currentAdjustedZoom = Camera.main.orthographicSize - zoomMin;
        float zoomPercent = currentAdjustedZoom / differenceBetweenZoomMinMax;

        float currentDragClamp = cameraDragYClampDistance - (cameraDragYClampDistance * zoomPercent);

        return currentDragClamp;
    }

    private void Zoom(float _amount)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - _amount, zoomMin, zoomMax);
        Vector3 newPosition = new Vector3(Mathf.Clamp(Camera.main.transform.position.x, -GetCurrentXDragClamp(), GetCurrentXDragClamp()),
            Mathf.Clamp(Camera.main.transform.position.y, -GetCurrentYDragClamp(), GetCurrentYDragClamp()),
            Camera.main.transform.position.z);
        Camera.main.transform.position = newPosition;
    }

    public void ZoomIn()
    {
        Zoom(1);
    }

    public void ZoomOut()
    {
        Zoom(-1);
    }
}
