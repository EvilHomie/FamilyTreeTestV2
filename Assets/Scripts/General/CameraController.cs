using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera mainCam;

    float minFOV = 50f;
    float maxFOV = 120f;
    float zoomSensitivity = 10f;
    float moveSensitivity = 600f;

    private void Awake()
    {
        mainCam = GetComponent<Camera>();
    }

    void Update()
    {
        ZoomController();
        OffsetController();
    }


    void ZoomController()
    {
        float newFOV = mainCam.fieldOfView;
        newFOV -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
        newFOV = Mathf.Clamp(newFOV, minFOV, maxFOV);
        Camera.main.fieldOfView = newFOV;
    }

    void OffsetController()
    {
        Vector3 Movement = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        mainCam.transform.position += moveSensitivity * Time.deltaTime * Movement.normalized;
    }
}
