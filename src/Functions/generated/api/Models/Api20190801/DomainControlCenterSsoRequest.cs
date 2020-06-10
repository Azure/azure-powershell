namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Single sign-on request information for domain management.</summary>
    public partial class DomainControlCenterSsoRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainControlCenterSsoRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainControlCenterSsoRequestInternal
    {

        /// <summary>Internal Acessors for PostParameterKey</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainControlCenterSsoRequestInternal.PostParameterKey { get => this._postParameterKey; set { {_postParameterKey = value;} } }

        /// <summary>Internal Acessors for PostParameterValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainControlCenterSsoRequestInternal.PostParameterValue { get => this._postParameterValue; set { {_postParameterValue = value;} } }

        /// <summary>Internal Acessors for Url</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainControlCenterSsoRequestInternal.Url { get => this._url; set { {_url = value;} } }

        /// <summary>Backing field for <see cref="PostParameterKey" /> property.</summary>
        private string _postParameterKey;

        /// <summary>Post parameter key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PostParameterKey { get => this._postParameterKey; }

        /// <summary>Backing field for <see cref="PostParameterValue" /> property.</summary>
        private string _postParameterValue;

        /// <summary>
        /// Post parameter value. Client should use 'application/x-www-form-urlencoded' encoding for this value.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PostParameterValue { get => this._postParameterValue; }

        /// <summary>Backing field for <see cref="Url" /> property.</summary>
        private string _url;

        /// <summary>URL where the single sign-on request is to be made.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Url { get => this._url; }

        /// <summary>Creates an new <see cref="DomainControlCenterSsoRequest" /> instance.</summary>
        public DomainControlCenterSsoRequest()
        {

        }
    }
    /// Single sign-on request information for domain management.
    public partial interface IDomainControlCenterSsoRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Post parameter key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Post parameter key.",
        SerializedName = @"postParameterKey",
        PossibleTypes = new [] { typeof(string) })]
        string PostParameterKey { get;  }
        /// <summary>
        /// Post parameter value. Client should use 'application/x-www-form-urlencoded' encoding for this value.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Post parameter value. Client should use 'application/x-www-form-urlencoded' encoding for this value.",
        SerializedName = @"postParameterValue",
        PossibleTypes = new [] { typeof(string) })]
        string PostParameterValue { get;  }
        /// <summary>URL where the single sign-on request is to be made.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"URL where the single sign-on request is to be made.",
        SerializedName = @"url",
        PossibleTypes = new [] { typeof(string) })]
        string Url { get;  }

    }
    /// Single sign-on request information for domain management.
    internal partial interface IDomainControlCenterSsoRequestInternal

    {
        /// <summary>Post parameter key.</summary>
        string PostParameterKey { get; set; }
        /// <summary>
        /// Post parameter value. Client should use 'application/x-www-form-urlencoded' encoding for this value.
        /// </summary>
        string PostParameterValue { get; set; }
        /// <summary>URL where the single sign-on request is to be made.</summary>
        string Url { get; set; }

    }
}