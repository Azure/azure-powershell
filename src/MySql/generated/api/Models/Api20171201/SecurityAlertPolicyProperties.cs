namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>Properties of a security alert policy.</summary>
    public partial class SecurityAlertPolicyProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ISecurityAlertPolicyProperties,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal
    {

        /// <summary>Backing field for <see cref="DisabledAlert" /> property.</summary>
        private string[] _disabledAlert;

        /// <summary>
        /// Specifies an array of alerts that are disabled. Allowed values are: Sql_Injection, Sql_Injection_Vulnerability, Access_Anomaly
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string[] DisabledAlert { get => this._disabledAlert; set => this._disabledAlert = value; }

        /// <summary>Backing field for <see cref="EmailAccountAdmin" /> property.</summary>
        private bool? _emailAccountAdmin;

        /// <summary>Specifies that the alert is sent to the account administrators.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public bool? EmailAccountAdmin { get => this._emailAccountAdmin; set => this._emailAccountAdmin = value; }

        /// <summary>Backing field for <see cref="EmailAddress" /> property.</summary>
        private string[] _emailAddress;

        /// <summary>Specifies an array of e-mail addresses to which the alert is sent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string[] EmailAddress { get => this._emailAddress; set => this._emailAddress = value; }

        /// <summary>Backing field for <see cref="RetentionDay" /> property.</summary>
        private int? _retentionDay;

        /// <summary>Specifies the number of days to keep in the Threat Detection audit logs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public int? RetentionDay { get => this._retentionDay; set => this._retentionDay = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerSecurityAlertPolicyState _state;

        /// <summary>Specifies the state of the policy, whether it is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerSecurityAlertPolicyState State { get => this._state; set => this._state = value; }

        /// <summary>Backing field for <see cref="StorageAccountAccessKey" /> property.</summary>
        private string _storageAccountAccessKey;

        /// <summary>Specifies the identifier key of the Threat Detection audit storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string StorageAccountAccessKey { get => this._storageAccountAccessKey; set => this._storageAccountAccessKey = value; }

        /// <summary>Backing field for <see cref="StorageEndpoint" /> property.</summary>
        private string _storageEndpoint;

        /// <summary>
        /// Specifies the blob storage endpoint (e.g. https://MyAccount.blob.core.windows.net). This blob storage will hold all Threat
        /// Detection audit logs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string StorageEndpoint { get => this._storageEndpoint; set => this._storageEndpoint = value; }

        /// <summary>Creates an new <see cref="SecurityAlertPolicyProperties" /> instance.</summary>
        public SecurityAlertPolicyProperties()
        {

        }
    }
    /// Properties of a security alert policy.
    public partial interface ISecurityAlertPolicyProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Specifies an array of alerts that are disabled. Allowed values are: Sql_Injection, Sql_Injection_Vulnerability, Access_Anomaly
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies an array of alerts that are disabled. Allowed values are: Sql_Injection, Sql_Injection_Vulnerability, Access_Anomaly",
        SerializedName = @"disabledAlerts",
        PossibleTypes = new [] { typeof(string) })]
        string[] DisabledAlert { get; set; }
        /// <summary>Specifies that the alert is sent to the account administrators.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies that the alert is sent to the account administrators.",
        SerializedName = @"emailAccountAdmins",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EmailAccountAdmin { get; set; }
        /// <summary>Specifies an array of e-mail addresses to which the alert is sent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies an array of e-mail addresses to which the alert is sent.",
        SerializedName = @"emailAddresses",
        PossibleTypes = new [] { typeof(string) })]
        string[] EmailAddress { get; set; }
        /// <summary>Specifies the number of days to keep in the Threat Detection audit logs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the number of days to keep in the Threat Detection audit logs.",
        SerializedName = @"retentionDays",
        PossibleTypes = new [] { typeof(int) })]
        int? RetentionDay { get; set; }
        /// <summary>Specifies the state of the policy, whether it is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the state of the policy, whether it is enabled or disabled.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerSecurityAlertPolicyState) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerSecurityAlertPolicyState State { get; set; }
        /// <summary>Specifies the identifier key of the Threat Detection audit storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the identifier key of the Threat Detection audit storage account.",
        SerializedName = @"storageAccountAccessKey",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountAccessKey { get; set; }
        /// <summary>
        /// Specifies the blob storage endpoint (e.g. https://MyAccount.blob.core.windows.net). This blob storage will hold all Threat
        /// Detection audit logs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the blob storage endpoint (e.g. https://MyAccount.blob.core.windows.net). This blob storage will hold all Threat Detection audit logs.",
        SerializedName = @"storageEndpoint",
        PossibleTypes = new [] { typeof(string) })]
        string StorageEndpoint { get; set; }

    }
    /// Properties of a security alert policy.
    internal partial interface ISecurityAlertPolicyPropertiesInternal

    {
        /// <summary>
        /// Specifies an array of alerts that are disabled. Allowed values are: Sql_Injection, Sql_Injection_Vulnerability, Access_Anomaly
        /// </summary>
        string[] DisabledAlert { get; set; }
        /// <summary>Specifies that the alert is sent to the account administrators.</summary>
        bool? EmailAccountAdmin { get; set; }
        /// <summary>Specifies an array of e-mail addresses to which the alert is sent.</summary>
        string[] EmailAddress { get; set; }
        /// <summary>Specifies the number of days to keep in the Threat Detection audit logs.</summary>
        int? RetentionDay { get; set; }
        /// <summary>Specifies the state of the policy, whether it is enabled or disabled.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerSecurityAlertPolicyState State { get; set; }
        /// <summary>Specifies the identifier key of the Threat Detection audit storage account.</summary>
        string StorageAccountAccessKey { get; set; }
        /// <summary>
        /// Specifies the blob storage endpoint (e.g. https://MyAccount.blob.core.windows.net). This blob storage will hold all Threat
        /// Detection audit logs.
        /// </summary>
        string StorageEndpoint { get; set; }

    }
}