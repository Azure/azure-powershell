namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>An object that wraps the Lifecycle rule. Each rule is uniquely defined by name.</summary>
    public partial class ManagementPolicyRule :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRule,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRuleInternal
    {

        /// <summary>Backing field for <see cref="Definition" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinition _definition;

        /// <summary>An object that defines the Lifecycle rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinition Definition { get => (this._definition = this._definition ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicyDefinition()); set => this._definition = value; }

        /// <summary>Value indicating the age in days after creation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public float DeleteDaysAfterCreationGreaterThan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).DeleteDaysAfterCreationGreaterThan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).DeleteDaysAfterCreationGreaterThan = value; }

        /// <summary>Value indicating the age in days after last modification</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public float DeleteDaysAfterModificationGreaterThan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).DeleteDaysAfterModificationGreaterThan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).DeleteDaysAfterModificationGreaterThan = value; }

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool? _enabled;

        /// <summary>Rule is enabled if set to true.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>An array of predefined enum values. Only blockBlob is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] FilterBlobType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).FilterBlobType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).FilterBlobType = value; }

        /// <summary>An array of strings for prefixes to be match.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] FilterPrefixMatch { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).FilterPrefixMatch; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).FilterPrefixMatch = value; }

        /// <summary>Internal Acessors for ActionBaseBlob</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlob Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRuleInternal.ActionBaseBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).ActionBaseBlob; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).ActionBaseBlob = value; }

        /// <summary>Internal Acessors for ActionSnapshot</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySnapShot Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRuleInternal.ActionSnapshot { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).ActionSnapshot; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).ActionSnapshot = value; }

        /// <summary>Internal Acessors for BaseBlobDelete</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRuleInternal.BaseBlobDelete { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).BaseBlobDelete; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).BaseBlobDelete = value; }

        /// <summary>Internal Acessors for BaseBlobTierToArchive</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRuleInternal.BaseBlobTierToArchive { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).BaseBlobTierToArchive; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).BaseBlobTierToArchive = value; }

        /// <summary>Internal Acessors for BaseBlobTierToCool</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRuleInternal.BaseBlobTierToCool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).BaseBlobTierToCool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).BaseBlobTierToCool = value; }

        /// <summary>Internal Acessors for Definition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinition Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRuleInternal.Definition { get => (this._definition = this._definition ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicyDefinition()); set { {_definition = value;} } }

        /// <summary>Internal Acessors for DefinitionAction</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyAction Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRuleInternal.DefinitionAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).Action; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).Action = value; }

        /// <summary>Internal Acessors for DefinitionFilter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyFilter Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRuleInternal.DefinitionFilter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).Filter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).Filter = value; }

        /// <summary>Internal Acessors for SnapshotDelete</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterCreation Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRuleInternal.SnapshotDelete { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).SnapshotDelete; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).SnapshotDelete = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyRuleInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within
        /// a policy.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Value indicating the age in days after last modification</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public float TierToArchiveDaysAfterModificationGreaterThan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).TierToArchiveDaysAfterModificationGreaterThan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).TierToArchiveDaysAfterModificationGreaterThan = value; }

        /// <summary>Value indicating the age in days after last modification</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public float TierToCoolDaysAfterModificationGreaterThan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).TierToCoolDaysAfterModificationGreaterThan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal)Definition).TierToCoolDaysAfterModificationGreaterThan = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type= @"Lifecycle";

        /// <summary>The valid value is Lifecycle</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="ManagementPolicyRule" /> instance.</summary>
        public ManagementPolicyRule()
        {

        }
    }
    /// An object that wraps the Lifecycle rule. Each rule is uniquely defined by name.
    public partial interface IManagementPolicyRule :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Value indicating the age in days after creation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Value indicating the age in days after creation",
        SerializedName = @"daysAfterCreationGreaterThan",
        PossibleTypes = new [] { typeof(float) })]
        float DeleteDaysAfterCreationGreaterThan { get; set; }
        /// <summary>Value indicating the age in days after last modification</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Value indicating the age in days after last modification",
        SerializedName = @"daysAfterModificationGreaterThan",
        PossibleTypes = new [] { typeof(float) })]
        float DeleteDaysAfterModificationGreaterThan { get; set; }
        /// <summary>Rule is enabled if set to true.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Rule is enabled if set to true.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Enabled { get; set; }
        /// <summary>An array of predefined enum values. Only blockBlob is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"An array of predefined enum values. Only blockBlob is supported.",
        SerializedName = @"blobTypes",
        PossibleTypes = new [] { typeof(string) })]
        string[] FilterBlobType { get; set; }
        /// <summary>An array of strings for prefixes to be match.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"An array of strings for prefixes to be match.",
        SerializedName = @"prefixMatch",
        PossibleTypes = new [] { typeof(string) })]
        string[] FilterPrefixMatch { get; set; }
        /// <summary>
        /// A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within
        /// a policy.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within a policy.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Value indicating the age in days after last modification</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Value indicating the age in days after last modification",
        SerializedName = @"daysAfterModificationGreaterThan",
        PossibleTypes = new [] { typeof(float) })]
        float TierToArchiveDaysAfterModificationGreaterThan { get; set; }
        /// <summary>Value indicating the age in days after last modification</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Value indicating the age in days after last modification",
        SerializedName = @"daysAfterModificationGreaterThan",
        PossibleTypes = new [] { typeof(float) })]
        float TierToCoolDaysAfterModificationGreaterThan { get; set; }
        /// <summary>The valid value is Lifecycle</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Description = @"The valid value is Lifecycle",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// An object that wraps the Lifecycle rule. Each rule is uniquely defined by name.
    internal partial interface IManagementPolicyRuleInternal

    {
        /// <summary>The management policy action for base blob</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlob ActionBaseBlob { get; set; }
        /// <summary>The management policy action for snapshot</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySnapShot ActionSnapshot { get; set; }
        /// <summary>The function to delete the blob</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification BaseBlobDelete { get; set; }
        /// <summary>
        /// The function to tier blobs to archive storage. Support blobs currently at Hot or Cool tier
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification BaseBlobTierToArchive { get; set; }
        /// <summary>The function to tier blobs to cool storage. Support blobs currently at Hot tier</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification BaseBlobTierToCool { get; set; }
        /// <summary>An object that defines the Lifecycle rule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinition Definition { get; set; }
        /// <summary>An object that defines the action set.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyAction DefinitionAction { get; set; }
        /// <summary>An object that defines the filter set.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyFilter DefinitionFilter { get; set; }
        /// <summary>Value indicating the age in days after creation</summary>
        float DeleteDaysAfterCreationGreaterThan { get; set; }
        /// <summary>Value indicating the age in days after last modification</summary>
        float DeleteDaysAfterModificationGreaterThan { get; set; }
        /// <summary>Rule is enabled if set to true.</summary>
        bool? Enabled { get; set; }
        /// <summary>An array of predefined enum values. Only blockBlob is supported.</summary>
        string[] FilterBlobType { get; set; }
        /// <summary>An array of strings for prefixes to be match.</summary>
        string[] FilterPrefixMatch { get; set; }
        /// <summary>
        /// A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within
        /// a policy.
        /// </summary>
        string Name { get; set; }
        /// <summary>The function to delete the blob snapshot</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterCreation SnapshotDelete { get; set; }
        /// <summary>Value indicating the age in days after last modification</summary>
        float TierToArchiveDaysAfterModificationGreaterThan { get; set; }
        /// <summary>Value indicating the age in days after last modification</summary>
        float TierToCoolDaysAfterModificationGreaterThan { get; set; }
        /// <summary>The valid value is Lifecycle</summary>
        string Type { get; set; }

    }
}