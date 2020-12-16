namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>BaseBackupPolicy resource</summary>
    public partial class BaseBackupPolicyResource :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBaseBackupPolicyResource,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBaseBackupPolicyResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDppResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDppResource __dppResource = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.DppResource();

        /// <summary>Type of datasource for the backup management</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string[] DatasourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBaseBackupPolicyInternal)Property).DatasourceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBaseBackupPolicyInternal)Property).DatasourceType = value; }

        /// <summary>Resource Id represents the complete path to the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDppResourceInternal)__dppResource).Id; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBaseBackupPolicy Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBaseBackupPolicyResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.BaseBackupPolicy()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDppResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDppResourceInternal)__dppResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDppResourceInternal)__dppResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDppResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDppResourceInternal)__dppResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDppResourceInternal)__dppResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDppResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDppResourceInternal)__dppResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDppResourceInternal)__dppResource).Type = value; }

        /// <summary>Resource name associated with the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDppResourceInternal)__dppResource).Name; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBaseBackupPolicyInternal)Property).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBaseBackupPolicyInternal)Property).ObjectType = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBaseBackupPolicy _property;

        /// <summary>BaseBackupPolicyResource properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBaseBackupPolicy Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.BaseBackupPolicy()); set => this._property = value; }

        /// <summary>
        /// Resource type represents the complete path of the form Namespace/ResourceType/ResourceType/...
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDppResourceInternal)__dppResource).Type; }

        /// <summary>Creates an new <see cref="BaseBackupPolicyResource" /> instance.</summary>
        public BaseBackupPolicyResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__dppResource), __dppResource);
            await eventListener.AssertObjectIsValid(nameof(__dppResource), __dppResource);
        }
    }
    /// BaseBackupPolicy resource
    public partial interface IBaseBackupPolicyResource :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDppResource
    {
        /// <summary>Type of datasource for the backup management</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Type of datasource for the backup management",
        SerializedName = @"datasourceTypes",
        PossibleTypes = new [] { typeof(string) })]
        string[] DatasourceType { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"objectType",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectType { get; set; }

    }
    /// BaseBackupPolicy resource
    internal partial interface IBaseBackupPolicyResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDppResourceInternal
    {
        /// <summary>Type of datasource for the backup management</summary>
        string[] DatasourceType { get; set; }

        string ObjectType { get; set; }
        /// <summary>BaseBackupPolicyResource properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBaseBackupPolicy Property { get; set; }

    }
}