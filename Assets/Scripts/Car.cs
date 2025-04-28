using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;  // Reference to UIManager

    private void OnMouseDown()
    {
        // When the car is clicked, toggle its UI
        if (uiManager != null)
        {
            Debug.Log("Car clicked: " + gameObject.name);
            uiManager.ToggleTextExclusive();  // Calls ToggleTextExclusive on the UIManager
        }
    }
}
