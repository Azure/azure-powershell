namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class representing the config for the solution in the migrate project.</summary>
    public partial class SolutionConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionConfig,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionConfigInternal
    {

        /// <summary>Backing field for <see cref="PublisherSasUri" /> property.</summary>
        private string _publisherSasUri;

        /// <summary>Gets or sets the publisher sas uri for the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PublisherSasUri { get => this._publisherSasUri; set => this._publisherSasUri = value; }

        /// <summary>Creates an new <see cref="SolutionConfig" /> instance.</summary>
        public SolutionConfig()
        {

        }
    }
    /// Class representing the config for the solution in the migrate project.
    public partial interface ISolutionConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the publisher sas uri for the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the publisher sas uri for the solution.",
        SerializedName = @"publisherSasUri",
        PossibleTypes = new [] { typeof(string) })]
        string PublisherSasUri { get; set; }

    }
    /// Class representing the config for the solution in the migrate project.
    internal partial interface ISolutionConfigInternal

    {
        /// <summary>Gets or sets the publisher sas uri for the solution.</summary>
        string PublisherSasUri { get; set; }

    }
}