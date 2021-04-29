namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Azure backup rule</summary>
    public partial class AzureBackupRule :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRule,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRuleInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBasePolicyRule"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBasePolicyRule __basePolicyRule = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.BasePolicyRule();

        /// <summary>Backing field for <see cref="BackupParameter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupParameters _backupParameter;

        /// <summary>BackupParameters base</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupParameters BackupParameter { get => (this._backupParameter = this._backupParameter ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.BackupParameters()); set => this._backupParameter = value; }

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string BackupParameterObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupParametersInternal)BackupParameter).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupParametersInternal)BackupParameter).ObjectType = value ?? null; }

        /// <summary>Backing field for <see cref="DataStore" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDataStoreInfoBase _dataStore;

        /// <summary>DataStoreInfo base</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDataStoreInfoBase DataStore { get => (this._dataStore = this._dataStore ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.DataStoreInfoBase()); set => this._dataStore = value; }

        /// <summary>Type of Datasource object, used to initialize the right inherited type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string DataStoreObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDataStoreInfoBaseInternal)DataStore).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDataStoreInfoBaseInternal)DataStore).ObjectType = value ; }

        /// <summary>type of datastore; Operational/Vault/Archive</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes DataStoreType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDataStoreInfoBaseInternal)DataStore).DataStoreType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDataStoreInfoBaseInternal)DataStore).DataStoreType = value ; }

        /// <summary>Internal Acessors for BackupParameter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupParameters Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRuleInternal.BackupParameter { get => (this._backupParameter = this._backupParameter ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.BackupParameters()); set { {_backupParameter = value;} } }

        /// <summary>Internal Acessors for DataStore</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDataStoreInfoBase Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRuleInternal.DataStore { get => (this._dataStore = this._dataStore ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.DataStoreInfoBase()); set { {_dataStore = value;} } }

        /// <summary>Internal Acessors for Trigger</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITriggerContext Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRuleInternal.Trigger { get => (this._trigger = this._trigger ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.TriggerContext()); set { {_trigger = value;} } }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBasePolicyRuleInternal)__basePolicyRule).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBasePolicyRuleInternal)__basePolicyRule).Name = value ; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBasePolicyRuleInternal)__basePolicyRule).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBasePolicyRuleInternal)__basePolicyRule).ObjectType = value ; }

        /// <summary>Backing field for <see cref="Trigger" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITriggerContext _trigger;

        /// <summary>Trigger context</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITriggerContext Trigger { get => (this._trigger = this._trigger ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.TriggerContext()); set => this._trigger = value; }

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string TriggerObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITriggerContextInternal)Trigger).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITriggerContextInternal)Trigger).ObjectType = value ; }

        /// <summary>Creates an new <see cref="AzureBackupRule" /> instance.</summary>
        public AzureBackupRule()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__basePolicyRule), __basePolicyRule);
            await eventListener.AssertObjectIsValid(nameof(__basePolicyRule), __basePolicyRule);
        }
    }
    /// Azure backup rule
    public partial interface IAzureBackupRule :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBasePolicyRule
    {
        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of the specific object - used for deserializing",
        SerializedName = @"objectType",
        PossibleTypes = new [] { typeof(string) })]
        string BackupParameterObjectType { get; set; }
        /// <summary>Type of Datasource object, used to initialize the right inherited type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Type of Datasource object, used to initialize the right inherited type",
        SerializedName = @"objectType",
        PossibleTypes = new [] { typeof(string) })]
        string DataStoreObjectType { get; set; }
        /// <summary>type of datastore; Operational/Vault/Archive</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"type of datastore; Operational/Vault/Archive",
        SerializedName = @"dataStoreType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes DataStoreType { get; set; }
        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Type of the specific object - used for deserializing",
        SerializedName = @"objectType",
        PossibleTypes = new [] { typeof(string) })]
        string TriggerObjectType { get; set; }

    }
    /// Azure backup rule
    internal partial interface IAzureBackupRuleInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBasePolicyRuleInternal
    {
        /// <summary>BackupParameters base</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupParameters BackupParameter { get; set; }
        /// <summary>Type of the specific object - used for deserializing</summary>
        string BackupParameterObjectType { get; set; }
        /// <summary>DataStoreInfo base</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDataStoreInfoBase DataStore { get; set; }
        /// <summary>Type of Datasource object, used to initialize the right inherited type</summary>
        string DataStoreObjectType { get; set; }
        /// <summary>type of datastore; Operational/Vault/Archive</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes DataStoreType { get; set; }
        /// <summary>Trigger context</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITriggerContext Trigger { get; set; }
        /// <summary>Type of the specific object - used for deserializing</summary>
        string TriggerObjectType { get; set; }

    }
}