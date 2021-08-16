namespace Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Extensions;

    /// <summary>
    /// User preference on what size disks are needed for the job. The map is from the disk size in TB to the count. Eg. {2,5}
    /// means 5 disks of 2 TB size. Key is string but will be checked against an int.
    /// </summary>
    public partial class DataBoxDiskJobDetailsPreferredDisks :
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.IDataBoxDiskJobDetailsPreferredDisks,
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.IDataBoxDiskJobDetailsPreferredDisksInternal
    {

        /// <summary>Creates an new <see cref="DataBoxDiskJobDetailsPreferredDisks" /> instance.</summary>
        public DataBoxDiskJobDetailsPreferredDisks()
        {

        }
    }
    /// User preference on what size disks are needed for the job. The map is from the disk size in TB to the count. Eg. {2,5}
    /// means 5 disks of 2 TB size. Key is string but will be checked against an int.
    public partial interface IDataBoxDiskJobDetailsPreferredDisks :
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.IAssociativeArray<int>
    {

    }
    /// User preference on what size disks are needed for the job. The map is from the disk size in TB to the count. Eg. {2,5}
    /// means 5 disks of 2 TB size. Key is string but will be checked against an int.
    internal partial interface IDataBoxDiskJobDetailsPreferredDisksInternal

    {

    }
}