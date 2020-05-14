namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The Storage Account ManagementPolicy properties.</summary>
    public partial class ManagementPolicyProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyPropertiesInternal
    {

        /// <summary>Backing field for <see cref="LastModifiedTime" /> property.</summary>
        private global::System.DateTime? _lastModifiedTime;

        /// <summary>Returns the date and time the ManagementPolicies was last modified.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? LastModifiedTime { get => this._lastModifiedTime; }

        /// <summary>Internal Acessors for LastModifiedTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyPropertiesInternal.LastModifiedTime { get => this._lastModifiedTime; set { {_lastModifiedTime = value;} } }

        /// <summary>Internal Acessors for Policy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySchema Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyPropertiesInternal.Policy { get => (this._policy = this._policy ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicySchema()); set { {_policy = value;} } }

        /// <summary>Backing field for <see cref="Policy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySchema _policy;

        /// <summary>
        /// The Storage Account ManagementPolicy, in JSON format. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySchema Policy { get => (this._policy = this._policy ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicySchema()); set => this._policy = value; }

        /// <summary>
        /// The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRule[] PolicyRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySchemaInternal)Policy).Rule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySchemaInternal)Policy).Rule = value; }

        /// <summary>Creates an new <see cref="ManagementPolicyProperties" /> instance.</summary>
        public ManagementPolicyProperties()
        {

        }
    }
    /// The Storage Account ManagementPolicy properties.
    public partial interface IManagementPolicyProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Returns the date and time the ManagementPolicies was last modified.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Returns the date and time the ManagementPolicies was last modified.",
        SerializedName = @"lastModifiedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastModifiedTime { get;  }
        /// <summary>
        /// The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.",
        SerializedName = @"rules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRule[] PolicyRule { get; set; }

    }
    /// The Storage Account ManagementPolicy properties.
    internal partial interface IManagementPolicyPropertiesInternal

    {
        /// <summary>Returns the date and time the ManagementPolicies was last modified.</summary>
        global::System.DateTime? LastModifiedTime { get; set; }
        /// <summary>
        /// The Storage Account ManagementPolicy, in JSON format. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySchema Policy { get; set; }
        /// <summary>
        /// The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRule[] PolicyRule { get; set; }

    }
}