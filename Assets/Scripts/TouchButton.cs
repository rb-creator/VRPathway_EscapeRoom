// 7/10/2024 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TouchButton : XRBaseInteractable
{
    private Renderer buttonRenderer;
    public Color defaultColor = Color.white;
    public Color hoverColor = Color.green;
    public string buttonValue;
    public NumberPad numberPad; // Reference to the NumberPad script

    protected override void Awake()
    {
        base.Awake();
        buttonRenderer = GetComponent<Renderer>();
        buttonRenderer.material.color = defaultColor;
    }

    private void Start() 
    {
        numberPad = FindObjectOfType<NumberPad>();

       TextMeshProUGUI textBox = GetComponentInChildren<TextMeshProUGUI>();
       if (textBox != null)
       {
            buttonValue = textBox.text;
       } 
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        buttonRenderer.material.color = hoverColor;
        numberPad.AddDigit(buttonValue); // Update number pad input
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        buttonRenderer.material.color = defaultColor;
    }
}