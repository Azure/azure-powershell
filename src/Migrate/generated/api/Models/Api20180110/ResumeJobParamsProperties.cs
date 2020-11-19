namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Resume job properties.</summary>
    public partial class ResumeJobParamsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResumeJobParamsProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResumeJobParamsPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Comment" /> property.</summary>
        private string _comment;

        /// <summary>Resume job comments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Comment { get => this._comment; set => this._comment = value; }

        /// <summary>Creates an new <see cref="ResumeJobParamsProperties" /> instance.</summary>
        public ResumeJobParamsProperties()
        {

        }
    }
    /// Resume job properties.
    public partial interface IResumeJobParamsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Resume job comments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resume job comments.",
        SerializedName = @"comments",
        PossibleTypes = new [] { typeof(string) })]
        string Comment { get; set; }

    }
    /// Resume job properties.
    internal partial interface IResumeJobParamsPropertiesInternal

    {
        /// <summary>Resume job comments.</summary>
        string Comment { get; set; }

    }
}