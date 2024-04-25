using System;
using System.Collections.Generic;
using TMPro;
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
        clear.onClick.AddListener(ClearFallbackFonts);
        add.onClick.AddListener(LoadAndAddFallbackFonts);
        toggle.onClick.AddListener(TogglePanel);
    }

    private void TogglePanel()
    {
        panel.SetActive(!panel.activeSelf);
    }

    private void LoadAndAddFallbackFonts()
    {
        LoadFontSC();
    }

    private void ClearFallbackFonts()
    {
        TMP_Settings.fallbackFontAssets.Clear();
    }

    [ContextMenu("Log fallbacks")]
    public void LogLoadedFallbackFonts()
    {
        var fallbackFontAssets = TMP_Settings.fallbackFontAssets;
        if (fallbackFontAssets == null || fallbackFontAssets.Count <= 0)
        {
            Debug.Log("No fallbacks");
            return;
        }
        foreach (var fontAsset in fallbackFontAssets)
        {
            Debug.Log(fontAsset.name);    
        }
        
    }
    
    [ContextMenu("Load and assign SC font")]
    public void LoadFontSC()
    {
        TMP_FontAsset font = Resources.Load<TMP_FontAsset>("Fonts & Materials/NotoSansSC-Regular SDF");
        if (font == null)
        {
            Debug.Log($"failed to load");
            return;
        }
        Debug.Log($"loaded {font}");
        TMP_Settings.fallbackFontAssets.Add(font); 
    }
}
