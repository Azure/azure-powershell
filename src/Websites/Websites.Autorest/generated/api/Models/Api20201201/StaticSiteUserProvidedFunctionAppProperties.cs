namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>StaticSiteUserProvidedFunctionApp resource specific properties</summary>
    public partial class StaticSiteUserProvidedFunctionAppProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionAppProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionAppPropertiesInternal
    {

        /// <summary>Backing field for <see cref="CreatedOn" /> property.</summary>
        private global::System.DateTime? _createdOn;

        /// <summary>
        /// The date and time on which the function app was registered with the static site.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public global::System.DateTime? CreatedOn { get => this._createdOn; }

        /// <summary>Backing field for <see cref="FunctionAppRegion" /> property.</summary>
        private string _functionAppRegion;

        /// <summary>The region of the function app registered with the static site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string FunctionAppRegion { get => this._functionAppRegion; set => this._functionAppRegion = value; }

        /// <summary>Backing field for <see cref="FunctionAppResourceId" /> property.</summary>
        private string _functionAppResourceId;

        /// <summary>The resource id of the function app registered with the static site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string FunctionAppResourceId { get => this._functionAppResourceId; set => this._functionAppResourceId = value; }

        /// <summary>Internal Acessors for CreatedOn</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionAppPropertiesInternal.CreatedOn { get => this._createdOn; set { {_createdOn = value;} } }

        /// <summary>
        /// Creates an new <see cref="StaticSiteUserProvidedFunctionAppProperties" /> instance.
        /// </summary>
        public StaticSiteUserProvidedFunctionAppProperties()
        {

        }
    }
    /// StaticSiteUserProvidedFunctionApp resource specific properties
    public partial interface IStaticSiteUserProvidedFunctionAppProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The date and time on which the function app was registered with the static site.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The date and time on which the function app was registered with the static site.",
        SerializedName = @"createdOn",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedOn { get;  }
        /// <summary>The region of the function app registered with the static site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The region of the function app registered with the static site",
        SerializedName = @"functionAppRegion",
        PossibleTypes = new [] { typeof(string) })]
        string FunctionAppRegion { get; set; }
        /// <summary>The resource id of the function app registered with the static site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource id of the function app registered with the static site",
        SerializedName = @"functionAppResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string FunctionAppResourceId { get; set; }

    }
    /// StaticSiteUserProvidedFunctionApp resource specific properties
    internal partial interface IStaticSiteUserProvidedFunctionAppPropertiesInternal

    {
        /// <summary>
        /// The date and time on which the function app was registered with the static site.
        /// </summary>
        global::System.DateTime? CreatedOn { get; set; }
        /// <summary>The region of the function app registered with the static site</summary>
        string FunctionAppRegion { get; set; }
        /// <summary>The resource id of the function app registered with the static site</summary>
        string FunctionAppResourceId { get; set; }

    }
}