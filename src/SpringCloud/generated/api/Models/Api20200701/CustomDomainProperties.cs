namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Custom domain of app resource payload.</summary>
    public partial class CustomDomainProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICustomDomainProperties,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICustomDomainPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AppName" /> property.</summary>
        private string _appName;

        /// <summary>The app name of domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string AppName { get => this._appName; }

        /// <summary>Backing field for <see cref="CertName" /> property.</summary>
        private string _certName;

        /// <summary>The bound certificate name of domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string CertName { get => this._certName; set => this._certName = value; }

        /// <summary>Internal Acessors for AppName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICustomDomainPropertiesInternal.AppName { get => this._appName; set { {_appName = value;} } }

        /// <summary>Backing field for <see cref="Thumbprint" /> property.</summary>
        private string _thumbprint;

        /// <summary>The thumbprint of bound certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Thumbprint { get => this._thumbprint; set => this._thumbprint = value; }

        /// <summary>Creates an new <see cref="CustomDomainProperties" /> instance.</summary>
        public CustomDomainProperties()
        {

        }
    }
    /// Custom domain of app resource payload.
    public partial interface ICustomDomainProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>The app name of domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The app name of domain.",
        SerializedName = @"appName",
        PossibleTypes = new [] { typeof(string) })]
        string AppName { get;  }
        /// <summary>The bound certificate name of domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The bound certificate name of domain.",
        SerializedName = @"certName",
        PossibleTypes = new [] { typeof(string) })]
        string CertName { get; set; }
        /// <summary>The thumbprint of bound certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The thumbprint of bound certificate.",
        SerializedName = @"thumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string Thumbprint { get; set; }

    }
    /// Custom domain of app resource payload.
    public partial interface ICustomDomainPropertiesInternal

    {
        /// <summary>The app name of domain.</summary>
        string AppName { get; set; }
        /// <summary>The bound certificate name of domain.</summary>
        string CertName { get; set; }
        /// <summary>The thumbprint of bound certificate.</summary>
        string Thumbprint { get; set; }

    }
}