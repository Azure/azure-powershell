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

using System.Management.Automation;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.NetApp;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Management.NetApp.Models;
using System;

namespace Microsoft.Azure.Commands.NetAppFiles.VolumeGroup
{   
    [Cmdlet(
        "New",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesVolumeGroup",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesVolumeGroupDetail))]
    [Alias("New-AnfVolumeGroup")]
    public class NewAzureRmNetAppFilesVolumeGroup : AzureNetAppFilesCmdletBase
    {
        public const string SAPHANAOnGENPOPDeploymentSpecID = "20542149-bfca-5618-1879-9863dc6767f1";
        public const string DefaultGroupName = "SAP-HANA";
        public const string DefaultApplicationType = "SAP-HANA";
        public const string DefaultSapSystemId = "SH1";
        public const int DefaultCapacityOverhead = 50;
        private const string DefaultCapacityOverheadHelp = "50"; //do to limitation of current compliler this must be text 
        public const int DefaultStartingHostId = 1;
        private const string DefaultStartingHostIdHelp = "1"; //do to limitation of current compliler this must be text 
        public const int DefaultHostCount = 1;
        private const string DefaultHostCountHelp = "1"; //do to limitation of current compliler this must be text 
        private const string DefaultSubnetName = "Default";
        private readonly string[] DefaultProtocoTypes = new string[] { VolumeProtocolTypes.NSFv41 };

        public const long tebibyte = 1024L * 1024L * 1024L * 1024L;
        public const long gibibyte = 1024L * 1024L * 1024L;
        public const int tbInGi9b = 1024;

        private string poolResourceId = string.Empty;

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The resource group of the ANF VolumeGroup")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The location of the resource")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.NetApp/netAppAccounts/volumegroups")]
        public string Location { get; set; }
        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts",
            nameof(ResourceGroupName))]
        public string AccountName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Default capacity pool for volumes, use a manual QoS type capacity pool")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/capacitypools",
            nameof(ResourceGroupName),
            nameof(CapacityPool))]
        public string PoolName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the ANF VolumeGroup, example SAP-HANA-SH00001. Defaults to SAP-HANA-{HostId}, where the {HostId} pattern in the name will be replaced by a 5 digit host ID that begins at 1 for the Single-host and counts up for the subsequent Multiple-host, host ")]
        [ValidateNotNullOrEmpty]
        [Alias("VolumeGroupName")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/volumegroups",
            nameof(ResourceGroupName),
            nameof(AccountName))]
        [PSArgumentCompleter("SAP-HANA-SH00001")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Group Description, example Primary for SH1-{HostId} (default)")]        
        [ValidateNotNullOrEmpty]        
        public string GroupDescription { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Application Type, default "+ DefaultApplicationType)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("SAP-HANA")]
        [PSDefaultValue(Help = "Default \"SAP-HANA\"", Value = DefaultApplicationType)]
        public string ApplicationType { get; set; } = DefaultApplicationType;

        [Parameter(
            Mandatory = true,
            HelpMessage = "Application specific identifier, default SAP System ID "+ DefaultSapSystemId)]
        [ValidateNotNullOrEmpty]
        [PSDefaultValue(Help = "Default \"SAP-HANA\"", Value = DefaultSapSystemId)]
        public string ApplicationIdentifier { get; set; } = DefaultSapSystemId;

        [Parameter(
            Mandatory = true,
            HelpMessage = "Default proximity placement group, for data, log, and if present the shared volume, in all volume groups. Specifies that the data, log, and shared volumes are to be created close to the VMs")]
        //[ResourceNameCompleter(
        //    "Microsoft.NetApp/netAppAccounts/volumegroups",
        //    nameof(ResourceGroupName),
        //    nameof(ProximityPlacementGroup))]
        public string ProximityPlacementGroup { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "SAP node memory (GiB), Memory on SAP compute host")]
        [ValidateNotNullOrEmpty]
        public int NodeMemory { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Capacity overhead %, Additional quota reserved for snapshots during best-practice sizing of data volume, default " + DefaultCapacityOverheadHelp)]
        [ValidateNotNullOrEmpty]
        [PSDefaultValue(Help = "Default 50%", Value = DefaultCapacityOverhead)]
        [PSArgumentCompleter("50")]
        public int CapacityOverhead { get; set; } = DefaultCapacityOverhead;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Starting SAP HANA Host ID. Host ID 1 indicates Master Host. Shared, Data Backup and Log Backup volumes are only provisioned for Master Host i.e. HostID == 1." + DefaultStartingHostIdHelp)]
        [ValidateNotNullOrEmpty]
        [PSDefaultValue(Help = "Default 1", Value = DefaultStartingHostId)]
        public int StartingHostId { get; set; } = DefaultStartingHostId;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Number of SAP HANA hosts. Total Number of SAP HANA hosts for single or multiplehost scenarios. Defaults to "+DefaultCapacityOverheadHelp+" for single-host setups. Currently at max 3 nodes can be configured.")]
        [PSDefaultValue(Help = "Default 1", Value = DefaultHostCount)]
        public int HostCount { get; set; } = DefaultHostCount;

        [Parameter(            
            Mandatory = false,
            HelpMessage = "The role of the system, Primary SAP system, HANA System Replication(HSR) or DataRecovery destination for ANF Cross-region replication (CRR)")]
        [PSArgumentCompleter("PRIMARY", "HA", "DR")]
        [PSDefaultValue(Help = "Default PRIMARY", Value = SystemRoles.PRIMARY)]
        public string SystemRole { get; set; } = SystemRoles.PRIMARY;

        [Parameter(
            Mandatory = false,
            HelpMessage = "All volume names will be prefixed with the given text. The default values for prefix text depends on system role. For PRIMARY it will be empty and HA it will be \"HA - \"")]
        [ValidateNotNullOrEmpty]
        public string Prefix { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Default virtual network, for all volume groups")]
        public string Vnet { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Default delegated subnet, for all volume groups")]
        [PSDefaultValue(Help = "Default", Value = DefaultSubnetName)]
        public string SubnetId { get; set; } = DefaultSubnetName;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify capacity (in GiB). If ommited DataSize will be autocalculated or specify an integer value representing size.")]
        public long? DataSize { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify throughput in MiB/s. If ommited DataPerformance will be autocalculated or specify and integer value representing throughput.")]
        public int? DataPerformance { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify capacity (in GiB). If ommited LogSize will be autocalculated or specify an integer value representing size.")]
        public long? LogSize { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify throughput in MiB/s. If ommited LogPerformance will be autocalculated or specify and integer value representing throughput.")]
        public int? LogPerformance { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify capacity (in GiB). If ommited SharedSize will be autocalculated or specify an integer value representing size.")]
        public long? SharedSize { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify throughput in MiB/s. If ommited SharedPerformance will be autocalculated or specify and integer value representing throughput.")]
        public int? SharedPerformance { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify capacity (in GiB). If ommited DataSize will be autocalculated or specify an integer value representing size.")]
        public long? DataBackupSize { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify throughput in MiB/s. If ommited DataBackupPerformance will be autocalculated or specify an integer value representing throughput.")]
        public int? DataBackupPerformance { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify capacity (in GiB). If ommited DataSize will be autocalculated or specify an integer value representing size.")]
        public long? LogBackupSize { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify throughput in MiB/s. If ommited LogBackupPerformance will be autocalculated or specify an integer value representing throughput.")]
        public int? LogBackupPerformance { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "HANA System Replication (HSR): Replication between the same SID instance on hosts in the same region, or differerent regions. This could be Scale-Up or Scale-Out configurations.")]
        [PSDefaultValue(Help = "Default true", Value = false)]
        public SwitchParameter HannaSystemReplication { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Create volume groups for DR, using ANF Cross Region Replication, scenario allows volumes to be replicated between different regions using SnapMirror")]
        [PSDefaultValue(Help = "Default false", Value = false)]
        public SwitchParameter DisasterRecoveryDestination { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable array which represents the protocol types for Data Backup/Log Backup volumes default " + VolumeProtocolTypes.NSFv41 + ", for other volume types nfsv4.1 will be used.")]
        [ValidateNotNullOrEmpty]
        [PSDefaultValue(Help = "Default " + VolumeProtocolTypes.NSFv41, Value = VolumeProtocolTypes.NSFv41)]
        [PSArgumentCompleter("NFSv3", "NFSv4.1")]
        public string[] BackupProtocolType { get; set; } = new string[] { VolumeProtocolTypes.NSFv41 };

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable array which represents the export policy, which should be common to all volumes.")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesVolumeExportPolicy ExportPolicy { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Application specific placement rules for the volume group")]
        [ValidateNotNullOrEmpty]
        public IList<PlacementKeyValuePairs> GlobalPlacementRule { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags")]
        [ValidateNotNullOrEmpty]
        [Alias("Tags")]
        public Hashtable Tag { get; set; }

        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The account for the new pool object")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesAccount AccountObject { get; set; }

        public override void ExecuteCmdlet()
        {
            IDictionary<string, string> tagPairs = null;

            if (Tag != null)
            {
                tagPairs = new Dictionary<string, string>();

                foreach (string key in Tag.Keys)
                {
                    tagPairs.Add(key, Tag[key].ToString());
                }
            }
            if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = AccountObject.ResourceGroupName;
                var NameParts = AccountObject.Name.Split('/');
                AccountName = NameParts[0];
            }
            try
            {
                ResourceIdentifier targetResourceInfo = new ResourceIdentifier(this.Vnet);
            }
            catch(ArgumentException) 
            {
                Vnet = $"/subscriptions/{this.AzureNetAppFilesManagementClient.SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Network/virtualNetworks/{this.Vnet}";
            }

            try
            {
                ResourceIdentifier targetResourceInfo = new ResourceIdentifier(this.SubnetId);
            }
            catch(ArgumentException) 
            {
                SubnetId = $"{Vnet}/subnets/{SubnetId}";
            }

            //check existing 
            Management.NetApp.Models.VolumeGroupDetails existingVolumeGroup = null;

            try
            {
                existingVolumeGroup = AzureNetAppFilesManagementClient.VolumeGroups.Get(ResourceGroupName, AccountName, Name);
            }
            catch
            {
                existingVolumeGroup = null;
            }
            if (existingVolumeGroup != null)
            {
                throw new AzPSResourceNotFoundCloudException($"A VolumeGroup with name '{this.Name}' in resource group '{this.ResourceGroupName}' already exists. Please use Update-AzNetAppFilesVolumeGroup to update an existing VolumeGroup.");
            }
            
            //check existing Pool
            Management.NetApp.Models.CapacityPool existingPool = null;
            try
            {
                existingPool = AzureNetAppFilesManagementClient.Pools.Get(ResourceGroupName, AccountName, this.PoolName);
            }
            catch
            {
                existingPool = null;
            }
            if (existingPool == null)
            {
                throw new AzPSResourceNotFoundCloudException($"A Pool with name '{this.PoolName}' in resource group '{this.ResourceGroupName}' does not exist. Please provide PoolName for an existing pool, use New-AzNetAppFilesPool to create a new Capacity Pool if needed.");
            }
            else
            {
                poolResourceId = existingPool.Id;
            }
            var volumeGroup = CreateVolumeGroup(Name, ResourceGroupName, AccountName, poolResourceId, tagPairs);
            if (ShouldProcess(Name, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.CreateResourceMessage, ResourceGroupName)))
            {
                var anfVolumeGroups = AzureNetAppFilesManagementClient.VolumeGroups.Create(volumeGroup, ResourceGroupName, AccountName, Name);
                var ret = anfVolumeGroups.ConvertToPs();
                WriteObject(ret);
            }
        }

        private VolumeGroupDetails CreateVolumeGroup(string name, string reourceGroup, string accountName, string poolResourceId, IDictionary<string, string> tagPairs)
        {
            //var defaultBackupProtocolType = BackupProtocolTypes.NSFv41;
            //var volumeBackupProtocolTypes = BackupProtocolType == null ? defaultBackupProtocolType : BackupProtocolType;
            VolumePropertiesExportPolicy volumeExportPolicy;
            if (ExportPolicy == null)
            {
                volumeExportPolicy = new VolumePropertiesExportPolicy
                {
                    Rules = new List<ExportPolicyRule>()
                    {
                        new ExportPolicyRule { Nfsv3 = false, Nfsv41 = true, RuleIndex = 1, AllowedClients = "0.0.0.0/0", UnixReadOnly = false, UnixReadWrite = true, 
                            Kerberos5ReadOnly = false, Kerberos5iReadOnly = false, Kerberos5iReadWrite = false, Kerberos5pReadOnly = false, 
                            Kerberos5pReadWrite = false, Kerberos5ReadWrite = false
                        }
                    }
                };
            }
            else
            {
                volumeExportPolicy = ModelExtensions.ConvertExportPolicyFromPs(ExportPolicy);
            }

            return CreateHostVolumeGroup(name, ApplicationIdentifier, poolResourceId, tagPairs, BackupProtocolType, volumeExportPolicy, StartingHostId, HostCount);
            
        }

        private VolumeGroupDetails CreateHostVolumeGroup(string name, string sid, string poolResourceId, IDictionary<string, string> tagPairs, string[] volumeBackupProtocolTypes, VolumePropertiesExportPolicy volumeExportPolicy, int startingHostId,  int hostCount)
        {                        
            var dataUsageThreshold = this.DataSize ?? CalulateUsageThreshold(NodeMemory, CapacityOverhead, this.HostCount, null, null, SapVolumeType.Data);
            var logUsageThreshold = this.LogSize ?? CalulateUsageThreshold(NodeMemory, CapacityOverhead, this.HostCount, null, null, SapVolumeType.Log);
            var sharedUsageThreshold = this.SharedSize ?? CalulateUsageThreshold(NodeMemory, CapacityOverhead, this.HostCount, dataUsageThreshold, logUsageThreshold, SapVolumeType.Shared);
            var logBackupdUsageThreshold = this.LogBackupSize ?? CalulateUsageThreshold(NodeMemory, CapacityOverhead, this.HostCount, dataUsageThreshold, logUsageThreshold, SapVolumeType.LogBackup);
            var dataBackupUsageThreshold = this.DataBackupSize ?? CalulateUsageThreshold(NodeMemory, CapacityOverhead, this.HostCount, dataUsageThreshold, logUsageThreshold, SapVolumeType.DataBackup);

            var dataThroughput = this.DataPerformance ?? CalculateThroughput(NodeMemory, SapVolumeType.Data);
            var logThroughput = this.LogPerformance ?? CalculateThroughput(NodeMemory, SapVolumeType.Log);
            var sharedThroughput = this.SharedPerformance ?? CalculateThroughput(NodeMemory, SapVolumeType.Shared);
            var logBackupThroughput = this.LogBackupPerformance ?? CalculateThroughput(NodeMemory, SapVolumeType.LogBackup);
            var dataBackupThroughput = this.DataBackupPerformance ?? CalculateThroughput(NodeMemory, SapVolumeType.DataBackup);

            List<VolumeGroupVolumeProperties> volumesInGroup = new List<VolumeGroupVolumeProperties>();
            for (int i = 0; i < hostCount; i++)
            {
                int currentHostCount = i + 1;
                string dataVolumeName = GenerateVolumeName(ApplicationIdentifier, SapVolumeType.Data, currentHostCount, SystemRole, Prefix);
                string logVolumeName = GenerateVolumeName(ApplicationIdentifier, SapVolumeType.Log, currentHostCount, SystemRole, Prefix);
                string sharedVolumeName = GenerateVolumeName(ApplicationIdentifier, SapVolumeType.Shared, currentHostCount, SystemRole, Prefix);
                string logBackupVolumeName = GenerateVolumeName(ApplicationIdentifier, SapVolumeType.LogBackup, currentHostCount, SystemRole, Prefix);
                string dataBackupVolumeName = GenerateVolumeName(ApplicationIdentifier, SapVolumeType.DataBackup, currentHostCount, SystemRole, Prefix);

                var dataVolume = new VolumeGroupVolumeProperties
                {
                    Name = dataVolumeName,
                    VolumeSpecName = SapVolumeType.Data,
                    CapacityPoolResourceId = poolResourceId,
                    ProximityPlacementGroup = ProximityPlacementGroup,
                    UsageThreshold = dataUsageThreshold,
                    ThroughputMibps = dataThroughput,
                    ProtocolTypes = DefaultProtocoTypes,
                    CreationToken = dataVolumeName,
                    SubnetId = SubnetId,
                    Tags = tagPairs,
                    ExportPolicy = volumeExportPolicy
                };
                volumesInGroup.Add(dataVolume);
                var logVolume = new VolumeGroupVolumeProperties {
                    Name = logVolumeName,
                    VolumeSpecName = SapVolumeType.Log,
                    CapacityPoolResourceId = poolResourceId,
                    ProximityPlacementGroup = ProximityPlacementGroup,
                    ThroughputMibps = logThroughput,
                    UsageThreshold = logUsageThreshold,
                    ProtocolTypes = DefaultProtocoTypes,
                    CreationToken = logVolumeName,
                    SubnetId = SubnetId,
                    Tags = tagPairs,
                    ExportPolicy = volumeExportPolicy
                };
                volumesInGroup.Add(logVolume);
                //Shared, Log backup and Data backup only created for HostID==1.
                if (currentHostCount == 1)
                {
                    var sharedVolume = new VolumeGroupVolumeProperties
                    {
                        Name = sharedVolumeName,
                        VolumeSpecName = SapVolumeType.Shared,
                        CapacityPoolResourceId = poolResourceId,
                        ProximityPlacementGroup = ProximityPlacementGroup,
                        ThroughputMibps = sharedThroughput,
                        UsageThreshold = sharedUsageThreshold,
                        ProtocolTypes = DefaultProtocoTypes,
                        CreationToken = sharedVolumeName,
                        SubnetId = SubnetId,
                        Tags = tagPairs,
                        ExportPolicy = volumeExportPolicy
                    };
                    volumesInGroup.Add(sharedVolume);
                    var logBackupVolume = new VolumeGroupVolumeProperties
                    {
                        Name = logBackupVolumeName,
                        VolumeSpecName = SapVolumeType.LogBackup,
                        CapacityPoolResourceId = poolResourceId,
                        ProximityPlacementGroup = ProximityPlacementGroup,
                        ThroughputMibps = logBackupThroughput,
                        UsageThreshold = logBackupdUsageThreshold,
                        ProtocolTypes = volumeBackupProtocolTypes,
                        CreationToken = logBackupVolumeName,
                        SubnetId = SubnetId,
                        Tags = tagPairs,
                        ExportPolicy = volumeExportPolicy
                    };
                    volumesInGroup.Add(logBackupVolume);
                    var dataBackupVolume = new VolumeGroupVolumeProperties
                    {
                        Name = dataBackupVolumeName,
                        VolumeSpecName = SapVolumeType.DataBackup,
                        CapacityPoolResourceId = poolResourceId,
                        ProximityPlacementGroup = ProximityPlacementGroup,
                        ThroughputMibps = dataBackupThroughput,
                        UsageThreshold = dataBackupUsageThreshold,
                        ProtocolTypes = volumeBackupProtocolTypes,
                        CreationToken = dataBackupVolumeName,
                        SubnetId = SubnetId,
                        Tags = tagPairs,
                        ExportPolicy = volumeExportPolicy
                    };
                    volumesInGroup.Add(dataBackupVolume);
                }
            }
            var volumeGroup = new VolumeGroupDetails()
            {
                Location = Location,                
                GroupMetaData = new VolumeGroupMetaData()
                {
                    ApplicationType = ApplicationType,
                    ApplicationIdentifier = ApplicationIdentifier,
                    GlobalPlacementRules = GlobalPlacementRule,
                    DeploymentSpecId = SAPHANAOnGENPOPDeploymentSpecID,
                    GroupDescription = GroupDescription                    
                },
                Volumes = volumesInGroup
            };            
            return volumeGroup;
        }

        public static string GenerateVolumeName(string sid, string volumeType, int hostCount, string systemRole, string userPrefix)
        {            
            string prefix = sid;
            if (systemRole == SystemRoles.PRIMARY)
            {
                prefix = $"{sid}-";
            }
            else if (systemRole == SystemRoles.HA)
            {
                prefix = $"HA-{sid}-";
            }
            if (!string.IsNullOrWhiteSpace(userPrefix))
            {
                prefix = $"{userPrefix}-{sid}-";
            }
            string postFix = String.Empty;
            if (volumeType == SapVolumeType.Data || volumeType == SapVolumeType.Log)
            {
                postFix = $"-mnt{hostCount.ToString().PadLeft(5, '0')}";
            }
            return $"{prefix}{volumeType}{postFix}";
        }

        public static long CalulateUsageThreshold(int nodeMemory, int capacityOverhead, int numberOfHosts, long? dataSize, long? logSize, string volumeType)
        {
            long size = 0;
            if (volumeType == SapVolumeType.Data)
            {
                size = nodeMemory + (capacityOverhead * nodeMemory);
                size = Math.Max(100*gibibyte, size*gibibyte);
            }
            else if (volumeType == SapVolumeType.Log)
            {
                size = 512;
                if (nodeMemory < 512)
                {
                    size = (int)(0.5 * nodeMemory);
                }
                //Max(100, Min(512, (0.5 * Memory)))
                size = Math.Max(100 * gibibyte, size * gibibyte);
            }
            else if (volumeType == SapVolumeType.Shared)
            {
                size = Math.Max(1000, (numberOfHosts+3) / 4 * nodeMemory);
                //Max(1TB, (int((TotalNumberofSAPHANAHosts + 3) / 4)) * Memory)
                size = Math.Max(1024*gibibyte, size * gibibyte);

            }
            else if (volumeType == SapVolumeType.DataBackup)
            {
                size = Math.Max(100, dataSize.Value/gibibyte + logSize.Value/gibibyte);
                //Max(100, sum(data.size, log.size))
                size = Math.Max(100 * gibibyte, size * gibibyte);
            }
            else if (volumeType == SapVolumeType.LogBackup)
            {
                size = 512*gibibyte;
            }
            return size;
        }

        /// <summary>
        /// Returns throughput in MiB/s
        /// </summary>
        /// <param name="nodeMemory">nodeMemory should be sent in GiB</param>
        /// <param name="volumeType"></param>
        /// <returns></returns>
        public static long CalculateThroughput(int nodeMemory, string volumeType)
        {            
            int throughput = 1500;
            //double nodeMemorytb = nodeMemory / tbInGi9b; //Double.Divide(nodeMemory,tbInGi9b);
            if (volumeType == SapVolumeType.Data)
            {
                if (nodeMemory <= 1024)
                {
                    throughput = 400;
                }
                else if (nodeMemory <= 2048)
                {
                    throughput = 600;
                }
                else if (nodeMemory <= 4096)
                {
                    throughput = 800;
                }
                else if (nodeMemory <= 6144)
                {
                    throughput = 1000;
                }
                else if (nodeMemory <= 8192)
                {
                    throughput = 1200;
                }
                else if (nodeMemory <= 10248)
                {
                    throughput = 1400;
                }
            }
            else if (volumeType == SapVolumeType.Log)
            {
                throughput = 500;
                if (nodeMemory <= 4096)
                {
                    throughput = 250;
                }
            }
            else if (volumeType == SapVolumeType.Shared)
            {
                throughput = 64;
            }
            else if (volumeType == SapVolumeType.DataBackup)
            {
                throughput = 128;
            }
            else if (volumeType == SapVolumeType.LogBackup)
            {
                throughput = 250;
            }
            return throughput;
        }

        public struct SapVolumeType
        {
            public const string Data = "data";
            public const string Log = "log";
            public const string Shared = "shared";
            public const string DataBackup = "data-backup";
            public const string LogBackup = "log-backup";
        }

        public struct SystemRoles
        {
            public const string PRIMARY = "PRIMARY";            
            public const string HA = "HA";
        }

        public struct VolumeProtocolTypes
        {
            public const string NFSv3 =  "NFSv3";
            public const string NSFv41 = "NFSv4.1";
        }
    }
}
