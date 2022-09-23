using System.Collections;
using System.Collections.Generic;
using EMA.Scripts.PatternClasses;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIElements : MonoSingleton<UIElements>
{
    [SerializeField]  private DynamicJoystick dynamicJoystick;
    [SerializeField] private TMP_Text expText;
    [SerializeField] private Image fuelBar;
    [SerializeField] private TMP_Text plateText;

    [SerializeField] private GameObject respawnPanel;
    [SerializeField] private GameObject gamePanel;
    public DynamicJoystick DynamicJoystick
    {
        get => dynamicJoystick;
        set => dynamicJoystick = value;
    }

    public TMP_Text ExpText
    {
        get => expText;
        set => expText = value;
    }

    public Image FuelBar
    {
        get => fuelBar;
        set => fuelBar = value;
    }
    
    public TMP_Text PlateText
    {
        get => plateText;
        set => plateText = value;
    }

    public GameObject GamePanel
    {
        get => gamePanel;
        set => gamePanel = value;
    }

    public GameObject RespawnPanel
    {
        get => respawnPanel;
        set => respawnPanel = value;
    }
}
