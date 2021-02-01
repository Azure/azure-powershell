namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>
    /// Specifies an OAuth 2.0 permission scope or an app role that an application requires. The resourceAccess property of the
    /// RequiredResourceAccess type is a collection of ResourceAccess.
    /// </summary>
    public partial class ResourceAccess :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IResourceAccess,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IResourceAccessInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>
        /// The unique identifier for one of the OAuth2Permission or AppRole instances that the resource application exposes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>
        /// Specifies whether the id property references an OAuth2Permission or an AppRole. Possible values are "scope" or "role".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="ResourceAccess" /> instance.</summary>
        public ResourceAccess()
        {

        }
    }
    /// Specifies an OAuth 2.0 permission scope or an app role that an application requires. The resourceAccess property of the
    /// RequiredResourceAccess type is a collection of ResourceAccess.
    public partial interface IResourceAccess :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>
    {
        /// <summary>
        /// The unique identifier for one of the OAuth2Permission or AppRole instances that the resource application exposes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The unique identifier for one of the OAuth2Permission or AppRole instances that the resource application exposes.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>
        /// Specifies whether the id property references an OAuth2Permission or an AppRole. Possible values are "scope" or "role".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies whether the id property references an OAuth2Permission or an AppRole. Possible values are ""scope"" or ""role"".",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// Specifies an OAuth 2.0 permission scope or an app role that an application requires. The resourceAccess property of the
    /// RequiredResourceAccess type is a collection of ResourceAccess.
    internal partial interface IResourceAccessInternal

    {
        /// <summary>
        /// The unique identifier for one of the OAuth2Permission or AppRole instances that the resource application exposes.
        /// </summary>
        string Id { get; set; }
        /// <summary>
        /// Specifies whether the id property references an OAuth2Permission or an AppRole. Possible values are "scope" or "role".
        /// </summary>
        string Type { get; set; }

    }
}