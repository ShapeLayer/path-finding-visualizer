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
        pitch -= config.rotatingSpeed.x * Input.GetAxis("Mouse Y");
        yaw += config.rotatingSpeed.y * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
    void _ProcessingCameraRotatingWithController() {}
    void _ProcessingCameraMovingWithInputManager()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector3(
            horizontal * config.movingSpeed.x,
            rigidbody.velocity.y, // Keyboard, EQ?
            vertical * config.movingSpeed.y
        );
    }
}
