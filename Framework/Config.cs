using System.Collections.Generic;
using StardewModdingAPI;
using TeleportPoint.Framework.Gui;

namespace TeleportPoint.Framework
{
    public class Config
    {
        public SButton OpenTeleport { get; set; } = SButton.L;
        public List<TeleportData> TeleportDatas { get; set; } = new List<TeleportData>();
    }
}