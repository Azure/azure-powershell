namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Request to configure alerts for the system.</summary>
    public partial class ConfigureAlertRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigureAlertRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigureAlertRequestInternal
    {

        /// <summary>The custom email address for sending emails.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string[] CustomEmailAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigureAlertRequestPropertiesInternal)Property).CustomEmailAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigureAlertRequestPropertiesInternal)Property).CustomEmailAddress = value ?? null /* arrayOf */; }

        /// <summary>The locale for the email notification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Locale { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigureAlertRequestPropertiesInternal)Property).Locale; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigureAlertRequestPropertiesInternal)Property).Locale = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigureAlertRequestProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigureAlertRequestInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ConfigureAlertRequestProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigureAlertRequestProperties _property;

        /// <summary>The properties of a configure alert request.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigureAlertRequestProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ConfigureAlertRequestProperties()); set => this._property = value; }

        /// <summary>A value indicating whether to send email to subscription administrator.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string SendToOwner { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigureAlertRequestPropertiesInternal)Property).SendToOwner; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigureAlertRequestPropertiesInternal)Property).SendToOwner = value ?? null; }

        /// <summary>Creates an new <see cref="ConfigureAlertRequest" /> instance.</summary>
        public ConfigureAlertRequest()
        {

        }
    }
    /// Request to configure alerts for the system.
    public partial interface IConfigureAlertRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
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
    /// Request to configure alerts for the system.
    internal partial interface IConfigureAlertRequestInternal

    {
        /// <summary>The custom email address for sending emails.</summary>
        string[] CustomEmailAddress { get; set; }
        /// <summary>The locale for the email notification.</summary>
        string Locale { get; set; }
        /// <summary>The properties of a configure alert request.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigureAlertRequestProperties Property { get; set; }
        /// <summary>A value indicating whether to send email to subscription administrator.</summary>
        string SendToOwner { get; set; }

    }
}