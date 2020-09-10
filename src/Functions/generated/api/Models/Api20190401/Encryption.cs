namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The encryption settings on the storage account.</summary>
    public partial class Encryption :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryption,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal
    {

        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? BlobEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).BlobEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).BlobEnabled = value; }

        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? BlobLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).BlobLastEnabledTime; }

        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? FileEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).FileEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).FileEnabled = value; }

        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? FileLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).FileLastEnabledTime; }

        /// <summary>Backing field for <see cref="KeySource" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeySource _keySource;

        /// <summary>
        /// The encryption keySource (provider). Possible values (case-insensitive): Microsoft.Storage, Microsoft.Keyvault
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeySource KeySource { get => this._keySource; set => this._keySource = value; }

        /// <summary>Backing field for <see cref="Keyvaultproperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IKeyVaultProperties _keyvaultproperty;

        /// <summary>Properties provided by key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IKeyVaultProperties Keyvaultproperty { get => (this._keyvaultproperty = this._keyvaultproperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.KeyVaultProperties()); set => this._keyvaultproperty = value; }

        /// <summary>The name of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string KeyvaultpropertyKeyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IKeyVaultPropertiesInternal)Keyvaultproperty).KeyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IKeyVaultPropertiesInternal)Keyvaultproperty).KeyName = value; }

        /// <summary>The Uri of KeyVault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string KeyvaultpropertyKeyVaultUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IKeyVaultPropertiesInternal)Keyvaultproperty).KeyVaultUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IKeyVaultPropertiesInternal)Keyvaultproperty).KeyVaultUri = value; }

        /// <summary>The version of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string KeyvaultpropertyKeyVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IKeyVaultPropertiesInternal)Keyvaultproperty).KeyVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IKeyVaultPropertiesInternal)Keyvaultproperty).KeyVersion = value; }

        /// <summary>Internal Acessors for BlobLastEnabledTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal.BlobLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).BlobLastEnabledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).BlobLastEnabledTime = value; }

        /// <summary>Internal Acessors for FileLastEnabledTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal.FileLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).FileLastEnabledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).FileLastEnabledTime = value; }

        /// <summary>Internal Acessors for Keyvaultproperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IKeyVaultProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal.Keyvaultproperty { get => (this._keyvaultproperty = this._keyvaultproperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.KeyVaultProperties()); set { {_keyvaultproperty = value;} } }

        /// <summary>Internal Acessors for QueueLastEnabledTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal.QueueLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).QueueLastEnabledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).QueueLastEnabledTime = value; }

        /// <summary>Internal Acessors for Service</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServices Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal.Service { get => (this._service = this._service ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServices()); set { {_service = value;} } }

        /// <summary>Internal Acessors for ServiceBlob</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal.ServiceBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).Blob; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).Blob = value; }

        /// <summary>Internal Acessors for ServiceFile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal.ServiceFile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).File; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).File = value; }

        /// <summary>Internal Acessors for ServiceQueue</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal.ServiceQueue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).Queue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).Queue = value; }

        /// <summary>Internal Acessors for ServiceTable</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal.ServiceTable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).Table; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).Table = value; }

        /// <summary>Internal Acessors for TableLastEnabledTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal.TableLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).TableLastEnabledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).TableLastEnabledTime = value; }

        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? QueueEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).QueueEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).QueueEnabled = value; }

        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? QueueLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).QueueLastEnabledTime; }

        /// <summary>Backing field for <see cref="Service" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServices _service;

        /// <summary>List of services which support encryption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServices Service { get => (this._service = this._service ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServices()); set => this._service = value; }

        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? TableEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).TableEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).TableEnabled = value; }

        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? TableLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)Service).TableLastEnabledTime; }

        /// <summary>Creates an new <see cref="Encryption" /> instance.</summary>
        public Encryption()
        {

        }
    }
    /// The encryption settings on the storage account.
    public partial interface IEncryption :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A boolean indicating whether or not the service encrypts the data as it is stored.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? BlobEnabled { get; set; }
        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.",
        SerializedName = @"lastEnabledTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? BlobLastEnabledTime { get;  }
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A boolean indicating whether or not the service encrypts the data as it is stored.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? FileEnabled { get; set; }
        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.",
        SerializedName = @"lastEnabledTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? FileLastEnabledTime { get;  }
        /// <summary>
        /// The encryption keySource (provider). Possible values (case-insensitive): Microsoft.Storage, Microsoft.Keyvault
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The encryption keySource (provider). Possible values (case-insensitive):  Microsoft.Storage, Microsoft.Keyvault",
        SerializedName = @"keySource",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeySource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeySource KeySource { get; set; }
        /// <summary>The name of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of KeyVault key.",
        SerializedName = @"keyname",
        PossibleTypes = new [] { typeof(string) })]
        string KeyvaultpropertyKeyName { get; set; }
        /// <summary>The Uri of KeyVault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Uri of KeyVault.",
        SerializedName = @"keyvaulturi",
        PossibleTypes = new [] { typeof(string) })]
        string KeyvaultpropertyKeyVaultUri { get; set; }
        /// <summary>The version of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The version of KeyVault key.",
        SerializedName = @"keyversion",
        PossibleTypes = new [] { typeof(string) })]
        string KeyvaultpropertyKeyVersion { get; set; }
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A boolean indicating whether or not the service encrypts the data as it is stored.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? QueueEnabled { get; set; }
        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.",
        SerializedName = @"lastEnabledTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? QueueLastEnabledTime { get;  }
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A boolean indicating whether or not the service encrypts the data as it is stored.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? TableEnabled { get; set; }
        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.",
        SerializedName = @"lastEnabledTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? TableLastEnabledTime { get;  }

    }
    /// The encryption settings on the storage account.
    internal partial interface IEncryptionInternal

    {
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        bool? BlobEnabled { get; set; }
        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        global::System.DateTime? BlobLastEnabledTime { get; set; }
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        bool? FileEnabled { get; set; }
        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        global::System.DateTime? FileLastEnabledTime { get; set; }
        /// <summary>
        /// The encryption keySource (provider). Possible values (case-insensitive): Microsoft.Storage, Microsoft.Keyvault
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeySource KeySource { get; set; }
        /// <summary>Properties provided by key vault.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IKeyVaultProperties Keyvaultproperty { get; set; }
        /// <summary>The name of KeyVault key.</summary>
        string KeyvaultpropertyKeyName { get; set; }
        /// <summary>The Uri of KeyVault.</summary>
        string KeyvaultpropertyKeyVaultUri { get; set; }
        /// <summary>The version of KeyVault key.</summary>
        string KeyvaultpropertyKeyVersion { get; set; }
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        bool? QueueEnabled { get; set; }
        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        global::System.DateTime? QueueLastEnabledTime { get; set; }
        /// <summary>List of services which support encryption.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServices Service { get; set; }
        /// <summary>The encryption function of the blob storage service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService ServiceBlob { get; set; }
        /// <summary>The encryption function of the file storage service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService ServiceFile { get; set; }
        /// <summary>The encryption function of the queue storage service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService ServiceQueue { get; set; }
        /// <summary>The encryption function of the table storage service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService ServiceTable { get; set; }
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        bool? TableEnabled { get; set; }
        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        global::System.DateTime? TableLastEnabledTime { get; set; }

    }
}