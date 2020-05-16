namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Properties that define an API key of an Application Insights Component.</summary>
    public partial class ApplicationInsightsComponentApiKey :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKey,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal
    {

        /// <summary>Backing field for <see cref="ApiKey" /> property.</summary>
        private string _apiKey;

        /// <summary>The API key value. It will be only return once when the API Key was created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ApiKey { get => this._apiKey; }

        /// <summary>Backing field for <see cref="CreatedDate" /> property.</summary>
        private string _createdDate;

        /// <summary>The create date of this API key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string CreatedDate { get => this._createdDate; set => this._createdDate = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>
        /// The unique ID of the API key inside an Application Insights component. It is auto generated when the API key is created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="LinkedReadProperty" /> property.</summary>
        private string[] _linkedReadProperty;

        /// <summary>The read access rights of this API Key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] LinkedReadProperty { get => this._linkedReadProperty; set => this._linkedReadProperty = value; }

        /// <summary>Backing field for <see cref="LinkedWriteProperty" /> property.</summary>
        private string[] _linkedWriteProperty;

        /// <summary>The write access rights of this API Key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] LinkedWriteProperty { get => this._linkedWriteProperty; set => this._linkedWriteProperty = value; }

        /// <summary>Internal Acessors for ApiKey</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal.ApiKey { get => this._apiKey; set { {_apiKey = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the API key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="ApplicationInsightsComponentApiKey" /> instance.</summary>
        public ApplicationInsightsComponentApiKey()
        {

        }
    }
    /// Properties that define an API key of an Application Insights Component.
    public partial interface IApplicationInsightsComponentApiKey :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The API key value. It will be only return once when the API Key was created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The API key value. It will be only return once when the API Key was created.",
        SerializedName = @"apiKey",
        PossibleTypes = new [] { typeof(string) })]
        string ApiKey { get;  }
        /// <summary>The create date of this API key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The create date of this API key.",
        SerializedName = @"createdDate",
        PossibleTypes = new [] { typeof(string) })]
        string CreatedDate { get; set; }
        /// <summary>
        /// The unique ID of the API key inside an Application Insights component. It is auto generated when the API key is created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The unique ID of the API key inside an Application Insights component. It is auto generated when the API key is created.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>The read access rights of this API Key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The read access rights of this API Key.",
        SerializedName = @"linkedReadProperties",
        PossibleTypes = new [] { typeof(string) })]
        string[] LinkedReadProperty { get; set; }
        /// <summary>The write access rights of this API Key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The write access rights of this API Key.",
        SerializedName = @"linkedWriteProperties",
        PossibleTypes = new [] { typeof(string) })]
        string[] LinkedWriteProperty { get; set; }
        /// <summary>The name of the API key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the API key.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Properties that define an API key of an Application Insights Component.
    internal partial interface IApplicationInsightsComponentApiKeyInternal

    {
        /// <summary>The API key value. It will be only return once when the API Key was created.</summary>
        string ApiKey { get; set; }
        /// <summary>The create date of this API key.</summary>
        string CreatedDate { get; set; }
        /// <summary>
        /// The unique ID of the API key inside an Application Insights component. It is auto generated when the API key is created.
        /// </summary>
        string Id { get; set; }
        /// <summary>The read access rights of this API Key.</summary>
        string[] LinkedReadProperty { get; set; }
        /// <summary>The write access rights of this API Key.</summary>
        string[] LinkedWriteProperty { get; set; }
        /// <summary>The name of the API key.</summary>
        string Name { get; set; }

    }
}