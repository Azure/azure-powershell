namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Resume job params.</summary>
    public partial class ResumeJobParams :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResumeJobParams,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResumeJobParamsInternal
    {

        /// <summary>Resume job comments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Comment { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResumeJobParamsPropertiesInternal)Property).Comment; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResumeJobParamsPropertiesInternal)Property).Comment = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResumeJobParamsProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResumeJobParamsInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResumeJobParamsProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResumeJobParamsProperties _property;

        /// <summary>Resume job properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResumeJobParamsProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResumeJobParamsProperties()); set => this._property = value; }

        /// <summary>Creates an new <see cref="ResumeJobParams" /> instance.</summary>
        public ResumeJobParams()
        {

        }
    }
    /// Resume job params.
    public partial interface IResumeJobParams :
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
    /// Resume job params.
    internal partial interface IResumeJobParamsInternal

    {
        /// <summary>Resume job comments.</summary>
        string Comment { get; set; }
        /// <summary>Resume job properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResumeJobParamsProperties Property { get; set; }

    }
}