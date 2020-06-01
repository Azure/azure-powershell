namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
    /// </summary>
    public partial class ManagementPolicySchema :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySchema,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySchemaInternal
    {

        /// <summary>Backing field for <see cref="Rule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRule[] _rule;

        /// <summary>
        /// The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRule[] Rule { get => this._rule; set => this._rule = value; }

        /// <summary>Creates an new <see cref="ManagementPolicySchema" /> instance.</summary>
        public ManagementPolicySchema()
        {

        }
    }
    /// The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
    public partial interface IManagementPolicySchema :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.",
        SerializedName = @"rules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRule[] Rule { get; set; }

    }
    /// The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
    internal partial interface IManagementPolicySchemaInternal

    {
        /// <summary>
        /// The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRule[] Rule { get; set; }

    }
}