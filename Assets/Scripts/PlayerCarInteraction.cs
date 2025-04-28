using UnityEngine;

public class PlayerCarInteraction : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject car;
    [SerializeField] private Transform carSeat;
    [SerializeField] private Transform exitPoint;
    [SerializeField] private MonoBehaviour playerController;
    [SerializeField] private MonoBehaviour carController;
    [SerializeField] private float interactDistance = 3f;
    
    [Header("Camera Settings")]
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject carCamera;
    [SerializeField] private bool enableCameraSwitch = true;

    private bool inCar = false;

    void Start()
    {
        carController.enabled = false;
        if (carCamera != null) carCamera.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (inCar)
            {
                ExitCar();
            }
            else
            {
                float distance = Vector3.Distance(player.transform.position, car.transform.position);
                if (distance <= interactDistance)
                {
                    EnterCar();
                }
            }
        }
    }

    void EnterCar()
    {
        inCar = true;
        
        // Handle player
        player.transform.position = carSeat.position;
        player.transform.rotation = carSeat.rotation;
        player.transform.SetParent(car.transform);
        player.SetActive(false);
        player.GetComponent<Collider>().enabled = false;
        
        // Enable car controls
        carController.enabled = true;
        
        // Handle cameras
        if (enableCameraSwitch)
        {
            if (playerCamera != null) playerCamera.SetActive(false);
            if (carCamera != null) carCamera.SetActive(true);
        }
    }

    void ExitCar()
    {
        inCar = false;
        
        // Handle player
        player.transform.SetParent(null);
        player.transform.position = exitPoint.position;
        player.SetActive(true);
        player.GetComponent<Collider>().enabled = true;
        
        // Disable car controls
        carController.enabled = false;
        
        // Handle cameras
        if (enableCameraSwitch)
        {
            if (playerCamera != null) playerCamera.SetActive(true);
            if (carCamera != null) carCamera.SetActive(false);
        }

        // Stop car movement
        Rigidbody rb = car.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}