using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Interfaces;
using PlayerRoles;
using UnityEngine;

namespace CustomRoleFacilityManager.Configs
{
    public sealed class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Role Id")]
        public uint CustomRoleId { get; set; } = 52;
        [Description("Max health of the Facility Manager")]
        public int MaxHealth { get; set; } = 120;
        [Description("Role of the Facility Manager")]
        public RoleTypeId Role { get; set; } = RoleTypeId.Scientist;
        [Description("Scale of the Facility Manager")]
        public Vector3 Scale { get; set; } = new Vector3(1, 1, 1);
        public float SpawnChance { get; set; } = 50;
        public SpawnLocationType SpawnLocationType { get; set; } = SpawnLocationType.InsideIntercom;
        public bool IgnoreSpawnSystem { get; set; } = true;
        public int MinPlayersForSpawn { get; set; } = 6;
        [Description("Ammo on spawn - (https://discord.com/channels/656673194693885975/1081961667874795521/1082601409846984754)")]
        public Dictionary<AmmoType, ushort> Ammo { get; set; } = new Dictionary<AmmoType, ushort>()
        {
            { AmmoType.Nato9, 18 },
            { AmmoType.Nato556, 30 }
        };
        [Description("Inventory on spawn - (https://discord.com/channels/656673194693885975/1081961667874795521/1081961667874795521)")]
        public List<string> Inventory { get; set; } = new List<string>()
        {
            "KeycardFacilityManager",
            "GunE11SR",
            "Radio",
            "ArmorLight"
        };
    }
}