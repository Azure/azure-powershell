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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SRSDataModel = Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models
{
    /// <summary>
    ///     The definition of a health object.
    /// </summary>
    public class ASRHealthError_2016_08_10
    {
        /// <summary>
        ///     Initializes a new instance of the HealthError class.
        /// </summary>
        /// <param name="healthError">Event health error object.</param>
        public ASRHealthError_2016_08_10(HealthError healthError)
        {
            if (healthError.CreationTimeUtc.HasValue)
            {
                this.CreationTimeUtc = healthError.CreationTimeUtc.Value.ToUniversalTime()
                    .ToString("o");
            }

            this.ErrorSource = healthError.ErrorSource;
            this.ErrorType = healthError.ErrorType;
            this.EntityId = healthError.EntityId;
            this.ErrorCode = healthError.ErrorCode;
            this.ErrorLevel = healthError.ErrorLevel;
            this.ErrorMessage = healthError.ErrorMessage;
            this.PossibleCauses = healthError.PossibleCauses;
            this.RecommendedAction = healthError.RecommendedAction;
            this.RecoveryProviderErrorMessage = healthError.RecoveryProviderErrorMessage;
            this.childError = new List<ASRHealthError_2016_08_10>();
            if (healthError.InnerHealthErrors != null)
            {
                foreach (var innerHealthError in healthError.InnerHealthErrors)
                {
                    var childHealthError = new ASRHealthError_2016_08_10(innerHealthError);
                    this.childError.Add(childHealthError);
                }

            }
        }

        /// <summary>
        ///     Initializes a new instance of the HealthError class.
        /// </summary>
        /// <param name="healthError">Event health error object.</param>
        public ASRHealthError_2016_08_10(InnerHealthError healthError)
        {
            if (healthError.CreationTimeUtc.HasValue)
            {
                this.CreationTimeUtc = healthError.CreationTimeUtc.Value.ToUniversalTime()
                    .ToString("o");
            }

            this.ErrorSource = healthError.ErrorSource;
            this.ErrorType = healthError.ErrorType;
            this.EntityId = healthError.EntityId;
            this.ErrorCode = healthError.ErrorCode;
            this.ErrorLevel = healthError.ErrorLevel;
            this.ErrorMessage = healthError.ErrorMessage;
            this.PossibleCauses = healthError.PossibleCauses;
            this.RecommendedAction = healthError.RecommendedAction;
            this.RecoveryProviderErrorMessage = healthError.RecoveryProviderErrorMessage;
        }

        /// <summary>
        ///     Error source.
        /// </summary>
        public string ErrorSource { get; set; }

        /// <summary>
        ///     Error type.
        /// </summary>
        public string ErrorType { get; set; }

        /// <summary>
        ///     Error type.
        /// </summary>
        public IList<ASRHealthError_2016_08_10> childError { get; set; }

        /// <summary>
        ///     Error creation time (UTC).
        /// </summary>
        public string CreationTimeUtc { get; set; }

        /// <summary>
        ///     ID of the entity.
        /// </summary>
        public string EntityId { get; set; }

        /// <summary>
        ///     Error code.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        ///     Level of error.
        /// </summary>
        public string ErrorLevel { get; set; }

        /// <summary>
        ///     Error message.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     Possible causes of error.
        /// </summary>
        public string PossibleCauses { get; set; }

        /// <summary>
        ///     Recommended action to resolve error.
        /// </summary>
        public string RecommendedAction { get; set; }

        /// <summary>
        ///     Recovery Provider error message.
        /// </summary>
        public string RecoveryProviderErrorMessage { get; set; }
    }

    /// <summary>
    ///     ASR VM Nic Details
    /// </summary>
    public class ASRVMNicDetails_2016_08_10
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRVMNicDetails_2016_08_10" /> class.
        /// </summary>
        public ASRVMNicDetails_2016_08_10()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRVMNicDetails_2016_08_10" /> class.
        /// </summary>
        public ASRVMNicDetails_2016_08_10(
            VMNicDetails vMNicDetails)
        {
            this.NicId = vMNicDetails.NicId;
            this.ReplicaNicId = vMNicDetails.ReplicaNicId;
            this.SourceNicArmId = vMNicDetails.SourceNicArmId;
            this.VMNetworkName = vMNicDetails.VMNetworkName;
            this.VMSubnetName = vMNicDetails.VMSubnetName;
            this.RecoveryVMNetworkId = vMNicDetails.RecoveryVMNetworkId;
            this.RecoveryVMSubnetName = vMNicDetails.RecoveryVMSubnetName;
            this.ReplicaNicStaticIPAddress = vMNicDetails.ReplicaNicStaticIPAddress;
            this.IpAddressType = vMNicDetails.IpAddressType;
            this.SelectionType = vMNicDetails.SelectionType;
            this.PrimaryNicStaticIPAddress = vMNicDetails.PrimaryNicStaticIPAddress;
            this.RecoveryNicIpAddressType = vMNicDetails.RecoveryNicIpAddressType;
        }

        //
        // Summary:
        //     Gets or sets primary nic static IP address.
        public string PrimaryNicStaticIPAddress { get; set; }

        //
        // Summary:
        //     Gets or sets IP allocation type for recovery VM.
        public string RecoveryNicIpAddressType { get; set; }

        //
        // Summary:
        //     Gets or sets the replica nic Id.
        public string ReplicaNicId { get; set; }

        //
        // Summary:
        //     Gets or sets the source nic ARM Id.
        public string SourceNicArmId { get; set; }

        /// <summary>
        ///     Gets or sets ipv4 address type.
        /// </summary>
        public string IpAddressType { get; set; }

        /// <summary>
        ///     Gets or sets the nic Id.
        /// </summary>
        public string NicId { get; set; }

        /// <summary>
        ///     Gets or sets recovery VM network Id.
        /// </summary>
        public string RecoveryVMNetworkId { get; set; }

        /// <summary>
        ///     Gets or sets recovery VM subnet name.
        /// </summary>
        public string RecoveryVMSubnetName { get; set; }

        /// <summary>
        ///     Gets or sets replica nic static IP address.
        /// </summary>
        public string ReplicaNicStaticIPAddress { get; set; }

        /// <summary>
        ///     Gets or sets selection type for failover.
        /// </summary>
        public string SelectionType { get; set; }

        /// <summary>
        ///     Gets or sets VM network name.
        /// </summary>
        public string VMNetworkName { get; set; }

        /// <summary>
        ///     Gets or sets VM subnet name.
        /// </summary>
        public string VMSubnetName { get; set; }
    }

    /// <summary>
    /// Onprem disk details data.
    /// </summary>
    public class ASRHyperVReplicaDiskDetails_2016_08_10
    {
        public ASRHyperVReplicaDiskDetails_2016_08_10(DiskDetails diskDetails)
        {
            this.MaxSizeMB = diskDetails.MaxSizeMB;
            this.VhdId = diskDetails.VhdId;
            this.VhdName = diskDetails.VhdName;
            this.VhdType = diskDetails.VhdType;
        }
        /// <summary>
        ///    Gets or sets the hard disk max size in MB.
        /// </summary>
        public long? MaxSizeMB { get; set; }

        /// <summary>
        ///     Gets or sets the type of the volume.
        /// </summary>
        public string VhdType { get; set; }

        /// <summary>
        ///     Gets or sets the VHD Id.
        /// </summary>
        public string VhdId { get; set; }

        /// <summary>
        ///     Gets or sets the VHD name.
        /// </summary>
        public string VhdName { get; set; }
    }

    public class ASRHyperVReplicaAzureVmDiskDetails_2016_08_10
    {
        public ASRHyperVReplicaAzureVmDiskDetails_2016_08_10(AzureVmDiskDetails hyperVReplicaAzureVmDiskDetails)
        {
            this.VhdType = hyperVReplicaAzureVmDiskDetails.VhdType;
            this.VhdId = hyperVReplicaAzureVmDiskDetails.VhdId;
            this.VhdName = hyperVReplicaAzureVmDiskDetails.VhdName;
            this.MaxSizeMB = hyperVReplicaAzureVmDiskDetails.MaxSizeMB;
            this.TargetDiskLocation = hyperVReplicaAzureVmDiskDetails.TargetDiskLocation;
            this.TargetDiskName = hyperVReplicaAzureVmDiskDetails.TargetDiskName;
            this.LunId = hyperVReplicaAzureVmDiskDetails.LunId;
        }

        /// <summary>
        ///    Gets or sets VHD type.
        /// </summary>
        public string VhdType { get; set; }

        /// <summary>
        ///    Gets or sets the VHD id.
        /// </summary>
        public string VhdId { get; set; }

        /// <summary>
        ///    Gets or sets VHD name.
        /// </summary>
        public string VhdName { get; set; }

        /// <summary>
        ///    Gets or sets max side in MB.
        /// </summary>
        public string MaxSizeMB { get; set; }

        /// <summary>
        ///    Gets or sets blob uri of the Azure disk.
        /// </summary>
        public string TargetDiskLocation { get; set; }

        /// <summary>
        ///     Gets or sets the target Azure disk name.
        /// </summary>
        public string TargetDiskName { get; set; }

        /// <summary>
        ///     Gets or sets ordinal\LunId of the disk for the Azure VM.
        /// </summary>
        public string LunId { get; set; }
    }
    /// <summary>
    /// Azure to Azure VM synced configuration details.
    /// </summary>
    public class ASRAzureToAzureVmSyncedConfigDetails_2016_08_10
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRAzureToAzureVmSyncedConfigDetails_2016_08_10" />
        /// class.
        /// </summary>
        public ASRAzureToAzureVmSyncedConfigDetails_2016_08_10()
        {
            this.Tags = new Dictionary<string, string>();
            this.RoleAssignments = new List<ASRRoleAssignment_2016_08_10>();
            this.InputEndpoints = new List<ASRInputEndpoint_2016_08_10>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRAzureToAzureVmSyncedConfigDetails_2016_08_10" />
        /// class.
        /// </summary>
        public ASRAzureToAzureVmSyncedConfigDetails_2016_08_10(AzureToAzureVmSyncedConfigDetails details)
        {
            if (details.Tags == null)
            {
                this.Tags = new Dictionary<string, string>();
            }
            else
            {
                this.Tags = new Dictionary<string, string>(details.Tags);
            }

            if (details.RoleAssignments != null)
            {
                this.RoleAssignments =
                    details.RoleAssignments.ToList()
                    .ConvertAll(role => new ASRRoleAssignment_2016_08_10(role));
            }

            if (details.InputEndpoints != null)
            {
                this.InputEndpoints =
                    details.InputEndpoints.ToList()
                    .ConvertAll(endpoint => new ASRInputEndpoint_2016_08_10(endpoint));
            }
        }

        /// <summary>
        /// Gets or sets the Azure VM tags.
        /// </summary>
        public Dictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the Azure role assignments.
        /// </summary>
        public List<ASRRoleAssignment_2016_08_10> RoleAssignments { get; set; }

        /// <summary>
        /// Gets or sets the Azure VM input endpoints.
        /// </summary>
        public List<ASRInputEndpoint_2016_08_10> InputEndpoints { get; set; }
    }

    /// <summary>
    /// Azure VM input endpoint details.
    /// </summary>
    public class ASRInputEndpoint_2016_08_10
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRInputEndpoint_2016_08_10" /> class.
        /// </summary>
        public ASRInputEndpoint_2016_08_10(InputEndpoint endpoint)
        {
            this.EndpointName = endpoint.EndpointName;
            this.PrivatePort = endpoint.PrivatePort;
            this.PublicPort = endpoint.PublicPort;
            this.Protocol = endpoint.Protocol;
        }

        /// <summary>
        /// Gets or sets the input endpoint name.
        /// </summary>
        public string EndpointName { get; set; }

        /// <summary>
        /// Gets or sets the input endpoint private port.
        /// </summary>
        public int? PrivatePort { get; set; }

        /// <summary>
        /// Gets or sets the input endpoint public port.
        /// </summary>
        public int? PublicPort { get; set; }

        /// <summary>
        /// Gets or sets the input endpoint protocol.
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// Returns a string representation of the object.
        /// </summary>
        /// <returns>Returns a string representing the object.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("EndpointName     : " + this.EndpointName);
            sb.AppendLine("PrivatePort      : " + this.PrivatePort);
            sb.AppendLine("PublicPort       : " + this.PublicPort);
            sb.AppendLine("Protocol         : " + this.Protocol);

            return sb.ToString();
        }
    }

    /// <summary>
    /// Azure role assignment details.
    /// </summary>
    public class ASRRoleAssignment_2016_08_10
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRRoleAssignment_2016_08_10" /> class.
        /// </summary>
        public ASRRoleAssignment_2016_08_10(RoleAssignment role)
        {
            this.Id = role.Id;
            this.Name = role.Name;
            this.Scope = role.Scope;
            this.PrincipalId = role.PrincipalId;
            this.RoleDefinitionId = role.RoleDefinitionId;
        }

        /// <summary>
        /// Gets or sets the ARM Id of the role assignment.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the role assignment.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets role assignment scope.
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets principal Id.
        /// </summary>
        public string PrincipalId { get; set; }

        /// <summary>
        /// Gets or sets role definition id.
        /// </summary>
        public string RoleDefinitionId { get; set; }

        /// <summary>
        /// Returns a string representation of the object.
        /// </summary>
        /// <returns>Returns a string representing the object.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Id: " + this.Id);
            sb.AppendLine("Name: " + this.Name);
            sb.AppendLine("Scope: " + this.Scope);
            sb.AppendLine("PrincipalId: " + this.PrincipalId);
            sb.AppendLine("RoleDefinitionId: " + this.RoleDefinitionId);

            return sb.ToString();
        }
    }

    /// <summary>
    /// AzureToAzure replication provider specific protected disk details.
    /// </summary>
    public class ASRAzureToAzureProtectedDiskDetails_2016_08_10
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRAzureToAzureProtectedDiskDetails_2016_08_10" />
        /// class.
        /// </summary>
        public ASRAzureToAzureProtectedDiskDetails_2016_08_10()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRAzureToAzureProtectedDiskDetails_2016_08_10" />
        /// class.
        /// </summary>
        public ASRAzureToAzureProtectedDiskDetails_2016_08_10(A2AProtectedDiskDetails disk)
        {
            this.DiskUri = disk.DiskUri;
            this.PrimaryDiskAzureStorageAccountId = disk.PrimaryDiskAzureStorageAccountId;
            this.PrimaryStagingAzureStorageAccountId = disk.PrimaryStagingAzureStorageAccountId;
            this.RecoveryAzureStorageAccountId = disk.RecoveryAzureStorageAccountId;
            this.RecoveryDiskUri = disk.RecoveryDiskUri;
            this.ResyncRequired = disk.ResyncRequired;
            this.MonitoringPercentageCompletion = disk.MonitoringPercentageCompletion;
            this.MonitoringJobType = disk.MonitoringJobType;
            this.DataPendingInStagingStorageAccountInMB = disk.DataPendingInStagingStorageAccountInMB;
            this.DataPendingAtSourceAgentInMB = disk.DataPendingAtSourceAgentInMB;
            this.DiskCapacityInBytes = disk.DiskCapacityInBytes;
            this.DiskName = disk.DiskName;
            this.DiskType = disk.DiskType;
            this.Managed = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRAzureToAzureProtectedDiskDetails_2016_08_10" />
        /// class.
        /// </summary>
        public ASRAzureToAzureProtectedDiskDetails_2016_08_10(A2AProtectedManagedDiskDetails disk)
        {
            this.PrimaryStagingAzureStorageAccountId = disk.PrimaryStagingAzureStorageAccountId;
            this.ResyncRequired = disk.ResyncRequired;
            this.MonitoringPercentageCompletion = disk.MonitoringPercentageCompletion;
            this.MonitoringJobType = disk.MonitoringJobType;
            this.DataPendingInStagingStorageAccountInMB = disk.DataPendingInStagingStorageAccountInMB;
            this.DataPendingAtSourceAgentInMB = disk.DataPendingAtSourceAgentInMB;
            this.DiskCapacityInBytes = disk.DiskCapacityInBytes;
            this.DiskName = disk.DiskName;
            this.DiskType = disk.DiskType;
            this.RecoveryReplicaDiskAccountType = disk.RecoveryReplicaDiskAccountType;
            this.RecoveryReplicaDiskId = disk.RecoveryReplicaDiskId;
            this.RecoveryResourceGroupId = disk.RecoveryResourceGroupId;
            this.RecoveryTargetDiskAccountType = disk.RecoveryTargetDiskAccountType;
            this.RecoveryTargetDiskId = disk.RecoveryTargetDiskId;
            this.Managed = true;
        }

        /// <summary>
        /// Gets or sets is azure vm managed disk.
        /// </summary>
        public bool Managed { get; set; }

        /// <summary>
        /// Gets or sets is recovery azure vm managed disk type.
        /// </summary>
        public string RecoveryReplicaDiskAccountType { get; set; }

        /// <summary>
        /// Gets or sets the recovery replica disk id.
        /// </summary>
        public string RecoveryReplicaDiskId { get; set; }

        /// <summary>
        /// Gets or sets the recovery resource group id.
        /// </summary>
        public string RecoveryResourceGroupId { get; set; }

        /// <summary>
        /// Gets or sets the recovery target disk AccountType.
        /// </summary>

        public string RecoveryTargetDiskAccountType { get; set; }

        /// <summary>
        /// Gets or sets the recovery target disk Id.
        /// </summary>
        public string RecoveryTargetDiskId { get; set; }

        /// <summary>
        /// Gets or sets the disk uri.
        /// </summary>
        public string DiskUri { get; set; }

        /// <summary>
        /// Gets or sets the primary disk storage account. 
        /// </summary>
        public string PrimaryDiskAzureStorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets the primary staging storage account.
        /// </summary>
        public string PrimaryStagingAzureStorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets the recovery disk storage account. 
        /// </summary>
        public string RecoveryAzureStorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets the disk capacity in bytes. 
        /// </summary>

        public long? DiskCapacityInBytes { get; set; }

        /// <summary>
        /// Gets or sets the disk name. 
        /// </summary>
        public string DiskName { get; set; }

        /// <summary>
        /// Gets or sets the diskType. 
        /// </summary>
        public string DiskType { get; set; }

        /// <summary>
        /// Gets or sets recovery disk uri.
        /// </summary>
        public string RecoveryDiskUri { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether resync is required for this disk.
        /// </summary>
        public bool? ResyncRequired { get; set; }

        /// <summary>
        /// Gets or sets the type of the monitoring job. The progress is contained in
        /// MonitoringPercentageCompletion property.
        /// </summary>
        public string MonitoringJobType { get; set; }

        /// <summary>
        /// Gets or sets the percentage of the monitoring job. The type of the monitoring job
        /// is defined by MonitoringJobType property.
        /// </summary>
        public int? MonitoringPercentageCompletion { get; set; }

        /// <summary>
        /// Gets or sets the data pending for replication in MB at staging account.
        /// </summary>
        public double? DataPendingInStagingStorageAccountInMB { get; set; }

        /// <summary>
        /// Gets or sets the data pending at source virtual machine in MB.
        /// </summary>
        public double? DataPendingAtSourceAgentInMB { get; set; }
    }

    /// <summary>
    ///     Disk Details.
    /// </summary>
    public class ASRHyperVReplicaAzureOsDetails_2016_08_10
    {
        public ASRHyperVReplicaAzureOsDetails_2016_08_10(OSDetails hyperVOsSetails)
        {
            this.OsType = hyperVOsSetails.OsType;
            this.ProductType = hyperVOsSetails.ProductType;
            this.OsEdition = hyperVOsSetails.OsEdition;
            this.OSVersion = hyperVOsSetails.OSVersion;
            this.OSMinorVersion = hyperVOsSetails.OSMinorVersion;
            this.OSMajorVersion = hyperVOsSetails.OSMajorVersion;
        }
        /// <summary>
        ///     Gets or sets VM Disk details.
        /// </summary>
        public string OsType { get; set; }

        /// <summary>
        ///  Gets or sets product type.
        /// </summary>
        public string ProductType { get; set; }

        /// <summary>
        ///     Gets or sets the OSEdition.
        /// </summary>
        public string OsEdition { get; set; }

        /// <summary>
        ///     Gets or sets the OS Version.
        /// </summary>
        public string OSVersion { get; set; }

        /// <summary>
        ///    Gets or sets the OS Major Version.
        /// </summary>
        public string OSMajorVersion { get; set; }

        /// <summary>
        ///    Gets or sets the OS Minor Version.
        /// </summary>
        public string OSMinorVersion { get; set; }
    }
}
