namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Profile for diagnostics on the container service VMs.</summary>
    public partial class ContainerServiceVMDiagnostics :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceVMDiagnostics,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceVMDiagnosticsInternal
    {

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool _enabled;

        /// <summary>Whether the VM diagnostic agent is provisioned on the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public bool Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Internal Acessors for StorageUri</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceVMDiagnosticsInternal.StorageUri { get => this._storageUri; set { {_storageUri = value;} } }

        /// <summary>Backing field for <see cref="StorageUri" /> property.</summary>
        private string _storageUri;

        /// <summary>The URI of the storage account where diagnostics are stored.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string StorageUri { get => this._storageUri; }

        /// <summary>Creates an new <see cref="ContainerServiceVMDiagnostics" /> instance.</summary>
        public ContainerServiceVMDiagnostics()
        {

        }
    }
    /// Profile for diagnostics on the container service VMs.
    public partial interface IContainerServiceVMDiagnostics :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>Whether the VM diagnostic agent is provisioned on the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Whether the VM diagnostic agent is provisioned on the VM.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool Enabled { get; set; }
        /// <summary>The URI of the storage account where diagnostics are stored.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The URI of the storage account where diagnostics are stored.",
        SerializedName = @"storageUri",
        PossibleTypes = new [] { typeof(string) })]
        string StorageUri { get;  }

    }
    /// Profile for diagnostics on the container service VMs.
    internal partial interface IContainerServiceVMDiagnosticsInternal

    {
        /// <summary>Whether the VM diagnostic agent is provisioned on the VM.</summary>
        bool Enabled { get; set; }
        /// <summary>The URI of the storage account where diagnostics are stored.</summary>
        string StorageUri { get; set; }

    }
}