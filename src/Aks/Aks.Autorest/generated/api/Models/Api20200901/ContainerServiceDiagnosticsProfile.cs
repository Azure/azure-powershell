namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Profile for diagnostics on the container service cluster.</summary>
    public partial class ContainerServiceDiagnosticsProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceDiagnosticsProfile,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceDiagnosticsProfileInternal
    {

        /// <summary>Internal Acessors for VMDiagnostic</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceVMDiagnostics Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceDiagnosticsProfileInternal.VMDiagnostic { get => (this._vMDiagnostic = this._vMDiagnostic ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ContainerServiceVMDiagnostics()); set { {_vMDiagnostic = value;} } }

        /// <summary>Internal Acessors for VMDiagnosticStorageUri</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceDiagnosticsProfileInternal.VMDiagnosticStorageUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceVMDiagnosticsInternal)VMDiagnostic).StorageUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceVMDiagnosticsInternal)VMDiagnostic).StorageUri = value; }

        /// <summary>Backing field for <see cref="VMDiagnostic" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceVMDiagnostics _vMDiagnostic;

        /// <summary>Profile for diagnostics on the container service VMs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceVMDiagnostics VMDiagnostic { get => (this._vMDiagnostic = this._vMDiagnostic ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ContainerServiceVMDiagnostics()); set => this._vMDiagnostic = value; }

        /// <summary>Whether the VM diagnostic agent is provisioned on the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public bool VMDiagnosticEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceVMDiagnosticsInternal)VMDiagnostic).Enabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceVMDiagnosticsInternal)VMDiagnostic).Enabled = value ; }

        /// <summary>The URI of the storage account where diagnostics are stored.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string VMDiagnosticStorageUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceVMDiagnosticsInternal)VMDiagnostic).StorageUri; }

        /// <summary>Creates an new <see cref="ContainerServiceDiagnosticsProfile" /> instance.</summary>
        public ContainerServiceDiagnosticsProfile()
        {

        }
    }
    /// Profile for diagnostics on the container service cluster.
    public partial interface IContainerServiceDiagnosticsProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>Whether the VM diagnostic agent is provisioned on the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Whether the VM diagnostic agent is provisioned on the VM.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool VMDiagnosticEnabled { get; set; }
        /// <summary>The URI of the storage account where diagnostics are stored.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The URI of the storage account where diagnostics are stored.",
        SerializedName = @"storageUri",
        PossibleTypes = new [] { typeof(string) })]
        string VMDiagnosticStorageUri { get;  }

    }
    /// Profile for diagnostics on the container service cluster.
    internal partial interface IContainerServiceDiagnosticsProfileInternal

    {
        /// <summary>Profile for diagnostics on the container service VMs.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceVMDiagnostics VMDiagnostic { get; set; }
        /// <summary>Whether the VM diagnostic agent is provisioned on the VM.</summary>
        bool VMDiagnosticEnabled { get; set; }
        /// <summary>The URI of the storage account where diagnostics are stored.</summary>
        string VMDiagnosticStorageUri { get; set; }

    }
}