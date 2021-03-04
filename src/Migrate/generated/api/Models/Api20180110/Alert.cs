namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Implements the Alert class.</summary>
    public partial class Alert :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAlert,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAlertInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.Resource();

        /// <summary>The custom email address for sending emails.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string[] CustomEmailAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAlertPropertiesInternal)Property).CustomEmailAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAlertPropertiesInternal)Property).CustomEmailAddress = value ?? null /* arrayOf */; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id; }

        /// <summary>The locale for the email notification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Locale { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAlertPropertiesInternal)Property).Locale; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAlertPropertiesInternal)Property).Locale = value ?? null; }

        /// <summary>Resource Location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Location = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAlertProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAlertInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AlertProperties()); set { {_property = value;} } }

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
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAlertProperties _property;

        /// <summary>Alert related data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAlertProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AlertProperties()); set => this._property = value; }

        /// <summary>A value indicating whether to send email to subscription administrator.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string SendToOwner { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAlertPropertiesInternal)Property).SendToOwner; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAlertPropertiesInternal)Property).SendToOwner = value ?? null; }

        /// <summary>Resource Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="Alert" /> instance.</summary>
        public Alert()
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
    /// Implements the Alert class.
    public partial interface IAlert :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource
    {
        /// <summary>The custom email address for sending emails.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The custom email address for sending emails.",
        SerializedName = @"customEmailAddresses",
        PossibleTypes = new [] { typeof(string) })]
        string[] CustomEmailAddress { get; set; }
        /// <summary>The locale for the email notification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The locale for the email notification.",
        SerializedName = @"locale",
        PossibleTypes = new [] { typeof(string) })]
        string Locale { get; set; }
        /// <summary>A value indicating whether to send email to subscription administrator.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether to send email to subscription administrator.",
        SerializedName = @"sendToOwners",
        PossibleTypes = new [] { typeof(string) })]
        string SendToOwner { get; set; }

    }
    /// Implements the Alert class.
    internal partial interface IAlertInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal
    {
        /// <summary>The custom email address for sending emails.</summary>
        string[] CustomEmailAddress { get; set; }
        /// <summary>The locale for the email notification.</summary>
        string Locale { get; set; }
        /// <summary>Alert related data.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAlertProperties Property { get; set; }
        /// <summary>A value indicating whether to send email to subscription administrator.</summary>
        string SendToOwner { get; set; }

    }
}