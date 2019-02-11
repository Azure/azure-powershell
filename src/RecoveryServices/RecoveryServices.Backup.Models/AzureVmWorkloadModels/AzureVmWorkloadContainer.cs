// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Azure Workload specific container class.
    /// </summary>
    public class AzureVmWorkloadContainer : AzureContainer
    {
        /// <summary>
        ///  Gets resource Id represents the complete path to the resource.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///  Gets or sets ARM ID of the virtual machine represented by this Azure Workload
        /// </summary>
        public string SourceResourceId { get; set; }

        /// <summary>
        ///  Gets or sets status of health of the container.
        /// </summary>
        public string HealthStatus { get; set; }

        /// <summary>
        ///  Gets or sets additional details of a workload container.
        /// </summary>
        public List<AzureVmWorkloadContainerExtendedInfo> ExtendedInfo { get; set; }

        public string WorkloadsPresent { get; set; }

        /// <summary>
        /// Constructor. Takes the service client object representing the container 
        /// and converts it in to the PS container model
        /// </summary>
        /// <param name="protectionContainerResource">Service client object representing the container</param>
        public AzureVmWorkloadContainer(ProtectionContainerResource protectionContainerResource)
            : base(protectionContainerResource)
        {
            AzureVMAppContainerProtectionContainer protectionContainer = (AzureVMAppContainerProtectionContainer)protectionContainerResource.Properties;
            Id = protectionContainerResource.Id;
            SourceResourceId = protectionContainer.SourceResourceId;
            HealthStatus = protectionContainer.HealthStatus;
            ExtendedInfo = new List<AzureVmWorkloadContainerExtendedInfo>();
            WorkloadsPresent = "";
            foreach (var inquiryDetail in protectionContainer.ExtendedInfo.InquiryInfo.InquiryDetails)
            {
                ExtendedInfo.Add(new AzureVmWorkloadContainerExtendedInfo()
                {
                    InquiryStatus = inquiryDetail.InquiryValidation.Status,
                    WorkloadItems = inquiryDetail.ItemCount,
                    WorkloadType = inquiryDetail.Type
                });
                WorkloadsPresent += inquiryDetail.Type + ",";
            }
            WorkloadsPresent = WorkloadsPresent.Remove(WorkloadsPresent.Length - 1);
        }
    }
    public class AzureVmWorkloadContainerExtendedInfo
    {
        /// <summary>
        /// Gets or sets status for the Inquiry Validation.
        /// </summary>
        public string InquiryStatus { get; set; }

        /// <summary>
        /// Gets or sets contains the protectable item Count inside this Container.
        /// </summary>
        public string WorkloadType { get; set; }

        /// <summary>
        /// Gets or sets type of the Workload such as SQL, Oracle etc.
        /// </summary>
        public long? WorkloadItems { get; set; }
    }
}