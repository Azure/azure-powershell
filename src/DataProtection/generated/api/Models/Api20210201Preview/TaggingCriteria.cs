namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Tagging criteria</summary>
    public partial class TaggingCriteria :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITaggingCriteria,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITaggingCriteriaInternal
    {

        /// <summary>Backing field for <see cref="Criterion" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupCriteria[] _criterion;

        /// <summary>Criteria which decides whether the tag can be applied to a triggered backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupCriteria[] Criterion { get => this._criterion; set => this._criterion = value; }

        /// <summary>Backing field for <see cref="IsDefault" /> property.</summary>
        private bool _isDefault;

        /// <summary>Specifies if tag is default.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public bool IsDefault { get => this._isDefault; set => this._isDefault = value; }

        /// <summary>Internal Acessors for TagInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRetentionTag Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITaggingCriteriaInternal.TagInfo { get => (this._tagInfo = this._tagInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.RetentionTag()); set { {_tagInfo = value;} } }

        /// <summary>Internal Acessors for TagInfoETag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITaggingCriteriaInternal.TagInfoETag { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRetentionTagInternal)TagInfo).ETag; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRetentionTagInternal)TagInfo).ETag = value; }

        /// <summary>Internal Acessors for TagInfoId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITaggingCriteriaInternal.TagInfoId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRetentionTagInternal)TagInfo).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRetentionTagInternal)TagInfo).Id = value; }

        /// <summary>Backing field for <see cref="TagInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRetentionTag _tagInfo;

        /// <summary>Retention tag information</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRetentionTag TagInfo { get => (this._tagInfo = this._tagInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.RetentionTag()); set => this._tagInfo = value; }

        /// <summary>Retention Tag version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string TagInfoETag { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRetentionTagInternal)TagInfo).ETag; }

        /// <summary>Retention Tag version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string TagInfoId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRetentionTagInternal)TagInfo).Id; }

        /// <summary>Retention Tag Name to relate it to retention rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string TagInfoTagName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRetentionTagInternal)TagInfo).TagName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRetentionTagInternal)TagInfo).TagName = value ; }

        /// <summary>Backing field for <see cref="TaggingPriority" /> property.</summary>
        private long _taggingPriority;

        /// <summary>Retention Tag priority.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public long TaggingPriority { get => this._taggingPriority; set => this._taggingPriority = value; }

        /// <summary>Creates an new <see cref="TaggingCriteria" /> instance.</summary>
        public TaggingCriteria()
        {

        }
    }
    /// Tagging criteria
    public partial interface ITaggingCriteria :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Criteria which decides whether the tag can be applied to a triggered backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Criteria which decides whether the tag can be applied to a triggered backup.",
        SerializedName = @"criteria",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupCriteria),typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IScheduleBasedBackupCriteria) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupCriteria[] Criterion { get; set; }
        /// <summary>Specifies if tag is default.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies if tag is default.",
        SerializedName = @"isDefault",
        PossibleTypes = new [] { typeof(bool) })]
        bool IsDefault { get; set; }
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
        Required = true,
        ReadOnly = false,
        Description = @"Retention Tag Name to relate it to retention rule.",
        SerializedName = @"tagName",
        PossibleTypes = new [] { typeof(string) })]
        string TagInfoTagName { get; set; }
        /// <summary>Retention Tag priority.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Retention Tag priority.",
        SerializedName = @"taggingPriority",
        PossibleTypes = new [] { typeof(long) })]
        long TaggingPriority { get; set; }

    }
    /// Tagging criteria
    internal partial interface ITaggingCriteriaInternal

    {
        /// <summary>Criteria which decides whether the tag can be applied to a triggered backup.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupCriteria[] Criterion { get; set; }
        /// <summary>Specifies if tag is default.</summary>
        bool IsDefault { get; set; }
        /// <summary>Retention tag information</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRetentionTag TagInfo { get; set; }
        /// <summary>Retention Tag version.</summary>
        string TagInfoETag { get; set; }
        /// <summary>Retention Tag version.</summary>
        string TagInfoId { get; set; }
        /// <summary>Retention Tag Name to relate it to retention rule.</summary>
        string TagInfoTagName { get; set; }
        /// <summary>Retention Tag priority.</summary>
        long TaggingPriority { get; set; }

    }
}