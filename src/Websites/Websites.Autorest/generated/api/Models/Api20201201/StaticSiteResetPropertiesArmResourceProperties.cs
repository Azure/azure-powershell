namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>StaticSiteResetPropertiesARMResource resource specific properties</summary>
    public partial class StaticSiteResetPropertiesArmResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteResetPropertiesArmResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteResetPropertiesArmResourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="RepositoryToken" /> property.</summary>
        private string _repositoryToken;

        /// <summary>The token which proves admin privileges to the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string RepositoryToken { get => this._repositoryToken; set => this._repositoryToken = value; }

        /// <summary>Backing field for <see cref="ShouldUpdateRepository" /> property.</summary>
        private bool? _shouldUpdateRepository;

        /// <summary>Determines whether the repository should be updated with the new properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public bool? ShouldUpdateRepository { get => this._shouldUpdateRepository; set => this._shouldUpdateRepository = value; }

        /// <summary>
        /// Creates an new <see cref="StaticSiteResetPropertiesArmResourceProperties" /> instance.
        /// </summary>
        public StaticSiteResetPropertiesArmResourceProperties()
        {

        }
    }
    /// StaticSiteResetPropertiesARMResource resource specific properties
    public partial interface IStaticSiteResetPropertiesArmResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable
    {
        /// <summary>The token which proves admin privileges to the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The token which proves admin privileges to the repository.",
        SerializedName = @"repositoryToken",
        PossibleTypes = new [] { typeof(string) })]
        string RepositoryToken { get; set; }
        /// <summary>Determines whether the repository should be updated with the new properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Determines whether the repository should be updated with the new properties.",
        SerializedName = @"shouldUpdateRepository",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ShouldUpdateRepository { get; set; }

    }
    /// StaticSiteResetPropertiesARMResource resource specific properties
    internal partial interface IStaticSiteResetPropertiesArmResourcePropertiesInternal

    {
        /// <summary>The token which proves admin privileges to the repository.</summary>
        string RepositoryToken { get; set; }
        /// <summary>Determines whether the repository should be updated with the new properties.</summary>
        bool? ShouldUpdateRepository { get; set; }

    }
}