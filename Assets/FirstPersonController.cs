using UnityEngine;

public class SimpleFPS : MonoBehaviour
{
    public float speed = 5f;
    public float sensitivity = 2f;
    public Camera playerCam;
    public Transform weaponHold; 

    private CharacterController controller;
    private float rotX;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = transform.right * h + transform.forward * v;
        controller.SimpleMove(move * speed);

        
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        transform.Rotate(Vector3.up * mouseX);
        rotX -= mouseY;
        rotX = Mathf.Clamp(rotX, -80f, 80f);
        playerCam.transform.localRotation = Quaternion.Euler(rotX, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Hacha Blendervs3")
        {
            
            if (other.GetComponent<Rigidbody>()) Destroy(other.GetComponent<Rigidbody>());
            if (other.GetComponent<Collider>()) other.GetComponent<Collider>().enabled = false;

            
            other.transform.SetParent(weaponHold);
            other.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;
        }
    }
}
