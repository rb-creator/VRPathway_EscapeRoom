// 7/10/2024 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberPad : MonoBehaviour
{
    public string correctCode = "1234";
    private string currentInput = "";
    public Transform keycardDispenser;
    public GameObject keycardPrefab;
    public TextMeshProUGUI codeTextBox; // Assign this in the inspector to reference the UI Text component

    public void AddDigit(string digit)
    {
        currentInput += digit;
        Debug.Log("Current input: " + currentInput);
        UpdateDisplay();

        if (currentInput.Length >= correctCode.Length)
        {
            if (currentInput == correctCode)
            {
                SpawnKeycard();
            }
            ResetNumberPad();
        }
    }

    private void UpdateDisplay()
    {
        if (codeTextBox != null)
        {
            codeTextBox.text = currentInput;
        }
    }

    private void SpawnKeycard()
    {
        if (keycardPrefab != null && keycardDispenser != null)
        {
            Instantiate(keycardPrefab, keycardDispenser.position, Quaternion.identity);
        }
    }

    private void ResetNumberPad()
    {
        currentInput = "";
        UpdateDisplay();
    }
}