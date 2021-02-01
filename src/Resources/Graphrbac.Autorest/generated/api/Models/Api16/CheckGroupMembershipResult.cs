namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Server response for IsMemberOf API call</summary>
    public partial class CheckGroupMembershipResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ICheckGroupMembershipResult,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ICheckGroupMembershipResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private bool? _value;

        /// <summary>
        /// True if the specified user, group, contact, or service principal has either direct or transitive membership in the specified
        /// group; otherwise, false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="CheckGroupMembershipResult" /> instance.</summary>
        public CheckGroupMembershipResult()
        {

        }
    }
    /// Server response for IsMemberOf API call
    public partial interface ICheckGroupMembershipResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>
    {
        /// <summary>
        /// True if the specified user, group, contact, or service principal has either direct or transitive membership in the specified
        /// group; otherwise, false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"True if the specified user, group, contact, or service principal has either direct or transitive membership in the specified group; otherwise, false.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Value { get; set; }

    }
    /// Server response for IsMemberOf API call
    internal partial interface ICheckGroupMembershipResultInternal

    {
        /// <summary>
        /// True if the specified user, group, contact, or service principal has either direct or transitive membership in the specified
        /// group; otherwise, false.
        /// </summary>
        bool? Value { get; set; }

    }
}