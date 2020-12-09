namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Gets or sets the tags.</summary>
    public partial class MigrateProjectTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateProjectTags,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateProjectTagsInternal
    {

        /// <summary>Backing field for <see cref="AdditionalProperty" /> property.</summary>
        private string _additionalProperty;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AdditionalProperty { get => this._additionalProperty; set => this._additionalProperty = value; }

        /// <summary>Creates an new <see cref="MigrateProjectTags" /> instance.</summary>
        public MigrateProjectTags()
        {

        }
    }
    /// Gets or sets the tags.
    public partial interface IMigrateProjectTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"additionalProperties",
        PossibleTypes = new [] { typeof(string) })]
        string AdditionalProperty { get; set; }

    }
    /// Gets or sets the tags.
    internal partial interface IMigrateProjectTagsInternal

    {
        string AdditionalProperty { get; set; }

    }
}