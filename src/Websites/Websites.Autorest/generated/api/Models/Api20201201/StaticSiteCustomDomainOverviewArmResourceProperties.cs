namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>StaticSiteCustomDomainOverviewARMResource resource specific properties</summary>
    public partial class StaticSiteCustomDomainOverviewArmResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteCustomDomainOverviewArmResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteCustomDomainOverviewArmResourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="CreatedOn" /> property.</summary>
        private global::System.DateTime? _createdOn;

        /// <summary>The date and time on which the custom domain was created for the static site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public global::System.DateTime? CreatedOn { get => this._createdOn; }

        /// <summary>Backing field for <see cref="DomainName" /> property.</summary>
        private string _domainName;

        /// <summary>The domain name for the static site custom domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string DomainName { get => this._domainName; }

        /// <summary>Backing field for <see cref="ErrorMessage" /> property.</summary>
        private string _errorMessage;

        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string ErrorMessage { get => this._errorMessage; }

        /// <summary>Internal Acessors for CreatedOn</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteCustomDomainOverviewArmResourcePropertiesInternal.CreatedOn { get => this._createdOn; set { {_createdOn = value;} } }

        /// <summary>Internal Acessors for DomainName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteCustomDomainOverviewArmResourcePropertiesInternal.DomainName { get => this._domainName; set { {_domainName = value;} } }

        /// <summary>Internal Acessors for ErrorMessage</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteCustomDomainOverviewArmResourcePropertiesInternal.ErrorMessage { get => this._errorMessage; set { {_errorMessage = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.CustomDomainStatus? Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteCustomDomainOverviewArmResourcePropertiesInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Internal Acessors for ValidationToken</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteCustomDomainOverviewArmResourcePropertiesInternal.ValidationToken { get => this._validationToken; set { {_validationToken = value;} } }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.CustomDomainStatus? _status;

        /// <summary>The status of the custom domain</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.CustomDomainStatus? Status { get => this._status; }

        /// <summary>Backing field for <see cref="ValidationToken" /> property.</summary>
        private string _validationToken;

        /// <summary>The TXT record validation token</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string ValidationToken { get => this._validationToken; }

        /// <summary>
        /// Creates an new <see cref="StaticSiteCustomDomainOverviewArmResourceProperties" /> instance.
        /// </summary>
        public StaticSiteCustomDomainOverviewArmResourceProperties()
        {

        }
    }
    /// StaticSiteCustomDomainOverviewARMResource resource specific properties
    public partial interface IStaticSiteCustomDomainOverviewArmResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable
    {
        /// <summary>The date and time on which the custom domain was created for the static site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The date and time on which the custom domain was created for the static site.",
        SerializedName = @"createdOn",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedOn { get;  }
        /// <summary>The domain name for the static site custom domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The domain name for the static site custom domain.",
        SerializedName = @"domainName",
        PossibleTypes = new [] { typeof(string) })]
        string DomainName { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"errorMessage",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorMessage { get;  }
        /// <summary>The status of the custom domain</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The status of the custom domain",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.CustomDomainStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.CustomDomainStatus? Status { get;  }
        /// <summary>The TXT record validation token</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The TXT record validation token",
        SerializedName = @"validationToken",
        PossibleTypes = new [] { typeof(string) })]
        string ValidationToken { get;  }

    }
    /// StaticSiteCustomDomainOverviewARMResource resource specific properties
    internal partial interface IStaticSiteCustomDomainOverviewArmResourcePropertiesInternal

    {
        /// <summary>The date and time on which the custom domain was created for the static site.</summary>
        global::System.DateTime? CreatedOn { get; set; }
        /// <summary>The domain name for the static site custom domain.</summary>
        string DomainName { get; set; }

        string ErrorMessage { get; set; }
        /// <summary>The status of the custom domain</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.CustomDomainStatus? Status { get; set; }
        /// <summary>The TXT record validation token</summary>
        string ValidationToken { get; set; }

    }
}