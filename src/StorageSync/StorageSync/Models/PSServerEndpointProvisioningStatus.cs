using Microsoft.Azure.Management.StorageSync.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.StorageSync.Models
{
    public class PSServerEndpointProvisioningStatus
    {
        /// <summary>
        /// Gets server Endpoint provisioning status. Possible values include:
        /// 'NotStarted', 'InProgress', 'Ready_SyncNotFunctional',
        /// 'Ready_SyncFunctional', 'Error'
        /// </summary>
        public string ProvisioningStatus { get; set; }

        /// <summary>
        /// Gets server Endpoint provisioning type
        /// </summary>
        public string ProvisioningType { get; set; }

        /// <summary>
        /// Gets provisioning Step status information for each step in the
        /// provisioning process
        /// </summary>
        public IList<PSServerEndpointProvisioningStepStatus> ProvisioningStepStatuses { get; set; }
    }

    public class PSServerEndpointProvisioningStepStatus
    {
        /// <summary>
        /// Gets name of the provisioning step
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets status of the provisioning step
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets start time of the provisioning step
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets estimated completion time of the provisioning step in minutes
        /// </summary>
        public int? MinutesLeft { get; set; }

        /// <summary>
        /// Gets estimated progress percentage
        /// </summary>
        public int? ProgressPercentage { get; set; }

        /// <summary>
        /// Gets end time of the provisioning step
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets error code (HResult) for the provisioning step
        /// </summary>
        public int? ErrorCode { get; set; }

        /// <summary>
        /// Gets additional information for the provisioning step
        /// </summary>
        public IDictionary<string, string> AdditionalInformation { get; set; }
    }
}
