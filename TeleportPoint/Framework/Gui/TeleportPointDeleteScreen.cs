﻿using EnaiumToolKit.Framework.Screen;
using EnaiumToolKit.Framework.Screen.Elements;

namespace TeleportPoint.Framework.Gui;

public class TeleportPointDeleteScreen : ScreenGui
{
    public TeleportPointDeleteScreen()
    {
        AddElement(new Label(ModEntry.GetTranslation("teleportPoint.label.teleportPointList.title"),
            ModEntry.GetTranslation("teleportPoint.label.teleportPointList.title")));

        foreach (var variable in ModEntry.Config.TeleportData)
        {
            var delete = new Button($"{ModEntry.GetTranslation("teleportPoint.button.delete.title")}:{variable.Name}",
                $"{ModEntry.GetTranslation("teleportPoint.button.delete.title")}:{variable.Name}");
            delete.OnLeftClicked = () =>
            {
                ModEntry.Config.TeleportData.Remove(variable);
                RemoveElement(delete);
            };
            AddElement(delete);
        }
    }
}