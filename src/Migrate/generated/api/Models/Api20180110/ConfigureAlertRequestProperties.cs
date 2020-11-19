namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Properties of a configure alert request.</summary>
    public partial class ConfigureAlertRequestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigureAlertRequestProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigureAlertRequestPropertiesInternal
    {

        /// <summary>Backing field for <see cref="CustomEmailAddress" /> property.</summary>
        private string[] _customEmailAddress;

        /// <summary>The custom email address for sending emails.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] CustomEmailAddress { get => this._customEmailAddress; set => this._customEmailAddress = value; }

        /// <summary>Backing field for <see cref="Locale" /> property.</summary>
        private string _locale;

        /// <summary>The locale for the email notification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Locale { get => this._locale; set => this._locale = value; }

        /// <summary>Backing field for <see cref="SendToOwner" /> property.</summary>
        private string _sendToOwner;

        /// <summary>A value indicating whether to send email to subscription administrator.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SendToOwner { get => this._sendToOwner; set => this._sendToOwner = value; }

        /// <summary>Creates an new <see cref="ConfigureAlertRequestProperties" /> instance.</summary>
        public ConfigureAlertRequestProperties()
        {

        }
    }
    /// Properties of a configure alert request.
    public partial interface IConfigureAlertRequestProperties :
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
    /// Properties of a configure alert request.
    internal partial interface IConfigureAlertRequestPropertiesInternal

    {
        /// <summary>The custom email address for sending emails.</summary>
        string[] CustomEmailAddress { get; set; }
        /// <summary>The locale for the email notification.</summary>
        string Locale { get; set; }
        /// <summary>A value indicating whether to send email to subscription administrator.</summary>
        string SendToOwner { get; set; }

    }
}