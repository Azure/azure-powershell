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

using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Models
{
    public class LegacyApplianceConfiguration
    {
        public string ConfigId { get; set; }
        public DateTime ImportedOn { get; set; }
        public string ConfigFile { get; set; }
        public string TargetApplianceName { get; set; }
        public LegacyApplianceDetails Details { get; set; }
        public string Result { get; set; }
    }

    public class LegacyApplianceDetails : LegacyApplianceConfig
    {
        /// <summary>
        /// List of grouped volume container names of volume containers to be migrated together
        /// </summary>
        public List<string[]> RelatedVolumeContainerNames { get; set; }

        /// <summary>
        /// Displays the content in the desired format
        /// </summary>
        /// <returns>format content to be displayed</returns>
        public override string ToString()
        {
            try
            {
                StringBuilder consoleOutput = new StringBuilder();
                if (null != this.VolumeGroupList)
                {
                    consoleOutput.Append(Resources.MigrationVolumeContainerRelatedGroupHeader).AppendLine();
                    int groupCount = 0;
                    List<List<MigrationDataContainer>> dataContainerGroupList = GetMigrationDataContainerGroups();
                    if (null != dataContainerGroupList)
                    {
                        foreach (List<MigrationDataContainer> dataContainerGroup in dataContainerGroupList)
                        {
                            consoleOutput.AppendFormat("\tVolumeContainer set: {0}", ++groupCount).AppendLine();
                            if (null != dataContainerGroup)
                            {
                                foreach (MigrationDataContainer dataContainerName in dataContainerGroup)
                                {
                                    consoleOutput.AppendFormat("\t\t{0}", dataContainerName.Name).AppendLine();
                                }
                            }
                        }
                    }
                    else
                    {
                        consoleOutput.AppendLine(Resources.MigrationVolumeContainerRelatedGroupingNotFound);
                    }
                }

                if (null != AccessControlRecordList)
                {
                    consoleOutput.AppendLine(FormatStringList("AccessControlRecordList", AccessControlRecordList.Select(acr => acr.Name)));
                }

                if (null != BackupPolicyList)
                {
                    consoleOutput.AppendLine(FormatStringList("BackupPolicyList", BackupPolicyList.Select(policy => policy.Name)));
                }

                if (null != BandwidthSettingList)
                {
                    consoleOutput.AppendLine(FormatStringList("BandwidthSettingList", BandwidthSettingList.Select(bandwidthSetting => bandwidthSetting.Name)));
                }

                if (null != VolumeContainerList)
                {
                    consoleOutput.AppendLine(FormatStringList("VolumeContainerList", VolumeContainerList.Select(dc => dc.Name)));
                }

                if (null != StorageAccountCredentialList)
                {
                    consoleOutput.AppendLine(FormatStringList("StorageAccountCredentialList", StorageAccountCredentialList.Select(sac => sac.Name)));
                }

                if (null != VolumeList)
                {
                    consoleOutput.AppendLine(FormatStringList("VolumeList", VolumeList.Select(virtualDisk => virtualDisk.Name)));
                }

                return consoleOutput.ToString();
            }
            catch(Exception except)
            {
                // powershell will consume the exception, and no details will be displayed if the exception is thrown, hence handling and returning error string.
                return string.Format(Resources.MigrationErrorInDisplayingDetails, except.ToString());
            }
        }

        /// <summary>
        /// Formats the string array list for display.
        /// Only two items are displayed and if more contents are present it will displayed as "..."
        /// </summary>
        /// <param name="contentListName">content list name</param>
        /// <param name="contentList">content list</param>
        /// <returns></returns>
        private string FormatStringList(string contentListName, IEnumerable<string> contentList)
        {
            const int itemDisplayCount = 2;
            StringBuilder formattedStr = new StringBuilder();
            formattedStr.Append("{");
            if (null != contentList)
            {
                List<string> displayContentList = contentList.ToList();
                for (int index = 0; index < displayContentList.Count && index < itemDisplayCount; index++)
                {
                    if (formattedStr.Length > "{".Length)
                    {
                        formattedStr.Append(", ");
                    }

                    formattedStr.Append(displayContentList[index]);
                }

                if (displayContentList.Count > itemDisplayCount)
                {
                    formattedStr.Append(", ...");
                }
            }

            formattedStr.Append("}");
            return string.Format("{0} : {1}", contentListName, formattedStr.ToString());
        }

        /// <summary>
        /// Update Migration Data Container Groups
        /// </summary>
        /// <returns></returns>
        internal List<string[]> UpdateMigrationDataContainerGroups()
        {
            List<List<MigrationDataContainer>> relatedDataContainerGroupList = this.GetMigrationDataContainerGroups();
            List<string[]> relatedDataContainerNameList = new List<string[]>();
            foreach(List<MigrationDataContainer> relatedDCList in relatedDataContainerGroupList)
            {
                if (null != relatedDCList && 0 < relatedDCList.Count)
                {
                    IEnumerable<string> relatedDCNameList = relatedDCList.Select(dc => dc.Name);
                    relatedDataContainerNameList.Add(relatedDCNameList.ToArray());
                }
            }

            return relatedDataContainerNameList;
        }

        /// <summary>
        /// Gets the groups of data container which needs to be migrated together
        /// </summary>
        /// <returns>Groups of data container which needs to be migrated together</returns>
        private List<List<MigrationDataContainer>> GetMigrationDataContainerGroups()
        {
            var dcDict = new Dictionary<string, DataContainerInfo>();
            foreach (VirtualDiskGroup virtualDiskGroup in this.VolumeGroupList)
            {
                List<string> diskIDList = virtualDiskGroup.VirtualDiskList.ToList();
                string vDGIdentity = Guid.NewGuid().ToString();
                foreach (string virtualDiskId in diskIDList)
                {
                    VirtualDisk virtualDisk = this.VolumeList.FirstOrDefault(volume => (volume.InstanceId == virtualDiskId));
                    MigrationDataContainer dataContainer = this.VolumeContainerList.FirstOrDefault(volumeContainer => (volumeContainer.InstanceId == virtualDisk.DataContainerId));
                    if (null != dataContainer)
                    {
                        if (!dcDict.ContainsKey(dataContainer.InstanceId))
                        {
                            DataContainerInfo newDc = new DataContainerInfo()
                            {
                                DcInfo = dataContainer,
                                VirtualDiskGroups = new List<string>() { vDGIdentity },
                                Visited = false
                            };

                            dcDict.Add(dataContainer.InstanceId, newDc);
                        }
                        else if (!dcDict[dataContainer.InstanceId].VirtualDiskGroups.Contains(vDGIdentity))
                        {
                            dcDict[dataContainer.InstanceId].VirtualDiskGroups.Add(vDGIdentity);
                        }
                    }
                    else
                    {
                        throw new MissingMemberException(string.Format(Resources.MigrationVolumeToVolumeContainerMapNotFound, virtualDisk.DataContainerId, virtualDisk.InstanceId));
                    }
                }
            }

            foreach (MigrationDataContainer dataContainer in this.VolumeContainerList)
            {
                if (!dcDict.Keys.Contains(dataContainer.InstanceId))
                {
                    dcDict.Add(dataContainer.InstanceId,
                        new DataContainerInfo()
                        {
                            DcInfo = dataContainer,
                            VirtualDiskGroups = new List<string>(),
                            Visited = false
                        });
                }
            }

            DataContainerInfo[] dcArray = dcDict.Values.ToArray();

            // create an adjacency matrix of DCs
            bool[,] dcGraph = new bool[dcDict.Count, dcDict.Count];
            for (int row = 0; row < dcDict.Count; row++)
            {
                for (int col = 0; col < dcDict.Count; col++)
                {
                    dcGraph[row, col] = false;
                }
            }

            for (int row = 0; row < dcArray.Count(); row++)
            {
                DataContainerInfo currDc = dcArray[row];
                foreach (string groupInstanceID in currDc.VirtualDiskGroups)
                {
                    for (int col = 0; col < dcArray.Count(); col++)
                    {
                        DataContainerInfo otherDc = dcArray[col];
                        if (!currDc.DcInfo.InstanceId.Equals(otherDc.DcInfo.InstanceId) && // we're looking at the same vertex
                            !(dcGraph[row, col] && dcGraph[col, row])) // or the vertices are already known neighbours
                        {
                            if (otherDc.VirtualDiskGroups.Contains(groupInstanceID))
                            {
                                dcGraph[row, col] = true;
                                dcGraph[col, row] = true;
                            }
                        }                      
                    }
                }
            }

            // evaluate DCs connected by policies
            List<List<MigrationDataContainer>> connectedDCs = new List<List<MigrationDataContainer>>();
            for (int index = 0; index < dcArray.Count(); index++)
            {
                if (dcArray[index].Visited == false)
                {
                    connectedDCs.Add(RunDFS(dcGraph, dcArray, index, new List<MigrationDataContainer>()));
                }
            }

            return connectedDCs;
        }

        /// <summary>
        /// Data container node
        /// </summary>
        private class DataContainerInfo
        {
            public MigrationDataContainer DcInfo;
            public List<string> VirtualDiskGroups;
            public bool Visited;
        }

        /// <summary>
        /// DFS algorithm to traverse through the data container graph and returns dependent container list
        /// </summary>
        /// <param name="dcGraph">data container graph</param>
        /// <param name="dcArray">list of data containers</param>
        /// <param name="startingNode">starting node for traversal</param>
        /// <param name="traversedNodes">list of nodes already discovered from previous iteration (to start with this pass as empty)</param>
        /// <returns>dependent data container list</returns>
        private List<MigrationDataContainer> RunDFS(bool[,] dcGraph,
            DataContainerInfo[] dcArray,
            int startingNode,
            List<MigrationDataContainer> traversedNodes)
        {
            traversedNodes.Add(dcArray[startingNode].DcInfo);
            dcArray[startingNode].Visited = true;

            for (int index = 0; index < dcArray.Count(); index++)
            {
                if ((dcGraph[startingNode, index] == true) && (dcArray[index].Visited == false))
                {
                    RunDFS(dcGraph, dcArray, index, traversedNodes);
                }
            }

            return traversedNodes;
        }
       
    }

    /// <summary>
    /// Overall Status of data container migration
    /// </summary>
    public class DataContainerMigrationStatus 
    {
        /// <summary>
        /// Gets or sets Config ID of migration instance under consideration
        /// </summary>
        public string ConfigId { get; set; }

        /// <summary>
        /// Gets or sets the list of migration state, where MigrationState is Completed
        /// </summary>
        public LegacyDataContainerMigrationStatus MigrationCompleted { get; set; }

        /// <summary>
        /// Gets or sets the list of migration state, where MigrationState is InProgress
        /// </summary>
        public LegacyDataContainerMigrationStatus MigrationInprogresss { get; set; }

        /// <summary>
        /// Gets or sets the list of migration state, where MigrationState is NotStarted
        /// </summary>
        public LegacyDataContainerMigrationStatus MigrationNotStarted { get; set; }

        /// <summary>
        /// Gets or sets the list of migration state, where MigrationState is Failed
        /// </summary>
        public LegacyDataContainerMigrationStatus MigrationFailed { get; set; }

        /// <summary>
        /// Data container migration status
        /// </summary>
        /// <param name="configId">ConfigId corresponding to current instance of migration</param>
        /// <param name="overallStatusList">Overall list of status obtained from service</param>
        public DataContainerMigrationStatus(string configId, List<MigrationDataContainerStatus> overallStatusList)
        {
            this.ConfigId = configId;
            this.MigrationNotStarted = new LegacyDataContainerMigrationStatus(overallStatusList, MigrationStatus.NotStarted);
            this.MigrationInprogresss = new LegacyDataContainerMigrationStatus(overallStatusList, MigrationStatus.InProgress);
            this.MigrationFailed = new LegacyDataContainerMigrationStatus(overallStatusList, MigrationStatus.Failed);
            this.MigrationCompleted = new LegacyDataContainerMigrationStatus(overallStatusList, MigrationStatus.Completed);
        }

    }

    /// <summary>
    /// Status migration in one particular Migration state
    /// </summary>
    public class LegacyDataContainerMigrationStatus
    {
        /// <summary>
        /// Migration status in Migration state the state specified
        /// </summary>
        public List<MigrationDataContainerStatus> StatusList { get; set; }

        /// <summary>
        /// Migration State
        /// </summary>
        private MigrationStatus migrationState;

        /// <summary>
        /// Constructor - Constructor LegacyDataContainerMigrationStatus object of given MigrationStatus, by filter from overall status list provided 
        /// </summary>
        /// <param name="overallStatusList">overall migration status</param>
        /// <param name="type">MigrationStatus of the list of stored</param>
        public LegacyDataContainerMigrationStatus(List<MigrationDataContainerStatus> overallStatusList, MigrationStatus type)
        {
            this.StatusList = new List<MigrationDataContainerStatus>();
            this.migrationState = type;
            if (null != overallStatusList)
            {
                this.StatusList.AddRange(overallStatusList.FindAll(status => type == status.Status));
            }
        }

        /// <summary>
        /// Displays the content in the desired format
        /// </summary>
        /// <returns>format content to be displayed</returns>
        public override string ToString()
        {
            try
            {
                StringBuilder consoleop = new StringBuilder();
                if (null != this.StatusList && 0 < this.StatusList.Count)
                {
                    foreach (MigrationDataContainerStatus status in this.StatusList)
                    {
                        consoleop.AppendLine(string.Format("VolumeContainer : {0}", status.DataContainerName));
                        consoleop.AppendLine(string.Format("PercentageCompleted : {0}", status.PercentageCompleted));
                        consoleop.AppendLine(string.Format("MigrationStatus : {0}", status.Status.ToString()));
                        if (null != status.BackupSets && 0 < status.BackupSets.Count)
                        {
                            consoleop.AppendLine("BackupSets :");
                            foreach (MigrationBackupSet backupSet in status.BackupSets)
                            {
                                consoleop.AppendLine(string.Format("\tPolicy : {0}, Status : {1}", backupSet.BackupPolicyName, backupSet.Status.ToString()));
                                if (!string.IsNullOrEmpty(backupSet.Message.Message))
                                {
                                    consoleop.Append(string.Format(", Message : {0}", backupSet.Message.Message));
                                }

                                if (!string.IsNullOrEmpty(backupSet.Message.Recommendation))
                                {
                                    consoleop.Append(string.Format(", Recommendation : {0}", backupSet.Message.Recommendation));
                                }
                            }
                        }
                        else
                        {
                            consoleop.AppendLine(Resources.MigrationBackupSetNotFound);
                        }

                        consoleop.AppendLine();
                    }                    
                }
                else
                {
                    return string.Format(Resources.MigrationNoDataContainerInGivenStateOfMigration, this.migrationState.ToString());
                }

                return consoleop.ToString();
            }
            catch (Exception)
            {
                // powershell will consume the exception, and no details will be displayed if the exception is thrown, hence handling and returning error string.
                return Resources.MigrationErrorInParsingDisplayContent;
            }
        }
    }

    /// <summary>
    /// Confirm Migration status msg
    /// </summary>
    public class ConfirmMigrationStatusMsg
    {
        public string ConfigId { get; set;}
        public ConfirmMigrationStatus MigrationNotStarted {get;set;}
        public ConfirmMigrationStatus MigrationInProgress {get;set;}
        public ConfirmMigrationStatus MigrationComplete  {get;set;}
        public ConfirmMigrationStatus MigrationFailed  {get;set;}
        public ConfirmMigrationStatus CommitInProgress  {get;set;}
        public ConfirmMigrationStatus CommitComplete  {get;set;}
        public ConfirmMigrationStatus CommitFailed  {get;set;}
        public ConfirmMigrationStatus RollbackInProgress  {get;set;}
        public ConfirmMigrationStatus RollbackComplete  {get;set;}
        public ConfirmMigrationStatus RollbackFailed { get; set; }

        /// <summary>
        /// Constructor - Groups the confirmation status based on status
        /// </summary>
        /// <param name="configID">config id</param>
        /// <param name="overallStatus">overall status of migration</param>
        public ConfirmMigrationStatusMsg(string configID, ConfirmStatus overallStatus)
        {
            this.ConfigId = configID;
            this.MigrationNotStarted = new ConfirmMigrationStatus(MigrationDataContainerConfirmStatus.MigrationNotStarted, overallStatus);
            this.MigrationInProgress = new ConfirmMigrationStatus(MigrationDataContainerConfirmStatus.MigrationInProgress, overallStatus);
            this.MigrationFailed = new ConfirmMigrationStatus(MigrationDataContainerConfirmStatus.MigrationFailed, overallStatus);
            this.MigrationComplete = new ConfirmMigrationStatus(MigrationDataContainerConfirmStatus.MigrationComplete, overallStatus);

            this.CommitInProgress = new ConfirmMigrationStatus(MigrationDataContainerConfirmStatus.CommitInProgress, overallStatus);
            this.CommitFailed = new ConfirmMigrationStatus(MigrationDataContainerConfirmStatus.CommitFailed, overallStatus);
            this.CommitComplete = new ConfirmMigrationStatus(MigrationDataContainerConfirmStatus.CommitComplete, overallStatus);

            this.RollbackInProgress = new ConfirmMigrationStatus(MigrationDataContainerConfirmStatus.RollbackInProgress, overallStatus);
            this.RollbackFailed = new ConfirmMigrationStatus(MigrationDataContainerConfirmStatus.RollbackFailed, overallStatus);
            this.RollbackComplete = new ConfirmMigrationStatus(MigrationDataContainerConfirmStatus.RollbackComplete, overallStatus);
        }

        /// <summary>
        /// Converts the Migration status message to string
        /// </summary>
        /// <returns>Message string</returns>
        public override string ToString()
        {
            StringBuilder consoleop = new StringBuilder();
            if ((null != this.MigrationNotStarted.ConfirmStatus && 0 < this.MigrationNotStarted.ConfirmStatus.Count) ||
                (null != this.MigrationInProgress.ConfirmStatus && 0 < this.MigrationInProgress.ConfirmStatus.Count) ||
                (null != this.MigrationComplete.ConfirmStatus && 0 < this.MigrationComplete.ConfirmStatus.Count) ||
                (null != this.MigrationFailed.ConfirmStatus && 0 < this.MigrationFailed.ConfirmStatus.Count) ||
                (null != this.CommitInProgress.ConfirmStatus && 0 < this.CommitInProgress.ConfirmStatus.Count) ||
                (null != this.CommitComplete.ConfirmStatus && 0 < this.CommitComplete.ConfirmStatus.Count) ||
                (null != this.CommitFailed.ConfirmStatus && 0 < this.CommitFailed.ConfirmStatus.Count) ||
                (null != this.RollbackInProgress.ConfirmStatus && 0 < this.RollbackInProgress.ConfirmStatus.Count) ||
                (null != this.RollbackComplete.ConfirmStatus && 0 < this.RollbackComplete.ConfirmStatus.Count) ||
                (null != this.RollbackFailed.ConfirmStatus && 0 < this.RollbackFailed.ConfirmStatus.Count))
            {
                if(null != this.MigrationNotStarted.ConfirmStatus && 0 < this.MigrationNotStarted.ConfirmStatus.Count)
                {
                    consoleop.AppendLine("MigrationNotStarted:");
                    consoleop.AppendLine(this.MigrationNotStarted.ToString());
                }
                if (null != this.MigrationInProgress.ConfirmStatus && 0 < this.MigrationInProgress.ConfirmStatus.Count)
                {
                    consoleop.AppendLine("MigrationInProgress:");
                    consoleop.AppendLine(this.MigrationInProgress.ToString());
                }
                if (null != this.MigrationComplete.ConfirmStatus && 0 < this.MigrationComplete.ConfirmStatus.Count)
                {
                    consoleop.AppendLine("MigrationComplete:");
                    consoleop.AppendLine(this.MigrationComplete.ToString());
                }
                if (null != this.MigrationFailed.ConfirmStatus && 0 < this.MigrationFailed.ConfirmStatus.Count)
                {
                    consoleop.AppendLine("MigrationFailed:");
                    consoleop.AppendLine(this.MigrationFailed.ToString());
                }
                if (null != this.CommitInProgress.ConfirmStatus && 0 < this.CommitInProgress.ConfirmStatus.Count)
                {
                    consoleop.AppendLine("CommitInProgress:");
                    consoleop.AppendLine(this.CommitInProgress.ToString());
                }
                if (null != this.CommitComplete.ConfirmStatus && 0 < this.CommitComplete.ConfirmStatus.Count)
                {
                    consoleop.AppendLine("CommitComplete:");
                    consoleop.AppendLine(this.CommitComplete.ToString());
                }
                if (null != this.CommitFailed.ConfirmStatus && 0 < this.CommitFailed.ConfirmStatus.Count)
                {
                    consoleop.AppendLine("CommitFailed:");
                    consoleop.AppendLine(this.CommitFailed.ToString());
                }
                if (null != this.RollbackInProgress.ConfirmStatus && 0 < this.RollbackInProgress.ConfirmStatus.Count)
                {
                    consoleop.AppendLine("RollbackInProgress:");
                    consoleop.AppendLine(this.RollbackInProgress.ToString());
                }
                if (null != this.RollbackComplete.ConfirmStatus && 0 < this.RollbackComplete.ConfirmStatus.Count)
                {
                    consoleop.AppendLine("RollbackComplete:");
                    consoleop.AppendLine(this.RollbackComplete.ToString());
                }
                if (null != this.RollbackFailed.ConfirmStatus && 0 < this.RollbackFailed.ConfirmStatus.Count)
                {
                    consoleop.AppendLine("RollbackFailed:");
                    consoleop.AppendLine(this.RollbackFailed.ToString());
                }

                return consoleop.ToString();
            }
            
            return string.Format(Resources.MigrationConfirmMigrationStatusReturnedEmpty, this.ConfigId.ToString());
        }
    }

    /// <summary>
    /// Status of confirm migration
    /// </summary>
    public class ConfirmMigrationStatus
    {
        public List<ContainerConfirmStatus> ConfirmStatus { get; set; }

        public MigrationDataContainerConfirmStatus Status { get; set; }

        public ConfirmMigrationStatus(MigrationDataContainerConfirmStatus statusType, ConfirmStatus overallStatus)
        {
            this.Status = statusType;
            if (null != overallStatus)
            {
                List<ContainerConfirmStatus> statusList = new List<ContainerConfirmStatus>(overallStatus.ContainerConfirmStatus);
                this.ConfirmStatus = statusList.FindAll(status => status.Status == statusType);
            }
            else
            {
                this.ConfirmStatus = new List<ContainerConfirmStatus>();
            }
        }

        int CompareConfirmStatus(ContainerConfirmStatus rhs, ContainerConfirmStatus lhs)
        {
            return rhs.Status.CompareTo(lhs.Status);
        }

        public override string ToString()
        {
            StringBuilder consoleop = new StringBuilder();
            if(null != ConfirmStatus && 0 < ConfirmStatus.Count)
            {
                ConfirmStatus.Sort(CompareConfirmStatus);
                foreach (ContainerConfirmStatus status in ConfirmStatus)
                {
                    consoleop.AppendLine(string.Format("VolumeContainer : {0}", status.ContainerName));
                    consoleop.AppendLine(string.Format("Operation : {0}", status.Operation));
                    consoleop.AppendLine(string.Format("PercentageCompleted : {0}", status.PercentageComplete));
                    consoleop.AppendLine(string.Format("Status : {0}", status.Status));
                    if (null != status.StatusMessage && 0 < status.StatusMessage.Count)
                    {
                        consoleop.AppendLine("Messages :");
                        foreach(HcsMessageInfo msgInfo in status.StatusMessage)
                        {
                            if (!string.IsNullOrEmpty(msgInfo.Message) || !string.IsNullOrEmpty(msgInfo.Recommendation))
                            {
                                consoleop.AppendLine("\t");
                                if (!string.IsNullOrEmpty(msgInfo.Message))
                                {
                                    consoleop.Append(string.Format(" Message : {0}.", msgInfo.Message));
                                }
                                if (!string.IsNullOrEmpty(msgInfo.Recommendation))
                                {
                                    consoleop.Append(string.Format(" Recommendation : {0}.", msgInfo.Recommendation));
                                }
                            }
                        }
                    }

                    consoleop.AppendLine();
                }
            }
            
            return consoleop.ToString();
        }
    }
}