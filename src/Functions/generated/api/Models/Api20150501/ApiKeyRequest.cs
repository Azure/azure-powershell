namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>An Application Insights component API Key creation request definition.</summary>
    public partial class ApiKeyRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApiKeyRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApiKeyRequestInternal
    {

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

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the API Key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="ApiKeyRequest" /> instance.</summary>
        public ApiKeyRequest()
        {

        }
    }
    /// An Application Insights component API Key creation request definition.
    public partial interface IApiKeyRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
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
        /// <summary>The name of the API Key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the API Key.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// An Application Insights component API Key creation request definition.
    internal partial interface IApiKeyRequestInternal

    {
        /// <summary>The read access rights of this API Key.</summary>
        string[] LinkedReadProperty { get; set; }
        /// <summary>The write access rights of this API Key.</summary>
        string[] LinkedWriteProperty { get; set; }
        /// <summary>The name of the API Key.</summary>
        string Name { get; set; }

    }
}