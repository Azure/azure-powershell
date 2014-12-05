using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public partial class PSStorSimpleClient
    {
        public VirtualDiskListResponse GetAllVolumesFordataContainer(string deviceid,string datacontainerid)
        {
            return GetStorSimpleClient().VirtualDisk.List(deviceid, datacontainerid, GetCustomRequestHeaders());
        }

        public VirtualDiskGetResponse GetVolumeByName(string deviceid, string diskName)
        {
            return GetStorSimpleClient().VirtualDisk.GetByName(deviceid, diskName, GetCustomRequestHeaders());
        }

        public JobStatusInfo CreateVolume(string deviceid, VirtualDiskRequest diskDetails)
        {
            return GetStorSimpleClient().VirtualDisk.Create(deviceid, diskDetails, GetCustomRequestHeaders());
        }

        public GuidJobResponse CreateVolumeAsync(string deviceid, VirtualDiskRequest diskDetails)
        {
            return GetStorSimpleClient().VirtualDisk.BeginCreating(deviceid, diskDetails, GetCustomRequestHeaders());
        }

        public JobStatusInfo RemoveVolume(string deviceid, string diskid)
        {
            return GetStorSimpleClient().VirtualDisk.Delete(deviceid, diskid, GetCustomRequestHeaders());
        }
        public GuidJobResponse RemoveVolumeAsync(string deviceid, string diskid)
        {
            return GetStorSimpleClient().VirtualDisk.BeginDeleting(deviceid, diskid, GetCustomRequestHeaders());
        }

        public JobStatusInfo UpdateVolume(string deviceid, string diskid, VirtualDisk diskDetails)
        {
            return GetStorSimpleClient().VirtualDisk.Update(deviceid, diskid, diskDetails, GetCustomRequestHeaders());
        }
        public GuidJobResponse UpdateVolumeAsync(string deviceid, string diskid, VirtualDisk diskDetails)
        {
            return GetStorSimpleClient().VirtualDisk.BeginUpdating(deviceid, diskid, diskDetails,GetCustomRequestHeaders());
        }
    }
}