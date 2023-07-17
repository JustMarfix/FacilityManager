using System.Collections.Generic;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using PlayerRoles;
using UnityEngine;

namespace CustomRoleFacilityManager.Api.Roles
{
    public class FacilityManager : CustomRole
    {
        public override uint Id { get; set; } = Plugin.Singleton.Config.CustomRoleId;
        public override int MaxHealth { get; set; } = Plugin.Singleton.Config.MaxHealth;
        public override string Name { get; set; } = Plugin.Singleton.Translation.CustomName;
        public override string Description { get; set; } = Plugin.Singleton.Translation.Description;
        public override string CustomInfo { get; set; } = Plugin.Singleton.Translation.CustomInfo;
        public override string ConsoleMessage { get; set; } = Plugin.Singleton.Translation.ConsoleMsg;
        public override bool IgnoreSpawnSystem { get; set; } = Plugin.Singleton.Config.IgnoreSpawnSystem;
        public override RoleTypeId Role { get; set; } = Plugin.Singleton.Config.Role;
        public override bool KeepPositionOnSpawn { get; set; } = false;
        public override bool KeepInventoryOnSpawn { get; set; } = false;
        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = Plugin.Singleton.Config.Ammo;
        public override List<string> Inventory { get; set; } = Plugin.Singleton.Config.Inventory;
        public override Vector3 Scale { get; set; } = Plugin.Singleton.Config.Scale;
        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 1,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
            {
                new DynamicSpawnPoint
                {
                    Chance = Plugin.Singleton.Config.SpawnChance,
                    Location = Plugin.Singleton.Config.SpawnLocationType
                }
            }
        };
        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
        }
        protected override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
        }
        public void OnRoundStarted()
        {
            if (Player.List.Count() < Plugin.Singleton.Config.MinPlayersForSpawn) return;
            if (Random.Range(0, 101) > Plugin.Singleton.Config.SpawnChance)
            {
                Log.Debug("Facility Manager will not be spawned in this round.");
                return;
            }
            if (Player.List.Count(x => x.Role.Type == Plugin.Singleton.Config.Role) == 0)
            {
                Log.Debug($"There is no one with role - {Plugin.Singleton.Config.Role}");
                return;
            }
            Player ply;
            var list = Player.List.Where(x => x.Role.Type == Plugin.Singleton.Config.Role);
            if (list.Count() == 1)
            {
                ply = list.First();
                Log.Debug($"There is only one person with role - {Plugin.Singleton.Config.Role}");
            }
            else
            {
                ply = list.ToList()[(Random.Range(0, list.Count()))];
                Log.Debug($"There is more then one person with role - {Plugin.Singleton.Config.Role}");
            }
            Get(typeof(FacilityManager))?.AddRole(ply);
        }
    }
}