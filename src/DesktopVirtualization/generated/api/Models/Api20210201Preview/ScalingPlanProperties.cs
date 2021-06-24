namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>Scaling plan properties.</summary>
    public partial class ScalingPlanProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of scaling plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="ExclusionTag" /> property.</summary>
        private string _exclusionTag;

        /// <summary>Exclusion tag for scaling plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string ExclusionTag { get => this._exclusionTag; set => this._exclusionTag = value; }

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>User friendly name of scaling plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Backing field for <see cref="HostPoolReference" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingHostPoolReference[] _hostPoolReference;

        /// <summary>List of ScalingHostPoolReference definitions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingHostPoolReference[] HostPoolReference { get => this._hostPoolReference; set => this._hostPoolReference = value; }

        /// <summary>Backing field for <see cref="HostPoolType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HostPoolType? _hostPoolType;

        /// <summary>HostPool type for desktop.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HostPoolType? HostPoolType { get => this._hostPoolType; set => this._hostPoolType = value; }

        /// <summary>Backing field for <see cref="Schedule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingSchedule[] _schedule;

        /// <summary>List of ScalingSchedule definitions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingSchedule[] Schedule { get => this._schedule; set => this._schedule = value; }

        /// <summary>Backing field for <see cref="TimeZone" /> property.</summary>
        private string _timeZone;

        /// <summary>Timezone of the scaling plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string TimeZone { get => this._timeZone; set => this._timeZone = value; }

        /// <summary>Creates an new <see cref="ScalingPlanProperties" /> instance.</summary>
        public ScalingPlanProperties()
        {

        }
    }
    /// Scaling plan properties.
    public partial interface IScalingPlanProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IJsonSerializable
    {
        /// <summary>Description of scaling plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of scaling plan.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>Exclusion tag for scaling plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Exclusion tag for scaling plan.",
        SerializedName = @"exclusionTag",
        PossibleTypes = new [] { typeof(string) })]
        string ExclusionTag { get; set; }
        /// <summary>User friendly name of scaling plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"User friendly name of scaling plan.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>List of ScalingHostPoolReference definitions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of ScalingHostPoolReference definitions.",
        SerializedName = @"hostPoolReferences",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingHostPoolReference) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingHostPoolReference[] HostPoolReference { get; set; }
        /// <summary>HostPool type for desktop.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"HostPool type for desktop.",
        SerializedName = @"hostPoolType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HostPoolType) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HostPoolType? HostPoolType { get; set; }
        /// <summary>List of ScalingSchedule definitions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of ScalingSchedule definitions.",
        SerializedName = @"schedules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingSchedule) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingSchedule[] Schedule { get; set; }
        /// <summary>Timezone of the scaling plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Timezone of the scaling plan.",
        SerializedName = @"timeZone",
        PossibleTypes = new [] { typeof(string) })]
        string TimeZone { get; set; }

    }
    /// Scaling plan properties.
    internal partial interface IScalingPlanPropertiesInternal

    {
        /// <summary>Description of scaling plan.</summary>
        string Description { get; set; }
        /// <summary>Exclusion tag for scaling plan.</summary>
        string ExclusionTag { get; set; }
        /// <summary>User friendly name of scaling plan.</summary>
        string FriendlyName { get; set; }
        /// <summary>List of ScalingHostPoolReference definitions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingHostPoolReference[] HostPoolReference { get; set; }
        /// <summary>HostPool type for desktop.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HostPoolType? HostPoolType { get; set; }
        /// <summary>List of ScalingSchedule definitions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingSchedule[] Schedule { get; set; }
        /// <summary>Timezone of the scaling plan.</summary>
        string TimeZone { get; set; }

    }
}