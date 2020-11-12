using System.Collections.Generic;
using EnaiumToolKit.Framework.Screen;
using EnaiumToolKit.Framework.Screen.Elements;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewValley;

namespace TeleportPoint.Framework.Gui
{
    public class TeleportPointScreen : ScreenGui
    {
        private Config _config;

        public TeleportPointScreen()
        {
            _config = ModEntry.GetInstance().Helper.ReadConfig<Config>();
            AddElement(new Button(Get("teleportPoint.button.record"), Get("teleportPoint.button.record"))
            {
                OnLeftClicked = () =>
                {
                    Game1.activeClickableMenu =
                        new NamingScreen(name =>
                            {
                                _config.TeleportDatas.Add(new TeleportData(name, Game1.player.currentLocation.name,
                                    Game1.player.getTileX(), Game1.player.getTileY()));
                                ModEntry.GetInstance().Helper.WriteConfig(_config);
                                Game1.activeClickableMenu = null;
                            },
                            Get("teleportPoint.title.naming"));
                }
            });
            
            AddElement(new Label(Get("teleportPoint.label.teleportPointList"), Get("teleportPoint.label.teleportPointList")));

            foreach (var variable in _config.TeleportDatas)
            {
                AddElement(new Button($"{Get("teleportPoint.button.teleportPoint")}{variable.Name}", $"{Get("teleportPoint.button.teleportPoint")}{variable.Name}")
                {
                    OnLeftClicked = () => { Teleport(variable.LocationName, variable.TileX, variable.TileY); }
                });
            }
        }

        private string Get(string key)
        {
            return ModEntry.GetInstance().Helper.Translation.Get(key);
        }

        private void Teleport(string locationName, int tileX, int tileY)
        {
            Game1.exitActiveMenu();
            Game1.player.swimming.Value = false;
            Game1.player.changeOutOfSwimSuit();
            Game1.warpFarmer(locationName, tileX, tileY, false);
        }
    }

    public class TeleportData
    {
        public string Name { get; }

        public string LocationName { get; }

        public int TileX { get; }

        public int TileY { get; }

        public TeleportData(string name, string locationName, int tileX, int tileY)
        {
            Name = name;
            LocationName = locationName;
            TileX = tileX;
            TileY = tileY;
        }
    }
}