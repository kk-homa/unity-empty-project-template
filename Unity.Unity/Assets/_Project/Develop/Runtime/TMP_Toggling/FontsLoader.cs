using System.Linq;
using TMPro;
using UnityEngine;

public static class FontsLoader
{
    public static void ClearFallbackFonts()
    {
        TMP_Settings.fallbackFontAssets.Clear();
    }
    
    public static void LogLoadedFallbackFonts()
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

    public static void LoadFontFromResources(string fontName)
    {
        TMP_FontAsset font = Resources.Load<TMP_FontAsset>($"Fonts & Materials/{fontName}");
        if (font == null)
        {
            Debug.Log($"failed to load");
            return;
        }
        Debug.Log($"loaded {font}");
        if (TMP_Settings.fallbackFontAssets.Any(f => f.name == font.name))
        {
            Debug.Log($"Was already a fallback {font}");
            return;
        }
        TMP_Settings.fallbackFontAssets.Add(font); 
    }
}