namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Parameters for Operational-Tier DataStore</summary>
    public partial class AzureOperationalStoreParameters :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureOperationalStoreParameters,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureOperationalStoreParametersInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDataStoreParameters"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDataStoreParameters __dataStoreParameters = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.DataStoreParameters();

        /// <summary>type of datastore; Operational/Vault/Archive</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes DataStoreType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDataStoreParametersInternal)__dataStoreParameters).DataStoreType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDataStoreParametersInternal)__dataStoreParameters).DataStoreType = value ; }

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDataStoreParametersInternal)__dataStoreParameters).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDataStoreParametersInternal)__dataStoreParameters).ObjectType = value ; }

        /// <summary>Backing field for <see cref="ResourceGroupId" /> property.</summary>
        private string _resourceGroupId;

        /// <summary>Gets or sets the Resource Group Uri.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ResourceGroupId { get => this._resourceGroupId; set => this._resourceGroupId = value; }

        /// <summary>Creates an new <see cref="AzureOperationalStoreParameters" /> instance.</summary>
        public AzureOperationalStoreParameters()
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
            await eventListener.AssertNotNull(nameof(__dataStoreParameters), __dataStoreParameters);
            await eventListener.AssertObjectIsValid(nameof(__dataStoreParameters), __dataStoreParameters);
        }
    }
    /// Parameters for Operational-Tier DataStore
    public partial interface IAzureOperationalStoreParameters :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDataStoreParameters
    {
        /// <summary>Gets or sets the Resource Group Uri.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the Resource Group Uri.",
        SerializedName = @"resourceGroupId",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGroupId { get; set; }

    }
    /// Parameters for Operational-Tier DataStore
    internal partial interface IAzureOperationalStoreParametersInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDataStoreParametersInternal
    {
        /// <summary>Gets or sets the Resource Group Uri.</summary>
        string ResourceGroupId { get; set; }

    }
}