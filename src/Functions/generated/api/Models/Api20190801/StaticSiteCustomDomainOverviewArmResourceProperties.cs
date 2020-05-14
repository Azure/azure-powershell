namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>StaticSiteCustomDomainOverviewARMResource resource specific properties</summary>
    public partial class StaticSiteCustomDomainOverviewArmResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteCustomDomainOverviewArmResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteCustomDomainOverviewArmResourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="CreatedOn" /> property.</summary>
        private global::System.DateTime? _createdOn;

        /// <summary>The date and time on which the custom domain was created for the static site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? CreatedOn { get => this._createdOn; }

        /// <summary>Backing field for <see cref="DomainName" /> property.</summary>
        private string _domainName;

        /// <summary>The domain name for the static site custom domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DomainName { get => this._domainName; }

        /// <summary>Internal Acessors for CreatedOn</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteCustomDomainOverviewArmResourcePropertiesInternal.CreatedOn { get => this._createdOn; set { {_createdOn = value;} } }

        /// <summary>Internal Acessors for DomainName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteCustomDomainOverviewArmResourcePropertiesInternal.DomainName { get => this._domainName; set { {_domainName = value;} } }

        /// <summary>
        /// Creates an new <see cref="StaticSiteCustomDomainOverviewArmResourceProperties" /> instance.
        /// </summary>
        public StaticSiteCustomDomainOverviewArmResourceProperties()
        {

        }
    }
    /// StaticSiteCustomDomainOverviewARMResource resource specific properties
    public partial interface IStaticSiteCustomDomainOverviewArmResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The date and time on which the custom domain was created for the static site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The date and time on which the custom domain was created for the static site.",
        SerializedName = @"createdOn",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedOn { get;  }
        /// <summary>The domain name for the static site custom domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The domain name for the static site custom domain.",
        SerializedName = @"domainName",
        PossibleTypes = new [] { typeof(string) })]
        string DomainName { get;  }

    }
    /// StaticSiteCustomDomainOverviewARMResource resource specific properties
    internal partial interface IStaticSiteCustomDomainOverviewArmResourcePropertiesInternal

    {
        /// <summary>The date and time on which the custom domain was created for the static site.</summary>
        global::System.DateTime? CreatedOn { get; set; }
        /// <summary>The domain name for the static site custom domain.</summary>
        string DomainName { get; set; }

    }
}