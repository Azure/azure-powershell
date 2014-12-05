
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public partial class PSStorSimpleClient
    {
        public DataContainerListResponse GetAllDataContainers(string deviceId)
        {
            return this.GetStorSimpleClient().DataContainer.List(deviceId, this.GetCustomRequestHeaders());
        }

        public JobStatusInfo GetJobStatus(string jobId)
        {
            return GetStorSimpleClient().GetOperationStatus(jobId);
        }
        public JobStatusInfo CreateDataContainer(string deviceId,DataContainerRequest dc)
        {
                return GetStorSimpleClient().DataContainer.Create(deviceId, dc, GetCustomRequestHeaders());
           
        }

        public JobResponse CreateDataContainerAsync(string deviceId, DataContainerRequest dc)
        {
            return GetStorSimpleClient().DataContainer.BeginCreating(deviceId, dc, GetCustomRequestHeaders());
        }


        public DataContainerGetResponse GetDataContainer(string deviceId, string Name)
        {
            return GetStorSimpleClient().DataContainer.Get(deviceId, Name, GetCustomRequestHeaders());
        }

        public JobResponse DeleteDataContainerAsync(string deviceid, string dcid)
        {
            return GetStorSimpleClient().DataContainer.BeginDeleting(deviceid, dcid, GetCustomRequestHeaders());
        }

        public JobStatusInfo DeleteDataContainer(string deviceid, string dcid)
        {
            return GetStorSimpleClient().DataContainer.Delete(deviceid, dcid, GetCustomRequestHeaders());
        }
    }
}