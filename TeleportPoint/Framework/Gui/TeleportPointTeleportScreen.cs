using EnaiumToolKit.Framework.Screen;
using EnaiumToolKit.Framework.Screen.Elements;
using StardewValley;

namespace TeleportPoint.Framework.Gui
{
    public class TeleportPointTeleportScreen : ScreenGui
    {
        public TeleportPointTeleportScreen()
        {
            AddElement(new Label(Get("teleportPoint.label.teleportPointList"),
                Get("teleportPoint.label.teleportPointList")));

            foreach (var variable in ModEntry.Config.TeleportData)
            {
                AddElement(new Button($"{Get("teleportPoint.button.teleport")}:{variable.Name}",
                    $"{Get("teleportPoint.button.teleport")}:{variable.Name}")
                {
                    OnLeftClicked = () => { Teleport(variable.LocationName, variable.TileX, variable.TileY); }
                });
            }
        }

        private void Teleport(string locationName, float tileX, float tileY)
        {
            Game1.exitActiveMenu();
            Game1.player.swimming.Value = false;
            Game1.player.changeOutOfSwimSuit();
            Game1.warpFarmer(locationName, (int)tileX, (int)tileY, false);
        }

        private string Get(string key)
        {
            return ModEntry.GetInstance().Helper.Translation.Get(key);
        }
    }

    public class TeleportData
    {
        public string Name { get; }

        public string LocationName { get; }

        public float TileX { get; }

        public float TileY { get; }

        public TeleportData(string name, string locationName, float tileX, float tileY)
        {
            Name = name;
            LocationName = locationName;
            TileX = tileX;
            TileY = tileY;
        }
    }
}