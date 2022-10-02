using System;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;
using UnityEngine.TextCore;

namespace PickupLock;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public static Plugin Instance;
    private readonly ConfigEntry<bool> _enabled;
    private readonly ConfigEntry<bool> _enableIcon;
    private readonly ConfigEntry<bool> _enableChatAlert;
    private readonly ConfigEntry<KeyCode> _hotkey;

    private readonly Harmony harmony = new(PluginInfo.PLUGIN_GUID);

    private bool _enabledPickup = true;

    public Plugin()
    {
        _enabled = Config.Bind("Options", "Enabled", true,
            "Disable injection of this mod. Useful for troubleshooting mods without uninstalling them.");
        _enableIcon = Config.Bind("Options", "EnableIcon", true,
            "Enable adding an icon to the top right corner of the screen to show pickup status");
        _enableChatAlert = Config.Bind("Options", "EnabledChatAlerts", true,
            "Enables Chat Alerts when pickup status changes");
        _hotkey = Config.Bind("Options", "Hotkey", KeyCode.O,
            "You can enable/disable functionality of this mod by pressing this key.");
    }

    private void Awake()
    {
        Instance = this;
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        
            if (!_enabled.Value)
            {
                Logger.LogInfo($"Mod: {PluginInfo.PLUGIN_NAME} is disabled!");
                Logger.LogInfo("Enable it via the OctrDev.ValueTooltip.cfg file.");
                return;
            } 
        Patch();
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(_hotkey.Value))
        {
            _enabledPickup = !_enabledPickup;
            if (_enableChatAlert.Value)
                NotificationManager.manage.createChatNotification(
                    $"Placed items are now {(_enabledPickup ? "unlocked" : "locked")}!");
        }
    }

    private void OnGUI()
    {
        if (!_enableIcon.Value) return;
        if (_enabledPickup) return;

        int xoffset = Screen.width/80;
        int yoffset = Screen.height / 160;
        int fontsize = xoffset + yoffset / 2;

        Rect rect = new Rect(Screen.width - xoffset, yoffset, xoffset, yoffset);
        GUIStyle style = new GUIStyle();
        style.richText = true;
        style.fontSize = fontsize;
        string text = "" + Convert.ToChar(0x00a4);
        GUI.Box(rect, text , style);
    }

    private void Patch()
    {
        harmony.PatchAll();

        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} has loaded!");
        Logger.LogInfo($"Version: {PluginInfo.PLUGIN_VERSION}");
    }

    public bool GetIsEnabled()
    {
        return _enabledPickup;
    }
}