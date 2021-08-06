namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>Scaling plan properties that can be patched.</summary>
    public partial class ScalingPlanPatch :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatch,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchInternal
    {

        /// <summary>Description of scaling plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchPropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchPropertiesInternal)Property).Description = value ?? null; }

        /// <summary>Exclusion tag for scaling plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string ExclusionTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchPropertiesInternal)Property).ExclusionTag; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchPropertiesInternal)Property).ExclusionTag = value ?? null; }

        /// <summary>User friendly name of scaling plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string FriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchPropertiesInternal)Property).FriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchPropertiesInternal)Property).FriendlyName = value ?? null; }

        /// <summary>List of ScalingHostPoolReference definitions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingHostPoolReference[] HostPoolReference { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchPropertiesInternal)Property).HostPoolReference; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchPropertiesInternal)Property).HostPoolReference = value ?? null /* arrayOf */; }

        /// <summary>HostPool type for desktop.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HostPoolType? HostPoolType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchPropertiesInternal)Property).HostPoolType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchPropertiesInternal)Property).HostPoolType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HostPoolType)""); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchProperties Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ScalingPlanPatchProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchProperties _property;

        /// <summary>Detailed properties for scaling plan</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ScalingPlanPatchProperties()); set => this._property = value; }

        /// <summary>List of ScalingSchedule definitions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingSchedule[] Schedule { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchPropertiesInternal)Property).Schedule; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchPropertiesInternal)Property).Schedule = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchTags _tag;

        /// <summary>tags to be updated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ScalingPlanPatchTags()); set => this._tag = value; }

        /// <summary>Timezone of the scaling plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string TimeZone { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchPropertiesInternal)Property).TimeZone; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchPropertiesInternal)Property).TimeZone = value ?? null; }

        /// <summary>Creates an new <see cref="ScalingPlanPatch" /> instance.</summary>
        public ScalingPlanPatch()
        {

        }
    }
    /// Scaling plan properties that can be patched.
    public partial interface IScalingPlanPatch :
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
        /// <summary>tags to be updated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"tags to be updated",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchTags Tag { get; set; }
        /// <summary>Timezone of the scaling plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Timezone of the scaling plan.",
        SerializedName = @"timeZone",
        PossibleTypes = new [] { typeof(string) })]
        string TimeZone { get; set; }

    }
    /// Scaling plan properties that can be patched.
    internal partial interface IScalingPlanPatchInternal

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
        /// <summary>Detailed properties for scaling plan</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchProperties Property { get; set; }
        /// <summary>List of ScalingSchedule definitions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingSchedule[] Schedule { get; set; }
        /// <summary>tags to be updated</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPatchTags Tag { get; set; }
        /// <summary>Timezone of the scaling plan.</summary>
        string TimeZone { get; set; }

    }
}