using System;
using Unity.Reflect.Runtime;
using Unity.Reflect.Utils;
using UnityEditor;
using UnityEngine;

public class ReflectRegionSwitcher : MonoBehaviour
{
    const string k_RegionMenuUS = "Window/Reflect/Region/US";
    const string k_RegionMenuUK = "Window/Reflect/Region/UK";
    const string k_RegionMenuChina = "Window/Reflect/Region/China";

    [MenuItem(k_RegionMenuUS)]
    static void SetRegionUS()
    {
        SetProvider(RegionUtils.Provider.GCP);
    }

    [MenuItem(k_RegionMenuUS, true)]
    static bool CheckRegionIsUS()
    {
        CheckProviderMenu(k_RegionMenuUS, RegionUtils.Provider.GCP);
        return true;
    }

    [MenuItem(k_RegionMenuUK)]
    static void SetRegionUK()
    {
        SetProvider(RegionUtils.Provider.GCPUK);
    }

    [MenuItem(k_RegionMenuUK, true)]
    static bool CheckRegionIsUK()
    {
        CheckProviderMenu(k_RegionMenuUK, RegionUtils.Provider.GCPUK);
        return true;
    }

    [MenuItem(k_RegionMenuChina)]
    static void SetRegionChina()
    {
        SetProvider(RegionUtils.Provider.Tencent);
    }

    [MenuItem(k_RegionMenuChina, true)]
    static bool CheckRegionIsChina()
    {
        CheckProviderMenu(k_RegionMenuChina, RegionUtils.Provider.Tencent);
        return true;
    }

    static void SetProvider(RegionUtils.Provider provider)
    {
        PlayerPrefs.SetString(LocaleUtils.SettingsKeys.Provider, provider.ToString());
        Debug.Log($"Reflect Region set to '{provider}'. Make sure to close and reopen the Reflect Importer to apply change.");
    }

    static void CheckProviderMenu(string menu, RegionUtils.Provider provider)
    {
        var enabled = PlayerPrefs.HasKey(LocaleUtils.SettingsKeys.Provider) && PlayerPrefs.GetString(LocaleUtils.SettingsKeys.Provider) == provider.ToString();
        Menu.SetChecked(menu, enabled);
    }
}
