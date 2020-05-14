namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>DiagnosticCategory resource specific properties</summary>
    public partial class DiagnosticCategoryProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticCategoryProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticCategoryPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of the diagnostic category</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Description { get => this._description; }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticCategoryPropertiesInternal.Description { get => this._description; set { {_description = value;} } }

        /// <summary>Creates an new <see cref="DiagnosticCategoryProperties" /> instance.</summary>
        public DiagnosticCategoryProperties()
        {

        }
    }
    /// DiagnosticCategory resource specific properties
    public partial interface IDiagnosticCategoryProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Description of the diagnostic category</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Description of the diagnostic category",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }

    }
    /// DiagnosticCategory resource specific properties
    internal partial interface IDiagnosticCategoryPropertiesInternal

    {
        /// <summary>Description of the diagnostic category</summary>
        string Description { get; set; }

    }
}