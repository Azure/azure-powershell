namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Adhoc backup rules</summary>
    public partial class AdHocBackupRuleOptions :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAdHocBackupRuleOptions,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAdHocBackupRuleOptionsInternal
    {

        /// <summary>Internal Acessors for TriggerOption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAdhocBackupTriggerOption Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAdHocBackupRuleOptionsInternal.TriggerOption { get => (this._triggerOption = this._triggerOption ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.AdhocBackupTriggerOption()); set { {_triggerOption = value;} } }

        /// <summary>Backing field for <see cref="RuleName" /> property.</summary>
        private string _ruleName;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string RuleName { get => this._ruleName; set => this._ruleName = value; }

        /// <summary>Backing field for <see cref="TriggerOption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAdhocBackupTriggerOption _triggerOption;

        /// <summary>Adhoc backup trigger option</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAdhocBackupTriggerOption TriggerOption { get => (this._triggerOption = this._triggerOption ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.AdhocBackupTriggerOption()); set => this._triggerOption = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string TriggerOptionRetentionTagOverride { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAdhocBackupTriggerOptionInternal)TriggerOption).RetentionTagOverride; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAdhocBackupTriggerOptionInternal)TriggerOption).RetentionTagOverride = value ?? null; }

        /// <summary>Creates an new <see cref="AdHocBackupRuleOptions" /> instance.</summary>
        public AdHocBackupRuleOptions()
        {

        }
    }
    /// Adhoc backup rules
    public partial interface IAdHocBackupRuleOptions :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"ruleName",
        PossibleTypes = new [] { typeof(string) })]
        string RuleName { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"retentionTagOverride",
        PossibleTypes = new [] { typeof(string) })]
        string TriggerOptionRetentionTagOverride { get; set; }

    }
    /// Adhoc backup rules
    internal partial interface IAdHocBackupRuleOptionsInternal

    {
        string RuleName { get; set; }
        /// <summary>Adhoc backup trigger option</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAdhocBackupTriggerOption TriggerOption { get; set; }

        string TriggerOptionRetentionTagOverride { get; set; }

    }
}