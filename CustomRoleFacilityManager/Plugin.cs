using System;
using Exiled.API.Features;
using Exiled.CustomRoles.API;
namespace CustomRoleFacilityManager
{
    public class Plugin : Plugin<Configs.Config, Configs.Translation>
    {
        public override string Name => "CustomRoleFacilityManager";
        public override string Author => "_soufi";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(7, 2, 0);
        public static Plugin Singleton = new Plugin();
        public Api.Roles.FacilityManager FacilityManager;
        public override void OnEnabled()
        {
            Singleton = this;
            base.OnEnabled();
            FacilityManager = new Api.Roles.FacilityManager { Role = Config.Role };
            FacilityManager.Register();
        }
        public override void OnDisabled()
        {
            FacilityManager.Unregister();
            Singleton = null;
            base.OnDisabled();
        }
    }
}