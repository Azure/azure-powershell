namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Datasource to be backed up</summary>
    public partial class Datasource :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDatasource,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDatasourceInternal
    {

        /// <summary>Backing field for <see cref="ObjectType" /> property.</summary>
        private string _objectType;

        /// <summary>Type of Datasource object, used to initialize the right inherited type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ObjectType { get => this._objectType; set => this._objectType = value; }

        /// <summary>Backing field for <see cref="ResourceId" /> property.</summary>
        private string _resourceId;

        /// <summary>
        /// Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created
        /// by backup service via Fabric/Vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ResourceId { get => this._resourceId; set => this._resourceId = value; }

        /// <summary>Backing field for <see cref="ResourceLocation" /> property.</summary>
        private string _resourceLocation;

        /// <summary>Location of datasource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ResourceLocation { get => this._resourceLocation; set => this._resourceLocation = value; }

        /// <summary>Backing field for <see cref="ResourceName" /> property.</summary>
        private string _resourceName;

        /// <summary>Unique identifier of the resource in the context of parent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ResourceName { get => this._resourceName; set => this._resourceName = value; }

        /// <summary>Backing field for <see cref="ResourceType" /> property.</summary>
        private string _resourceType;

        /// <summary>Resource Type of Datasource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ResourceType { get => this._resourceType; set => this._resourceType = value; }

        /// <summary>Backing field for <see cref="ResourceUri" /> property.</summary>
        private string _resourceUri;

        /// <summary>Uri of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ResourceUri { get => this._resourceUri; set => this._resourceUri = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>DatasourceType of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="Datasource" /> instance.</summary>
        public Datasource()
        {

        }
    }
    /// Datasource to be backed up
    public partial interface IDatasource :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Type of Datasource object, used to initialize the right inherited type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of Datasource object, used to initialize the right inherited type",
        SerializedName = @"objectType",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectType { get; set; }
        /// <summary>
        /// Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created
        /// by backup service via Fabric/Vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.",
        SerializedName = @"resourceID",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceId { get; set; }
        /// <summary>Location of datasource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Location of datasource.",
        SerializedName = @"resourceLocation",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceLocation { get; set; }
        /// <summary>Unique identifier of the resource in the context of parent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Unique identifier of the resource in the context of parent.",
        SerializedName = @"resourceName",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceName { get; set; }
        /// <summary>Resource Type of Datasource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource Type of Datasource.",
        SerializedName = @"resourceType",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceType { get; set; }
        /// <summary>Uri of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Uri of the resource.",
        SerializedName = @"resourceUri",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceUri { get; set; }
        /// <summary>DatasourceType of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"DatasourceType of the resource.",
        SerializedName = @"datasourceType",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// Datasource to be backed up
    internal partial interface IDatasourceInternal

    {
        /// <summary>Type of Datasource object, used to initialize the right inherited type</summary>
        string ObjectType { get; set; }
        /// <summary>
        /// Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created
        /// by backup service via Fabric/Vault.
        /// </summary>
        string ResourceId { get; set; }
        /// <summary>Location of datasource.</summary>
        string ResourceLocation { get; set; }
        /// <summary>Unique identifier of the resource in the context of parent.</summary>
        string ResourceName { get; set; }
        /// <summary>Resource Type of Datasource.</summary>
        string ResourceType { get; set; }
        /// <summary>Uri of the resource.</summary>
        string ResourceUri { get; set; }
        /// <summary>DatasourceType of the resource.</summary>
        string Type { get; set; }

    }
}