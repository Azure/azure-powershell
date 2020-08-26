namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>App resource properties payload</summary>
    public partial class AppResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IAppResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IAppResourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="ActiveDeploymentName" /> property.</summary>
        private string _activeDeploymentName;

        /// <summary>Name of the active deployment of the App</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string ActiveDeploymentName { get => this._activeDeploymentName; set => this._activeDeploymentName = value; }

        /// <summary>Backing field for <see cref="CreatedTime" /> property.</summary>
        private global::System.DateTime? _createdTime;

        /// <summary>Date time when the resource is created</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public global::System.DateTime? CreatedTime { get => this._createdTime; }

        /// <summary>Backing field for <see cref="Fqdn" /> property.</summary>
        private string _fqdn;

        /// <summary>Fully qualified dns Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Fqdn { get => this._fqdn; set => this._fqdn = value; }

        /// <summary>Backing field for <see cref="HttpsOnly" /> property.</summary>
        private bool? _httpsOnly;

        /// <summary>Indicate if only https is allowed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public bool? HttpsOnly { get => this._httpsOnly; set => this._httpsOnly = value; }

        /// <summary>Internal Acessors for CreatedTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IAppResourcePropertiesInternal.CreatedTime { get => this._createdTime; set { {_createdTime = value;} } }

        /// <summary>Internal Acessors for PersistentDisk</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IPersistentDisk Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IAppResourcePropertiesInternal.PersistentDisk { get => (this._persistentDisk = this._persistentDisk ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.PersistentDisk()); set { {_persistentDisk = value;} } }

        /// <summary>Internal Acessors for PersistentDiskUsedInGb</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IAppResourcePropertiesInternal.PersistentDiskUsedInGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IPersistentDiskInternal)PersistentDisk).UsedInGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IPersistentDiskInternal)PersistentDisk).UsedInGb = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.AppResourceProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IAppResourcePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for TemporaryDisk</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITemporaryDisk Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IAppResourcePropertiesInternal.TemporaryDisk { get => (this._temporaryDisk = this._temporaryDisk ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.TemporaryDisk()); set { {_temporaryDisk = value;} } }

        /// <summary>Internal Acessors for Url</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IAppResourcePropertiesInternal.Url { get => this._url; set { {_url = value;} } }

        /// <summary>Backing field for <see cref="PersistentDisk" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IPersistentDisk _persistentDisk;

        /// <summary>Persistent disk settings</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IPersistentDisk PersistentDisk { get => (this._persistentDisk = this._persistentDisk ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.PersistentDisk()); set => this._persistentDisk = value; }

        /// <summary>Mount path of the persistent disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string PersistentDiskMountPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IPersistentDiskInternal)PersistentDisk).MountPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IPersistentDiskInternal)PersistentDisk).MountPath = value; }

        /// <summary>Size of the persistent disk in GB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public int? PersistentDiskSizeInGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IPersistentDiskInternal)PersistentDisk).SizeInGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IPersistentDiskInternal)PersistentDisk).SizeInGb = value; }

        /// <summary>Size of the used persistent disk in GB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public int? PersistentDiskUsedInGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IPersistentDiskInternal)PersistentDisk).UsedInGb; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.AppResourceProvisioningState? _provisioningState;

        /// <summary>Provisioning state of the App</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.AppResourceProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="Public" /> property.</summary>
        private bool? _public;

        /// <summary>Indicates whether the App exposes public endpoint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public bool? Public { get => this._public; set => this._public = value; }

        /// <summary>Backing field for <see cref="TemporaryDisk" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITemporaryDisk _temporaryDisk;

        /// <summary>Temporary disk settings</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITemporaryDisk TemporaryDisk { get => (this._temporaryDisk = this._temporaryDisk ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.TemporaryDisk()); set => this._temporaryDisk = value; }

        /// <summary>Mount path of the temporary disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string TemporaryDiskMountPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITemporaryDiskInternal)TemporaryDisk).MountPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITemporaryDiskInternal)TemporaryDisk).MountPath = value; }

        /// <summary>Size of the temporary disk in GB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public int? TemporaryDiskSizeInGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITemporaryDiskInternal)TemporaryDisk).SizeInGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITemporaryDiskInternal)TemporaryDisk).SizeInGb = value; }

        /// <summary>Backing field for <see cref="Url" /> property.</summary>
        private string _url;

        /// <summary>URL of the App</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Url { get => this._url; }

        /// <summary>Creates an new <see cref="AppResourceProperties" /> instance.</summary>
        public AppResourceProperties()
        {

        }
    }
    /// App resource properties payload
    public partial interface IAppResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>Name of the active deployment of the App</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the active deployment of the App",
        SerializedName = @"activeDeploymentName",
        PossibleTypes = new [] { typeof(string) })]
        string ActiveDeploymentName { get; set; }
        /// <summary>Date time when the resource is created</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Date time when the resource is created",
        SerializedName = @"createdTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedTime { get;  }
        /// <summary>Fully qualified dns Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fully qualified dns Name.",
        SerializedName = @"fqdn",
        PossibleTypes = new [] { typeof(string) })]
        string Fqdn { get; set; }
        /// <summary>Indicate if only https is allowed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicate if only https is allowed.",
        SerializedName = @"httpsOnly",
        PossibleTypes = new [] { typeof(bool) })]
        bool? HttpsOnly { get; set; }
        /// <summary>Mount path of the persistent disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Mount path of the persistent disk",
        SerializedName = @"mountPath",
        PossibleTypes = new [] { typeof(string) })]
        string PersistentDiskMountPath { get; set; }
        /// <summary>Size of the persistent disk in GB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Size of the persistent disk in GB",
        SerializedName = @"sizeInGB",
        PossibleTypes = new [] { typeof(int) })]
        int? PersistentDiskSizeInGb { get; set; }
        /// <summary>Size of the used persistent disk in GB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Size of the used persistent disk in GB",
        SerializedName = @"usedInGB",
        PossibleTypes = new [] { typeof(int) })]
        int? PersistentDiskUsedInGb { get;  }
        /// <summary>Provisioning state of the App</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the App",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.AppResourceProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.AppResourceProvisioningState? ProvisioningState { get;  }
        /// <summary>Indicates whether the App exposes public endpoint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether the App exposes public endpoint",
        SerializedName = @"public",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Public { get; set; }
        /// <summary>Mount path of the temporary disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Mount path of the temporary disk",
        SerializedName = @"mountPath",
        PossibleTypes = new [] { typeof(string) })]
        string TemporaryDiskMountPath { get; set; }
        /// <summary>Size of the temporary disk in GB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Size of the temporary disk in GB",
        SerializedName = @"sizeInGB",
        PossibleTypes = new [] { typeof(int) })]
        int? TemporaryDiskSizeInGb { get; set; }
        /// <summary>URL of the App</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"URL of the App",
        SerializedName = @"url",
        PossibleTypes = new [] { typeof(string) })]
        string Url { get;  }

    }
    /// App resource properties payload
    public partial interface IAppResourcePropertiesInternal

    {
        /// <summary>Name of the active deployment of the App</summary>
        string ActiveDeploymentName { get; set; }
        /// <summary>Date time when the resource is created</summary>
        global::System.DateTime? CreatedTime { get; set; }
        /// <summary>Fully qualified dns Name.</summary>
        string Fqdn { get; set; }
        /// <summary>Indicate if only https is allowed.</summary>
        bool? HttpsOnly { get; set; }
        /// <summary>Persistent disk settings</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IPersistentDisk PersistentDisk { get; set; }
        /// <summary>Mount path of the persistent disk</summary>
        string PersistentDiskMountPath { get; set; }
        /// <summary>Size of the persistent disk in GB</summary>
        int? PersistentDiskSizeInGb { get; set; }
        /// <summary>Size of the used persistent disk in GB</summary>
        int? PersistentDiskUsedInGb { get; set; }
        /// <summary>Provisioning state of the App</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.AppResourceProvisioningState? ProvisioningState { get; set; }
        /// <summary>Indicates whether the App exposes public endpoint</summary>
        bool? Public { get; set; }
        /// <summary>Temporary disk settings</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITemporaryDisk TemporaryDisk { get; set; }
        /// <summary>Mount path of the temporary disk</summary>
        string TemporaryDiskMountPath { get; set; }
        /// <summary>Size of the temporary disk in GB</summary>
        int? TemporaryDiskSizeInGb { get; set; }
        /// <summary>URL of the App</summary>
        string Url { get; set; }

    }
}