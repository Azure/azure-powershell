namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>List of BaseBackupPolicy resources</summary>
    public partial class BaseBackupPolicyResourceList :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBaseBackupPolicyResourceList,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBaseBackupPolicyResourceListInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceList"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceList __dppResourceList = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.DppResourceList();

        /// <summary>
        /// The uri to fetch the next page of resources. Call ListNext() fetches next page of resources.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string NextLink { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceListInternal)__dppResourceList).NextLink; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceListInternal)__dppResourceList).NextLink = value ?? null; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBaseBackupPolicyResource[] _value;

        /// <summary>List of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBaseBackupPolicyResource[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="BaseBackupPolicyResourceList" /> instance.</summary>
        public BaseBackupPolicyResourceList()
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
            await eventListener.AssertNotNull(nameof(__dppResourceList), __dppResourceList);
            await eventListener.AssertObjectIsValid(nameof(__dppResourceList), __dppResourceList);
        }
    }
    /// List of BaseBackupPolicy resources
    public partial interface IBaseBackupPolicyResourceList :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceList
    {
        /// <summary>List of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of resources.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBaseBackupPolicyResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBaseBackupPolicyResource[] Value { get; set; }

    }
    /// List of BaseBackupPolicy resources
    internal partial interface IBaseBackupPolicyResourceListInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceListInternal
    {
        /// <summary>List of resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBaseBackupPolicyResource[] Value { get; set; }

    }
}