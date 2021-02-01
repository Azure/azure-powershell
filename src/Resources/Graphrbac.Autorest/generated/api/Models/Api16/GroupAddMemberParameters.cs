namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Request parameters for adding a member to a group.</summary>
    public partial class GroupAddMemberParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IGroupAddMemberParameters,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IGroupAddMemberParametersInternal
    {

        /// <summary>Backing field for <see cref="Url" /> property.</summary>
        private string _url;

        /// <summary>
        /// A member object URL, such as "https://graph.windows.net/0b1f9851-1bf0-433f-aec3-cb9272f093dc/directoryObjects/f260bbc4-c254-447b-94cf-293b5ec434dd",
        /// where "0b1f9851-1bf0-433f-aec3-cb9272f093dc" is the tenantId and "f260bbc4-c254-447b-94cf-293b5ec434dd" is the objectId
        /// of the member (user, application, servicePrincipal, group) to be added.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Url { get => this._url; set => this._url = value; }

        /// <summary>Creates an new <see cref="GroupAddMemberParameters" /> instance.</summary>
        public GroupAddMemberParameters()
        {

        }
    }
    /// Request parameters for adding a member to a group.
    public partial interface IGroupAddMemberParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>
    {
        /// <summary>
        /// A member object URL, such as "https://graph.windows.net/0b1f9851-1bf0-433f-aec3-cb9272f093dc/directoryObjects/f260bbc4-c254-447b-94cf-293b5ec434dd",
        /// where "0b1f9851-1bf0-433f-aec3-cb9272f093dc" is the tenantId and "f260bbc4-c254-447b-94cf-293b5ec434dd" is the objectId
        /// of the member (user, application, servicePrincipal, group) to be added.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A member object URL, such as ""https://graph.windows.net/0b1f9851-1bf0-433f-aec3-cb9272f093dc/directoryObjects/f260bbc4-c254-447b-94cf-293b5ec434dd"", where ""0b1f9851-1bf0-433f-aec3-cb9272f093dc"" is the tenantId and ""f260bbc4-c254-447b-94cf-293b5ec434dd"" is the objectId of the member (user, application, servicePrincipal, group) to be added.",
        SerializedName = @"url",
        PossibleTypes = new [] { typeof(string) })]
        string Url { get; set; }

    }
    /// Request parameters for adding a member to a group.
    internal partial interface IGroupAddMemberParametersInternal

    {
        /// <summary>
        /// A member object URL, such as "https://graph.windows.net/0b1f9851-1bf0-433f-aec3-cb9272f093dc/directoryObjects/f260bbc4-c254-447b-94cf-293b5ec434dd",
        /// where "0b1f9851-1bf0-433f-aec3-cb9272f093dc" is the tenantId and "f260bbc4-c254-447b-94cf-293b5ec434dd" is the objectId
        /// of the member (user, application, servicePrincipal, group) to be added.
        /// </summary>
        string Url { get; set; }

    }
}