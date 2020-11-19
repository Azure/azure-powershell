namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>
    /// Guest disk signature based disk exclusion option when doing enable protection of virtual machine in InMage provider.
    /// </summary>
    public partial class InMageDiskSignatureExclusionOptions :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskSignatureExclusionOptions,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskSignatureExclusionOptionsInternal
    {

        /// <summary>Backing field for <see cref="DiskSignature" /> property.</summary>
        private string _diskSignature;

        /// <summary>The guest signature of disk to be excluded from replication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskSignature { get => this._diskSignature; set => this._diskSignature = value; }

        /// <summary>Creates an new <see cref="InMageDiskSignatureExclusionOptions" /> instance.</summary>
        public InMageDiskSignatureExclusionOptions()
        {

        }
    }
    /// Guest disk signature based disk exclusion option when doing enable protection of virtual machine in InMage provider.
    public partial interface IInMageDiskSignatureExclusionOptions :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The guest signature of disk to be excluded from replication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The guest signature of disk to be excluded from replication.",
        SerializedName = @"diskSignature",
        PossibleTypes = new [] { typeof(string) })]
        string DiskSignature { get; set; }

    }
    /// Guest disk signature based disk exclusion option when doing enable protection of virtual machine in InMage provider.
    internal partial interface IInMageDiskSignatureExclusionOptionsInternal

    {
        /// <summary>The guest signature of disk to be excluded from replication.</summary>
        string DiskSignature { get; set; }

    }
}