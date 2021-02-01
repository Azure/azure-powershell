namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>
    /// Specifies the set of OAuth 2.0 permission scopes and app roles under the specified resource that an application requires
    /// access to. The specified OAuth 2.0 permission scopes may be requested by client applications (through the requiredResourceAccess
    /// collection) when calling a resource application. The requiredResourceAccess property of the Application entity is a collection
    /// of RequiredResourceAccess.
    /// </summary>
    public partial class RequiredResourceAccess :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccessInternal
    {

        /// <summary>Backing field for <see cref="ResourceAccess" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IResourceAccess[] _resourceAccess;

        /// <summary>
        /// The list of OAuth2.0 permission scopes and app roles that the application requires from the specified resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IResourceAccess[] ResourceAccess { get => this._resourceAccess; set => this._resourceAccess = value; }

        /// <summary>Backing field for <see cref="ResourceAppId" /> property.</summary>
        private string _resourceAppId;

        /// <summary>
        /// The unique identifier for the resource that the application requires access to. This should be equal to the appId declared
        /// on the target resource application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string ResourceAppId { get => this._resourceAppId; set => this._resourceAppId = value; }

        /// <summary>Creates an new <see cref="RequiredResourceAccess" /> instance.</summary>
        public RequiredResourceAccess()
        {

        }
    }
    /// Specifies the set of OAuth 2.0 permission scopes and app roles under the specified resource that an application requires
    /// access to. The specified OAuth 2.0 permission scopes may be requested by client applications (through the requiredResourceAccess
    /// collection) when calling a resource application. The requiredResourceAccess property of the Application entity is a collection
    /// of RequiredResourceAccess.
    public partial interface IRequiredResourceAccess :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>
    {
        /// <summary>
        /// The list of OAuth2.0 permission scopes and app roles that the application requires from the specified resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The list of OAuth2.0 permission scopes and app roles that the application requires from the specified resource.",
        SerializedName = @"resourceAccess",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IResourceAccess) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IResourceAccess[] ResourceAccess { get; set; }
        /// <summary>
        /// The unique identifier for the resource that the application requires access to. This should be equal to the appId declared
        /// on the target resource application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The unique identifier for the resource that the application requires access to. This should be equal to the appId declared on the target resource application.",
        SerializedName = @"resourceAppId",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceAppId { get; set; }

    }
    /// Specifies the set of OAuth 2.0 permission scopes and app roles under the specified resource that an application requires
    /// access to. The specified OAuth 2.0 permission scopes may be requested by client applications (through the requiredResourceAccess
    /// collection) when calling a resource application. The requiredResourceAccess property of the Application entity is a collection
    /// of RequiredResourceAccess.
    internal partial interface IRequiredResourceAccessInternal

    {
        /// <summary>
        /// The list of OAuth2.0 permission scopes and app roles that the application requires from the specified resource.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IResourceAccess[] ResourceAccess { get; set; }
        /// <summary>
        /// The unique identifier for the resource that the application requires access to. This should be equal to the appId declared
        /// on the target resource application.
        /// </summary>
        string ResourceAppId { get; set; }

    }
}