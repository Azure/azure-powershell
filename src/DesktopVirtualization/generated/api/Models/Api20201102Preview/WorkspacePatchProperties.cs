namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>Workspace properties that can be patched.</summary>
    public partial class WorkspacePatchProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IWorkspacePatchProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IWorkspacePatchPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ApplicationGroupReference" /> property.</summary>
        private string[] _applicationGroupReference;

        /// <summary>List of applicationGroup links.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string[] ApplicationGroupReference { get => this._applicationGroupReference; set => this._applicationGroupReference = value; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of Workspace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>Friendly name of Workspace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Creates an new <see cref="WorkspacePatchProperties" /> instance.</summary>
        public WorkspacePatchProperties()
        {

        }
    }
    /// Workspace properties that can be patched.
    public partial interface IWorkspacePatchProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IJsonSerializable
    {
        /// <summary>List of applicationGroup links.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of applicationGroup links.",
        SerializedName = @"applicationGroupReferences",
        PossibleTypes = new [] { typeof(string) })]
        string[] ApplicationGroupReference { get; set; }
        /// <summary>Description of Workspace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of Workspace.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>Friendly name of Workspace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Friendly name of Workspace.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }

    }
    /// Workspace properties that can be patched.
    internal partial interface IWorkspacePatchPropertiesInternal

    {
        /// <summary>List of applicationGroup links.</summary>
        string[] ApplicationGroupReference { get; set; }
        /// <summary>Description of Workspace.</summary>
        string Description { get; set; }
        /// <summary>Friendly name of Workspace.</summary>
        string FriendlyName { get; set; }

    }
}