namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Trigger backup request</summary>
    public partial class TriggerBackupRequest :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITriggerBackupRequest,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITriggerBackupRequestInternal
    {

        /// <summary>Backing field for <see cref="BackupRuleOption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAdHocBackupRuleOptions _backupRuleOption;

        /// <summary>Name for the Rule of the Policy which needs to be applied for this backup</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAdHocBackupRuleOptions BackupRuleOption { get => (this._backupRuleOption = this._backupRuleOption ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.AdHocBackupRuleOptions()); set => this._backupRuleOption = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string BackupRuleOptionRuleName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAdHocBackupRuleOptionsInternal)BackupRuleOption).RuleName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAdHocBackupRuleOptionsInternal)BackupRuleOption).RuleName = value ; }

        /// <summary>Internal Acessors for BackupRuleOption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAdHocBackupRuleOptions Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITriggerBackupRequestInternal.BackupRuleOption { get => (this._backupRuleOption = this._backupRuleOption ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.AdHocBackupRuleOptions()); set { {_backupRuleOption = value;} } }

        /// <summary>Internal Acessors for BackupRuleOptionTriggerOption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAdhocBackupTriggerOption Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITriggerBackupRequestInternal.BackupRuleOptionTriggerOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAdHocBackupRuleOptionsInternal)BackupRuleOption).TriggerOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAdHocBackupRuleOptionsInternal)BackupRuleOption).TriggerOption = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string TriggerOptionRetentionTagOverride { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAdHocBackupRuleOptionsInternal)BackupRuleOption).TriggerOptionRetentionTagOverride; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAdHocBackupRuleOptionsInternal)BackupRuleOption).TriggerOptionRetentionTagOverride = value ?? null; }

        /// <summary>Creates an new <see cref="TriggerBackupRequest" /> instance.</summary>
        public TriggerBackupRequest()
        {

        }
    }
    /// Trigger backup request
    public partial interface ITriggerBackupRequest :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"ruleName",
        PossibleTypes = new [] { typeof(string) })]
        string BackupRuleOptionRuleName { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"retentionTagOverride",
        PossibleTypes = new [] { typeof(string) })]
        string TriggerOptionRetentionTagOverride { get; set; }

    }
    /// Trigger backup request
    internal partial interface ITriggerBackupRequestInternal

    {
        /// <summary>Name for the Rule of the Policy which needs to be applied for this backup</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAdHocBackupRuleOptions BackupRuleOption { get; set; }

        string BackupRuleOptionRuleName { get; set; }
        /// <summary>Adhoc backup trigger option</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAdhocBackupTriggerOption BackupRuleOptionTriggerOption { get; set; }

        string TriggerOptionRetentionTagOverride { get; set; }

    }
}