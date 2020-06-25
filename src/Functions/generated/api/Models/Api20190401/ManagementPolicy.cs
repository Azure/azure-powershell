namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The Get Storage Account ManagementPolicies operation response.</summary>
    public partial class ManagementPolicy :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicy,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.Resource();

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Id; }

        /// <summary>Returns the date and time the ManagementPolicies was last modified.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? LastModifiedTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyPropertiesInternal)Property).LastModifiedTime; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Type = value; }

        /// <summary>Internal Acessors for LastModifiedTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyInternal.LastModifiedTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyPropertiesInternal)Property).LastModifiedTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyPropertiesInternal)Property).LastModifiedTime = value; }

        /// <summary>Internal Acessors for Policy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySchema Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyInternal.Policy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyPropertiesInternal)Property).Policy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyPropertiesInternal)Property).Policy = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicyProperties()); set { {_property = value;} } }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Name; }

        /// <summary>
        /// The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRule[] PolicyRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyPropertiesInternal)Property).PolicyRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyPropertiesInternal)Property).PolicyRule = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyProperties _property;

        /// <summary>Returns the Storage Account Data Policies Rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicyProperties()); set => this._property = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="ManagementPolicy" /> instance.</summary>
        public ManagementPolicy()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// The Get Storage Account ManagementPolicies operation response.
    public partial interface IManagementPolicy :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResource
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
    /// The Get Storage Account ManagementPolicies operation response.
    internal partial interface IManagementPolicyInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal
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
        /// <summary>Returns the Storage Account Data Policies Rules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyProperties Property { get; set; }

    }
}