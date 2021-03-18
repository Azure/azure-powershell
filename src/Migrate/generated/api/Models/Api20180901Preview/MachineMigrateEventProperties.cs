namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Properties of the machine error resource.</summary>
    public partial class MachineMigrateEventProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachineMigrateEventProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachineMigrateEventPropertiesInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventProperties __migrateEventProperties = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MigrateEventProperties();

        /// <summary>
        /// Gets or sets the client request Id of the payload for which the event is being reported.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string ClientRequestId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventPropertiesInternal)__migrateEventProperties).ClientRequestId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventPropertiesInternal)__migrateEventProperties).ClientRequestId = value ?? null; }

        /// <summary>Gets or sets the error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string ErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventPropertiesInternal)__migrateEventProperties).ErrorCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventPropertiesInternal)__migrateEventProperties).ErrorCode = value ?? null; }

        /// <summary>Gets or sets the error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string ErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventPropertiesInternal)__migrateEventProperties).ErrorMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventPropertiesInternal)__migrateEventProperties).ErrorMessage = value ?? null; }

        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventPropertiesInternal)__migrateEventProperties).InstanceType; }

        /// <summary>Backing field for <see cref="Machine" /> property.</summary>
        private string _machine;

        /// <summary>Gets or sets the machine for which the error is being reported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Machine { get => this._machine; set => this._machine = value; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventPropertiesInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventPropertiesInternal)__migrateEventProperties).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventPropertiesInternal)__migrateEventProperties).InstanceType = value; }

        /// <summary>Gets or sets the possible causes for the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string PossibleCaus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventPropertiesInternal)__migrateEventProperties).PossibleCaus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventPropertiesInternal)__migrateEventProperties).PossibleCaus = value ?? null; }

        /// <summary>Gets or sets the recommendation for the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Recommendation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventPropertiesInternal)__migrateEventProperties).Recommendation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventPropertiesInternal)__migrateEventProperties).Recommendation = value ?? null; }

        /// <summary>Gets or sets the solution for which the error is being reported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Solution { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventPropertiesInternal)__migrateEventProperties).Solution; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventPropertiesInternal)__migrateEventProperties).Solution = value ?? null; }

        /// <summary>Creates an new <see cref="MachineMigrateEventProperties" /> instance.</summary>
        public MachineMigrateEventProperties()
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
            await eventListener.AssertNotNull(nameof(__migrateEventProperties), __migrateEventProperties);
            await eventListener.AssertObjectIsValid(nameof(__migrateEventProperties), __migrateEventProperties);
        }
    }
    /// Properties of the machine error resource.
    public partial interface IMachineMigrateEventProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventProperties
    {
        /// <summary>Gets or sets the machine for which the error is being reported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the machine for which the error is being reported.",
        SerializedName = @"machine",
        PossibleTypes = new [] { typeof(string) })]
        string Machine { get; set; }

    }
    /// Properties of the machine error resource.
    internal partial interface IMachineMigrateEventPropertiesInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventPropertiesInternal
    {
        /// <summary>Gets or sets the machine for which the error is being reported.</summary>
        string Machine { get; set; }

    }
}