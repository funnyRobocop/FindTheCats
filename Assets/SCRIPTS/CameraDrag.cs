using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    private Vector3 origin;
    private bool dragging;

    public bool CanMove = true;

    public Vector2 minCameraPos;
    public Vector2 maxCameraPos;

    public float minZoom = 5f;   // Минимальный размер для orthographicSize
    public float maxZoom = 10f;  // Максимальный размер для orthographicSize
    public float zoomSpeed = 0.1f; // Скорость масштабирования

    void Update()
    {
        if(CanMove)
        {
        if (Input.GetMouseButtonDown(0) && Input.touchCount == 0)
        {
            origin = GetWorldPosition();
            dragging = true;
        }

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            origin = GetWorldPosition(Input.GetTouch(0).position);
            dragging = true;
        }

        if (!Input.GetMouseButton(0) && (Input.touchCount == 0 || Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            dragging = false;
        }

        if (dragging)
        {
            Vector3 newPosition = GetWorldPosition() - origin;
            Vector3 cameraPosition = Camera.main.transform.position - newPosition;

            cameraPosition.x = Mathf.Clamp(cameraPosition.x, minCameraPos.x, maxCameraPos.x);
            cameraPosition.y = Mathf.Clamp(cameraPosition.y, minCameraPos.y, maxCameraPos.y);

            Camera.main.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, Camera.main.transform.position.z);
        }

        // Обработка масштабирования
        // Для мультитача на мобильных устройствах
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            Camera.main.orthographicSize += deltaMagnitudeDiff * zoomSpeed;
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom);
        }

        // Для прокрутки колесиком мыши или тачпадом
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - scroll * zoomSpeed, minZoom, maxZoom);
        }
        }
    }

    Vector3 GetWorldPosition(Vector2 screenPosition = default(Vector2))
    {
        if(screenPosition == default(Vector2))
        {
            screenPosition = Input.mousePosition;
        }
        return Camera.main.ScreenToWorldPoint(screenPosition);
    }
}
