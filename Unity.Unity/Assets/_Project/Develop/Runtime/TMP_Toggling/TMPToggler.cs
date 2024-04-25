using UnityEngine;
using UnityEngine.UI;

public class TMPToggler : MonoBehaviour
{
    [SerializeField] private Button clear;
    [SerializeField] private Button add;
    [SerializeField] private Button toggle;
    [SerializeField] private GameObject panel;

    private void Awake()
    {
        clear.onClick.AddListener(FontsLoader.ClearFallbackFonts);
        add.onClick.AddListener(LoadAndAddFallbackFonts);
        toggle.onClick.AddListener(TogglePanel);
    }

    private void TogglePanel()
    {
        panel.SetActive(!panel.activeSelf);
    }

    private void LoadAndAddFallbackFonts()
    {
        FontsLoader.LoadFontFromResources("NotoSansSC-Regular SDF");
    }
}
