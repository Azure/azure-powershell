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
using System.Collections.Generic;
using System.Collections;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Management.NetApp.Models;
using System;
using Microsoft.Rest.Azure;
using System.Linq;
using System.Data;
using static Microsoft.Azure.Commands.NetAppFiles.VolumeGroup.NewAzureRmNetAppFilesVolumeGroup;

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
        public const string OracleParameterSetName = "ORACLE";
        public const string SAPParameterSetName = "SAP";
        public const string SAPHANAOnGENPOPDeploymentSpecID = "20542149-bfca-5618-1879-9863dc6767f1";
        public const string DefaultGroupName = "SAP-HANA";
        public const string DefaultApplicationType = "SAP-HANA";
        public const string OracleApplicationType = "ORACLE";
        public const string DefaultSapApplicationId = "SH1";
        public const string DefaultOracleApplicationId = "OR1";
        public const string DefaultSapSystemId = "SH1";
        public const string DefaultOracleSystemId = "ORA1";
        public const int DefaultCapacityOverhead = 50;
        public const int DefaultDataVolumes = 2;
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

        private string _applicationIdentifier;
        private string _systemId;
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
        [PSArgumentCompleter("SAP-HANA", "ORACLE")]
        [PSDefaultValue(Help = "Default \"SAP-HANA\"", Value = DefaultApplicationType)]
        public string ApplicationType { get; set; } = DefaultApplicationType;

        [Parameter(
            Mandatory = true,
            HelpMessage = "Application specific identifier, default SAP ApplicationIdentifier " + DefaultSapApplicationId + " , default Oracle ApplicationIdentifier " + DefaultOracleApplicationId)]
        [ValidateNotNullOrEmpty]        
        public string ApplicationIdentifier 
        {
            get => _applicationIdentifier ?? (ApplicationType == DefaultApplicationType ? DefaultSapApplicationId : DefaultOracleApplicationId);
            set => _applicationIdentifier = value;
        }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Unique Oracle system ID, default SAP System ID " + DefaultSapSystemId + " , default Oracle System Id (OID)" + DefaultOracleSystemId)]
        [ValidateNotNullOrEmpty]
        public string SystemId
        {
            get => _systemId?? (ApplicationType == DefaultApplicationType ? DefaultSapSystemId : DefaultOracleSystemId);
            set => _systemId = value;
        }


        [Parameter(
            Mandatory = false,
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
            HelpMessage = "The role of the system, Primary SAP system, HANA System Replication(HSR) or DataRecovery destination for ANF Cross-region replication (CRR). Oracle Primary or DR (DataRecovery) destination for ANF Cross-region replication (CRR)")]
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
            HelpMessage = "The resource id of the source volume. Used for Oracle DataProtection volumes.",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string DataReplicationSourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Replication schedule for data2 volume. Used for Oracle DataProtection volumes.",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("_10minutely", "hourly", "daily")]
        public string DataReplicationSchedule { get; set; }

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
            HelpMessage = "The resource id of the log source volume. Used for DataProtection volumes.",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string LogReplicationSourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Replication schedule for log volume. Used for DataProtection volumes.",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("_10minutely", "hourly", "daily")]
        public string LogReplicationSchedule { get; set; }

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
            HelpMessage = "The resource id of the shared volume. Used for DataProtection volumes.",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string SharedReplicationSourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Replication schedule for shared volume. Used for DataProtection volumes.",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("_10minutely", "hourly", "daily")]
        public string SharedReplicationSchedule { get; set; }

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
            HelpMessage = "The resource id of the DataBackup volume. Used for DataProtection volumes.",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string DataBackupReplicationSourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Replication schedule for DataBackup volume. Used for DataProtection volumes.",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("_10minutely", "hourly", "daily")]
        public string DataBackupReplicationSchedule { get; set; }

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
            HelpMessage = "The resource id of the LogBackup volume. Used for DataProtection volumes.",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string LogBackupReplicationSourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Replication schedule for LogBackup volume. Used for DataProtection volumes.",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("_10minutely", "hourly", "daily")]
        public string LogBackupReplicationSchedule { get; set; }

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
            HelpMessage = "Source of key used to encrypt data in volume. Applicable if NetApp account has encryption.keySource = 'Microsoft.KeyVault'. Possible values are: 'Microsoft.NetApp, Microsoft.KeyVault'. To create a volume using customer-managed keys use 'Microsoft.KeyVault' note then you must set -NetworkFeature to Standard.")]
        [PSArgumentCompleter("Microsoft.NetApp", "Microsoft.KeyVault")]
        public string EncryptionKeySource { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Basic network, or Standard features available to the volume (Basic, Standard).")]
        [PSArgumentCompleter("Basic", "Standard")]
        public string NetworkFeature { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource ID of private endpoint for KeyVault. It must reside in the same VNET as the volume. Only applicable if encryptionKeySource = 'Microsoft.KeyVault'")]
        public string KeyVaultPrivateEndpointResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A list of Availability Zones")]
        public string[] Zone { get; set; }


        #region oracle specific

        [Parameter(
            Mandatory = false,
            HelpMessage = "Total size of the Oracle Data Base (TiB). For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName)]        
        public int? OracleDatabaseSize { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "How many data volume to create. Can have a minimum of 2 up to 8 data volumes. Defaults to 2. For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName)]
        [ValidateRange(2, 8)]
        public int? NumberOfDataVolume { get; set; } = 2;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify the total throughput required for your database. If you select more than one database volume, the throughput is distributed evenly among all volumes. You can change each individual volume, using the DataSize(no) DataPerformance(no) properties provided. For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName)]
        public int? OracleDatabaseThroughput { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify capacity (in GiB). If ommited a DataSize size for disk 2 will be autocalculated or specify an integer value representing size.For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName )]
        public long? DataSize2 { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify throughput in MiB/s. If ommited DataPerformance for disk 2 will be autocalculated or specify and integer value representing throughput. For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName)]
        public int? Data2Performance { get; set; }

        [Parameter(            
            Mandatory = false,
            HelpMessage = "The resource id of the source volume. Used to override DataSourceId. Used for Oracle DataProtection volumes.",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string Data2ReplicationSourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Replication schedule for data2 volume. Used to override DataReplicationSchedule. Used for Oracle DataProtection volumes.",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("_10minutely", "hourly", "daily")]
        public string Data2ReplicationSchedule { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify capacity (in GiB). If ommited DataSize for disk 3 will be autocalculated or specify an integer value representing size. If NumberOfDataVolume is less than 3 this will be ignored. For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName)]
        public long? DataSize3 { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify throughput in MiB/s. If ommited DataPerformance for disk 3 will be autocalculated or specify and integer value representing throughput. For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName)]
        public int? Data3Performance { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource id of the source volume. Used for Oracle DataProtection volumes (SystemRole = DR).",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string Data3ReplicationSourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Replication schedule for data3 volume. Used to override DataReplicationSchedule. Used for Oracle DataProtection volumes (SystemRole = DR).",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("_10minutely", "hourly", "daily")]
        public string Data3ReplicationSchedule { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify capacity (in GiB). If ommited DataSize for disk 4 will be autocalculated or specify an integer value representing size. If NumberOfDataVolume is less than 4 this will be ignored. For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName)]
        public long? Data4Size { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify throughput in MiB/s. If ommited DataPerformance for disk 4 will be autocalculated or specify and integer value representing throughput. For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName)]
        public int? Data4Performance { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource id of the source volume. Used for Oracle DataProtection volumes (SystemRole = DR).",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string Data4ReplicationSourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Replication schedule for data4 volume. Used to override DataReplicationSchedule. Used for Oracle DataProtection volumes (SystemRole = DR).",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("_10minutely", "hourly", "daily")]
        public string Data4ReplicationSchedule { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify capacity (in GiB). If ommited DataSize for disk 5 will be autocalculated or specify an integer value representing size.If NumberOfDataVolume is less than 5 this will be ignored. For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName)]
        public long? Data5Size { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify throughput in MiB/s. If ommited DataPerformance for disk 5 will be autocalculated or specify and integer value representing throughput. For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName)]
        public int? Data5Performance { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource id of the source volume. Used for Oracle DataProtection volumes (SystemRole = DR).",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string Data5ReplicationSourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Replication schedule for data5 volume. Used to override DataReplicationSchedule. Used for Oracle DataProtection volumes (SystemRole = DR).",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("_10minutely", "hourly", "daily")]
        public string Data5ReplicationSchedule { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify capacity (in GiB). If ommited DataSize for disk 6 will be autocalculated or specify an integer value representing size. If NumberOfDataVolume is less than 6 this will be ignored. For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName)]
        public long? Data6Size { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify throughput in MiB/s. If ommited DataPerformance for disk 6 will be autocalculated or specify and integer value representing throughput. For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName)]
        public int? Data6Performance { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource id of the source volume. Used for Oracle DataProtection volumes (SystemRole = DR).",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string Data6ReplicationSourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Replication schedule for data6 volume. Used to override DataReplicationSchedule. Used for Oracle DataProtection volumes (SystemRole = DR).",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("_10minutely", "hourly", "daily")]
        public string Data6ReplicationSchedule { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify capacity (in GiB). If ommited DataSize for disk 7 will be autocalculated or specify an integer value representing size. If NumberOfDataVolume is less than 7 this will be ignored. For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName)]
        public long? Data7Size { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify throughput in MiB/s. If ommited DataPerformance for disk 7 will be autocalculated or specify and integer value representing throughput. For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName
            )]
        public int? Data7Performance { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource id of the source volume. Used for Oracle DataProtection volumes (SystemRole = DR).",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string Data7ReplicationSourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Replication schedule for data7 volume. Used to override DataReplicationSchedule. Used for Oracle DataProtection volumes (SystemRole = DR).",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("_10minutely", "hourly", "daily")]
        public string Data7ReplicationSchedule { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify capacity (in GiB). If ommited DataSize for disk 8 will be autocalculated or specify an integer value representing size.If NumberOfDataVolume is less than 8 this will be ignored. For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName)]
        public long? DataSize8 { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify throughput in MiB/s. If ommited DataPerformance for disk 8 will be autocalculated or specify and integer value representing throughput. For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName)]
        public int? DataPerformance8 { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource id of the source volume. Used for Oracle DataProtection volumes (SystemRole = DR).",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string Data8ReplicationSourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Replication schedule for data8 volume. Used to override DataReplicationSchedule. Used for Oracle DataProtection volumes (SystemRole = DR).",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("_10minutely", "hourly", "daily")]
        public string Data8ReplicationSchedule { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify capacity (in GiB). If ommited Size for BinarySize will be autocalculated or specify an integer value representing size.For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName)]
        public long? BinarySize { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify throughput in MiB/s. If ommited BinaryPerformance will be autocalculated or specify and integer value representing throughput. For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName)]
        public int? BinaryPerformance { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource id of the source volume. Used for Oracle DataProtection volumes (SystemRole = DR).",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string BinaryReplicationSourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Replication schedule for data3 volume. Used to override DataReplicationSchedule. Used for Oracle DataProtection volumes (SystemRole = DR).",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("_10minutely", "hourly", "daily")]
        public string BinaryReplicationSchedule { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify capacity (in GiB). If ommited Size for BackupSize will be autocalculated or specify an integer value representing size.For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName)]
        public long? BackupSize { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify throughput in MiB/s. If ommited BackupPerformance will be autocalculated or specify and integer value representing throughput. For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName)]
        public int? BackupPerformance { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource id of the Backup source volume. Used for Oracle DataProtection volumes (SystemRole = DR).",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string BackupReplicationSourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Replication schedule for Backup volume. Used to override DataReplicationSchedule. Used for Oracle DataProtection volumes (SystemRole = DR).",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("_10minutely", "hourly", "daily")]
        public string BackupReplicationSchedule { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify capacity (in GiB). If ommited Size for LogMirrorSize will be autocalculated or specify an integer value representing size.For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName)]
        public long? LogMirrorSize { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specify throughput in MiB/s. If ommited LogMirrorPerformance will be autocalculated or specify and integer value representing throughput. For Oracle Application Volume Groups only",
            ParameterSetName = OracleParameterSetName)]
        public int? LogMirrorPerformance { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource id of the source volume. Used for Oracle DataProtection volumes (SystemRole = DR).",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string LogMirrorReplicationSourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Replication schedule for data3 volume. Used for Oracle DataProtection volumes (SystemRole = DR).",
            ParameterSetName = OracleParameterSetName)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("_10minutely", "hourly", "daily")]
        public string LogMirrorReplicationSchedule { get; set; }

        #endregion

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
            catch (ArgumentException)
            {
                Vnet = $"/subscriptions/{this.AzureNetAppFilesManagementClient.SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Network/virtualNetworks/{this.Vnet}";
            }

            try
            {
                ResourceIdentifier targetResourceInfo = new ResourceIdentifier(this.SubnetId);
            }
            catch (ArgumentException)
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
                try
                {
                    var anfVolumeGroups = AzureNetAppFilesManagementClient.VolumeGroups.Create(ResourceGroupName, AccountName, Name, volumeGroup);
                    var ret = anfVolumeGroups.ConvertToPs();
                    WriteObject(ret);
                }
                catch (ErrorResponseException ex)
                {
                    throw new CloudException(ex.Body.Error.Message, ex);
                }
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
                            Kerberos5ReadOnly = false, Kerberos5IReadOnly = false, Kerberos5IReadWrite = false, Kerberos5PReadOnly = false, 
                            Kerberos5PReadWrite = false, Kerberos5ReadWrite = false
                        }
                    }
                };
            }
            else
            {
                volumeExportPolicy = ModelExtensions.ConvertExportPolicyFromPs(ExportPolicy);
            }

            if (ApplicationType == OracleApplicationType)
            {
                return CreateOracleVolumeGroup(name, ApplicationIdentifier, poolResourceId, tagPairs, BackupProtocolType, volumeExportPolicy, OracleDatabaseSize, OracleDatabaseThroughput, NumberOfDataVolume, CapacityOverhead, SystemRole);
            }
            else
            {
                return CreateHostVolumeGroup(name, ApplicationIdentifier, poolResourceId, tagPairs, BackupProtocolType, volumeExportPolicy, StartingHostId, HostCount, SystemRole);
            }            
        }
        
        private VolumeGroupDetails CreateHostVolumeGroup(string name, string sid, string poolResourceId, IDictionary<string, string> tagPairs, string[] volumeBackupProtocolTypes, VolumePropertiesExportPolicy volumeExportPolicy, int startingHostId,  int hostCount, string systemRole)
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
            var zoneList = this.Zone?.ToList();

            List<VolumeGroupVolumeProperties> volumesInGroup = new List<VolumeGroupVolumeProperties>();
            for (int i = 0; i < hostCount; i++)
            {
                int currentHostCount = i + 1;
                string dataVolumeName = GenerateVolumeName(ApplicationIdentifier, SystemId, SapVolumeType.Data, currentHostCount, SystemRole, Prefix);
                string logVolumeName = GenerateVolumeName(ApplicationIdentifier, SystemId, SapVolumeType.Log, currentHostCount, SystemRole, Prefix);
                string sharedVolumeName = GenerateVolumeName(ApplicationIdentifier, SystemId, SapVolumeType.Shared, currentHostCount, SystemRole, Prefix);
                string logBackupVolumeName = GenerateVolumeName(ApplicationIdentifier, SystemId, SapVolumeType.LogBackup, currentHostCount, SystemRole, Prefix);
                string dataBackupVolumeName = GenerateVolumeName(ApplicationIdentifier, SystemId, SapVolumeType.DataBackup, currentHostCount, SystemRole, Prefix);

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
                    ExportPolicy = volumeExportPolicy,
                    Zones = zoneList,
                    KeyVaultPrivateEndpointResourceId = this.KeyVaultPrivateEndpointResourceId,
                    EncryptionKeySource = this.EncryptionKeySource,
                    NetworkFeatures = this.NetworkFeature
                };
                if (systemRole == SystemRoles.DR)
                {
                    VolumePropertiesDataProtection dpData = new VolumePropertiesDataProtection
                    {
                        Replication = new ReplicationObject(remoteVolumeResourceId: this.DataReplicationSourceId, replicationSchedule: this.DataReplicationSchedule)
                    };
                    dataVolume.DataProtection = dpData;
                }
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
                    ExportPolicy = volumeExportPolicy,
                    Zones = zoneList,
                    KeyVaultPrivateEndpointResourceId = this.KeyVaultPrivateEndpointResourceId,
                    EncryptionKeySource = this.EncryptionKeySource,
                    NetworkFeatures = this.NetworkFeature
                };
                if (systemRole == SystemRoles.DR)
                {
                    VolumePropertiesDataProtection dpLog = new VolumePropertiesDataProtection
                    {
                        Replication = new ReplicationObject(remoteVolumeResourceId: this.LogReplicationSourceId, replicationSchedule: this.LogReplicationSchedule)
                    };
                    logVolume.DataProtection = dpLog;
                }
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
                        ExportPolicy = volumeExportPolicy,
                        Zones = zoneList,
                        KeyVaultPrivateEndpointResourceId = this.KeyVaultPrivateEndpointResourceId,
                        EncryptionKeySource = this.EncryptionKeySource,
                        NetworkFeatures = this.NetworkFeature
                    };
                    if (this.Zone != null)
                    {
                        sharedVolume.Zones = this.Zone?.ToList();
                    }
                    if (systemRole == SystemRoles.DR)
                    {
                        VolumePropertiesDataProtection dpShared = new VolumePropertiesDataProtection
                        {
                            Replication = new ReplicationObject(remoteVolumeResourceId: this.SharedReplicationSourceId, replicationSchedule: this.SharedReplicationSchedule)
                        };
                        sharedVolume.DataProtection = dpShared;
                    }
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
                        ExportPolicy = volumeExportPolicy,
                        Zones = zoneList,
                        KeyVaultPrivateEndpointResourceId = this.KeyVaultPrivateEndpointResourceId,
                        EncryptionKeySource = this.EncryptionKeySource,
                        NetworkFeatures = this.NetworkFeature
                    };
                    if (this.Zone != null)
                    {
                        logBackupVolume.Zones = this.Zone?.ToList();
                    }
                    if (systemRole == SystemRoles.DR)
                    {
                        VolumePropertiesDataProtection dpLogBackup = new VolumePropertiesDataProtection
                        {
                            Replication = new ReplicationObject(remoteVolumeResourceId: this.DataReplicationSourceId, replicationSchedule: this.DataReplicationSchedule)
                        };
                        logBackupVolume.DataProtection = dpLogBackup;
                    }
                    if (systemRole == SystemRoles.DR)
                    {
                        VolumePropertiesDataProtection dpLogBackup = new VolumePropertiesDataProtection
                        {
                            Replication = new ReplicationObject(remoteVolumeResourceId: this.DataReplicationSourceId, replicationSchedule: this.DataReplicationSchedule)
                        };
                        logBackupVolume.DataProtection = dpLogBackup;
                    }
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
                        ExportPolicy = volumeExportPolicy,
                        Zones = zoneList,
                        KeyVaultPrivateEndpointResourceId = this.KeyVaultPrivateEndpointResourceId,
                        EncryptionKeySource = this.EncryptionKeySource,
                        NetworkFeatures = this.NetworkFeature
                    };
                    if (this.Zone != null)
                    {
                        dataBackupVolume.Zones = this.Zone?.ToList();
                    }
                    if (systemRole == SystemRoles.DR)
                    {
                        VolumePropertiesDataProtection dpBackup = new VolumePropertiesDataProtection
                        {
                            Replication = new ReplicationObject(remoteVolumeResourceId: this.DataReplicationSourceId, replicationSchedule: this.DataReplicationSchedule)
                        };
                        dataBackupVolume.DataProtection = dpBackup;
                    }
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
                    //DeploymentSpecId = SAPHANAOnGENPOPDeploymentSpecID,
                    GroupDescription = GroupDescription                    
                },
                Volumes = volumesInGroup
            };
            return volumeGroup;
        }

        public static string GenerateVolumeName(string applicationIdentifier, string sid, string volumeType, int hostCount, string systemRole, string userPrefix)
        {            
            string prefix = string.IsNullOrWhiteSpace(sid) ? applicationIdentifier: sid ;
            if (systemRole == SystemRoles.PRIMARY)
            {
                prefix = $"{prefix}-";
            }
            else if (systemRole == SystemRoles.HA)
            {
                prefix = $"HA-{prefix}-";
            }
            if (!string.IsNullOrWhiteSpace(userPrefix))
            {
                prefix = $"{userPrefix}-{prefix}-";
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

        private VolumeGroupDetails CreateOracleVolumeGroup(string name, string sid, string poolResourceId, IDictionary<string, string> tagPairs, string[] volumeBackupProtocolTypes, VolumePropertiesExportPolicy volumeExportPolicy, int? oracleDatabaseSize, int? oracleDatabaseThroughput, int? NumberOfDataVolume, int? capacityOverhead, string systemRole)
        {
            int snapshotCapacityOverhead = capacityOverhead ?? 0;
            var dataUsageThreshold = this.DataSize ?? CalulateOracleUsageThreshold(oracleDatabaseSize.Value, NumberOfDataVolume.Value, snapshotCapacityOverhead, OracleVolumeType.Data);
            var logUsageThreshold = this.LogSize ?? CalulateOracleUsageThreshold(oracleDatabaseSize.Value, NumberOfDataVolume.Value, snapshotCapacityOverhead, OracleVolumeType.Log);
            var binaryUsageThreshold = this.BinarySize ?? CalulateOracleUsageThreshold(oracleDatabaseSize.Value, NumberOfDataVolume.Value, snapshotCapacityOverhead, OracleVolumeType.Binary);
            var logMirrorUsageThreshold = this.LogMirrorPerformance ?? CalulateOracleUsageThreshold(oracleDatabaseSize.Value, NumberOfDataVolume.Value, snapshotCapacityOverhead, OracleVolumeType.LogMirror);
            var backupUsageThreshold = this.DataBackupSize ?? CalulateOracleUsageThreshold(oracleDatabaseSize.Value, NumberOfDataVolume.Value, snapshotCapacityOverhead, OracleVolumeType.Backup);

            var dataThroughput = this.DataPerformance ?? CalculateOracleThroughput(oracleDatabaseThroughput.Value, NumberOfDataVolume.Value, OracleVolumeType.Data);
            var logThroughput = this.LogPerformance ?? CalculateOracleThroughput(oracleDatabaseThroughput.Value, NumberOfDataVolume.Value, OracleVolumeType.Log);
            var binaryThroughput = this.SharedPerformance ?? CalculateOracleThroughput(oracleDatabaseThroughput.Value, NumberOfDataVolume.Value, OracleVolumeType.Binary);
            var logMirrorThroughput = this.LogBackupPerformance ?? CalculateOracleThroughput(oracleDatabaseThroughput.Value, NumberOfDataVolume.Value, OracleVolumeType.LogMirror);
            var backupThroughput = this.DataBackupPerformance ?? CalculateOracleThroughput(oracleDatabaseThroughput.Value, NumberOfDataVolume.Value, OracleVolumeType.Backup);
            var zoneList = this.Zone?.ToList();

            List<VolumeGroupVolumeProperties> volumesInGroup = new List<VolumeGroupVolumeProperties>();
            for (int i = 0; i < NumberOfDataVolume; i++)
            {
                int currentHostCount = i + 1;
                string dataVolumeName = GenerateOracleVolumeName(ApplicationIdentifier, SystemId, OracleVolumeType.Data, currentHostCount, systemRole);
                var dataVolume = new VolumeGroupVolumeProperties
                {
                    Name = dataVolumeName,
                    VolumeSpecName = OracleVolumeType.Data,
                    CapacityPoolResourceId = poolResourceId,
                    ProximityPlacementGroup = ProximityPlacementGroup,
                    UsageThreshold = dataUsageThreshold,
                    ThroughputMibps = dataThroughput,
                    ProtocolTypes = DefaultProtocoTypes,
                    CreationToken = dataVolumeName,
                    SubnetId = SubnetId,
                    Tags = tagPairs,
                    ExportPolicy = volumeExportPolicy,
                    Zones = zoneList,
                    KeyVaultPrivateEndpointResourceId = this.KeyVaultPrivateEndpointResourceId,
                    EncryptionKeySource = this.EncryptionKeySource,
                    NetworkFeatures = this.NetworkFeature
                };
                if (systemRole == SystemRoles.DR)
                {                    
                    VolumePropertiesDataProtection dp = new VolumePropertiesDataProtection
                    {
                        Replication = GetReplicationObject(currentHostCount, OracleVolumeType.Data)
                    };
                    dataVolume.DataProtection = dp;
                }
                volumesInGroup.Add(dataVolume);
            }
            string logVolumeName = GenerateOracleVolumeName(ApplicationIdentifier, SystemId, OracleVolumeType.Log, 0);
            string binaryVolumeName = GenerateOracleVolumeName(ApplicationIdentifier, SystemId, OracleVolumeType.Binary, 0);
            string logMirrorVolumeName = GenerateOracleVolumeName(ApplicationIdentifier, SystemId,OracleVolumeType.LogMirror, 0);
            string backupVolumeName = GenerateOracleVolumeName(ApplicationIdentifier, SystemId, OracleVolumeType.Backup, 0);

            
            var logVolume = new VolumeGroupVolumeProperties
            {
                Name = logVolumeName,
                VolumeSpecName = OracleVolumeType.Log,
                CapacityPoolResourceId = poolResourceId,
                ProximityPlacementGroup = ProximityPlacementGroup,
                ThroughputMibps = logThroughput,
                UsageThreshold = logUsageThreshold,
                ProtocolTypes = DefaultProtocoTypes,
                CreationToken = logVolumeName,
                SubnetId = SubnetId,
                Tags = tagPairs,
                ExportPolicy = volumeExportPolicy,
                Zones = zoneList,
                KeyVaultPrivateEndpointResourceId = this.KeyVaultPrivateEndpointResourceId,
                EncryptionKeySource = this.EncryptionKeySource,
                NetworkFeatures = this.NetworkFeature
            };
            if (systemRole == SystemRoles.DR)
            {
                VolumePropertiesDataProtection dpLog = new VolumePropertiesDataProtection
                {
                    Replication = GetReplicationObject(0, OracleVolumeType.Log)
                };
                logVolume.DataProtection = dpLog;
            }
            volumesInGroup.Add(logVolume);

            var binaryVolume = new VolumeGroupVolumeProperties
            {
                Name = binaryVolumeName,
                VolumeSpecName = OracleVolumeType.Binary,
                CapacityPoolResourceId = poolResourceId,
                ProximityPlacementGroup = ProximityPlacementGroup,
                ThroughputMibps = binaryThroughput,
                UsageThreshold = binaryUsageThreshold,
                ProtocolTypes = DefaultProtocoTypes,
                CreationToken = binaryVolumeName,
                SubnetId = SubnetId,
                Tags = tagPairs,
                ExportPolicy = volumeExportPolicy,
                Zones = zoneList,
                KeyVaultPrivateEndpointResourceId = this.KeyVaultPrivateEndpointResourceId,
                EncryptionKeySource = this.EncryptionKeySource,
                NetworkFeatures = this.NetworkFeature
            };
            if (this.Zone != null)
            {
                binaryVolume.Zones = zoneList;
            }
            if (systemRole == SystemRoles.DR)
            {
                VolumePropertiesDataProtection dpBinary = new VolumePropertiesDataProtection
                {
                    Replication = GetReplicationObject(0, OracleVolumeType.Binary)
                };
                binaryVolume.DataProtection = dpBinary;
            }
            volumesInGroup.Add(binaryVolume);

            var logMirrorVolume = new VolumeGroupVolumeProperties
            {
                Name = logMirrorVolumeName,
                VolumeSpecName = OracleVolumeType.LogMirror,
                CapacityPoolResourceId = poolResourceId,
                ProximityPlacementGroup = ProximityPlacementGroup,
                ThroughputMibps = logMirrorThroughput,
                UsageThreshold = logMirrorUsageThreshold,
                ProtocolTypes = volumeBackupProtocolTypes,
                CreationToken = logMirrorVolumeName,
                SubnetId = SubnetId,
                Tags = tagPairs,
                ExportPolicy = volumeExportPolicy,
                Zones = zoneList,
                KeyVaultPrivateEndpointResourceId = this.KeyVaultPrivateEndpointResourceId,
                EncryptionKeySource = this.EncryptionKeySource,
                NetworkFeatures = this.NetworkFeature
            };
            if (this.Zone != null)
            {
                logMirrorVolume.Zones = this.Zone?.ToList();
            }
            if (systemRole == SystemRoles.DR)
            {
                VolumePropertiesDataProtection dpLogMirror = new VolumePropertiesDataProtection
                {
                    Replication = GetReplicationObject(0, OracleVolumeType.LogMirror)
                };
                logMirrorVolume.DataProtection = dpLogMirror;
            }
            volumesInGroup.Add(logMirrorVolume);

            var dataBackupVolume = new VolumeGroupVolumeProperties
            {
                Name = backupVolumeName,
                VolumeSpecName = OracleVolumeType.Backup,
                CapacityPoolResourceId = poolResourceId,
                ProximityPlacementGroup = ProximityPlacementGroup,
                ThroughputMibps = backupThroughput,
                UsageThreshold = backupUsageThreshold,
                ProtocolTypes = volumeBackupProtocolTypes,
                CreationToken = backupVolumeName,
                SubnetId = SubnetId,
                Tags = tagPairs,
                ExportPolicy = volumeExportPolicy,
                Zones = zoneList,
                KeyVaultPrivateEndpointResourceId = this.KeyVaultPrivateEndpointResourceId,
                EncryptionKeySource = this.EncryptionKeySource,
                NetworkFeatures = this.NetworkFeature
            };
            if (this.Zone != null)
            {
                dataBackupVolume.Zones = this.Zone?.ToList();
            }
            if (systemRole == SystemRoles.DR)
            {
                VolumePropertiesDataProtection dpBackup = new VolumePropertiesDataProtection
                {
                    Replication = GetReplicationObject(0, OracleVolumeType.Backup)
                };
                dataBackupVolume.DataProtection = dpBackup;
            }
            volumesInGroup.Add(dataBackupVolume);
            var volumeGroup = new VolumeGroupDetails()
            {
                Location = Location,
                GroupMetaData = new VolumeGroupMetaData()
                {
                    ApplicationType = ApplicationType,
                    ApplicationIdentifier = ApplicationIdentifier,
                    GlobalPlacementRules = GlobalPlacementRule,
                    GroupDescription = GroupDescription
                },
                Volumes = volumesInGroup
            };
            return volumeGroup;
        }

        public ReplicationObject GetReplicationObject(int currentHostCount, string volumeType)
        {
            ReplicationObject replciationObject = new ReplicationObject();
            if (volumeType == OracleVolumeType.Data)
            {                
                switch (currentHostCount)
                {
                    case 1:
                        replciationObject.RemoteVolumeResourceId = this.DataReplicationSourceId != null ? this.DataReplicationSourceId : this.DataReplicationSourceId;
                        replciationObject.ReplicationSchedule = this.Data2ReplicationSchedule != null ? this.Data2ReplicationSchedule : this.DataReplicationSchedule;
                        break;
                    case 2:
                        replciationObject.RemoteVolumeResourceId = this.Data2ReplicationSourceId;
                        replciationObject.ReplicationSchedule = this.Data2ReplicationSchedule != null ? this.Data2ReplicationSchedule : this.DataReplicationSchedule;
                        break;
                    case 3:
                        replciationObject.RemoteVolumeResourceId = this.Data3ReplicationSourceId;
                        replciationObject.ReplicationSchedule = this.Data3ReplicationSchedule != null ? this.Data3ReplicationSchedule : this.DataReplicationSchedule;
                        break;
                    case 4:
                        replciationObject.RemoteVolumeResourceId = this.Data4ReplicationSourceId;
                        replciationObject.ReplicationSchedule = this.Data4ReplicationSchedule != null ? this.Data4ReplicationSchedule : this.DataReplicationSchedule;
                        break;
                    case 5:
                        replciationObject.RemoteVolumeResourceId = this.Data5ReplicationSourceId;
                        replciationObject.ReplicationSchedule = this.Data5ReplicationSchedule != null ? this.Data5ReplicationSchedule : this.DataReplicationSchedule;
                        break;
                    case 6:
                        replciationObject.RemoteVolumeResourceId = this.Data6ReplicationSourceId;
                        replciationObject.ReplicationSchedule = this.Data6ReplicationSchedule != null ? this.Data6ReplicationSchedule : this.DataReplicationSchedule;
                        break;
                    case 7:
                        replciationObject.RemoteVolumeResourceId = this.Data7ReplicationSourceId;
                        replciationObject.ReplicationSchedule = this.Data7ReplicationSchedule != null ? this.Data7ReplicationSchedule : this.DataReplicationSchedule;
                        break;
                    case 8:
                        replciationObject.RemoteVolumeResourceId = this.Data8ReplicationSourceId;
                        replciationObject.ReplicationSchedule = this.Data8ReplicationSchedule != null ? this.Data8ReplicationSchedule : this.DataReplicationSchedule;
                        break;
                    default:
                        break;
                }
            }
            else if (volumeType == OracleVolumeType.Log)
            {
                replciationObject.RemoteVolumeResourceId = this.LogReplicationSourceId;
                replciationObject.ReplicationSchedule = this.LogReplicationSchedule != null ? this.LogReplicationSchedule : this.DataReplicationSchedule;
            }
            else if (volumeType == OracleVolumeType.LogMirror)
            {
                replciationObject.RemoteVolumeResourceId = this.LogMirrorReplicationSourceId;
                replciationObject.ReplicationSchedule = this.LogMirrorReplicationSchedule != null ? this.LogMirrorReplicationSchedule : this.DataReplicationSchedule;
            }
            else if (volumeType == OracleVolumeType.Binary)
            {
                replciationObject.RemoteVolumeResourceId = this.BinaryReplicationSourceId;
                replciationObject.ReplicationSchedule = this.BinaryReplicationSchedule != null ? this.BinaryReplicationSchedule : this.DataReplicationSchedule;
            }
            else if (volumeType == OracleVolumeType.Backup)
            {
                replciationObject.RemoteVolumeResourceId = this.BackupReplicationSourceId;
                replciationObject.ReplicationSchedule = this.BackupReplicationSchedule != null ? this.BackupReplicationSchedule : this.DataReplicationSchedule;
            }
            else if (volumeType == SapVolumeType.Shared)
            {
                replciationObject.RemoteVolumeResourceId = this.SharedReplicationSourceId;
                replciationObject.ReplicationSchedule = this.SharedReplicationSchedule != null ? this.SharedReplicationSchedule : this.DataReplicationSchedule;
            }
            else if (volumeType == SapVolumeType.DataBackup)
            {
                replciationObject.RemoteVolumeResourceId = this.DataBackupReplicationSourceId;
                replciationObject.ReplicationSchedule = this.DataBackupReplicationSchedule != null ? this.DataBackupReplicationSchedule : this.DataReplicationSchedule;
            }
            else if (volumeType == SapVolumeType.LogBackup)
            {
                replciationObject.RemoteVolumeResourceId = this.LogBackupReplicationSourceId;
                replciationObject.ReplicationSchedule = this.LogBackupReplicationSchedule != null ? this.LogBackupReplicationSchedule : this.DataReplicationSchedule;
            }
            else if (volumeType == SapVolumeType.Log)
            {
                replciationObject.RemoteVolumeResourceId = this.LogReplicationSourceId;
                replciationObject.ReplicationSchedule = this.LogReplicationSchedule != null ? this.LogReplicationSchedule : this.DataReplicationSchedule;
            }
            else
            {
                replciationObject.RemoteVolumeResourceId = this.DataReplicationSourceId;
                replciationObject.ReplicationSchedule = this.DataReplicationSchedule;
            }
            return replciationObject;
        }
            
        public static long CalulateOracleUsageThreshold(int oracleDatabaseSize, int NumberOfDataVolume, int snapshotReserveOverhead, string volumeType)
        {
            long size = 0;
            if (volumeType == OracleVolumeType.Data)
            {
                int sizeFactor = oracleDatabaseSize / NumberOfDataVolume;
                double capacityFactor = ((double)snapshotReserveOverhead /100) * sizeFactor;
                size = Math.Max(100, (long)(sizeFactor + capacityFactor));
            }
            else if (volumeType == OracleVolumeType.Log)
            {
                size = 100;
            }
            else if (volumeType == OracleVolumeType.Binary)
            {
                size = 100;

            }
            else if (volumeType == OracleVolumeType.Backup)
            {
                size = Math.Max(100, oracleDatabaseSize / 2);
            }
            else if (volumeType == OracleVolumeType.LogMirror)
            {
                size = 100;
            }
            return size * gibibyte;
        }

        /// <summary>
        /// Returns throughput in MiB/s
        /// </summary>
        /// <param name="oracleThroughput">nodeMemory should be sent in GiB</param>
        /// <param name="NumberOfDataVolume"></param>
        /// /// <param name="volumeType"></param>
        /// <returns></returns>
        public static long CalculateOracleThroughput(int oracleThroughput, int NumberOfDataVolume, string volumeType)
        {
            int throughput = 150;
            if (volumeType == OracleVolumeType.Data)
            {
                throughput = Math.Max(100,oracleThroughput/NumberOfDataVolume);
            }
            else if (volumeType == OracleVolumeType.Log)
            {
                throughput = 150;
            }
            else if (volumeType == OracleVolumeType.LogMirror)
            {
                throughput = 150;
            }
            else if (volumeType == OracleVolumeType.Backup)
            {
                throughput = 150;
            }
            else if (volumeType == OracleVolumeType.Binary)
            {
                throughput = 64;
            }
            return throughput;
        }

        public static string GenerateOracleVolumeName(string applicationIdentifier, string systemId, string volumeType, int diskCount, string systemRole = null)
        {
            string prefix = string.IsNullOrWhiteSpace(systemId) ? $"{applicationIdentifier}-ora-": $"{systemId}-ora-";
            prefix = String.Equals(SystemRoles.HA, systemRole) ? $"{systemRole}-{prefix}": prefix;
            
            string postFix = String.Empty;
            if (volumeType == OracleVolumeType.Data)
            {
                postFix = diskCount.ToString();
            }
            return $"{prefix}{volumeType.ToLower()}{postFix}";
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
            public const string DR = "DR";
        }

        public struct VolumeProtocolTypes
        {
            public const string NFSv3 = "NFSv3";
            public const string NSFv41 = "NFSv4.1";
        }

        public struct OracleVolumeType
        {
            public const string Data = "data";
            public const string Log = "log";
            public const string Binary = "binary";
            public const string Backup = "backup";
            public const string LogMirror = "log-mirror";
        }
    }
}
