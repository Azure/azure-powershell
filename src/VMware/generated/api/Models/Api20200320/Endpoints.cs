namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>Endpoint addresses</summary>
    public partial class Endpoints :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpoints,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpointsInternal
    {

        /// <summary>Backing field for <see cref="HcxCloudManager" /> property.</summary>
        private string _hcxCloudManager;

        /// <summary>Endpoint for the HCX Cloud Manager</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string HcxCloudManager { get => this._hcxCloudManager; }

        /// <summary>Internal Acessors for HcxCloudManager</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpointsInternal.HcxCloudManager { get => this._hcxCloudManager; set { {_hcxCloudManager = value;} } }

        /// <summary>Internal Acessors for NsxtManager</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpointsInternal.NsxtManager { get => this._nsxtManager; set { {_nsxtManager = value;} } }

        /// <summary>Internal Acessors for Vcsa</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpointsInternal.Vcsa { get => this._vcsa; set { {_vcsa = value;} } }

        /// <summary>Backing field for <see cref="NsxtManager" /> property.</summary>
        private string _nsxtManager;

        /// <summary>Endpoint for the NSX-T Data Center manager</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string NsxtManager { get => this._nsxtManager; }

        /// <summary>Backing field for <see cref="Vcsa" /> property.</summary>
        private string _vcsa;

        /// <summary>Endpoint for Virtual Center Server Appliance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string Vcsa { get => this._vcsa; }

        /// <summary>Creates an new <see cref="Endpoints" /> instance.</summary>
        public Endpoints()
        {

        }
    }
    /// Endpoint addresses
    public partial interface IEndpoints :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IJsonSerializable
    {
        /// <summary>Endpoint for the HCX Cloud Manager</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Endpoint for the HCX Cloud Manager",
        SerializedName = @"hcxCloudManager",
        PossibleTypes = new [] { typeof(string) })]
        string HcxCloudManager { get;  }
        /// <summary>Endpoint for the NSX-T Data Center manager</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Endpoint for the NSX-T Data Center manager",
        SerializedName = @"nsxtManager",
        PossibleTypes = new [] { typeof(string) })]
        string NsxtManager { get;  }
        /// <summary>Endpoint for Virtual Center Server Appliance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Endpoint for Virtual Center Server Appliance",
        SerializedName = @"vcsa",
        PossibleTypes = new [] { typeof(string) })]
        string Vcsa { get;  }

    }
    /// Endpoint addresses
    internal partial interface IEndpointsInternal

    {
        /// <summary>Endpoint for the HCX Cloud Manager</summary>
        string HcxCloudManager { get; set; }
        /// <summary>Endpoint for the NSX-T Data Center manager</summary>
        string NsxtManager { get; set; }
        /// <summary>Endpoint for Virtual Center Server Appliance</summary>
        string Vcsa { get; set; }

    }
}