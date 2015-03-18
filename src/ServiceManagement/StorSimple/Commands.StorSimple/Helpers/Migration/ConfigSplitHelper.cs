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
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Security.Cryptography;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    internal class ConfigSplitHelper
    {
        private const int maxRank = 20;

        private static Dictionary<Type, int> ranks = new Dictionary<Type, int>()
        {
            {typeof (AccessControlRecord), 1},
            {typeof (StorageAccountCredential), 1},
            {typeof (MigrationChapSetting), 1},
            {typeof (VirtualDiskGroup), 1},
            {typeof (BandwidthSetting), 3},
            {typeof (MigrationBackupPolicy), 3},
            {typeof (MigrationDataContainer), 4},
            {typeof (VirtualDisk), 5}
        };
        // ACR, SAC, CHAP, VDG = 1, BW, BP = 3, DC = 4, Vol = 5
        public static List<LegacyApplianceConfig> Split(LegacyApplianceConfig inputConfig)
        {
            var splitConfig = new List<LegacyApplianceConfig>();
            var serialNumber = 1;
            var parentConfig = new LegacyApplianceConfig();

            parentConfig.AccessControlRecordList = new List<AccessControlRecord>(inputConfig.AccessControlRecordList);
            parentConfig.BackupPolicyList = new List<MigrationBackupPolicy>(inputConfig.BackupPolicyList);
            parentConfig.BandwidthSettingList = new List<BandwidthSetting>(inputConfig.BandwidthSettingList);
            parentConfig.DeviceId = inputConfig.DeviceId;
            if (inputConfig.InboundChapSettingList != null)
            {
                parentConfig.InboundChapSettingList = new List<MigrationChapSetting>(inputConfig.InboundChapSettingList);
            }
            parentConfig.InstanceId = inputConfig.InstanceId;
            parentConfig.Name = inputConfig.Name;
            parentConfig.OperationInProgress = inputConfig.OperationInProgress;
            parentConfig.SerialNumber = inputConfig.SerialNumber;
            parentConfig.StorageAccountCredentialList = new List<StorageAccountCredential>(inputConfig.StorageAccountCredentialList);
            if (inputConfig.TargetChapSettingList != null)
            {
                parentConfig.TargetChapSettingList = new List<MigrationChapSetting>(inputConfig.TargetChapSettingList);
            }
            parentConfig.TotalCount = inputConfig.TotalCount;
            parentConfig.VolumeContainerList = new List<MigrationDataContainer>(inputConfig.VolumeContainerList);
            parentConfig.VolumeGroupList = new List<VirtualDiskGroup>(inputConfig.VolumeGroupList);
            parentConfig.VolumeList = new List<VirtualDisk>(inputConfig.VolumeList);

            while (!IsConfigEmpty(parentConfig))
            {
                var config = new LegacyApplianceConfig();
                var currRank = 0;
                var rank = 0;
                var objectCountCanBeAccomodated = 0;
                var objectsAccomodated = 0;

                config.SerialNumber = serialNumber++;

                config.DeviceId = parentConfig.DeviceId;
                config.InstanceId = parentConfig.InstanceId;
                config.Name = parentConfig.Name;
                config.OperationInProgress = parentConfig.OperationInProgress;

                rank = FindRank(typeof (VirtualDisk));
                objectCountCanBeAccomodated = (maxRank - currRank)/rank;
                if (objectCountCanBeAccomodated > 0)
                {
                    objectsAccomodated = Math.Min(objectCountCanBeAccomodated,
                        parentConfig.VolumeList.Count);
                    config.VolumeList =
                        new List<VirtualDisk>(
                            config.VolumeList.Concat(
                                parentConfig.VolumeList.Take(objectsAccomodated)));
                    parentConfig.VolumeList =
                        RemoveFirstNItems(new List<VirtualDisk>(parentConfig.VolumeList),
                            objectsAccomodated);
                }
                else
                {
                    objectsAccomodated = 0;
                    config.VolumeList = new List<VirtualDisk>();
                }
                currRank += rank * objectsAccomodated;

                rank = FindRank(typeof (MigrationDataContainer));
                objectCountCanBeAccomodated = (maxRank - currRank)/rank;
                if (objectCountCanBeAccomodated > 0)
                {
                    objectsAccomodated = Math.Min(objectCountCanBeAccomodated,
                        parentConfig.VolumeContainerList.Count);
                    config.VolumeContainerList =
                        new List<MigrationDataContainer>(
                            config.VolumeContainerList.Concat(
                                parentConfig.VolumeContainerList.Take(objectsAccomodated)));
                    parentConfig.VolumeContainerList =
                        RemoveFirstNItems(new List<MigrationDataContainer>(parentConfig.VolumeContainerList),
                            objectsAccomodated);
                }
                else
                {
                    objectsAccomodated = 0;
                    config.VolumeContainerList = new List<MigrationDataContainer>();
                }
                currRank += rank * objectsAccomodated;

                rank = FindRank(typeof (MigrationBackupPolicy));
                objectCountCanBeAccomodated = (maxRank - currRank)/rank;
                if (objectCountCanBeAccomodated > 0)
                {
                    objectsAccomodated = Math.Min(objectCountCanBeAccomodated,
                        parentConfig.BackupPolicyList.Count);
                    config.BackupPolicyList =
                        new List<MigrationBackupPolicy>(
                            config.BackupPolicyList.Concat(
                                parentConfig.BackupPolicyList.Take(objectsAccomodated)));
                    parentConfig.BackupPolicyList =
                        RemoveFirstNItems(new List<MigrationBackupPolicy>(parentConfig.BackupPolicyList),
                            objectsAccomodated);
                }
                else
                {
                    objectsAccomodated = 0;
                    config.BackupPolicyList = new List<MigrationBackupPolicy>();
                }
                currRank += rank * objectsAccomodated;

                rank = FindRank(typeof (BandwidthSetting));
                objectCountCanBeAccomodated = (maxRank - currRank)/rank;
                if (objectCountCanBeAccomodated > 0)
                {
                    objectsAccomodated = Math.Min(objectCountCanBeAccomodated,
                        parentConfig.BandwidthSettingList.Count);
                    config.BandwidthSettingList =
                        new List<BandwidthSetting>(
                            config.BandwidthSettingList.Concat(
                                parentConfig.BandwidthSettingList.Take(objectsAccomodated)));
                    parentConfig.BandwidthSettingList =
                        RemoveFirstNItems(new List<BandwidthSetting>(parentConfig.BandwidthSettingList),
                            objectsAccomodated);
                }
                else
                {
                    objectsAccomodated = 0;
                    config.BandwidthSettingList = new List<BandwidthSetting>();
                }
                currRank += rank * objectsAccomodated;

                rank = FindRank(typeof (VirtualDiskGroup));
                objectCountCanBeAccomodated = (maxRank - currRank)/rank;
                if (objectCountCanBeAccomodated > 0)
                {
                    objectsAccomodated = Math.Min(objectCountCanBeAccomodated,
                        parentConfig.VolumeGroupList.Count);
                    config.VolumeGroupList =
                        new List<VirtualDiskGroup>(
                            config.VolumeGroupList.Concat(
                                parentConfig.VolumeGroupList.Take(objectsAccomodated)));
                    parentConfig.VolumeGroupList =
                        RemoveFirstNItems(new List<VirtualDiskGroup>(parentConfig.VolumeGroupList),
                            objectsAccomodated);
                }
                else
                {
                    objectsAccomodated = 0;
                    config.VolumeGroupList = new List<VirtualDiskGroup>();
                }
                currRank += rank * objectsAccomodated;

                if (parentConfig.InboundChapSettingList != null)
                {
                    rank = FindRank(typeof (MigrationChapSetting));
                    objectCountCanBeAccomodated = (maxRank - currRank)/rank;
                    if (objectCountCanBeAccomodated > 0)
                    {
                        objectsAccomodated = Math.Min(objectCountCanBeAccomodated,
                            parentConfig.InboundChapSettingList.Count);
                        config.InboundChapSettingList =
                            new List<MigrationChapSetting>(
                                config.InboundChapSettingList.Concat(
                                    parentConfig.InboundChapSettingList.Take(objectsAccomodated)));
                        parentConfig.InboundChapSettingList =
                            RemoveFirstNItems(new List<MigrationChapSetting>(parentConfig.InboundChapSettingList),
                                objectsAccomodated);
                    }
                    else
                    {
                        objectsAccomodated = 0;
                        config.InboundChapSettingList = new List<MigrationChapSetting>();
                    }
                    currRank += rank*objectsAccomodated;
                }

                if (parentConfig.TargetChapSettingList != null)
                {
                    rank = FindRank(typeof (MigrationChapSetting));
                    objectCountCanBeAccomodated = (maxRank - currRank)/rank;
                    if (objectCountCanBeAccomodated > 0)
                    {
                        objectsAccomodated = Math.Min(objectCountCanBeAccomodated,
                            parentConfig.TargetChapSettingList.Count);
                        config.TargetChapSettingList =
                            new List<MigrationChapSetting>(
                                config.TargetChapSettingList.Concat(
                                    parentConfig.TargetChapSettingList.Take(objectsAccomodated)));
                        parentConfig.TargetChapSettingList =
                            RemoveFirstNItems(new List<MigrationChapSetting>(parentConfig.TargetChapSettingList),
                                objectsAccomodated);
                    }
                    else
                    {
                        objectsAccomodated = 0;
                        config.TargetChapSettingList = new List<MigrationChapSetting>();
                    }
                    currRank += rank*objectsAccomodated;
                }

                rank = FindRank(typeof (StorageAccountCredential));
                objectCountCanBeAccomodated = (maxRank - currRank)/rank;
                if (objectCountCanBeAccomodated > 0)
                {
                    objectsAccomodated = Math.Min(objectCountCanBeAccomodated,
                        parentConfig.StorageAccountCredentialList.Count);
                    config.StorageAccountCredentialList =
                        new List<StorageAccountCredential>(
                            config.StorageAccountCredentialList.Concat(
                                parentConfig.StorageAccountCredentialList.Take(objectsAccomodated)));
                    parentConfig.StorageAccountCredentialList =
                        RemoveFirstNItems(new List<StorageAccountCredential>(parentConfig.StorageAccountCredentialList),
                            objectsAccomodated);
                }
                else
                {
                    objectsAccomodated = 0;
                    config.StorageAccountCredentialList = new List<StorageAccountCredential>();
                }
                currRank += rank * objectsAccomodated;

                rank = FindRank(typeof (AccessControlRecord));
                objectCountCanBeAccomodated = (maxRank - currRank)/rank;
                if (objectCountCanBeAccomodated > 0)
                {
                    objectsAccomodated = Math.Min(objectCountCanBeAccomodated,
                        parentConfig.AccessControlRecordList.Count);
                    config.AccessControlRecordList =
                        new List<AccessControlRecord>(
                            config.AccessControlRecordList.Concat(
                                parentConfig.AccessControlRecordList.Take(objectsAccomodated)));
                    parentConfig.AccessControlRecordList =
                        RemoveFirstNItems(new List<AccessControlRecord>(parentConfig.AccessControlRecordList),
                            objectsAccomodated);
                }
                else
                {
                    objectsAccomodated = 0;
                    config.AccessControlRecordList = new List<AccessControlRecord>();
                }
                //currRank += rank * objectsAccomodated;

                splitConfig.Add(config);
            }

            foreach (var config in splitConfig)
            {
                config.TotalCount = splitConfig.Count;
            }

            return splitConfig;
        }

        private static bool IsConfigEmpty(LegacyApplianceConfig config)
        {
            return config.AccessControlRecordList.Count == 0 &&
                   config.BackupPolicyList.Count == 0 &&
                   config.BandwidthSettingList.Count == 0 &&
                   (config.InboundChapSettingList == null || config.InboundChapSettingList.Count == 0) &&
                   config.StorageAccountCredentialList.Count == 0 &&
                   (config.TargetChapSettingList == null || config.TargetChapSettingList.Count == 0) &&  
                   config.VolumeContainerList.Count == 0 &&
                   config.VolumeGroupList.Count == 0 &&
                   config.VolumeList.Count == 0;
        }

        private static int FindRank(Type T)
        {
            return ranks[T];
        }

        private static List<T> RemoveFirstNItems<T>(List<T> list, int count)
        {
            list.RemoveRange(0, count);
            return list;
        }
    }
}