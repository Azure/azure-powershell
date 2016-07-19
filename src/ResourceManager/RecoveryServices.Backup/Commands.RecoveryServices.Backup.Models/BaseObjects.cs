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
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Base class for all the PowerShell model objects.
    /// </summary>
    public class ObjectBase
    {
        /// <summary>
        /// Method to validate the object properties.
        /// </summary>
        public virtual void Validate() { }
    }

    /// <summary>
    /// Class containing common properties across different contexts.
    /// </summary>
    public class ManagementContext : ObjectBase
    {
        /// <summary>
        /// Type of the backup management agent.
        /// </summary>
        public BackupManagementType BackupManagementType { get; set; }

        public ManagementContext() { }

        public ManagementContext(string backupManagementType)
        {
            BackupManagementType = ConversionUtils.GetPsBackupManagementType(backupManagementType);
        }
    }

    /// <summary>
    /// Class representing backup container context.
    /// </summary>
    public class ContainerContext : ManagementContext
    {
        /// <summary>
        /// Type of the container that maybe managed by the recovery services vault.
        /// </summary>
        public ContainerType ContainerType { get; set; }

        public ContainerContext() { }

        public ContainerContext(ContainerType containerType, string backupManagementType)
            : base(backupManagementType)
        {
            ContainerType = containerType;
        }

        public ContainerContext(string backupManagementType)
            : base(backupManagementType)
        {
            
        }
    }

    /// <summary>
    /// Class representing backup engine context.
    /// </summary>
    public class BackupEngineContext : ManagementContext
    {
        /// <summary>
        /// Type of the backup engine.
        /// </summary>
        public string BackupEngineType { get; set; }

        public BackupEngineContext() { }

        public BackupEngineContext(string backupEngineType, string backupManagementType)
            : base(backupManagementType)
        {
            BackupEngineType = backupEngineType;
        }
    }

    /// <summary>
    /// Base class for backup container.
    /// </summary>
    public class ContainerBase : ContainerContext
    {
        /// <summary>
        /// Name of the container
        /// </summary>
        public string Name { get; set; }

        public ContainerBase(ServiceClientModel.ProtectionContainerResource protectionContainer)
            : base(ConversionUtils.GetPsContainerType(((ServiceClientModel.ProtectionContainer)protectionContainer.Properties).ContainerType),
                   ((ServiceClientModel.ProtectionContainer)protectionContainer.Properties).BackupManagementType)
        {
            Name = IdUtils.GetNameFromUri(protectionContainer.Name);
        }
    }

    /// <summary>
    /// Base class for backup engine.
    /// </summary>
    public class BackupEngineBase : BackupEngineContext
    {
        /// <summary>
        /// Name of the backup engine
        /// </summary>
        public string Name { get; set; }

        public BackupEngineBase(ServiceClientModel.BackupEngineResource backupEngine)
            : base(((ServiceClientModel.BackupEngineBase)backupEngine.Properties).BackupEngineType,
                   ((ServiceClientModel.BackupEngineBase)backupEngine.Properties).BackupManagementType)
        {
            Name = backupEngine.Name;
        }
    }

    /// <summary>
    /// Represents Azure Backup Item Context Class
    /// </summary>
    public class ItemContext : ContainerContext
    {
        /// <summary>
        /// Workload Type of Item
        /// </summary>
        public WorkloadType WorkloadType { get; set; }

        /// <summary>
        /// Unique name of the Container
        /// </summary>
        public string ContainerName { get; set; }

        public ItemContext()
            : base()
        {

        }

        public ItemContext(ServiceClientModel.ProtectedItem protectedItem,
            string containerName, ContainerType containerType)
            : base(containerType, protectedItem.BackupManagementType)
        {
            WorkloadType = ConversionUtils.GetPsWorkloadType(protectedItem.WorkloadType);
            ContainerName = containerName;
        }
    }

    /// <summary>
    /// Represents Azure Backup Item Base Class
    /// </summary>
    public class ItemBase : ItemContext
    {
        /// <summary>
        /// Name of the item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Id of the item
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Latest Recovery Point for the item
        /// </summary>
        public DateTime? LatestRecoveryPoint { get; set; }

        /// <summary>
        /// ARM ID of the resource represented by the item
        /// </summary>
        public string SourceResourceId { get; set; }

        public ItemBase(ServiceClientModel.ProtectedItemResource protectedItemResource,
            string containerName, ContainerType containerType)
            : base((ServiceClientModel.ProtectedItem)protectedItemResource.Properties, containerName, containerType)
        {
            ServiceClientModel.ProtectedItem protectedItem = (ServiceClientModel.ProtectedItem)protectedItemResource.Properties;
            Name = protectedItemResource.Name;
            Id = protectedItemResource.Id;
            LatestRecoveryPoint = protectedItem.LastRecoveryPoint;
            SourceResourceId = protectedItem.SourceResourceId;
        }
    }

    /// <summary>
    /// Represents Azure Backup Item ExtendedInfo Base Class
    /// </summary>
    public class ItemExtendedInfoBase : ObjectBase
    {
    }

    /// <summary>
    /// Base class for recovery point.
    /// </summary>
    public class RecoveryPointBase : ItemContext
    {
        private global::Microsoft.Azure.Management.RecoveryServices.Backup.Models.RecoveryPointResource rp;

        /// <summary>
        /// ID of the recovery point
        /// </summary>
        public string RecoveryPointId { get; set; }

        /// <summary>
        /// Name of the item represented by this recovery point
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Fully qualified ARM ID of this recovery point
        /// </summary>
        public string Id { get; set; }

        public RecoveryPointBase()
            : base()
        {
        }
    }

    /// <summary>
    /// Base class for backup policy.
    /// </summary>
    public class PolicyBase : ManagementContext
    {
        /// <summary>
        /// Name of the policy
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Workload type of the item associated with this policy
        /// </summary>
        public WorkloadType WorkloadType { get; set; }

        /// <summary>
        /// Fully qualified ARM ID of this policy
        /// </summary>
        public string Id { get; set; }

        public override void Validate()
        {
            base.Validate();

            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentException(Resources.PolicyNameIsEmptyOrNull);
            }

            if (string.IsNullOrEmpty(Id))
            {
                throw new ArgumentException(Resources.PolicyIdIsEmptyOrNull);
            }
        }
    }

    /// <summary>
    /// Base class for backup rentention policy.
    /// </summary>
    public class RetentionPolicyBase : ObjectBase
    {      
    }

    /// <summary>
    /// Base class for backup schedule policy.
    /// </summary>
    public class SchedulePolicyBase : ObjectBase
    {      
    }

    /// <summary>
    /// Base class for backup job.
    /// </summary>
    public class JobBase : ManagementContext
    {
        /// <summary>
        /// Activity ID of this job
        /// </summary>
        public string ActivityId { get; set; }

        /// <summary>
        /// ID of this job
        /// </summary>
        public string JobId { get; set; }

        /// <summary>
        /// Operation represented by this job
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// Status of this job
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Name of the workload handled by this job
        /// </summary>
        public string WorkloadName { get; set; }

        /// <summary>
        /// Time at which this job started
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Time at which this job was terminated
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Time taken by this job to run
        /// </summary>
        public TimeSpan Duration { get; set; }       
    }

    /// <summary>
    /// This class contains job error message details.
    /// </summary>
    public class JobErrorInfoBase
    {
        /// <summary>
        /// Description of the error in the backend service
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// List of recommendations to the user, provided by the backend service for this error
        /// </summary>
        public List<string> Recommendations { get; set; }
    }

    /// <summary>
    /// This class contains job sub tasks detail.
    /// </summary>
    public class JobSubTaskBase
    {
        /// <summary>
        /// Name of the sub task
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Status of the sub task
        /// </summary>
        public string Status { get; set; }
    }
}
