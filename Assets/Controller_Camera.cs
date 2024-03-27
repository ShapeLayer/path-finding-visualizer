using UnityEngine;

public class Controller_Camera : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Config_Camera config = new Config_Camera();
    public Config_Rigidbody configRigidbody = new Config_Rigidbody(useGravity: false);
    public bool enableCameraMoving = false;
    private float yaw = .0f;
    private float pitch = 45.0f;

    void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        EnableCameraMoving();
        configRigidbody.Apply(this.rigidbody);
    }
    void Update()
    {
        ProcessingCameraMoving();
        ProcessingCameraRotating();
        ProcessingKeyInterruptEvent();
    }

    public void ProcessingKeyInterruptEvent()
    {
        if (Input.GetAxis("Cancel") > 0)
        {
            DisableCameraMoving();
        }
        if (!this.enableCameraMoving)
        {
            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
            {
                EnableCameraMoving();
            }
        }
    }

    public void EnableCameraMoving()
    {
        this.enableCameraMoving = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void DisableCameraMoving()
    {
        this.enableCameraMoving = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    
    void ProcessingCameraMoving()
    {
        _ProcessingCameraMovingWithInputManager();
    }

    void ProcessingCameraRotating()
    {
        if (enableCameraMoving) {
            _ProcessingCameraRotatingWithMouse();
            _ProcessingCameraRotatingWithController();
        }
    }
    void _ProcessingCameraRotatingWithMouse()
    {
        pitch -= this.config.rotatingSpeed.x * Input.GetAxis("Mouse Y");
        yaw += this.config.rotatingSpeed.y * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
    void _ProcessingCameraRotatingWithController() {}
    void _ProcessingCameraMovingWithInputManager()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        float vector3Y = Input.GetAxis("Vector3Y");
        rigidbody.velocity = new Vector3(
            horizontal * this.config.movingSpeed.x,
            vector3Y * this.config.movingSpeed.y, // Keyboard, EQ?
            vertical * this.config.movingSpeed.z
        );
    }
}
