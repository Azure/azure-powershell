namespace Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Extensions;

    /// <summary>
    /// Contains the map of disk serial number to the disk size being used for the job. Is returned only after the disks are shipped
    /// to the customer.
    /// </summary>
    public partial class DataBoxDiskJobDetailsDisksAndSizeDetails :
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.IDataBoxDiskJobDetailsDisksAndSizeDetails,
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.IDataBoxDiskJobDetailsDisksAndSizeDetailsInternal
    {

        /// <summary>
        /// Creates an new <see cref="DataBoxDiskJobDetailsDisksAndSizeDetails" /> instance.
        /// </summary>
        public DataBoxDiskJobDetailsDisksAndSizeDetails()
        {

        }
    }
    /// Contains the map of disk serial number to the disk size being used for the job. Is returned only after the disks are shipped
    /// to the customer.
    public partial interface IDataBoxDiskJobDetailsDisksAndSizeDetails :
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.IAssociativeArray<int>
    {

    }
    /// Contains the map of disk serial number to the disk size being used for the job. Is returned only after the disks are shipped
    /// to the customer.
    internal partial interface IDataBoxDiskJobDetailsDisksAndSizeDetailsInternal

    {

    }
}