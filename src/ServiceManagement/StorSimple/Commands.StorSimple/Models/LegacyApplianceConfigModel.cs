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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Models
{
    /// <summary>
    /// Legacy appliance configuration to be returned by import legacy config cmdlet
    /// </summary>
    public class LegacyApplianceConfiguration
    {
        public string LegacyConfigId { get; set; }
        public DateTime ImportedOn { get; set; }
        public string ConfigFile { get; set; }
        public string TargetApplianceName { get; set; }
        public LegacyApplianceDetails Details { get; set; }
        public string Result { get; set; }
    }

    /// <summary>
    /// Represents the parsed config metadata to be send as input for migration
    /// </summary>
    public class LegacyApplianceDetails : LegacyApplianceConfig
    {
        /// <summary>
        /// List of container names of volume containers to be migrated together
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
                            consoleOutput.Append("\t");
                            consoleOutput.AppendFormat(Resources.MigrationVolumeContainerRelatedGroupSubHeader, ++groupCount).AppendLine();
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
        /// <returns>formatted o/p</returns>
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

}