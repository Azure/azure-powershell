namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>Scaling plan reference to hostpool.</summary>
    public partial class ScalingHostPoolReference :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingHostPoolReference,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingHostPoolReferenceInternal
    {

        /// <summary>Backing field for <see cref="HostPoolArmPath" /> property.</summary>
        private string _hostPoolArmPath;

        /// <summary>Arm path of referenced hostpool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string HostPoolArmPath { get => this._hostPoolArmPath; set => this._hostPoolArmPath = value; }

        /// <summary>Backing field for <see cref="ScalingPlanEnabled" /> property.</summary>
        private bool? _scalingPlanEnabled;

        /// <summary>Is the scaling plan enabled for this hostpool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public bool? ScalingPlanEnabled { get => this._scalingPlanEnabled; set => this._scalingPlanEnabled = value; }

        /// <summary>Creates an new <see cref="ScalingHostPoolReference" /> instance.</summary>
        public ScalingHostPoolReference()
        {

        }
    }
    /// Scaling plan reference to hostpool.
    public partial interface IScalingHostPoolReference :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IJsonSerializable
    {
        /// <summary>Arm path of referenced hostpool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Arm path of referenced hostpool.",
        SerializedName = @"hostPoolArmPath",
        PossibleTypes = new [] { typeof(string) })]
        string HostPoolArmPath { get; set; }
        /// <summary>Is the scaling plan enabled for this hostpool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Is the scaling plan enabled for this hostpool.",
        SerializedName = @"scalingPlanEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ScalingPlanEnabled { get; set; }

    }
    /// Scaling plan reference to hostpool.
    internal partial interface IScalingHostPoolReferenceInternal

    {
        /// <summary>Arm path of referenced hostpool.</summary>
        string HostPoolArmPath { get; set; }
        /// <summary>Is the scaling plan enabled for this hostpool.</summary>
        bool? ScalingPlanEnabled { get; set; }

    }
}