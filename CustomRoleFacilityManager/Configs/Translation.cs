using System.ComponentModel;
using Exiled.API.Interfaces;

namespace CustomRoleFacilityManager.Configs
{
    public sealed class Translation : ITranslation
    {
        public string CustomName { get; set; } = "Facility Manager";
        public string CustomInfo { get; set; } = "Facility Manager";
        public string Spawn { get; set; } = "You have spawned as a <color=red>Facility Manager</color>";
        public string Description { get; set; } = "You are <color=red>Facility Manager</color>, check console for more info (~)";
        public string ConsoleMsg { get; set; } = "<size=60%>You are <color=red>Facility Manager</color></size>";
    }
}