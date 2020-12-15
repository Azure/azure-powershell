namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>Schema for ApplicationGroup properties.</summary>
    public partial class ApplicationGroupProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationGroupProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationGroupPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ApplicationGroupType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.ApplicationGroupType _applicationGroupType;

        /// <summary>Resource Type of ApplicationGroup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.ApplicationGroupType ApplicationGroupType { get => this._applicationGroupType; set => this._applicationGroupType = value; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of ApplicationGroup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>Friendly name of ApplicationGroup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Backing field for <see cref="HostPoolArmPath" /> property.</summary>
        private string _hostPoolArmPath;

        /// <summary>HostPool arm path of ApplicationGroup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string HostPoolArmPath { get => this._hostPoolArmPath; set => this._hostPoolArmPath = value; }

        /// <summary>Internal Acessors for WorkspaceArmPath</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationGroupPropertiesInternal.WorkspaceArmPath { get => this._workspaceArmPath; set { {_workspaceArmPath = value;} } }

        /// <summary>Backing field for <see cref="WorkspaceArmPath" /> property.</summary>
        private string _workspaceArmPath;

        /// <summary>Workspace arm path of ApplicationGroup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string WorkspaceArmPath { get => this._workspaceArmPath; }

        /// <summary>Creates an new <see cref="ApplicationGroupProperties" /> instance.</summary>
        public ApplicationGroupProperties()
        {

        }
    }
    /// Schema for ApplicationGroup properties.
    public partial interface IApplicationGroupProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IJsonSerializable
    {
        /// <summary>Resource Type of ApplicationGroup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Resource Type of ApplicationGroup.",
        SerializedName = @"applicationGroupType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.ApplicationGroupType) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.ApplicationGroupType ApplicationGroupType { get; set; }
        /// <summary>Description of ApplicationGroup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of ApplicationGroup.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>Friendly name of ApplicationGroup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Friendly name of ApplicationGroup.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>HostPool arm path of ApplicationGroup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"HostPool arm path of ApplicationGroup.",
        SerializedName = @"hostPoolArmPath",
        PossibleTypes = new [] { typeof(string) })]
        string HostPoolArmPath { get; set; }
        /// <summary>Workspace arm path of ApplicationGroup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Workspace arm path of ApplicationGroup.",
        SerializedName = @"workspaceArmPath",
        PossibleTypes = new [] { typeof(string) })]
        string WorkspaceArmPath { get;  }

    }
    /// Schema for ApplicationGroup properties.
    internal partial interface IApplicationGroupPropertiesInternal

    {
        /// <summary>Resource Type of ApplicationGroup.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.ApplicationGroupType ApplicationGroupType { get; set; }
        /// <summary>Description of ApplicationGroup.</summary>
        string Description { get; set; }
        /// <summary>Friendly name of ApplicationGroup.</summary>
        string FriendlyName { get; set; }
        /// <summary>HostPool arm path of ApplicationGroup.</summary>
        string HostPoolArmPath { get; set; }
        /// <summary>Workspace arm path of ApplicationGroup.</summary>
        string WorkspaceArmPath { get; set; }

    }
}