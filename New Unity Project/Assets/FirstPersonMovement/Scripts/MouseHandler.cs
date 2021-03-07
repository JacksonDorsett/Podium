using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    // horizontal rotation speed
    public float horizontalSpeed = 1f;
    // vertical rotation speed
    public float verticalSpeed = 1f;
    public float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private Camera cam;

    public Vector3 HorizontalDirection
    {
        get
        {
            Vector3 direction = new Vector3(Mathf.Sin(yRotation), 0, Mathf.Cos(yRotation)).normalized;
            return direction;
        }
    }
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

        yRotation += mouseX;
        xRotation -= mouseY;
        //xRotation = Mathf.Clamp(xRotation, 0, 90);

        cam.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
    }
}
