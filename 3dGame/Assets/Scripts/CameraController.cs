using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    private float _mouseX;
    private float _mouseY;

    [Header("Sensitivity mouse")]
    public float sensitivityMouse = 200f;

    public bool invertedCameraRotation;

    public Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        _mouseX = Input.GetAxis("Mouse X") * sensitivityMouse * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * sensitivityMouse * Time.deltaTime;
        
        var transform1 = transform;
        transform1.localPosition = player.position;
        if (!invertedCameraRotation)
        {
            player.Rotate(_mouseX * new Vector3(0, 1, 0));
            player.position.Set(0, 0, transform1.localPosition.z);
            transform1.Rotate(_mouseX * new Vector3(0, 1, 0));
            transform1.Rotate(-_mouseY * new Vector3(1, 0, 0));
        }
        else
        {
            player.Rotate(-_mouseX * new Vector3(0, 1, 0));
            player.position.Set(0, 0, transform1.localPosition.z);
            transform1.Rotate(-_mouseX * new Vector3(0, 1, 0));
            transform1.Rotate(_mouseY * new Vector3(1, 0, 0));
        }
    }
}
