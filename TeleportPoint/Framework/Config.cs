using System.Collections.Generic;
using StardewModdingAPI;
using StardewModdingAPI.Utilities;
using TeleportPoint.Framework.Gui;

namespace TeleportPoint.Framework;

public class Config
{
    public KeybindList OpenTeleport { get; set; } = new(SButton.L);
    public List<TeleportData> TeleportData { get; set; } = new();
}