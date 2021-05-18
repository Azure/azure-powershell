namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>StaticSiteCustomDomainRequestPropertiesARMResource resource specific properties</summary>
    public partial class StaticSiteCustomDomainRequestPropertiesArmResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteCustomDomainRequestPropertiesArmResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteCustomDomainRequestPropertiesArmResourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="ValidationMethod" /> property.</summary>
        private string _validationMethod;

        /// <summary>Validation method for adding a custom domain</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string ValidationMethod { get => this._validationMethod; set => this._validationMethod = value; }

        /// <summary>
        /// Creates an new <see cref="StaticSiteCustomDomainRequestPropertiesArmResourceProperties" /> instance.
        /// </summary>
        public StaticSiteCustomDomainRequestPropertiesArmResourceProperties()
        {

        }
    }
    /// StaticSiteCustomDomainRequestPropertiesARMResource resource specific properties
    public partial interface IStaticSiteCustomDomainRequestPropertiesArmResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable
    {
        /// <summary>Validation method for adding a custom domain</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Validation method for adding a custom domain",
        SerializedName = @"validationMethod",
        PossibleTypes = new [] { typeof(string) })]
        string ValidationMethod { get; set; }

    }
    /// StaticSiteCustomDomainRequestPropertiesARMResource resource specific properties
    internal partial interface IStaticSiteCustomDomainRequestPropertiesArmResourcePropertiesInternal

    {
        /// <summary>Validation method for adding a custom domain</summary>
        string ValidationMethod { get; set; }

    }
}