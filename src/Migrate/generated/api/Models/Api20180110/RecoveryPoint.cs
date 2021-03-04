namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Base class representing a recovery point.</summary>
    public partial class RecoveryPoint :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPoint,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPointInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.Resource();

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id; }

        /// <summary>Resource Location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Location = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPointProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPointInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RecoveryPointProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProviderSpecificDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificRecoveryPointDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPointInternal.ProviderSpecificDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPointPropertiesInternal)Property).ProviderSpecificDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPointPropertiesInternal)Property).ProviderSpecificDetail = value; }

        /// <summary>Internal Acessors for ProviderSpecificDetailInstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPointInternal.ProviderSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPointPropertiesInternal)Property).ProviderSpecificDetailInstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPointPropertiesInternal)Property).ProviderSpecificDetailInstanceType = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource Name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPointProperties _property;

        /// <summary>Recovery point related data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPointProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RecoveryPointProperties()); set => this._property = value; }

        /// <summary>Gets the provider type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProviderSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPointPropertiesInternal)Property).ProviderSpecificDetailInstanceType; }

        /// <summary>The recovery point type: ApplicationConsistent, CrashConsistent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RecoveryPointType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPointPropertiesInternal)Property).RecoveryPointType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPointPropertiesInternal)Property).RecoveryPointType = value ?? null; }

        /// <summary>The recovery point time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public global::System.DateTime? Time { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPointPropertiesInternal)Property).RecoveryPointTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPointPropertiesInternal)Property).RecoveryPointTime = value ?? default(global::System.DateTime); }

        /// <summary>Resource Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="RecoveryPoint" /> instance.</summary>
        public RecoveryPoint()
        {

        }

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
    }
    /// Base class representing a recovery point.
    public partial interface IRecoveryPoint :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource
    {
        /// <summary>Gets the provider type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the provider type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string ProviderSpecificDetailInstanceType { get;  }
        /// <summary>The recovery point type: ApplicationConsistent, CrashConsistent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery point type: ApplicationConsistent, CrashConsistent.",
        SerializedName = @"recoveryPointType",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryPointType { get; set; }
        /// <summary>The recovery point time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery point time.",
        SerializedName = @"recoveryPointTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? Time { get; set; }

    }
    /// Base class representing a recovery point.
    internal partial interface IRecoveryPointInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal
    {
        /// <summary>Recovery point related data.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPointProperties Property { get; set; }
        /// <summary>The provider specific details for the recovery point.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificRecoveryPointDetails ProviderSpecificDetail { get; set; }
        /// <summary>Gets the provider type.</summary>
        string ProviderSpecificDetailInstanceType { get; set; }
        /// <summary>The recovery point type: ApplicationConsistent, CrashConsistent.</summary>
        string RecoveryPointType { get; set; }
        /// <summary>The recovery point time.</summary>
        global::System.DateTime? Time { get; set; }

    }
}