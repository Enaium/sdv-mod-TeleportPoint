using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using TeleportPoint.Framework;
using TeleportPoint.Framework.Gui;

namespace TeleportPoint
{
    public class ModEntry : Mod
    {
        private Config _config;
        private static ModEntry _instance;

        public ModEntry()
        {
            _instance = this;
        }

        public override void Entry(IModHelper helper)
        {
            _config = helper.ReadConfig<Config>();
            helper.Events.Input.ButtonPressed += OnButtonPress;
        }

        private void OnButtonPress(object sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;
            if (!Context.IsPlayerFree)
                return;
            if (e.Button != _config.OpenTeleport)
                return;
            Game1.activeClickableMenu = new TeleportPointScreen();
        }
        
        

        public static ModEntry GetInstance()
        {
            return _instance;
        }
    }
}