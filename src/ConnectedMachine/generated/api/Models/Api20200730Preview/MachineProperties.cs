namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Describes the properties of a hybrid machine.</summary>
    public partial class MachineProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal
    {

        /// <summary>Backing field for <see cref="AdFqdn" /> property.</summary>
        private string _adFqdn;

        /// <summary>Specifies the AD fully qualified display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string AdFqdn { get => this._adFqdn; }

        /// <summary>Backing field for <see cref="AgentVersion" /> property.</summary>
        private string _agentVersion;

        /// <summary>The hybrid machine agent full version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string AgentVersion { get => this._agentVersion; }

        /// <summary>Backing field for <see cref="ClientPublicKey" /> property.</summary>
        private string _clientPublicKey;

        /// <summary>
        /// Public Key that the client provides to be used during initial resource onboarding
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string ClientPublicKey { get => this._clientPublicKey; set => this._clientPublicKey = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Specifies the hybrid machine display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; }

        /// <summary>Backing field for <see cref="DnsFqdn" /> property.</summary>
        private string _dnsFqdn;

        /// <summary>Specifies the DNS fully qualified display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string DnsFqdn { get => this._dnsFqdn; }

        /// <summary>Backing field for <see cref="DomainName" /> property.</summary>
        private string _domainName;

        /// <summary>Specifies the Windows domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string DomainName { get => this._domainName; }

        /// <summary>Backing field for <see cref="ErrorDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IErrorDetail[] _errorDetail;

        /// <summary>Details about the error state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IErrorDetail[] ErrorDetail { get => this._errorDetail; }

        /// <summary>Backing field for <see cref="Extension" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionInstanceView[] _extension;

        /// <summary>Machine Extensions information</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionInstanceView[] Extension { get => this._extension; set => this._extension = value; }

        /// <summary>Backing field for <see cref="LastStatusChange" /> property.</summary>
        private global::System.DateTime? _lastStatusChange;

        /// <summary>The time of the last status change.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public global::System.DateTime? LastStatusChange { get => this._lastStatusChange; }

        /// <summary>Backing field for <see cref="LocationData" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationData _locationData;

        /// <summary>Metadata pertaining to the geographic location of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationData LocationData { get => (this._locationData = this._locationData ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.LocationData()); set => this._locationData = value; }

        /// <summary>The city or locality where the resource is located.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        public string LocationDataCity { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationDataInternal)LocationData).City; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationDataInternal)LocationData).City = value; }

        /// <summary>The country or region where the resource is located</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        public string LocationDataCountryOrRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationDataInternal)LocationData).CountryOrRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationDataInternal)LocationData).CountryOrRegion = value; }

        /// <summary>The district, state, or province where the resource is located.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        public string LocationDataDistrict { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationDataInternal)LocationData).District; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationDataInternal)LocationData).District = value; }

        /// <summary>A canonical name for the geographic or physical location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        public string LocationDataName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationDataInternal)LocationData).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationDataInternal)LocationData).Name = value; }

        /// <summary>Backing field for <see cref="MachineFqdn" /> property.</summary>
        private string _machineFqdn;

        /// <summary>Specifies the hybrid machine FQDN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string MachineFqdn { get => this._machineFqdn; }

        /// <summary>Internal Acessors for AdFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal.AdFqdn { get => this._adFqdn; set { {_adFqdn = value;} } }

        /// <summary>Internal Acessors for AgentVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal.AgentVersion { get => this._agentVersion; set { {_agentVersion = value;} } }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal.DisplayName { get => this._displayName; set { {_displayName = value;} } }

        /// <summary>Internal Acessors for DnsFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal.DnsFqdn { get => this._dnsFqdn; set { {_dnsFqdn = value;} } }

        /// <summary>Internal Acessors for DomainName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal.DomainName { get => this._domainName; set { {_domainName = value;} } }

        /// <summary>Internal Acessors for ErrorDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IErrorDetail[] Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal.ErrorDetail { get => this._errorDetail; set { {_errorDetail = value;} } }

        /// <summary>Internal Acessors for LastStatusChange</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal.LastStatusChange { get => this._lastStatusChange; set { {_lastStatusChange = value;} } }

        /// <summary>Internal Acessors for LocationData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationData Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal.LocationData { get => (this._locationData = this._locationData ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.LocationData()); set { {_locationData = value;} } }

        /// <summary>Internal Acessors for MachineFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal.MachineFqdn { get => this._machineFqdn; set { {_machineFqdn = value;} } }

        /// <summary>Internal Acessors for OSName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal.OSName { get => this._oSName; set { {_oSName = value;} } }

        /// <summary>Internal Acessors for OSProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesOSProfile Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal.OSProfile { get => (this._oSProfile = this._oSProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachinePropertiesOSProfile()); set { {_oSProfile = value;} } }

        /// <summary>Internal Acessors for OSProfileComputerName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal.OSProfileComputerName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOSProfileInternal)OSProfile).ComputerName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOSProfileInternal)OSProfile).ComputerName = value; }

        /// <summary>Internal Acessors for OSSku</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal.OSSku { get => this._oSSku; set { {_oSSku = value;} } }

        /// <summary>Internal Acessors for OSVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal.OSVersion { get => this._oSVersion; set { {_oSVersion = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusTypes? Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Internal Acessors for VMUuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal.VMUuid { get => this._vMUuid; set { {_vMUuid = value;} } }

        /// <summary>Backing field for <see cref="OSName" /> property.</summary>
        private string _oSName;

        /// <summary>The Operating System running on the hybrid machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string OSName { get => this._oSName; }

        /// <summary>Backing field for <see cref="OSProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesOSProfile _oSProfile;

        /// <summary>Specifies the operating system settings for the hybrid machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesOSProfile OSProfile { get => (this._oSProfile = this._oSProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachinePropertiesOSProfile()); set => this._oSProfile = value; }

        /// <summary>Specifies the host OS name of the hybrid machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        public string OSProfileComputerName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOSProfileInternal)OSProfile).ComputerName; }

        /// <summary>Backing field for <see cref="OSSku" /> property.</summary>
        private string _oSSku;

        /// <summary>Specifies the Operating System product SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string OSSku { get => this._oSSku; }

        /// <summary>Backing field for <see cref="OSVersion" /> property.</summary>
        private string _oSVersion;

        /// <summary>The version of Operating System running on the hybrid machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string OSVersion { get => this._oSVersion; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The provisioning state, which only appears in the response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusTypes? _status;

        /// <summary>The status of the hybrid machine agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusTypes? Status { get => this._status; }

        /// <summary>Backing field for <see cref="VMId" /> property.</summary>
        private string _vMId;

        /// <summary>Specifies the hybrid machine unique ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string VMId { get => this._vMId; set => this._vMId = value; }

        /// <summary>Backing field for <see cref="VMUuid" /> property.</summary>
        private string _vMUuid;

        /// <summary>Specifies the Arc Machine's unique SMBIOS ID</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string VMUuid { get => this._vMUuid; }

        /// <summary>Creates an new <see cref="MachineProperties" /> instance.</summary>
        public MachineProperties()
        {

        }
    }
    /// Describes the properties of a hybrid machine.
    public partial interface IMachineProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable
    {
        /// <summary>Specifies the AD fully qualified display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the AD fully qualified display name.",
        SerializedName = @"adFqdn",
        PossibleTypes = new [] { typeof(string) })]
        string AdFqdn { get;  }
        /// <summary>The hybrid machine agent full version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The hybrid machine agent full version.",
        SerializedName = @"agentVersion",
        PossibleTypes = new [] { typeof(string) })]
        string AgentVersion { get;  }
        /// <summary>
        /// Public Key that the client provides to be used during initial resource onboarding
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Public Key that the client provides to be used during initial resource onboarding",
        SerializedName = @"clientPublicKey",
        PossibleTypes = new [] { typeof(string) })]
        string ClientPublicKey { get; set; }
        /// <summary>Specifies the hybrid machine display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the hybrid machine display name.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get;  }
        /// <summary>Specifies the DNS fully qualified display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the DNS fully qualified display name.",
        SerializedName = @"dnsFqdn",
        PossibleTypes = new [] { typeof(string) })]
        string DnsFqdn { get;  }
        /// <summary>Specifies the Windows domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the Windows domain name.",
        SerializedName = @"domainName",
        PossibleTypes = new [] { typeof(string) })]
        string DomainName { get;  }
        /// <summary>Details about the error state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Details about the error state.",
        SerializedName = @"errorDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IErrorDetail) })]
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IErrorDetail[] ErrorDetail { get;  }
        /// <summary>Machine Extensions information</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Machine Extensions information",
        SerializedName = @"extensions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionInstanceView) })]
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionInstanceView[] Extension { get; set; }
        /// <summary>The time of the last status change.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The time of the last status change.",
        SerializedName = @"lastStatusChange",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastStatusChange { get;  }
        /// <summary>The city or locality where the resource is located.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The city or locality where the resource is located.",
        SerializedName = @"city",
        PossibleTypes = new [] { typeof(string) })]
        string LocationDataCity { get; set; }
        /// <summary>The country or region where the resource is located</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The country or region where the resource is located",
        SerializedName = @"countryOrRegion",
        PossibleTypes = new [] { typeof(string) })]
        string LocationDataCountryOrRegion { get; set; }
        /// <summary>The district, state, or province where the resource is located.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The district, state, or province where the resource is located.",
        SerializedName = @"district",
        PossibleTypes = new [] { typeof(string) })]
        string LocationDataDistrict { get; set; }
        /// <summary>A canonical name for the geographic or physical location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A canonical name for the geographic or physical location.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string LocationDataName { get; set; }
        /// <summary>Specifies the hybrid machine FQDN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the hybrid machine FQDN.",
        SerializedName = @"machineFqdn",
        PossibleTypes = new [] { typeof(string) })]
        string MachineFqdn { get;  }
        /// <summary>The Operating System running on the hybrid machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Operating System running on the hybrid machine.",
        SerializedName = @"osName",
        PossibleTypes = new [] { typeof(string) })]
        string OSName { get;  }
        /// <summary>Specifies the host OS name of the hybrid machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the host OS name of the hybrid machine.",
        SerializedName = @"computerName",
        PossibleTypes = new [] { typeof(string) })]
        string OSProfileComputerName { get;  }
        /// <summary>Specifies the Operating System product SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the Operating System product SKU.",
        SerializedName = @"osSku",
        PossibleTypes = new [] { typeof(string) })]
        string OSSku { get;  }
        /// <summary>The version of Operating System running on the hybrid machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The version of Operating System running on the hybrid machine.",
        SerializedName = @"osVersion",
        PossibleTypes = new [] { typeof(string) })]
        string OSVersion { get;  }
        /// <summary>The provisioning state, which only appears in the response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state, which only appears in the response.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>The status of the hybrid machine agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The status of the hybrid machine agent.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusTypes? Status { get;  }
        /// <summary>Specifies the hybrid machine unique ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the hybrid machine unique ID.",
        SerializedName = @"vmId",
        PossibleTypes = new [] { typeof(string) })]
        string VMId { get; set; }
        /// <summary>Specifies the Arc Machine's unique SMBIOS ID</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the Arc Machine's unique SMBIOS ID",
        SerializedName = @"vmUuid",
        PossibleTypes = new [] { typeof(string) })]
        string VMUuid { get;  }

    }
    /// Describes the properties of a hybrid machine.
    internal partial interface IMachinePropertiesInternal

    {
        /// <summary>Specifies the AD fully qualified display name.</summary>
        string AdFqdn { get; set; }
        /// <summary>The hybrid machine agent full version.</summary>
        string AgentVersion { get; set; }
        /// <summary>
        /// Public Key that the client provides to be used during initial resource onboarding
        /// </summary>
        string ClientPublicKey { get; set; }
        /// <summary>Specifies the hybrid machine display name.</summary>
        string DisplayName { get; set; }
        /// <summary>Specifies the DNS fully qualified display name.</summary>
        string DnsFqdn { get; set; }
        /// <summary>Specifies the Windows domain name.</summary>
        string DomainName { get; set; }
        /// <summary>Details about the error state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IErrorDetail[] ErrorDetail { get; set; }
        /// <summary>Machine Extensions information</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionInstanceView[] Extension { get; set; }
        /// <summary>The time of the last status change.</summary>
        global::System.DateTime? LastStatusChange { get; set; }
        /// <summary>Metadata pertaining to the geographic location of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationData LocationData { get; set; }
        /// <summary>The city or locality where the resource is located.</summary>
        string LocationDataCity { get; set; }
        /// <summary>The country or region where the resource is located</summary>
        string LocationDataCountryOrRegion { get; set; }
        /// <summary>The district, state, or province where the resource is located.</summary>
        string LocationDataDistrict { get; set; }
        /// <summary>A canonical name for the geographic or physical location.</summary>
        string LocationDataName { get; set; }
        /// <summary>Specifies the hybrid machine FQDN.</summary>
        string MachineFqdn { get; set; }
        /// <summary>The Operating System running on the hybrid machine.</summary>
        string OSName { get; set; }
        /// <summary>Specifies the operating system settings for the hybrid machine.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesOSProfile OSProfile { get; set; }
        /// <summary>Specifies the host OS name of the hybrid machine.</summary>
        string OSProfileComputerName { get; set; }
        /// <summary>Specifies the Operating System product SKU.</summary>
        string OSSku { get; set; }
        /// <summary>The version of Operating System running on the hybrid machine.</summary>
        string OSVersion { get; set; }
        /// <summary>The provisioning state, which only appears in the response.</summary>
        string ProvisioningState { get; set; }
        /// <summary>The status of the hybrid machine agent.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusTypes? Status { get; set; }
        /// <summary>Specifies the hybrid machine unique ID.</summary>
        string VMId { get; set; }
        /// <summary>Specifies the Arc Machine's unique SMBIOS ID</summary>
        string VMUuid { get; set; }

    }
}