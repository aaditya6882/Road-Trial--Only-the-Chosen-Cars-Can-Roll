using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text InformationText;  // Reference to the text displaying information
    [SerializeField] private Canvas UICanvas;  // Reference to the canvas

    // Ensure the text is hidden when the game starts
    void Start()
    {
        if (InformationText != null)
        {
            InformationText.gameObject.SetActive(false);  // Initially hide the text
        }

        if (UICanvas != null)
        {
            UICanvas.gameObject.SetActive(false);  // Initially hide the canvas
        }
    }

    // Show only the UI elements for the clicked car
    public void ToggleTextExclusive()
    {
        Debug.Log("Toggling text visibility for: " + gameObject.name);

        // Hide information for all other cars' UI elements
        foreach (var ui in FindObjectsOfType<UIManager>())
        {
            if (ui != this)
            {
                if (ui.InformationText != null)
                    ui.InformationText.gameObject.SetActive(false);

                if (ui.UICanvas != null)
                    ui.UICanvas.gameObject.SetActive(false);
            }
        }

        // Toggle visibility for this car's UI
        if (UICanvas != null)
            UICanvas.gameObject.SetActive(true);

        if (InformationText != null)
            InformationText.gameObject.SetActive(true);
    }
}
