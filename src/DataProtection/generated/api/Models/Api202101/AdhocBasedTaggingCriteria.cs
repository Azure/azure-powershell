namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Adhoc backup tagging criteria</summary>
    public partial class AdhocBasedTaggingCriteria :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTaggingCriteria,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTaggingCriteriaInternal
    {

        /// <summary>Internal Acessors for TagInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRetentionTag Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTaggingCriteriaInternal.TagInfo { get => (this._tagInfo = this._tagInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.RetentionTag()); set { {_tagInfo = value;} } }

        /// <summary>Internal Acessors for TagInfoETag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTaggingCriteriaInternal.TagInfoETag { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRetentionTagInternal)TagInfo).ETag; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRetentionTagInternal)TagInfo).ETag = value; }

        /// <summary>Internal Acessors for TagInfoId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAdhocBasedTaggingCriteriaInternal.TagInfoId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRetentionTagInternal)TagInfo).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRetentionTagInternal)TagInfo).Id = value; }

        /// <summary>Backing field for <see cref="TagInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRetentionTag _tagInfo;

        /// <summary>Retention tag information</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRetentionTag TagInfo { get => (this._tagInfo = this._tagInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.RetentionTag()); set => this._tagInfo = value; }

        /// <summary>Retention Tag version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string TagInfoETag { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRetentionTagInternal)TagInfo).ETag; }

        /// <summary>Retention Tag version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string TagInfoId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRetentionTagInternal)TagInfo).Id; }

        /// <summary>Retention Tag Name to relate it to retention rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string TagInfoTagName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRetentionTagInternal)TagInfo).TagName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRetentionTagInternal)TagInfo).TagName = value ?? null; }

        /// <summary>Creates an new <see cref="AdhocBasedTaggingCriteria" /> instance.</summary>
        public AdhocBasedTaggingCriteria()
        {

        }
    }
    /// Adhoc backup tagging criteria
    public partial interface IAdhocBasedTaggingCriteria :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
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
    /// Adhoc backup tagging criteria
    internal partial interface IAdhocBasedTaggingCriteriaInternal

    {
        /// <summary>Retention tag information</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRetentionTag TagInfo { get; set; }
        /// <summary>Retention Tag version.</summary>
        string TagInfoETag { get; set; }
        /// <summary>Retention Tag version.</summary>
        string TagInfoId { get; set; }
        /// <summary>Retention Tag Name to relate it to retention rule.</summary>
        string TagInfoTagName { get; set; }

    }
}