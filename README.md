# Pickup Lock

## Description
Enables or disables the ability to pick up already placed objects such as beds, crafting tables, chests, and more! 
While playing Dinkum, I have been constantly picking up my sleeping bag and crafting tables while trying to use them, hence this mod. 

## How to Use
Essentially, press `O` (the default key, can be changed) to enable/disable the lock. You should get an icon in the top right of the screen (configurable), and a chat notification (also configurable) that the lock has been enabled/disabled. 

## Installation
* Install the latest version of BepInEx following the instructions here: https://github.com/BepInEx/BepInEx/wiki/Installation 
* Extract the articraftry.PickupLock.dll into `Dinkum/BepInEx/plugins`
* Run Dinkum for the first time
* Change any configuration settings that you want in the `Dinkum/BepInEx/config/articraftry.PickupLock.cfg` file

## Configuration
PickupLock has a few configuration settings that you can change:

| Configuration Parameter | Default Value | Description                                                                               |
|-------------------------|---------------|-------------------------------------------------------------------------------------------|
| Enabled                 | true          | Disable injection of this mod. Useful for troubleshooting mods without uninstalling them. |
| EnableIcon              | true          | Enable adding an icon to the top right corner of the screen to show pickup status         |
| EnableChatAlerts        | true          | Enables Chat Alerts when pickup status changes                                            |
| Hotkey                  | O             | You can enable/disable functionality of this mod by pressing this key.                    |


## Support
Please add an issue in GitHub.


## Changelog
1.0.0 Initial Release.