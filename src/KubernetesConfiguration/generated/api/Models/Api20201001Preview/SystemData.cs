namespace Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20201001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Extensions;

    /// <summary>
    /// Top level metadata https://github.com/Azure/azure-resource-manager-rpc/blob/master/v1.0/common-api-contracts.md#system-metadata-for-all-azure-resources
    /// </summary>
    public partial class SystemData :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20201001Preview.ISystemData,
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20201001Preview.ISystemDataInternal
    {

        /// <summary>Backing field for <see cref="CreatedAt" /> property.</summary>
        private global::System.DateTime? _createdAt;

        /// <summary>The timestamp of resource creation (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public global::System.DateTime? CreatedAt { get => this._createdAt; }

        /// <summary>Backing field for <see cref="CreatedBy" /> property.</summary>
        private string _createdBy;

        /// <summary>A string identifier for the identity that created the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string CreatedBy { get => this._createdBy; }

        /// <summary>Backing field for <see cref="CreatedByType" /> property.</summary>
        private string _createdByType;

        /// <summary>
        /// The type of identity that created the resource: user, application, managedIdentity, key
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string CreatedByType { get => this._createdByType; }

        /// <summary>Backing field for <see cref="LastModifiedAt" /> property.</summary>
        private global::System.DateTime? _lastModifiedAt;

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public global::System.DateTime? LastModifiedAt { get => this._lastModifiedAt; }

        /// <summary>Backing field for <see cref="LastModifiedBy" /> property.</summary>
        private string _lastModifiedBy;

        /// <summary>A string identifier for the identity that last modified the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string LastModifiedBy { get => this._lastModifiedBy; }

        /// <summary>Backing field for <see cref="LastModifiedByType" /> property.</summary>
        private string _lastModifiedByType;

        /// <summary>
        /// The type of identity that last modified the resource: user, application, managedIdentity, key
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string LastModifiedByType { get => this._lastModifiedByType; }

        /// <summary>Internal Acessors for CreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20201001Preview.ISystemDataInternal.CreatedAt { get => this._createdAt; set { {_createdAt = value;} } }

        /// <summary>Internal Acessors for CreatedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20201001Preview.ISystemDataInternal.CreatedBy { get => this._createdBy; set { {_createdBy = value;} } }

        /// <summary>Internal Acessors for CreatedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20201001Preview.ISystemDataInternal.CreatedByType { get => this._createdByType; set { {_createdByType = value;} } }

        /// <summary>Internal Acessors for LastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20201001Preview.ISystemDataInternal.LastModifiedAt { get => this._lastModifiedAt; set { {_lastModifiedAt = value;} } }

        /// <summary>Internal Acessors for LastModifiedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20201001Preview.ISystemDataInternal.LastModifiedBy { get => this._lastModifiedBy; set { {_lastModifiedBy = value;} } }

        /// <summary>Internal Acessors for LastModifiedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20201001Preview.ISystemDataInternal.LastModifiedByType { get => this._lastModifiedByType; set { {_lastModifiedByType = value;} } }

        /// <summary>Creates an new <see cref="SystemData" /> instance.</summary>
        public SystemData()
        {

        }
    }
    /// Top level metadata https://github.com/Azure/azure-resource-manager-rpc/blob/master/v1.0/common-api-contracts.md#system-metadata-for-all-azure-resources
    public partial interface ISystemData :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>The timestamp of resource creation (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The timestamp of resource creation (UTC)",
        SerializedName = @"createdAt",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedAt { get;  }
        /// <summary>A string identifier for the identity that created the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A string identifier for the identity that created the resource",
        SerializedName = @"createdBy",
        PossibleTypes = new [] { typeof(string) })]
        string CreatedBy { get;  }
        /// <summary>
        /// The type of identity that created the resource: user, application, managedIdentity, key
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of identity that created the resource: user, application, managedIdentity, key",
        SerializedName = @"createdByType",
        PossibleTypes = new [] { typeof(string) })]
        string CreatedByType { get;  }
        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The timestamp of resource last modification (UTC)",
        SerializedName = @"lastModifiedAt",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastModifiedAt { get;  }
        /// <summary>A string identifier for the identity that last modified the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A string identifier for the identity that last modified the resource",
        SerializedName = @"lastModifiedBy",
        PossibleTypes = new [] { typeof(string) })]
        string LastModifiedBy { get;  }
        /// <summary>
        /// The type of identity that last modified the resource: user, application, managedIdentity, key
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of identity that last modified the resource: user, application, managedIdentity, key",
        SerializedName = @"lastModifiedByType",
        PossibleTypes = new [] { typeof(string) })]
        string LastModifiedByType { get;  }

    }
    /// Top level metadata https://github.com/Azure/azure-resource-manager-rpc/blob/master/v1.0/common-api-contracts.md#system-metadata-for-all-azure-resources
    internal partial interface ISystemDataInternal

    {
        /// <summary>The timestamp of resource creation (UTC)</summary>
        global::System.DateTime? CreatedAt { get; set; }
        /// <summary>A string identifier for the identity that created the resource</summary>
        string CreatedBy { get; set; }
        /// <summary>
        /// The type of identity that created the resource: user, application, managedIdentity, key
        /// </summary>
        string CreatedByType { get; set; }
        /// <summary>The timestamp of resource last modification (UTC)</summary>
        global::System.DateTime? LastModifiedAt { get; set; }
        /// <summary>A string identifier for the identity that last modified the resource</summary>
        string LastModifiedBy { get; set; }
        /// <summary>
        /// The type of identity that last modified the resource: user, application, managedIdentity, key
        /// </summary>
        string LastModifiedByType { get; set; }

    }
}