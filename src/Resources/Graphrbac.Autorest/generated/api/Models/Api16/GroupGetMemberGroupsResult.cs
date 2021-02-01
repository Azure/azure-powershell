namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Server response for GetMemberGroups API call.</summary>
    public partial class GroupGetMemberGroupsResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IGroupGetMemberGroupsResult,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IGroupGetMemberGroupsResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string[] _value;

        /// <summary>A collection of group IDs of which the group is a member.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="GroupGetMemberGroupsResult" /> instance.</summary>
        public GroupGetMemberGroupsResult()
        {

        }
    }
    /// Server response for GetMemberGroups API call.
    public partial interface IGroupGetMemberGroupsResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>A collection of group IDs of which the group is a member.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of group IDs of which the group is a member.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string[] Value { get; set; }

    }
    /// Server response for GetMemberGroups API call.
    internal partial interface IGroupGetMemberGroupsResultInternal

    {
        /// <summary>A collection of group IDs of which the group is a member.</summary>
        string[] Value { get; set; }

    }
}