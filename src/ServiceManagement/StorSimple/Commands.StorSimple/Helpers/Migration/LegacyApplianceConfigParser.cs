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

using Microsoft.WindowsAzure.Commands.StorSimple.Models;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{

    /// <summary>
    /// Schema for xsd validation
    /// </summary>
    internal class LegacyApplianceConfigXmlSchema
    {
        internal const string Configuration = "Configuration.xsd";
        internal const string Configuration1 = "Configuration1.xsd";
        internal const string Configuration2 = "Configuration2.xsd";
        internal const string Configuration3 = "Configuration3.xsd";
        internal const string Configuration4 = "Configuration4.xsd";
        internal const string Configuration5 = "Configuration5.xsd";
        internal const string Configuration6 = "Configuration6.xsd";
        internal const string Configuration7 = "Configuration7.xsd";
        internal const string Configuration8 = "Configuration8.xsd";
        internal const string Configuration9 = "Configuration9.xsd";
        internal const string Configuration10 = "Configuration10.xsd";
        internal const string Configuration11 = "Configuration11.xsd";
        internal const string Configuration12 = "Configuration12.xsd";
    }

    /// <summary>
    /// Parser Message Type
    /// </summary>
    public enum MessageType
    {
        Info = 0,
        Warning = 1,
        Error = 2,
        Verbose = 3
    }

    /// <summary>
    /// Legacy objects supported by parser
    /// </summary>
    public enum LegacyObjectsSupported
    {
        VolumeContainer,
        BackupPolicy,
        VirtualDiskGroup,
        DataContainer,
        AccessControlRecord,
        StorageAccountCredential,
        InboundChapSetting,
        TargetChapSetting,
        BandwidthSetting
    }

    /// <summary>
    /// Parser message
    /// </summary>
    public class LegacyParserMessage
    {
        /// <summary>
        /// Gets or sets Message type indicating the criticality of message to be displayed
        /// </summary>
        public MessageType Type { get; set; }

        /// <summary>
        /// Gets or sets Object type which can be parsed by the parser for which the message is logged
        /// </summary>
        public LegacyObjectsSupported ObjectType {get;set;}

        /// <summary>
        /// Gets or sets the common reason for which the message is logged
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets custom messages to be displayed
        /// </summary>
        public List<string> CustomMessageList { get; set; }
    }

    /// <summary>
    /// Legacy appliance config parser
    /// </summary>
    public class LegacyApplianceConfigParser
    {
        #region DATA MEMBERs
        
        // List of properties to be returned
        private List<BandwidthSetting> bandwidthSettingList;
        private List<StorageAccountCredential> storageAcctCredList;
        private List<DataContainer> dataContainerList;
        private List<MigrationDataContainer> migrationDataContainerList;
        private List<VirtualDisk> volumeList;
        private List<VirtualDiskGroup> virtualDiskGroupList;
        private List<AccessControlRecord> acrList;
        private List<MigrationBackupPolicy> policyList;
        private List<MigrationChapSetting> inboundChapSettingList;
        private List<MigrationChapSetting> targetChapSettingList;
        private List<LegacyParserMessage> parserMessageList;

        // Helper classes
        private IServiceSecretEncryptor serviceSecretEncryptor;
        private XDocument doc;

        // Constants
        private const int SizeofBlockInBytes = 512;
        private const int MaxRetentionCount = 64;
        private const int DefaultScheduleRecurrenceCount = 1;
        private const string MinManagementVersion = "2.1.1.485";
        private const string MaxTimeSpan = "23:59:59";
        private const int MaxBandwidthRateSupportedBps = 125 * 1000 * 1000;

        /// <summary>
        /// Gets the parser message
        /// </summary>
        public List<LegacyParserMessage> ParserMessages
        {
            get
            {
                return this.parserMessageList;
            }
        }
        
        /// <summary>
        /// Cloud Type Mapping of cofig xml strings to service enums.
        /// </summary>
        Dictionary<string, CloudType> CloudTypeMap = new Dictionary<string, CloudType>()
        {
            {"CLOUD_TYPE_NONE", CloudType.None},
            {"CLOUD_TYPE_ATMOS", CloudType.Atmos},
            {"CLOUD_TYPE_AZURE", CloudType.Azure},
            {"CLOUD_TYPE_S3", CloudType.S3},
            {"CLOUD_TYPE_SYNAPTIC", CloudType.Synaptic},
            {"CLOUD_TYPE_ATMOSONPREM", CloudType.AtmosOnPrem},
            {"CLOUD_TYPE_ASP_DEPRECATED", CloudType.ASPDeprecated},
            {"CLOUD_TYPE_ZETTA", CloudType.Zetta},
            {"CLOUD_TYPE_RACKSPACE", CloudType.RackSpace},
            {"CLOUD_TYPE_IIJ", CloudType.IIJ},
            {"CLOUD_TYPE_NIFTY", CloudType.NIFTY},
            {"CLOUD_TYPE_S3_RRS", CloudType.S3RRS},
            {"CLOUD_TYPE_DELLDX_DEPRECATED", CloudType.DellDXDeprecated},
            {"CLOUD_TYPE_OPENSTACK", CloudType.OpenStack},
            {"CLOUD_TYPE_HP", CloudType.HP},
            {"CLOUD_TYPE_GOOGLE", CloudType.Google},
            {"CLOUD_TYPE_NIRVANIX", CloudType.Nirvanix},
            {"CLOUD_TYPE_AZURE_CHINA", CloudType.AzureChina},
            {"CLOUD_TYPE_MAX", CloudType.Max}
        };

        /// <summary>
        /// Backup Type Mapping of cofig xml strings to service enums.
        /// Cloud clone is not supported hence mapped to invalid
        /// </summary>
        Dictionary<string, BackupType> BackupTypeMap = new Dictionary<string, BackupType>()
        {
            {"CloudClone", BackupType.Invalid},
            {"Snapshot", BackupType.LocalSnapshot},
            {"CloudSnap", BackupType.CloudSnapshot}
        };

        /// <summary>
        /// Access Type Mapping of cofig xml strings to service enums
        /// </summary>
        Dictionary<string, AccessType> AccessTypeMap = new Dictionary<string, AccessType>()
        {
			{"acl_no_data", AccessType.NoAccess},
			{"acl_read_only", AccessType.ReadOnly},
            {"acl_read_write", AccessType.ReadWrite} 
        };

        /// <summary>
        /// Chunk size to app type mapping, if chunck size is 64K Volume is of type Primary, if it is 512K the volume is Archived.
        /// Only Primary and Archived volume is supported by newer appliance, all the other volume types supported by legacy appliance henceforth is
        /// mapped to default type which is Primary.
        /// </summary>
        Dictionary<string, AppType> AppTypeMap = new Dictionary<string, AppType>()
        {
			{"LINEAR_FINGERPRINT_TYPE_DEFAULT", AppType.PrimaryVolume},
			{"LINEAR_FINGERPRINT_TYPE_VARIABLE", AppType.PrimaryVolume},
			{"LINEAR_FINGERPRINT_TYPE_FIXED_16K", AppType.PrimaryVolume},
			{"LINEAR_FINGERPRINT_TYPE_FIXED_32K", AppType.PrimaryVolume},
			{"LINEAR_FINGERPRINT_TYPE_FIXED_64K", AppType.PrimaryVolume},
			{"LINEAR_FINGERPRINT_TYPE_FIXED_128K", AppType.PrimaryVolume},
			{"LINEAR_FINGERPRINT_TYPE_FIXED_256K", AppType.PrimaryVolume},
			{"LINEAR_FINGERPRINT_TYPE_FIXED_512K", AppType.ArchiveVolume},
			{"LINEAR_FINGERPRINT_TYPE_MAX", AppType.PrimaryVolume}
		};

        #endregion

        /// <summary>
        /// LegacyApplianceConfig Parser constructor
        /// </summary>
        /// <param name="client">stor simple service client</param>
        public LegacyApplianceConfigParser(IServiceSecretEncryptor encryptor)
        {
            this.serviceSecretEncryptor = encryptor;            
            this.parserMessageList = new List<LegacyParserMessage>();            
        }
        
        /// <summary>
        /// Parse legacy appliance config
        /// </summary>
        /// <param name="filePath">config file path</param>
        /// <param name="decryptionKey">key to decrypt the config file</param>
        /// <returns>legacy appliance config</returns>
        public LegacyApplianceDetails ParseLegacyApplianceConfig(string filePath, string decryptionKey)
        {
            this.LoadAndValidateLegacyConfigXml(filePath, decryptionKey);
            ProcessConfigs();
            LegacyApplianceDetails legacyApplianceDetails = new LegacyApplianceDetails();
            legacyApplianceDetails.AccessControlRecordList = this.acrList;
            legacyApplianceDetails.BackupPolicyList = this.policyList;
            legacyApplianceDetails.BandwidthSettingList = this.bandwidthSettingList;
            legacyApplianceDetails.VolumeContainerList = this.migrationDataContainerList;
            legacyApplianceDetails.StorageAccountCredentialList = this.storageAcctCredList;
            legacyApplianceDetails.VolumeGroupList = this.virtualDiskGroupList;
            legacyApplianceDetails.VolumeList = this.volumeList;
            legacyApplianceDetails.InboundChapSettingList = this.inboundChapSettingList;
            legacyApplianceDetails.TargetChapSettingList = this.targetChapSettingList;
            legacyApplianceDetails.RelatedVolumeContainerNames = legacyApplianceDetails.UpdateMigrationDataContainerGroups();
            
            return legacyApplianceDetails;
        }

        #region HELPER APIs

        /// <summary>
        /// Create and load XmlDocument from XDocument
        /// </summary>
        /// <param name="xDocument">Instance of XDocument</param>
        /// <returns>Instance of XmlDocument</returns>
        private XmlDocument ToXmlDocument(XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }

        /// <summary>
        /// Load the legacy appliance config and do basic validation
        /// </summary>
        /// <param name="configXmlFilePath">legacy appliance config</param>
        private void LoadAndValidateLegacyConfigXml(string configXmlFilePath, string decryptionKey)
        {
            LegacyApplianceConfigDecryptor decryptor = new LegacyApplianceConfigDecryptor();
            StreamReader reader = new StreamReader(decryptor.Decrypt(decryptionKey, configXmlFilePath));
            doc = XDocument.Load(reader);
            //doc = XDocument.Load(configXmlFilePath);
            //this.ValidateXmlSchema();
            this.ValidateMinManagementVersion(doc);
        }

        /// <summary>
        /// Adds Parser message to message list, all custom messages are grouped and added based on object type and reason
        /// </summary>
        /// <param name="objectType">Legacy object supported by parser, whose message needs to be logged</param>
        /// <param name="reason">Global reason to be logged</param>
        /// <param name="customMessage">Customized message to be logged per logging instance</param>
        /// <param name="type">Message type indicating the severity of message to be displayed</param>
        private void AddMessage(LegacyObjectsSupported objectType, string reason, string customMessage, MessageType type)
        {
            LegacyParserMessage message = this.parserMessageList.Find(msg => msg.ObjectType == objectType && msg.Reason == reason);
            if(null != message)
            {
                message.CustomMessageList.Add(customMessage);
            }
            else
            {
                message = new LegacyParserMessage();
                message.CustomMessageList = new List<string>();
                message.CustomMessageList.Add(customMessage);
                message.ObjectType = objectType;
                message.Reason = reason;
                message.Type = type;
                this.parserMessageList.Add(message);
            }
        }

        /// <summary>
        /// Create xml schema for schema validation
        /// </summary>
        /// <param name="input">input schema</param>
        /// <returns>xml schema</returns>
        private XmlSchema CreateXmlSchema(string input)
        {
            Byte[] bytes = Encoding.UTF8.GetBytes(File.ReadAllText(input));
            MemoryStream memStream = new MemoryStream(bytes);
            StreamReader reader = new StreamReader(memStream, Encoding.UTF8);
            XmlSchema schema = XmlSchema.Read(reader, (o, err) => { throw new Exception(string.Format(Resources.MigrationSchemaParsingError, input)); });
            return schema;
        }

        /// <summary>
        /// Verify xml schema
        /// </summary>
        private void ValidateXmlSchema()
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(CreateXmlSchema(LegacyApplianceConfigXmlSchema.Configuration));
            schemas.Add(CreateXmlSchema(LegacyApplianceConfigXmlSchema.Configuration1));
            schemas.Add(CreateXmlSchema(LegacyApplianceConfigXmlSchema.Configuration2));
            schemas.Add(CreateXmlSchema(LegacyApplianceConfigXmlSchema.Configuration3));
            schemas.Add(CreateXmlSchema(LegacyApplianceConfigXmlSchema.Configuration4));
            schemas.Add(CreateXmlSchema(LegacyApplianceConfigXmlSchema.Configuration5));
            schemas.Add(CreateXmlSchema(LegacyApplianceConfigXmlSchema.Configuration6));
            schemas.Add(CreateXmlSchema(LegacyApplianceConfigXmlSchema.Configuration7));
            schemas.Add(CreateXmlSchema(LegacyApplianceConfigXmlSchema.Configuration8));
            schemas.Add(CreateXmlSchema(LegacyApplianceConfigXmlSchema.Configuration9));
            schemas.Add(CreateXmlSchema(LegacyApplianceConfigXmlSchema.Configuration10));
            schemas.Add(CreateXmlSchema(LegacyApplianceConfigXmlSchema.Configuration11));
            schemas.Add(CreateXmlSchema(LegacyApplianceConfigXmlSchema.Configuration12));
            schemas.Compile();

            doc.Validate(schemas, (o, err) => { throw new Exception(err.Message); });
        }

        /// <summary>
        /// Validate Management version 
        /// </summary>
        /// <param name="doc">Xml document</param>
        private void ValidateMinManagementVersion(XDocument doc)
        {
            var managementVersionElements = GetSubElements(doc.Root, "ManagementVersion");
            string managementVersion = string.Empty;
            if(null != managementVersionElements && 0 < managementVersionElements.Count())
            {
                managementVersion = managementVersionElements.First().Value;
            }
            else
            {
                throw new MissingMemberException(Resources.MigrationManagementVersionNotFound);
            }

            string buildIdentifier = "build ";
            managementVersion = managementVersion.Substring(managementVersion.IndexOf(buildIdentifier) + buildIdentifier.Length, managementVersion.Length - managementVersion.IndexOf(buildIdentifier) - buildIdentifier.Length - 1);

            Version currentVersion = Version.Parse(managementVersion);            
            Version minimumSupporteddVersion = Version.Parse(MinManagementVersion);
            if (minimumSupporteddVersion > currentVersion)
            {
                throw new NotSupportedException(string.Format(Resources.MigrationManagementVersionNotSupported, managementVersion, MinManagementVersion));
            }            
        }

        /// <summary>
        /// Parse the legacy appliance xml config and do the post processing
        /// </summary>
        private void ProcessConfigs()
        {
            // Parse legacy Appliance xml
            this.ParseAccessControlRecords();
            this.ParseStorageAccountCredentials();
            this.ParseBandwidthSettings();
            this.ParseDataContainers();
            this.ParseVirtualDisks();
            this.ParseVirtualDiskGroup();
            this.ParseBackupPolicy();
            this.ParseScsiChapSetting();

            // Post processing of parsed data

            // Removing unsupported policies 
            this.FilterSupportedPolicy();

            // Legacy appliance supports virtual disk group without policy while newer appliance does not.
            // All legacy virtual disk group which are not associated to policy will be associated to default policy
            // Also default policy will be added to virtual disk group with cloud clone and local snap shot
            this.AddDefaultPolicyToVolumeGroupWithNoPolicy();            

            // Fixing the dependencies, between virtualdisk and dataContainer, ACRs
            foreach (VirtualDisk virtualDisk in this.volumeList)
            {
                // associating volume to volume container
                virtualDisk.DataContainer =
                    this.dataContainerList.Find(dataContainer => virtualDisk.DataContainerId == dataContainer.InstanceId);
                if (null != virtualDisk.DataContainer)
                {
                    virtualDisk.DataContainer.VolumeCount++;
                }
                else
                {
                    throw new MissingMemberException(string.Format(Resources.MigrationExpectedVolumeContainerNotFound, virtualDisk.DataContainerId));
                }

                // associating acr to the volume
                virtualDisk.AcrList = new List<AccessControlRecord>();
                foreach (string acrId in virtualDisk.AcrIdList)
                {
                    AccessControlRecord acrtobeAdded = this.acrList.Find(acr => acr.InstanceId == acrId);
                    if (null != acrtobeAdded)
                    {
                        virtualDisk.AcrList.Add(acrtobeAdded);
                        acrtobeAdded.VolumeCount++;
                    }
                    else
                    {
                        throw new MissingMemberException(string.Format(Resources.MigrationExpectedACRNotFound, acrId));
                    }
                }
            }
        }
 
        /// <summary>
        /// Get subelements of the given element which matches the xml property name
        /// </summary>
        /// <param name="element">Parent xml element</param>
        /// <param name="xmlPropertyName">name of the subelement property</param>
        /// <returns>List of all subelements for the given element which matches the property name</returns>
        private IEnumerable<XElement> GetSubElements(XElement element, string xmlPropertyName)
        {
            return from acrXml in element.Elements()
                   where xmlPropertyName == acrXml.Name.LocalName
                   select acrXml;
        }

        /// <summary>
        /// Convert sac to sac response
        /// </summary>
        /// <param name="cred">Sac object to be converted</param>
        /// <returns>StorageAccountCredentialResponse object</returns>
        private StorageAccountCredentialResponse ConvertToSACResponse(StorageAccountCredential cred)
        {
            StorageAccountCredentialResponse credResponse = new StorageAccountCredentialResponse();
            credResponse.CloudType = cred.CloudType;
            credResponse.Hostname = cred.Hostname;
            credResponse.InstanceId = cred.InstanceId;
            credResponse.IsDefault = cred.IsDefault;
            credResponse.Location = cred.Location;
            credResponse.Login = cred.Login;
            credResponse.Name = cred.Name;
            credResponse.OperationInProgress = cred.OperationInProgress;
            credResponse.Password = cred.Password;
            credResponse.PasswordEncryptionCertThumbprint = cred.PasswordEncryptionCertThumbprint;
            credResponse.UseSSL = cred.UseSSL;
            credResponse.VolumeCount = cred.VolumeCount;
            return credResponse;
        }

        /// <summary>
        /// Add Default policy for virtual disk groups which are not associated to any policy
        /// </summary>
        private void AddDefaultPolicyToVolumeGroupWithNoPolicy()
        {
            IEnumerable<string> virtualDiskGroupIdListWithPolicy = this.policyList.Select(policy => policy.VirtualDiskGroupId);
            List<VirtualDiskGroup> virtualDiskGroupWithNoPolicy = this.virtualDiskGroupList.FindAll(virtualDiskGroup => !virtualDiskGroupIdListWithPolicy.Contains(virtualDiskGroup.InstanceId));
            foreach(VirtualDiskGroup virtualDiskGroup in virtualDiskGroupWithNoPolicy)
            {
                MigrationBackupPolicy backupPolicy = this.CreateDefaultBackupPolicy(virtualDiskGroup.InstanceId, virtualDiskGroup.Name);
                this.policyList.Add(backupPolicy);
                this.AddMessage(LegacyObjectsSupported.VirtualDiskGroup, Resources.MigrationDefaultPolicyAssigned, string.Format(Resources.MigrationPolicyUpdated, backupPolicy.Name, virtualDiskGroup.Name), MessageType.Info);
            }
        }

        /// <summary>
        /// Create default backup policy object
        /// </summary>
        /// <param name="virtualDiskGroupId">virtual disk group id associated with policy</param>
        /// <returns>Migration backup policy object</returns>
        private MigrationBackupPolicy CreateDefaultBackupPolicy(string virtualDiskGroupId, string policyNameSuffix)
        {
            MigrationBackupPolicy backupPolicy = new MigrationBackupPolicy();
            backupPolicy.InstanceId = Guid.NewGuid().ToString();
            backupPolicy.LastRunTime = null;
            backupPolicy.MaxRetentionCount = MaxRetentionCount;
            backupPolicy.Name = "Default_" + policyNameSuffix;
            backupPolicy.Type = BackupType.CloudSnapshot;
            backupPolicy.VirtualDiskGroupId = virtualDiskGroupId;
            backupPolicy.OperationInProgress = OperationInProgress.None;
            backupPolicy.Disabled = true;
            backupPolicy.CreatedOn = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
            backupPolicy.BackupSchedules = new List<BackupScheduleBase>();
            backupPolicy.BackupSchedules.Add(this.CreateDefaultBackupPolicySchedule());
            return backupPolicy;
        }

        /// <summary>
        /// Removes the backup policy and its associated virtual disk group which are not supported for migration
        /// </summary>
        private void FilterSupportedPolicy()
        {
            // The newer appliance supports only Cloud SnapShot and Local Snapshot. Cloud Clone is not supported and cannot be migrated.
            // Additionally, local snapshot where back does not reside in cloud is not consider for migration. Hence we need to filter out
            // all policy where back type is anything other than CloudSnapshot
            List<MigrationBackupPolicy> policiesToBeRemoved = this.policyList.FindAll(policy => BackupType.CloudSnapshot != policy.Type);
            this.policyList = this.policyList.FindAll(policy => BackupType.CloudSnapshot == policy.Type);
            foreach(MigrationBackupPolicy policy in policiesToBeRemoved)
            {
                if (BackupType.LocalSnapshot == policy.Type)
                {
                    this.AddMessage(LegacyObjectsSupported.BackupPolicy, Resources.MigrationLocalSnapshotPolicyNotSupported, policy.Name, MessageType.Warning);
                }
                else
                {
                    this.AddMessage(LegacyObjectsSupported.BackupPolicy, Resources.MigrationInvalidPolicyNotSupported, policy.Name, MessageType.Warning);
                }
            }

            // newer appliance has 1-1 mapping between policy and virtual disk group, fix the mapping by considering only the first policy which is mapped to same vdg
            Dictionary<string, MigrationBackupPolicy> policyVdgMap = new Dictionary<string, MigrationBackupPolicy>();
            foreach(MigrationBackupPolicy policy in this.policyList)
            {
                if(!policyVdgMap.ContainsKey(policy.VirtualDiskGroupId))
                {
                    policyVdgMap.Add(policy.VirtualDiskGroupId, policy);
                }
                else
                {
                    this.AddMessage(LegacyObjectsSupported.BackupPolicy, Resources.MigrationMultiplePolicyIgnored, policy.Name, MessageType.Warning);
                }
            }

            this.policyList = policyVdgMap.Values.ToList();
        }

        /// <summary>
        /// Generic parser implementation for Scsi chap data
        /// </summary>
        /// <param name="scsiClapRootElement">scsi chap data root element</param>
        /// <returns>List of chap data settings</returns>
        private List<MigrationChapSetting> ParseScsiChapDataImpl(XElement scsiClapRootElement)
        {
            List<MigrationChapSetting> chapSettingList = null;
            if (null != scsiClapRootElement)
            {
                var scsiChapXmlList = this.GetSubElements(scsiClapRootElement, "ScsiChapData");
                if (null != scsiChapXmlList && 0 < scsiChapXmlList.Count())
                {
                    chapSettingList = new List<MigrationChapSetting>();
                    foreach (XElement scsiChapXmlElement in scsiChapXmlList)
                    {
                        MigrationChapSetting chapSetting = new MigrationChapSetting();
                        var Id = this.GetSubElements(scsiChapXmlElement, "Id");
                        if (null != Id && 0 < Id.Count())
                        {
                            chapSetting.Id = Id.First().Value;
                        }

                        chapSetting.Name = this.GetSubElements(scsiChapXmlElement, "Name").First().Value;
                        chapSetting.Password = this.serviceSecretEncryptor.EncryptSecret(this.GetSubElements(scsiChapXmlElement, "Password").First().Value);
                        chapSetting.SecretsEncryptionThumbprint = this.serviceSecretEncryptor.GetSecretsEncryptionThumbprint();
                        chapSetting.Valid = bool.Parse(this.GetSubElements(scsiChapXmlElement, "Valid").First().Value);
                    }
                }
            }

            return chapSettingList;
        }
        
        /// <summary>
        /// Create default backup schedule
        /// </summary>
        /// <param name="scheduleNodeElement">backup schedule node</param>
        /// <returns>Backup schedule</returns>
        private BackupScheduleBase CreateDefaultBackupPolicySchedule()
        {
            BackupScheduleBase schedule = new BackupScheduleBase();
            schedule.StartTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-ddTHH:mm:sszzz");
            schedule.BackupType = BackupType.CloudSnapshot;
            schedule.RetentionCount = MaxRetentionCount;
            schedule.Status = ScheduleStatus.Disabled;
            schedule.Recurrence = new ScheduleRecurrence();
            schedule.Recurrence.RecurrenceType = RecurrenceType.Daily;
            schedule.Recurrence.RecurrenceValue = DefaultScheduleRecurrenceCount;
            return schedule;
        }

        /// <summary>
        /// Parse the backup schedule
        /// </summary>
        /// <param name="scheduleNodeElement">schedule node</param>
        /// <returns>back up schedule</returns>
        private BackupScheduleBase ParseBackupScheduleImpl(XElement scheduleNodeElement)
        {
            this.AddMessage(LegacyObjectsSupported.BackupPolicy, Resources.MigrationBackupSchedulesNotMigrated, string.Empty, MessageType.Info);
            return this.CreateDefaultBackupPolicySchedule();            
        }

        #endregion

        #region PARSER IMPLEMENTATION

        /// <summary>
        /// Parse the access control records
        /// </summary>
        private void ParseAccessControlRecords()
        {
            this.acrList = new List<AccessControlRecord>();
            var acrXmlList = this.GetSubElements(doc.Root, "AccessControlGroup");
            foreach (XElement acrElementList in acrXmlList)
            {
                foreach (XElement acrElement in acrElementList.Elements())
                {
                    AccessControlRecord acr = new AccessControlRecord();
                    foreach (XElement acrProperty in acrElement.Elements())
                    {
                        switch (acrProperty.Name.LocalName)
                        {
                            case "Id":
                                {
                                    acr.InstanceId = acrProperty.Value;
                                    break;
                                }
                            case "Members":
                                {
                                    var acrPropertyDetails = acrProperty.Elements().First().Elements().ToList();
                                    foreach (XElement acrEle in acrPropertyDetails)
                                    {
                                        switch (acrEle.Name.LocalName)
                                        {
                                            case "InitiatorName":
                                                {
                                                    acr.InitiatorName = acrEle.Value;
                                                    break;
                                                }
                                            case "GroupId":
                                                {
                                                    acr.GlobalId = acrEle.Value;
                                                    break;
                                                }
                                        }
                                    }

                                    break;
                                }
                            case "Name":
                                {
                                    acr.Name = acrProperty.Value;
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                    }

                    this.acrList.Add(acr);
                }
            }
        }

        /// <summary>
        /// Parse storage account credential
        /// </summary>
        private void ParseStorageAccountCredentials()
        {
            this.storageAcctCredList = new List<StorageAccountCredential>();
            var cloudCredentialsList = this.GetSubElements(doc.Root, "CloudCredentials");
            foreach (XElement cloudCredentialsL1 in cloudCredentialsList)
            {
                foreach (XElement elemL2 in cloudCredentialsL1.Elements())
                {
                    StorageAccountCredential credential = new StorageAccountCredential();
                    foreach (XElement elemL3 in elemL2.Elements())
                    {
                        switch (elemL3.Name.LocalName)
                        {
                            case "Hostname":
                                {
                                    credential.Hostname = elemL3.Value;
                                    break;
                                }
                            case "Login":
                                {
                                    credential.Login = elemL3.Value;
                                    break;
                                }
                            case "Password":
                                {
                                    credential.Password = this.serviceSecretEncryptor.EncryptSecret(elemL3.Value);
                                    credential.PasswordEncryptionCertThumbprint = this.serviceSecretEncryptor.GetSecretsEncryptionThumbprint();
                                    break;
                                }
                            case "Id":
                                {
                                    credential.InstanceId = elemL3.Value;
                                    break;
                                }
                            case "Alias":
                                {
                                    credential.Name = elemL3.Value;
                                    break;
                                }
                            case "Provider":
                                {
                                    credential.CloudType = CloudTypeMap[elemL3.Value];
                                    break;
                                }
                            case "SSL":
                                {
                                    credential.UseSSL = Boolean.Parse(elemL3.Value);
                                    break;
                                }
                            case "Location":
                                {
                                    credential.Location = elemL3.Value;
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                    }

                    credential.IsDefault = false;
                    credential.OperationInProgress = OperationInProgress.None;                    
                    credential.VolumeCount = 0;
                    this.storageAcctCredList.Add(credential);
                }
            }
        }

        /// <summary>
        /// Parses the Bandwidth setting from Legacy appliance config
        /// </summary>
        private void ParseBandwidthSettings()
        {
            this.bandwidthSettingList = new List<BandwidthSetting>();
            var qosTemplatesList = this.GetSubElements(doc.Root, "QosTemplates");
            foreach (XElement qosTemplate in qosTemplatesList)
            {
                var qosTemplateElementList = this.GetSubElements(qosTemplate, "QosTemplateInfo");
                foreach (XElement qosTemplateElement in qosTemplateElementList)
                {
                    BandwidthSetting bandWidthSetting = new BandwidthSetting();
                    foreach (XElement bandWidthSettingElement in qosTemplateElement.Elements())
                    {
                        switch (bandWidthSettingElement.Name.LocalName)
                        {
                            case "Name":
                                {
                                    bandWidthSetting.Name = bandWidthSettingElement.Value;
                                    break;
                                }

                            case "Id":
                                {
                                    bandWidthSetting.InstanceId = bandWidthSettingElement.Value;
                                    break;
                                }

                            case "Schedule":
                                {
                                    var scheduleElementList = this.GetSubElements(bandWidthSettingElement, "QosScheduleInfo");
          
                                    // Assuming ScheduleInfo has only one element
                                    bandWidthSetting.Schedules = new List<BandwidthSchedule>();
                                    BandwidthSchedule schedule = new BandwidthSchedule();
                                    bandWidthSetting.Schedules.Add(schedule);
                                    TimeSpan duration = TimeSpan.Zero;
                                    foreach (XElement scheduleElement in scheduleElementList.Elements())
                                    {
                                        switch (scheduleElement.Name.LocalName)
                                        {
                                            case "Days":
                                                {
                                                    schedule.Days = new List<int>();
                                                    foreach (XElement dayElem in scheduleElement.Elements())
                                                    {
                                                        schedule.Days.Add((int)Enum.Parse(typeof(DayOfWeek), dayElem.Value, true));
                                                    }

                                                    break;
                                                }
                                            case "Duration":
                                                {
                                                    duration = XmlConvert.ToTimeSpan(scheduleElement.Value.TrimEnd('T'));
                                                    break;
                                                }
                                            case "RateInBytes":
                                                {
                                                    schedule.Rate = 0;

                                                    int rate = 0;
                                                    if (int.TryParse(scheduleElement.Value, out rate))
                                                    {
                                                        if (rate > MaxBandwidthRateSupportedBps)
                                                        {
                                                            rate = MaxBandwidthRateSupportedBps;
                                                        }
                                                        else
                                                        {
                                                            if (0 != rate)
                                                            {
                                                                // In firenze appliance you can set bandwidth rate from 0 - 1000 Mbps
                                                                rate = (rate * 8) / (1000 * 1000);
                                                            }
                                                        }

                                                        schedule.Rate = rate;
                                                    }
                                                  
                                                    break;
                                                }
                                            case "Start":
                                                {
                                                    // Convert Start time to HH:mm:ss format as expected by service
                                                    if (string.IsNullOrEmpty(scheduleElement.Value))
                                                    {
                                                        schedule.Start = TimeSpan.Zero.ToString();
                                                    }
                                                    else
                                                    {
                                                        // start time should be in universal time. 
                                                        schedule.Start = DateTime.Parse(scheduleElement.Value).ToUniversalTime().ToString("HH:mm:ss");
                                                    }

                                                    break;
                                                }
                                            default:
                                                {
                                                    break;
                                                }

                                        }
                                    }

                                    // Calculating the schedule stop time from start time and duration. [stop time will also be in universal time zone] 
                                    // The stop time should be in HH:mm:ss format. This is a per day schedule and cannot spill to next day
                                    if (!string.IsNullOrEmpty(schedule.Start))
                                    {
                                        schedule.Stop = DateTime.Parse(schedule.Start).Add(duration).ToString("HH:mm:ss");
                                    }
                                    else
                                    {
                                        schedule.Stop = DateTime.Parse(TimeSpan.Zero.ToString()).Add(duration).ToString("HH:mm:ss");
                                    }

                                    // For whole day schedule
                                    if (schedule.Start == schedule.Stop)
                                    {
                                        schedule.Start = TimeSpan.Zero.ToString();
                                        schedule.Stop = MaxTimeSpan;
                                    }

                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                    }

                    this.bandwidthSettingList.Add(bandWidthSetting);
                }
            }
        }

        /// <summary>
        /// Parse data container
        /// </summary>
        private void ParseDataContainers()
        {
            this.dataContainerList = new List<DataContainer>();
            this.migrationDataContainerList = new List<MigrationDataContainer>();
            var cloudConfigurationsList = this.GetSubElements(doc.Root, "CloudConfigurations");
            foreach (XElement cloudConfigurations in cloudConfigurationsList)
            {
                var cloudConfigurationInfoList = this.GetSubElements(cloudConfigurations, "CloudConfigurationInfo");
                foreach (XElement cloudConfigurationInfo in cloudConfigurationInfoList)
                {
                    DataContainer dataContainer = new DataContainer();
                    MigrationDataContainer migrationDataContainer = new MigrationDataContainer();
                    string bandwidthSettingID = string.Empty;
                    bool bandwidthSettingAddStatus = true;
                    foreach (XElement dataContainerProperty in cloudConfigurationInfo.Elements())
                    {
                        switch (dataContainerProperty.Name.LocalName)
                        {
                            case "Alias":
                                {
                                    dataContainer.Name = dataContainerProperty.Value;
                                    migrationDataContainer.Name = dataContainer.Name;
                                    break;
                                }

                            case "PrimaryBucket":
                                {
                                    string Id = GetSubElements(dataContainerProperty, "CredentialId").First().Value;
                                    StorageAccountCredential primarySAC = this.storageAcctCredList.Find(sac => sac.InstanceId == Id);
                                    if (null != primarySAC)
                                    {
                                        dataContainer.PrimaryStorageAccountCredential = ConvertToSACResponse(primarySAC);
                                        migrationDataContainer.PrimaryStorageAccountCredential = primarySAC;
                                    }
                                    else
                                    {
                                        throw new MissingMemberException(string.Format(Resources.MigrationExpectedSACNotFound, Id));
                                    }
                                    
                                    migrationDataContainer.PrimaryBucket = GetSubElements(dataContainerProperty, "Name").First().Value;
                                    break;
                                }

                            case "BackupBucket":
                                {
                                    string Id = GetSubElements(dataContainerProperty, "CredentialId").First().Value;
                                    StorageAccountCredential backupSAC = this.storageAcctCredList.Find(sac => sac.InstanceId == Id);
                                    if (null != backupSAC)
                                    {
                                        migrationDataContainer.BackupStorageAccountCredential = backupSAC;
                                    }
                                    else
                                    {
                                        throw new MissingMemberException(string.Format(Resources.MigrationExpectedSACNotFound, Id));
                                    }

                                    migrationDataContainer.BackupBucket = GetSubElements(dataContainerProperty, "Name").First().Value;
                                    break;
                                }

                            case "QosTemplateId":
                                {
                                    migrationDataContainer.BandwidthSetting = this.bandwidthSettingList.Find(setting=>setting.InstanceId == dataContainerProperty.Value);
                                    if (null != migrationDataContainer.BandwidthSetting && 
                                        null != migrationDataContainer.BandwidthSetting.Schedules && 
                                        0 < migrationDataContainer.BandwidthSetting.Schedules.Count)
                                    {
                                        dataContainer.BandwidthRate = migrationDataContainer.BandwidthSetting.Schedules[0].Rate;
                                    }
                                    else
                                    {
                                        bandwidthSettingAddStatus = false;
                                    }

                                    break;
                                }

                            case "EncryptionKey":
                                {
                                    string encryptedEncryptionKey = string.Empty;
                                    dataContainer.IsEncryptionEnabled = !String.IsNullOrEmpty(dataContainerProperty.Value);
                                    if (dataContainer.IsEncryptionEnabled)
                                    {
                                        dataContainer.EncryptionKey = this.serviceSecretEncryptor.EncryptSecret(dataContainerProperty.Value);
                                        dataContainer.SecretsEncryptionThumbprint = this.serviceSecretEncryptor.GetSecretsEncryptionThumbprint();
                                    }
                                    else
                                    {
                                        dataContainer.EncryptionKey = string.Empty;
                                        dataContainer.SecretsEncryptionThumbprint = string.Empty;
                                    }

                                    dataContainer.IsEncryptionEnabled = !String.IsNullOrEmpty(dataContainerProperty.Value);
                                    migrationDataContainer.EncryptionKey = dataContainer.EncryptionKey;
                                    migrationDataContainer.SecretsEncryptionThumbprint = dataContainer.SecretsEncryptionThumbprint;
                                    break;
                                }

                            case "Id":
                                {
                                    dataContainer.InstanceId = dataContainerProperty.Value;
                                    migrationDataContainer.InstanceId = dataContainer.InstanceId;
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }

                    }

                    // below properties are a not a part of legacy appliance config filling with default value.
                    dataContainer.OperationInProgress = migrationDataContainer.OperationInProgress = OperationInProgress.None;
                    dataContainer.VolumeCount = -1;
                    dataContainer.IsDefault = migrationDataContainer.IsDefault = false;
                    dataContainer.Owned = migrationDataContainer.Owned = true;
                    migrationDataContainer.SecretsEncryptionThumbprint = migrationDataContainer.PrimaryStorageAccountCredential.PasswordEncryptionCertThumbprint;
                    if (!bandwidthSettingAddStatus)
                    {
                        this.AddMessage(LegacyObjectsSupported.DataContainer, Resources.MigrationAssociatedBandwidthSettingIncomplete, dataContainer.Name, MessageType.Warning);
                    }

                    this.dataContainerList.Add(dataContainer);
                    this.migrationDataContainerList.Add(migrationDataContainer);
                }
            }
        }

        /// <summary>
        /// Parse virtual disk details
        /// </summary>
        private void ParseVirtualDisks()
        {
            volumeList = new List<VirtualDisk>();
            var volumesList = this.GetSubElements(doc.Root, "Volumes");
            foreach (XElement volumes in volumesList)
            {
                var diskList = this.GetSubElements(volumes, "Volume");
                foreach (XElement disk in diskList)
                {
                    VirtualDisk volume = new VirtualDisk();
                    foreach (XElement diskItem in disk.Elements())
                    {
                        switch (diskItem.Name.LocalName)
                        {
                            case "AccessControlList":
                                {
                                    volume.AcrIdList = new List<string>();
                                    foreach (XElement acrElement in diskItem.Elements())
                                    {
                                        if ("VolumeAce" == acrElement.Name.LocalName)
                                        {
                                            foreach (XElement acr in acrElement.Elements())
                                            {
                                                if ("AccessControlGroupId" == acr.Name.LocalName)
                                                {
                                                    volume.AcrIdList.Add(acr.Value);
                                                }
                                            }
                                        }
                                    }

                                    break;
                                }
                            case "Alias":
                                {
                                    volume.Name = diskItem.Value;
                                    break;
                                }
                            case "BlockCount":
                                {
                                    volume.SizeInBytes = long.Parse(diskItem.Value) * SizeofBlockInBytes;
                                    break;
                                }
                            case "CloudId":
                                {
                                    volume.DataContainerId = diskItem.Value;
                                    break;
                                }
                            case "Id":
                                {
                                    volume.InstanceId = diskItem.Value;
                                    break;
                                }
                            case "SerialNumber":
                                {
                                    volume.VSN = diskItem.Value;
                                    break;
                                }
                            case "Online":
                                {
                                    volume.Online = bool.Parse(diskItem.Value);
                                    break;
                                }
                            case "Attr":
                                {
                                    volume.AccessType = AccessTypeMap[diskItem.Value];
                                    break;
                                }
                            case "ChunkSize":
                                {
                                    volume.AppType = AppTypeMap[diskItem.Value];
                                    break;
                                }
                            case "Priority":                            
                            default:
                                {
                                    break;
                                }

                        }
                    }

                    volume.DataContainer = null;
                    volume.InternalInstanceId = null;
                    volume.IsBackupEnabled = false;
                    volume.IsDefaultBackupEnabled = false;
                    volume.IsMonitoringEnabled = false;
                    volume.OperationInProgress = OperationInProgress.None;

                    // populate volume container
                    volumeList.Add(volume);
                }
            }
        }

        /// <summary>
        /// Parse Virtual disk group
        /// </summary>
        private void ParseVirtualDiskGroup()
        {
            this.virtualDiskGroupList = new List<VirtualDiskGroup>();
            var backupDataInfoList = this.GetSubElements(doc.Root, "BackupData");
            foreach (XElement backupData in backupDataInfoList)
            {
                // find items corresponding to
                var collectionsList = this.GetSubElements(backupData, "Collections");
                foreach (XElement collections in collectionsList)
                {
                    var collectionInfoList = this.GetSubElements(collections, "CollectionInfo");
                    foreach (XElement collectionInfo in collectionInfoList)
                    {
                        VirtualDiskGroup virtualDiskGroup = new VirtualDiskGroup();
                        virtualDiskGroup.VirtualDiskList = new List<string>();
                        foreach (XElement volumeGroupProperty in collectionInfo.Elements())
                        {
                            if ("Alias" == volumeGroupProperty.Name.LocalName)
                            {
                                virtualDiskGroup.Name = volumeGroupProperty.Value;
                            }
                            else if ("Id" == volumeGroupProperty.Name.LocalName)
                            {
                                virtualDiskGroup.InstanceId = volumeGroupProperty.Value;
                            }
                            else if ("ExplicitVolumes" == volumeGroupProperty.Name.LocalName)
                            {
                                foreach (XElement volumeInfo in volumeGroupProperty.Elements())
                                {
                                    if ("VolumeInfo" == volumeInfo.Name.LocalName)
                                    {
                                        foreach (XElement volumeInfoItem in volumeInfo.Elements())
                                        {
                                            if ("Name" == volumeInfoItem.Name.LocalName)
                                            {
                                                VirtualDisk disk = this.volumeList.Find(volume => volumeInfoItem.Value == volume.Name);
                                                if (null != disk)
                                                {
                                                    virtualDiskGroup.VirtualDiskList.Add(disk.InstanceId);
                                                }
                                                else
                                                {
                                                    throw new MissingMemberException(string.Format(Resources.MigrationExpectedVolumeNotFound, volumeInfoItem.Value));
                                                }

                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        this.virtualDiskGroupList.Add(virtualDiskGroup);
                    }

                }
            }
        }

        /// <summary>
        /// Parse the backup policy
        /// </summary>
        private void ParseBackupPolicy()
        {
            this.policyList = new List<MigrationBackupPolicy>();
            var backupDataInfoList = this.GetSubElements(doc.Root, "BackupData");
            foreach (XElement backupDataInfo in backupDataInfoList)
            {
                var backupPolicyInfoList = this.GetSubElements(backupDataInfo, "BackupPolicies");
                foreach (XElement backupPolicyInfo in backupPolicyInfoList)
                {
                    var policyInfo = this.GetSubElements(backupPolicyInfo, "BackupPolicyInfo");
                    foreach (XElement policyItem in policyInfo)
                    {
                        MigrationBackupPolicy backupPolicy = new MigrationBackupPolicy();
                        backupPolicy.BackupSchedules = new List<BackupScheduleBase>();
                        foreach (XElement policyProperty in policyItem.Elements())
                        {
                            switch (policyProperty.Name.LocalName)
                            {
                                case "Alias":
                                    {
                                        backupPolicy.Name = policyProperty.Value;
                                        break;
                                    }
                                case "Id":
                                    {
                                        backupPolicy.InstanceId = policyProperty.Value;
                                        break;
                                    }
                                case "BackupType":
                                    {
                                        backupPolicy.Type = BackupTypeMap[policyProperty.Value];
                                        break;
                                    }
                                case "CollectionId":
                                    {
                                        backupPolicy.VirtualDiskGroupId = policyProperty.Value;
                                        break;
                                    }
                                case "Disabled":
                                    {
                                        backupPolicy.Disabled = bool.Parse(policyProperty.Value);
                                        break;
                                    }
                                case "CreatedOn":
                                    {
                                        backupPolicy.CreatedOn = policyProperty.Elements().ToList().Find(property => "_d" == property.Name.LocalName).Value;
                                        break;
                                    }
                                case "LastRun":
                                    {
                                        if (null != policyProperty.Elements())
                                        {
                                            XElement lastRunProperty = policyProperty.Elements().ToList().Find(property => "_d" == property.Name.LocalName);
                                            if(null != lastRunProperty)
                                            {
                                                backupPolicy.LastRunTime = lastRunProperty.Value;
                                            }
                                        }

                                        break;
                                    }
                                case "MaxRetentionCount":
                                    {
                                        backupPolicy.MaxRetentionCount = long.Parse(policyProperty.Value);
                                        break;
                                    }
                                case "Schedule":
                                    {
                                        backupPolicy.BackupSchedules.Add(this.ParseBackupScheduleImpl(policyProperty));
                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }
                        }

                        this.policyList.Add(backupPolicy);
                    }

                }
            }
        }
                
        /// <summary>
        /// Parse the inbound and target chap settings
        /// </summary>
        private void ParseScsiChapSetting()
        {
            var inboundScsiChapXmlElement = this.GetSubElements(doc.Root, "InBoundScsiChap").First();
            var targetScsiChapXmlElement = this.GetSubElements(doc.Root, "OutBoundScsiChap").First();
            this.inboundChapSettingList = this.ParseScsiChapDataImpl(inboundScsiChapXmlElement);
            this.targetChapSettingList = this.ParseScsiChapDataImpl(targetScsiChapXmlElement);
        }

        #endregion
    }
}