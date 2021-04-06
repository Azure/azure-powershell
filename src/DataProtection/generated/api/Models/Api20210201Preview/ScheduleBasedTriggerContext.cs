namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Schedule based trigger context</summary>
    public partial class ScheduleBasedTriggerContext :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IScheduleBasedTriggerContext,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IScheduleBasedTriggerContextInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITriggerContext"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITriggerContext __triggerContext = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.TriggerContext();

        /// <summary>Internal Acessors for Schedule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupSchedule Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IScheduleBasedTriggerContextInternal.Schedule { get => (this._schedule = this._schedule ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.BackupSchedule()); set { {_schedule = value;} } }

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITriggerContextInternal)__triggerContext).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITriggerContextInternal)__triggerContext).ObjectType = value ; }

        /// <summary>Backing field for <see cref="Schedule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupSchedule _schedule;

        /// <summary>Schedule for this backup</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupSchedule Schedule { get => (this._schedule = this._schedule ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.BackupSchedule()); set => this._schedule = value; }

        /// <summary>ISO 8601 repeating time interval format</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string[] ScheduleRepeatingTimeInterval { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupScheduleInternal)Schedule).RepeatingTimeInterval; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupScheduleInternal)Schedule).RepeatingTimeInterval = value ; }

        /// <summary>Backing field for <see cref="TaggingCriterion" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITaggingCriteria[] _taggingCriterion;

        /// <summary>List of tags that can be applicable for given schedule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITaggingCriteria[] TaggingCriterion { get => this._taggingCriterion; set => this._taggingCriterion = value; }

        /// <summary>Creates an new <see cref="ScheduleBasedTriggerContext" /> instance.</summary>
        public ScheduleBasedTriggerContext()
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
            await eventListener.AssertNotNull(nameof(__triggerContext), __triggerContext);
            await eventListener.AssertObjectIsValid(nameof(__triggerContext), __triggerContext);
        }
    }
    /// Schedule based trigger context
    public partial interface IScheduleBasedTriggerContext :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITriggerContext
    {
        /// <summary>ISO 8601 repeating time interval format</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"ISO 8601 repeating time interval format",
        SerializedName = @"repeatingTimeIntervals",
        PossibleTypes = new [] { typeof(string) })]
        string[] ScheduleRepeatingTimeInterval { get; set; }
        /// <summary>List of tags that can be applicable for given schedule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"List of tags that can be applicable for given schedule.",
        SerializedName = @"taggingCriteria",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITaggingCriteria) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITaggingCriteria[] TaggingCriterion { get; set; }

    }
    /// Schedule based trigger context
    internal partial interface IScheduleBasedTriggerContextInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITriggerContextInternal
    {
        /// <summary>Schedule for this backup</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupSchedule Schedule { get; set; }
        /// <summary>ISO 8601 repeating time interval format</summary>
        string[] ScheduleRepeatingTimeInterval { get; set; }
        /// <summary>List of tags that can be applicable for given schedule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITaggingCriteria[] TaggingCriterion { get; set; }

    }
}