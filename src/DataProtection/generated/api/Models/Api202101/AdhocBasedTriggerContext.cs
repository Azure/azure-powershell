namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Adhoc trigger context</summary>
    public partial class AdhocBasedTriggerContext :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTriggerContext,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTriggerContextInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITriggerContext"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITriggerContext __triggerContext = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.TriggerContext();

        /// <summary>Internal Acessors for TagInfoETag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTriggerContextInternal.TagInfoETag { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTaggingCriteriaInternal)TaggingCriterion).TagInfoETag; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTaggingCriteriaInternal)TaggingCriterion).TagInfoETag = value; }

        /// <summary>Internal Acessors for TagInfoId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTriggerContextInternal.TagInfoId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTaggingCriteriaInternal)TaggingCriterion).TagInfoId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTaggingCriteriaInternal)TaggingCriterion).TagInfoId = value; }

        /// <summary>Internal Acessors for TaggingCriterion</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTaggingCriteria Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTriggerContextInternal.TaggingCriterion { get => (this._taggingCriterion = this._taggingCriterion ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AdhocBasedTaggingCriteria()); set { {_taggingCriterion = value;} } }

        /// <summary>Internal Acessors for TaggingCriterionTagInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRetentionTag Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTriggerContextInternal.TaggingCriterionTagInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTaggingCriteriaInternal)TaggingCriterion).TagInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTaggingCriteriaInternal)TaggingCriterion).TagInfo = value; }

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITriggerContextInternal)__triggerContext).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITriggerContextInternal)__triggerContext).ObjectType = value ; }

        /// <summary>Retention Tag version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string TagInfoETag { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTaggingCriteriaInternal)TaggingCriterion).TagInfoETag; }

        /// <summary>Retention Tag version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string TagInfoId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTaggingCriteriaInternal)TaggingCriterion).TagInfoId; }

        /// <summary>Retention Tag Name to relate it to retention rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string TagInfoTagName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTaggingCriteriaInternal)TaggingCriterion).TagInfoTagName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTaggingCriteriaInternal)TaggingCriterion).TagInfoTagName = value ?? null; }

        /// <summary>Backing field for <see cref="TaggingCriterion" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTaggingCriteria _taggingCriterion;

        /// <summary>Tagging Criteria containing retention tag for adhoc backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTaggingCriteria TaggingCriterion { get => (this._taggingCriterion = this._taggingCriterion ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AdhocBasedTaggingCriteria()); set => this._taggingCriterion = value; }

        /// <summary>Creates an new <see cref="AdhocBasedTriggerContext" /> instance.</summary>
        public AdhocBasedTriggerContext()
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
    /// Adhoc trigger context
    public partial interface IAdhocBasedTriggerContext :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITriggerContext
    {
        /// <summary>Retention Tag version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Retention Tag version.",
        SerializedName = @"eTag",
        PossibleTypes = new [] { typeof(string) })]
        string TagInfoETag { get;  }
        /// <summary>Retention Tag version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Retention Tag version.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string TagInfoId { get;  }
        /// <summary>Retention Tag Name to relate it to retention rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Retention Tag Name to relate it to retention rule.",
        SerializedName = @"tagName",
        PossibleTypes = new [] { typeof(string) })]
        string TagInfoTagName { get; set; }

    }
    /// Adhoc trigger context
    internal partial interface IAdhocBasedTriggerContextInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITriggerContextInternal
    {
        /// <summary>Retention Tag version.</summary>
        string TagInfoETag { get; set; }
        /// <summary>Retention Tag version.</summary>
        string TagInfoId { get; set; }
        /// <summary>Retention Tag Name to relate it to retention rule.</summary>
        string TagInfoTagName { get; set; }
        /// <summary>Tagging Criteria containing retention tag for adhoc backup.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTaggingCriteria TaggingCriterion { get; set; }
        /// <summary>Retention tag information</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRetentionTag TaggingCriterionTagInfo { get; set; }

    }
}