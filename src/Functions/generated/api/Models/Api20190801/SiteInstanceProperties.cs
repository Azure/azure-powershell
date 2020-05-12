namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>SiteInstance resource specific properties</summary>
    public partial class SiteInstanceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInstanceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInstancePropertiesInternal
    {

        /// <summary>Internal Acessors for SiteInstanceName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInstancePropertiesInternal.SiteInstanceName { get => this._siteInstanceName; set { {_siteInstanceName = value;} } }

        /// <summary>Backing field for <see cref="SiteInstanceName" /> property.</summary>
        private string _siteInstanceName;

        /// <summary>Name of instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SiteInstanceName { get => this._siteInstanceName; }

        /// <summary>Creates an new <see cref="SiteInstanceProperties" /> instance.</summary>
        public SiteInstanceProperties()
        {

        }
    }
    /// SiteInstance resource specific properties
    public partial interface ISiteInstanceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Name of instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of instance.",
        SerializedName = @"siteInstanceName",
        PossibleTypes = new [] { typeof(string) })]
        string SiteInstanceName { get;  }

    }
    /// SiteInstance resource specific properties
    internal partial interface ISiteInstancePropertiesInternal

    {
        /// <summary>Name of instance.</summary>
        string SiteInstanceName { get; set; }

    }
}