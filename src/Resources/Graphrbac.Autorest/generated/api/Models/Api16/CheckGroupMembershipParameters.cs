namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Request parameters for IsMemberOf API call.</summary>
    public partial class CheckGroupMembershipParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ICheckGroupMembershipParameters,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ICheckGroupMembershipParametersInternal
    {

        /// <summary>Backing field for <see cref="GroupId" /> property.</summary>
        private string _groupId;

        /// <summary>The object ID of the group to check.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string GroupId { get => this._groupId; set => this._groupId = value; }

        /// <summary>Backing field for <see cref="MemberId" /> property.</summary>
        private string _memberId;

        /// <summary>
        /// The object ID of the contact, group, user, or service principal to check for membership in the specified group.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string MemberId { get => this._memberId; set => this._memberId = value; }

        /// <summary>Creates an new <see cref="CheckGroupMembershipParameters" /> instance.</summary>
        public CheckGroupMembershipParameters()
        {

        }
    }
    /// Request parameters for IsMemberOf API call.
    public partial interface ICheckGroupMembershipParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>
    {
        /// <summary>The object ID of the group to check.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The object ID of the group to check.",
        SerializedName = @"groupId",
        PossibleTypes = new [] { typeof(string) })]
        string GroupId { get; set; }
        /// <summary>
        /// The object ID of the contact, group, user, or service principal to check for membership in the specified group.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The object ID of the contact, group, user, or service principal to check for membership in the specified group.",
        SerializedName = @"memberId",
        PossibleTypes = new [] { typeof(string) })]
        string MemberId { get; set; }

    }
    /// Request parameters for IsMemberOf API call.
    internal partial interface ICheckGroupMembershipParametersInternal

    {
        /// <summary>The object ID of the group to check.</summary>
        string GroupId { get; set; }
        /// <summary>
        /// The object ID of the contact, group, user, or service principal to check for membership in the specified group.
        /// </summary>
        string MemberId { get; set; }

    }
}