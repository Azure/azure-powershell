namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Request parameters for adding a owner to an application.</summary>
    public partial class AddOwnerParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAddOwnerParameters,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAddOwnerParametersInternal
    {

        /// <summary>Backing field for <see cref="Url" /> property.</summary>
        private string _url;

        /// <summary>
        /// A owner object URL, such as "https://graph.windows.net/0b1f9851-1bf0-433f-aec3-cb9272f093dc/directoryObjects/f260bbc4-c254-447b-94cf-293b5ec434dd",
        /// where "0b1f9851-1bf0-433f-aec3-cb9272f093dc" is the tenantId and "f260bbc4-c254-447b-94cf-293b5ec434dd" is the objectId
        /// of the owner (user, application, servicePrincipal, group) to be added.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Url { get => this._url; set => this._url = value; }

        /// <summary>Creates an new <see cref="AddOwnerParameters" /> instance.</summary>
        public AddOwnerParameters()
        {

        }
    }
    /// Request parameters for adding a owner to an application.
    public partial interface IAddOwnerParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>
    {
        /// <summary>
        /// A owner object URL, such as "https://graph.windows.net/0b1f9851-1bf0-433f-aec3-cb9272f093dc/directoryObjects/f260bbc4-c254-447b-94cf-293b5ec434dd",
        /// where "0b1f9851-1bf0-433f-aec3-cb9272f093dc" is the tenantId and "f260bbc4-c254-447b-94cf-293b5ec434dd" is the objectId
        /// of the owner (user, application, servicePrincipal, group) to be added.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A owner object URL, such as ""https://graph.windows.net/0b1f9851-1bf0-433f-aec3-cb9272f093dc/directoryObjects/f260bbc4-c254-447b-94cf-293b5ec434dd"", where ""0b1f9851-1bf0-433f-aec3-cb9272f093dc"" is the tenantId and ""f260bbc4-c254-447b-94cf-293b5ec434dd"" is the objectId of the owner (user, application, servicePrincipal, group) to be added.",
        SerializedName = @"url",
        PossibleTypes = new [] { typeof(string) })]
        string Url { get; set; }

    }
    /// Request parameters for adding a owner to an application.
    internal partial interface IAddOwnerParametersInternal

    {
        /// <summary>
        /// A owner object URL, such as "https://graph.windows.net/0b1f9851-1bf0-433f-aec3-cb9272f093dc/directoryObjects/f260bbc4-c254-447b-94cf-293b5ec434dd",
        /// where "0b1f9851-1bf0-433f-aec3-cb9272f093dc" is the tenantId and "f260bbc4-c254-447b-94cf-293b5ec434dd" is the objectId
        /// of the owner (user, application, servicePrincipal, group) to be added.
        /// </summary>
        string Url { get; set; }

    }
}