namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Vault health details definition.</summary>
    public partial class VaultHealthDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.Resource();

        /// <summary>The categorized resource counts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts ContainerHealthCategorizedResourceCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).ContainerHealthCategorizedResourceCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).ContainerHealthCategorizedResourceCount = value ?? null /* model class */; }

        /// <summary>The list of summary of health errors across the resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] ContainerHealthIssue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).ContainerHealthIssue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).ContainerHealthIssue = value ?? null /* arrayOf */; }

        /// <summary>The count of total resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? ContainerHealthResourceCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).ContainerHealthResourceCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).ContainerHealthResourceCount = value ?? default(int); }

        /// <summary>The categorized resource counts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts FabricHealthCategorizedResourceCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).FabricHealthCategorizedResourceCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).FabricHealthCategorizedResourceCount = value ?? null /* model class */; }

        /// <summary>The list of summary of health errors across the resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] FabricHealthIssue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).FabricHealthIssue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).FabricHealthIssue = value ?? null /* arrayOf */; }

        /// <summary>The count of total resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? FabricHealthResourceCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).FabricHealthResourceCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).FabricHealthResourceCount = value ?? default(int); }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id; }

        /// <summary>Resource Location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Location = value ?? null; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type = value; }

        /// <summary>Internal Acessors for ContainersHealth</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthDetailsInternal.ContainersHealth { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).ContainersHealth; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).ContainersHealth = value; }

        /// <summary>Internal Acessors for FabricsHealth</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthDetailsInternal.FabricsHealth { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).FabricsHealth; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).FabricsHealth = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthDetailsInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VaultHealthProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProtectedItemsHealth</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthDetailsInternal.ProtectedItemsHealth { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).ProtectedItemsHealth; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).ProtectedItemsHealth = value; }

        /// <summary>Resource Name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthProperties _property;

        /// <summary>The vault health related data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VaultHealthProperties()); set => this._property = value; }

        /// <summary>The categorized resource counts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts ProtectedItemHealthCategorizedResourceCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).ProtectedItemHealthCategorizedResourceCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).ProtectedItemHealthCategorizedResourceCount = value ?? null /* model class */; }

        /// <summary>The list of summary of health errors across the resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] ProtectedItemHealthIssue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).ProtectedItemHealthIssue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).ProtectedItemHealthIssue = value ?? null /* arrayOf */; }

        /// <summary>The count of total resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? ProtectedItemHealthResourceCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).ProtectedItemHealthResourceCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).ProtectedItemHealthResourceCount = value ?? default(int); }

        /// <summary>Resource Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type; }

        /// <summary>The list of errors on the vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] VaultError { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).VaultError; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)Property).VaultError = value ?? null /* arrayOf */; }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }

        /// <summary>Creates an new <see cref="VaultHealthDetails" /> instance.</summary>
        public VaultHealthDetails()
        {

        }
    }
    /// Vault health details definition.
    public partial interface IVaultHealthDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource
    {
        /// <summary>The categorized resource counts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The categorized resource counts.",
        SerializedName = @"categorizedResourceCounts",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts ContainerHealthCategorizedResourceCount { get; set; }
        /// <summary>The list of summary of health errors across the resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of summary of health errors across the resources under the container.",
        SerializedName = @"issues",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] ContainerHealthIssue { get; set; }
        /// <summary>The count of total resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The count of total resources under the container.",
        SerializedName = @"resourceCount",
        PossibleTypes = new [] { typeof(int) })]
        int? ContainerHealthResourceCount { get; set; }
        /// <summary>The categorized resource counts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The categorized resource counts.",
        SerializedName = @"categorizedResourceCounts",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts FabricHealthCategorizedResourceCount { get; set; }
        /// <summary>The list of summary of health errors across the resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of summary of health errors across the resources under the container.",
        SerializedName = @"issues",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] FabricHealthIssue { get; set; }
        /// <summary>The count of total resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The count of total resources under the container.",
        SerializedName = @"resourceCount",
        PossibleTypes = new [] { typeof(int) })]
        int? FabricHealthResourceCount { get; set; }
        /// <summary>The categorized resource counts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The categorized resource counts.",
        SerializedName = @"categorizedResourceCounts",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts ProtectedItemHealthCategorizedResourceCount { get; set; }
        /// <summary>The list of summary of health errors across the resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of summary of health errors across the resources under the container.",
        SerializedName = @"issues",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] ProtectedItemHealthIssue { get; set; }
        /// <summary>The count of total resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The count of total resources under the container.",
        SerializedName = @"resourceCount",
        PossibleTypes = new [] { typeof(int) })]
        int? ProtectedItemHealthResourceCount { get; set; }
        /// <summary>The list of errors on the vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of errors on the vault.",
        SerializedName = @"vaultErrors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] VaultError { get; set; }

    }
    /// Vault health details definition.
    internal partial interface IVaultHealthDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal
    {
        /// <summary>The categorized resource counts.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts ContainerHealthCategorizedResourceCount { get; set; }
        /// <summary>The list of summary of health errors across the resources under the container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] ContainerHealthIssue { get; set; }
        /// <summary>The count of total resources under the container.</summary>
        int? ContainerHealthResourceCount { get; set; }
        /// <summary>The list of the health detail of the containers in the vault.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary ContainersHealth { get; set; }
        /// <summary>The categorized resource counts.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts FabricHealthCategorizedResourceCount { get; set; }
        /// <summary>The list of summary of health errors across the resources under the container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] FabricHealthIssue { get; set; }
        /// <summary>The count of total resources under the container.</summary>
        int? FabricHealthResourceCount { get; set; }
        /// <summary>The list of the health detail of the fabrics in the vault.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary FabricsHealth { get; set; }
        /// <summary>The vault health related data.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthProperties Property { get; set; }
        /// <summary>The categorized resource counts.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts ProtectedItemHealthCategorizedResourceCount { get; set; }
        /// <summary>The list of summary of health errors across the resources under the container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] ProtectedItemHealthIssue { get; set; }
        /// <summary>The count of total resources under the container.</summary>
        int? ProtectedItemHealthResourceCount { get; set; }
        /// <summary>The list of the health detail of the protected items in the vault.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary ProtectedItemsHealth { get; set; }
        /// <summary>The list of errors on the vault.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] VaultError { get; set; }

    }
}