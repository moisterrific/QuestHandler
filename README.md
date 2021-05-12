# Quest Handler
A simple TShock plugin for create a text-based quest, also this is my first TShock plugin

# How to install
Download `QuestHandler.dll` from a [releases](https://github.com/munukhu/QuestHandler/releases), and place it on TShock `ServerPlugins` folder

This plugin will create a folder `QuestHandler` in `tshock` folder, this folder include `quest-daily.txt` & `quest-weekly.txt` this two file will displayed in game if player execute specific command, you can edit this file using an in-game command or edit it manually.

## Permission
- `questhandler.quest.change` Permission to change active quest

## Commands
- `/quest daily` `/quest d`  Show active daily quest
- `/quest weekly` `/quest w` Show active weekly quest
- `/quest changedaily` `/quest cd` Change (overwrite) current active quest (need a permission)
- `/quest changeweekly` `/quest cw` Change (overwrite) current active quest (need a permission)