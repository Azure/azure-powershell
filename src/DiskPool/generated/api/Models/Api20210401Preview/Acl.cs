namespace Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Extensions;

    /// <summary>Access Control List (ACL) for an iSCSI Target; defines LUN masking policy</summary>
    public partial class Acl :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IAcl,
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IAclInternal
    {

        /// <summary>Backing field for <see cref="InitiatorIqn" /> property.</summary>
        private string _initiatorIqn;

        /// <summary>
        /// iSCSI initiator IQN (iSCSI Qualified Name); example: "iqn.2005-03.org.iscsi:client".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        public string InitiatorIqn { get => this._initiatorIqn; set => this._initiatorIqn = value; }

        /// <summary>Backing field for <see cref="MappedLun" /> property.</summary>
        private string[] _mappedLun;

        /// <summary>List of LUN names mapped to the ACL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        public string[] MappedLun { get => this._mappedLun; set => this._mappedLun = value; }

        /// <summary>Creates an new <see cref="Acl" /> instance.</summary>
        public Acl()
        {

        }
    }
    /// Access Control List (ACL) for an iSCSI Target; defines LUN masking policy
    public partial interface IAcl :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.IJsonSerializable
    {
        /// <summary>
        /// iSCSI initiator IQN (iSCSI Qualified Name); example: "iqn.2005-03.org.iscsi:client".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"iSCSI initiator IQN (iSCSI Qualified Name); example: ""iqn.2005-03.org.iscsi:client"".",
        SerializedName = @"initiatorIqn",
        PossibleTypes = new [] { typeof(string) })]
        string InitiatorIqn { get; set; }
        /// <summary>List of LUN names mapped to the ACL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"List of LUN names mapped to the ACL.",
        SerializedName = @"mappedLuns",
        PossibleTypes = new [] { typeof(string) })]
        string[] MappedLun { get; set; }

    }
    /// Access Control List (ACL) for an iSCSI Target; defines LUN masking policy
    internal partial interface IAclInternal

    {
        /// <summary>
        /// iSCSI initiator IQN (iSCSI Qualified Name); example: "iqn.2005-03.org.iscsi:client".
        /// </summary>
        string InitiatorIqn { get; set; }
        /// <summary>List of LUN names mapped to the ACL.</summary>
        string[] MappedLun { get; set; }

    }
}