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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Management.Batch.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Microsoft.Azure.Commands.Batch.Utils
{
    /// <summary>
    /// Helper class
    /// </summary>
    internal static class Utils
    {
        /// <summary>
        /// Syncs the collections on a bound PSCloudPool with its wrapped OM object
        /// </summary>
        internal static void BoundPoolSyncCollections(PSCloudPool pool)
        {
            if (pool != null)
            {
                pool.omObject.ApplicationPackageReferences = CreateSyncedList(pool.ApplicationPackageReferences,
                (apr) =>
                {
                    return ConvertApplicationPackageReference(apr);
                });

                pool.omObject.Metadata = CreateSyncedDict(pool.Metadata, ConvertMetadataItem);

                if (pool.StartTask != null)
                {
                    StartTaskSyncCollections(pool.StartTask);
                }
            }
        }

        /// <summary>
        /// Syncs the collections on a bound PSCloudJobSchedule with its wrapped OM object
        /// </summary>
        internal static void BoundJobScheduleSyncCollections(PSCloudJobSchedule jobSchedule)
        {
            if (jobSchedule != null)
            {
                jobSchedule.omObject.Metadata = CreateSyncedDict(jobSchedule.Metadata, ConvertMetadataItem);

                if (jobSchedule.JobSpecification != null)
                {
                    JobSpecificationSyncCollections(jobSchedule.JobSpecification);
                }
            }
        }

        /// <summary>
        /// Syncs the collections on a bound PSCloudJob with its wrapped OM object
        /// </summary>
        internal static void BoundJobSyncCollections(PSCloudJob job)
        {
            if (job != null)
            {
                job.omObject.Metadata = CreateSyncedDict(job.Metadata, ConvertMetadataItem);
                if (job.PoolInformation != null)
                {
                    PoolInformationSyncCollections(job.PoolInformation);
                }
            }
        }

        /// <summary>
        /// Syncs the collections on a PSJobSpecification with its wrapped OM object
        /// </summary>
        internal static void JobSpecificationSyncCollections(PSJobSpecification specification)
        {
            if (specification != null)
            {
                specification.omObject.CommonEnvironmentSettings = CreateSyncedDict(
                    specification.CommonEnvironmentSettings,
                    ConvertEnvironmentSetting);

                if (specification.JobManagerTask != null)
                {
                    JobManagerTaskSyncCollections(specification.JobManagerTask);
                }

                if (specification.JobPreparationTask != null)
                {
                    JobPreparationTaskSyncCollections(specification.JobPreparationTask);
                }

                if (specification.JobReleaseTask != null)
                {
                    JobReleaseTaskSyncCollections(specification.JobReleaseTask);
                }

                specification.omObject.Metadata = CreateSyncedDict(specification.Metadata, ConvertMetadataItem);

                if (specification.PoolInformation != null)
                {
                    PoolInformationSyncCollections(specification.PoolInformation);
                }
            }
        }

        /// <summary>
        /// Syncs the collections on a PSJobManagerTask with its wrapped OM object
        /// </summary>
        internal static void JobManagerTaskSyncCollections(PSJobManagerTask jobManager)
        {
            if (jobManager != null)
            {
                jobManager.omObject.EnvironmentSettings = CreateSyncedDict(
                    jobManager.EnvironmentSettings,
                    ConvertEnvironmentSetting);

                jobManager.omObject.ResourceFiles = CreateSyncedList(jobManager.ResourceFiles, ConvertResourceFile);
                jobManager.omObject.OutputFiles = CreateSyncedList(jobManager.OutputFiles, ps => ps.omObject);
                jobManager.omObject.ApplicationPackageReferences = CreateSyncedList(jobManager.ApplicationPackageReferences,
                    a =>
                    {
                        Microsoft.Azure.Batch.ApplicationPackageReference applicationPackageReference = new Microsoft.Azure.Batch.ApplicationPackageReference
                        {
                            ApplicationId = a.ApplicationId,
                            Version = a.Version
                        };
                        return applicationPackageReference;
                    });
            }
        }

        /// <summary>
        /// Syncs the collections on a PSJobPreparationTask with its wrapped OM object
        /// </summary>
        internal static void JobPreparationTaskSyncCollections(PSJobPreparationTask jobPrepTask)
        {
            if (jobPrepTask != null)
            {
                jobPrepTask.omObject.EnvironmentSettings = CreateSyncedDict(
                    jobPrepTask.EnvironmentSettings,
                    ConvertEnvironmentSetting);

                jobPrepTask.omObject.ResourceFiles = CreateSyncedList(jobPrepTask.ResourceFiles, ConvertResourceFile);
            }
        }

        /// <summary>
        /// Syncs the collections on a PSJobReleaseTask with its wrapped OM object
        /// </summary>
        internal static void JobReleaseTaskSyncCollections(PSJobReleaseTask jobReleaseTask)
        {
            if (jobReleaseTask != null)
            {
                jobReleaseTask.omObject.EnvironmentSettings = CreateSyncedDict(
                    jobReleaseTask.EnvironmentSettings,
                    ConvertEnvironmentSetting);

                jobReleaseTask.omObject.ResourceFiles = CreateSyncedList(jobReleaseTask.ResourceFiles, ConvertResourceFile);
            }
        }

        /// <summary>
        /// Syncs the collections on a PSPoolInformation with its wrapped OM object
        /// </summary>
        internal static void PoolInformationSyncCollections(PSPoolInformation poolInfo)
        {
            if (poolInfo != null)
            {
                if (poolInfo.AutoPoolSpecification != null)
                {
                    AutoPoolSpecificationSyncCollections(poolInfo.AutoPoolSpecification);
                }
            }
        }

        /// <summary>
        /// Syncs the collections on a PSAutoPoolSpecification with its wrapped OM object
        /// </summary>
        internal static void AutoPoolSpecificationSyncCollections(PSAutoPoolSpecification spec)
        {
            if (spec != null)
            {
                if (spec.PoolSpecification != null)
                {
                    PoolSpecificationSyncCollections(spec.PoolSpecification);
                }
            }
        }

        /// <summary>
        /// Syncs the collections on a PSPoolSpecification with its wrapped OM object
        /// </summary>
        internal static void PoolSpecificationSyncCollections(PSPoolSpecification spec)
        {
            if (spec != null)
            {
                spec.omObject.Metadata = CreateSyncedDict(
                    spec.Metadata,
                    ConvertMetadataItem);

                spec.omObject.ApplicationPackageReferences = CreateSyncedList(spec.ApplicationPackageReferences,
                    (apr) =>
                    {
                        return new Microsoft.Azure.Batch.ApplicationPackageReference()
                        {
                            ApplicationId = apr.ApplicationId,
                            Version = apr.Version
                        };
                    });

                spec.omObject.UserAccounts = CreateSyncedList(spec.UserAccounts,
                    (user) =>
                    {
                        return new Microsoft.Azure.Batch.UserAccount(
                            user.Name,
                            user.Password,
                            user.ElevationLevel,
                            user.LinuxUserConfiguration?.omObject);
                    });

                if (spec.StartTask != null)
                {
                    StartTaskSyncCollections(spec.StartTask);
                }

                VirtualMachineConfigurationSyncCollections(spec.VirtualMachineConfiguration);
            }
        }

        /// <summary>
        /// Syncs the collections on a PSCloudTask with its wrapped OM object
        /// </summary>
        internal static void CloudTaskSyncCollections(PSCloudTask task)
        {
            if (task != null)
            {
                task.omObject.EnvironmentSettings = CreateSyncedDict(
                    task.EnvironmentSettings,
                    ConvertEnvironmentSetting);

                task.omObject.ResourceFiles = CreateSyncedList(task.ResourceFiles, ConvertResourceFile);
                task.omObject.OutputFiles = CreateSyncedList(task.OutputFiles, ps => ps.omObject);
                task.omObject.ApplicationPackageReferences = CreateSyncedList(task.ApplicationPackageReferences, ps => ps.omObject);
                ExitConditionsSyncCollections(task.ExitConditions);

                MultiInstanceSettingsSyncCollections(task.MultiInstanceSettings);
            }
        }

        /// <summary>
        /// Syncs the collections on a PSStartTask with its wrapped OM object
        /// </summary>
        internal static void StartTaskSyncCollections(PSStartTask startTask)
        {
            if (startTask != null)
            {
                startTask.omObject.EnvironmentSettings = CreateSyncedDict(
                    startTask.EnvironmentSettings,
                    ConvertEnvironmentSetting);

                startTask.omObject.ResourceFiles = CreateSyncedList(startTask.ResourceFiles, ConvertResourceFile);
            }
        }

        /// <summary>
        /// Syncs the collections on a PSVirtualMachineConfiguration with its wrapped OM object
        /// </summary>
        internal static void VirtualMachineConfigurationSyncCollections(PSVirtualMachineConfiguration virtualMachineConfiguration)
        {
            if (virtualMachineConfiguration != null)
            {
                if (virtualMachineConfiguration.omObject.ContainerConfiguration != null)
                {
                    virtualMachineConfiguration.omObject.ContainerConfiguration.ContainerImageNames =
                        CreateSyncedList(virtualMachineConfiguration.ContainerConfiguration.ContainerImageNames, s => s);

                    virtualMachineConfiguration.omObject.ContainerConfiguration.ContainerRegistries =
                        CreateSyncedList(virtualMachineConfiguration.ContainerConfiguration.ContainerRegistries, ps => ps.omObject);
                }

                virtualMachineConfiguration.omObject.DataDisks = CreateSyncedList(virtualMachineConfiguration.DataDisks, ps => ps.omObject);
                virtualMachineConfiguration.omObject.Extensions = CreateSyncedList(virtualMachineConfiguration.Extensions, ps => ps.omObject);
            }
        }

        /// <summary>
        /// Syncs the collections on a PSMultiInstanceSettings with its wrapped OM object
        /// </summary>
        internal static void MultiInstanceSettingsSyncCollections(PSMultiInstanceSettings multiInstanceSettings)
        {
            if (multiInstanceSettings != null)
            {
                multiInstanceSettings.omObject.CommonResourceFiles = CreateSyncedList(multiInstanceSettings.CommonResourceFiles, ConvertResourceFile);
            }
        }

        /// <summary>
        /// Creates a list of OM objects matching a list of PowerShell objects
        /// </summary>
        /// <typeparam name="Tps">The type of the PowerShell class</typeparam>
        /// <typeparam name="Tom">The type of the OM class</typeparam>
        /// <param name="psList">The list of PowerShell items</param>
        /// <param name="mappingFunction">The function to create a matching OM item</param>
        /// <returns>A list of OM objects matching a list of PowerShell objects</returns>
        private static IList<Tom> CreateSyncedList<Tps, Tom>(IEnumerable<Tps> psList, Func<Tps, Tom> mappingFunction)
        {
            if (psList == null)
            {
                return null;
            }

            List<Tom> omList = new List<Tom>();
            foreach (Tps item in psList)
            {
                Tom omItem = mappingFunction(item);
                omList.Add(omItem);
            }
            return omList;
        }

        private static IList<Tom> CreateSyncedDict<Tom>(IDictionary psDict, Func<string, string, Tom> mappingFunction)
        {
            if (psDict == null)
            {
                return null;
            }

            List<Tom> omList = new List<Tom>();
            foreach (DictionaryEntry item in psDict)
            {
                Tom omItem = mappingFunction(item.Key.ToString(), item.Value.ToString());
                omList.Add(omItem);
            }
            return omList;
        }

        private static Microsoft.Azure.Batch.MetadataItem ConvertMetadataItem(string key, string value) => new Microsoft.Azure.Batch.MetadataItem(key, value);

        private static Microsoft.Azure.Batch.EnvironmentSetting ConvertEnvironmentSetting(string key, string value) => new Microsoft.Azure.Batch.EnvironmentSetting(key, value);

        /// <summary>
        /// Converts a PSApplicationPackageReference to a ApplicationPackageReference
        /// </summary>
        private static Microsoft.Azure.Batch.ApplicationPackageReference ConvertApplicationPackageReference(PSApplicationPackageReference psApr)
        {
            Microsoft.Azure.Batch.ApplicationPackageReference applicationPackageReference = new Microsoft.Azure.Batch.ApplicationPackageReference()
            {
                ApplicationId = psApr.ApplicationId,
                Version = psApr.Version
            };
            return applicationPackageReference;
        }

        public static void ExitConditionsSyncCollections(PSExitConditions exitConditions)
        {
            if (exitConditions != null)
            {
                exitConditions.omObject.ExitCodeRanges = CreateSyncedList(
                    exitConditions.ExitCodeRanges,
                    (e) =>
                    {
                        ExitCodeRangeMapping exitCodeRangeMapping = new ExitCodeRangeMapping(e.Start, e.End, e.omObject.ExitOptions);
                        return exitCodeRangeMapping;
                    });
                exitConditions.omObject.ExitCodes = CreateSyncedList(exitConditions.ExitCodes,
                    (e) =>
                    {
                        ExitCodeMapping exitCodeMapping = new ExitCodeMapping(e.Code, e.omObject.ExitOptions);
                        return exitCodeMapping;
                    });
            }
        }

        internal static Microsoft.Azure.Batch.ResourceFile ConvertResourceFile(PSResourceFile psResourceFile)
        {
            if (!string.IsNullOrEmpty(psResourceFile.AutoStorageContainerName))
            {
                return Microsoft.Azure.Batch.ResourceFile.FromAutoStorageContainer(
                    psResourceFile.AutoStorageContainerName,
                    filePath: psResourceFile.FilePath,
                    blobPrefix: psResourceFile.BlobPrefix,
                    fileMode: psResourceFile.FileMode);
            }
            else if (!string.IsNullOrEmpty(psResourceFile.StorageContainerUrl))
            {
                return Microsoft.Azure.Batch.ResourceFile.FromStorageContainerUrl(
                    psResourceFile.StorageContainerUrl,
                    filePath: psResourceFile.FilePath,
                    blobPrefix: psResourceFile.BlobPrefix,
                    fileMode: psResourceFile.FileMode);
            }
            else if (!string.IsNullOrEmpty(psResourceFile.HttpUrl))
            {
                return Microsoft.Azure.Batch.ResourceFile.FromUrl(
                   psResourceFile.HttpUrl,
                   filePath: psResourceFile.FilePath,
                   fileMode: psResourceFile.FileMode);
            }
            else
            {
                throw new ArgumentException($"ResourceFile missing expected fields");
            }
        }

        internal static UpgradeMode toMgmtUpgradeMode(Azure.Batch.Common.UpgradeMode psUpgradeMode)
        {
            switch (psUpgradeMode)
            {
                case Azure.Batch.Common.UpgradeMode.Manual:
                    return UpgradeMode.Manual;
                case Azure.Batch.Common.UpgradeMode.Automatic:
                    return UpgradeMode.Automatic;
                case Azure.Batch.Common.UpgradeMode.Rolling:
                    return UpgradeMode.Rolling;
                default:
                    throw new ArgumentOutOfRangeException(nameof(psUpgradeMode), psUpgradeMode, null);
            }
        }

        internal static Azure.Batch.Common.UpgradeMode fromMgmtUpgradeMode(UpgradeMode mgmtUpgradeMode)
        {
            switch (mgmtUpgradeMode)
            {
                case UpgradeMode.Manual:
                    return Azure.Batch.Common.UpgradeMode.Manual;
                case UpgradeMode.Automatic:
                    return Azure.Batch.Common.UpgradeMode.Automatic;
                case UpgradeMode.Rolling:
                    return Azure.Batch.Common.UpgradeMode.Rolling;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mgmtUpgradeMode), mgmtUpgradeMode, null);
            }
        }

        internal static ComputeNodeFillType toMgmtComputeNodeFillType(Azure.Batch.Common.ComputeNodeFillType psComputeNodeFillType)
        {
            switch (psComputeNodeFillType)
            {
                case Azure.Batch.Common.ComputeNodeFillType.Pack:
                    return ComputeNodeFillType.Pack;
                case Azure.Batch.Common.ComputeNodeFillType.Spread:
                    return ComputeNodeFillType.Spread;
                default:
                    throw new ArgumentOutOfRangeException(nameof(psComputeNodeFillType), psComputeNodeFillType, null);
            }
        }

        internal static Azure.Batch.Common.ComputeNodeFillType fromMgmtComputeNodeFillType(ComputeNodeFillType mgmtComputeNodeFillType)
        {
            switch (mgmtComputeNodeFillType)
            {
                case ComputeNodeFillType.Pack:
                    return Azure.Batch.Common.ComputeNodeFillType.Pack;
                case ComputeNodeFillType.Spread:
                    return Azure.Batch.Common.ComputeNodeFillType.Spread;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mgmtComputeNodeFillType), mgmtComputeNodeFillType, null);
            }
        }

        internal static ContainerWorkingDirectory? toMgmtContainerWorkingDirectory(Azure.Batch.Common.ContainerWorkingDirectory? value)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (value)
            {
                case Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory:
                    return ContainerWorkingDirectory.TaskWorkingDirectory;
                case Azure.Batch.Common.ContainerWorkingDirectory.ContainerImageDefault:
                    return ContainerWorkingDirectory.ContainerImageDefault;
                default:
                    return null;
            }
        }

        internal static Azure.Batch.Common.ContainerWorkingDirectory? fromMgmtContainerWorkingDirectory(ContainerWorkingDirectory? value)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (value.Value)
            {
                case ContainerWorkingDirectory.TaskWorkingDirectory:
                    return Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory;
                case ContainerWorkingDirectory.ContainerImageDefault:
                    return Azure.Batch.Common.ContainerWorkingDirectory.ContainerImageDefault;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        internal static IList<Management.Batch.Models.ContainerHostBatchBindMountEntry> toMgmtContainerHostBatchBindMounts(IList<PSContainerHostBatchBindMountEntry> containerHostBatchBindMounts)
        {
            if (containerHostBatchBindMounts == null)
            {
                return null;
            }
            List<Management.Batch.Models.ContainerHostBatchBindMountEntry> mgmtContainerHostBatchBindMounts = new List<Management.Batch.Models.ContainerHostBatchBindMountEntry>();

            foreach (var mount in containerHostBatchBindMounts)
            {
                mgmtContainerHostBatchBindMounts.Add(new Management.Batch.Models.ContainerHostBatchBindMountEntry
                {
                    Source = mount.Source,
                    IsReadOnly = mount.IsReadOnly
                });
            }
            return mgmtContainerHostBatchBindMounts;
        }

        internal static IList<PSContainerHostBatchBindMountEntry> fromMgmtContainerHostBatchBindMounts(IList<Management.Batch.Models.ContainerHostBatchBindMountEntry> containerHostBatchBindMounts)
        {
            if (containerHostBatchBindMounts == null)
            {
                return null;
            }
            List<PSContainerHostBatchBindMountEntry> psContainerHostBatchBindMounts = new List<PSContainerHostBatchBindMountEntry>();
            foreach (var mount in containerHostBatchBindMounts)
            {
                psContainerHostBatchBindMounts.Add(new PSContainerHostBatchBindMountEntry
                {
                    Source = mount.Source,
                    IsReadOnly = mount.IsReadOnly
                });
            }
            return psContainerHostBatchBindMounts;
        }

        internal static IList<Management.Batch.Models.EnvironmentSetting> toMgmtEnvironmentSettings(IDictionary psEnvironmentSettings)
        {
            if(psEnvironmentSettings == null)
            {
                return null;
            }
            
            List<Management.Batch.Models.EnvironmentSetting> mgmtEnvironmentSettings = new List<Management.Batch.Models.EnvironmentSetting>();
            foreach (DictionaryEntry item in psEnvironmentSettings)
            {
                if (!(item.Key is string) || !(item.Value is string))
                {
                    throw new ArgumentException("EnvironmentSettings dictionary must have string keys and string values");
                }
                mgmtEnvironmentSettings.Add(new Management.Batch.Models.EnvironmentSetting
                {
                    Name = (string)item.Key,
                    Value = (string)item.Value
                });
            }
            return mgmtEnvironmentSettings;
        }

        internal static IDictionary fromMgmtEnvironmentSettings(IList<Management.Batch.Models.EnvironmentSetting> mgmtEnvironmentSettings)
        {
            if (mgmtEnvironmentSettings == null)
            {
                return null;
            }
            Dictionary<string, string> psEnvironmentSettings = new Dictionary<string, string>();
            foreach (var item in mgmtEnvironmentSettings)
            {
                psEnvironmentSettings.Add(item.Name, item.Value);
            }
            return psEnvironmentSettings;
        }

        internal static IList<Management.Batch.Models.ResourceFile> toMgmtResourceFiles(IList<PSResourceFile> resourceFiles)
        {
            if (resourceFiles == null)
            {
                return null;
            }
            List<Management.Batch.Models.ResourceFile> mgmtResourceFiles = new List<Management.Batch.Models.ResourceFile>();
            foreach (var psResourceFile in resourceFiles)
            {
                mgmtResourceFiles.Add(new Management.Batch.Models.ResourceFile
                {
                    AutoStorageContainerName = psResourceFile.AutoStorageContainerName,
                    StorageContainerUrl = psResourceFile.StorageContainerUrl,
                    HttpUrl = psResourceFile.HttpUrl,
                    BlobPrefix = psResourceFile.BlobPrefix,
                    FilePath = psResourceFile.FilePath,
                    FileMode = psResourceFile.FileMode,
                    IdentityReference = psResourceFile.IdentityReference.toMgmtIdentityReference()
                });
            }
            return mgmtResourceFiles;
        }

        internal static IList<PSResourceFile> fromMgmtResourceFiles(IList<Management.Batch.Models.ResourceFile> resourceFiles)
        {
            if (resourceFiles == null)
            {
                return null;
            }
            List<PSResourceFile> psResourceFiles = new List<PSResourceFile>();
            foreach (var mgmtResourceFile in resourceFiles)
            {
                Microsoft.Azure.Batch.ComputeNodeIdentityReference identityReference=  PSComputeNodeIdentityReference.fromMgmtIdentityReference(mgmtResourceFile.IdentityReference);
                Microsoft.Azure.Batch.ResourceFile resourceFile;
                if (!string.IsNullOrEmpty(mgmtResourceFile.HttpUrl))
                {
                    resourceFile = Microsoft.Azure.Batch.ResourceFile.FromUrl(mgmtResourceFile.HttpUrl, mgmtResourceFile.FilePath, fileMode: mgmtResourceFile.FileMode);
                }
                else if (!string.IsNullOrEmpty(mgmtResourceFile.StorageContainerUrl))
                {
                    resourceFile = Microsoft.Azure.Batch.ResourceFile.FromStorageContainerUrl(
                        storageContainerUrl: mgmtResourceFile.StorageContainerUrl,
                        identityReference: identityReference,
                        mgmtResourceFile.FilePath, 
                        blobPrefix: mgmtResourceFile.BlobPrefix, 
                        fileMode: mgmtResourceFile.FileMode);
                }
                else
                {
                    resourceFile = Microsoft.Azure.Batch.ResourceFile.FromAutoStorageContainer(mgmtResourceFile.AutoStorageContainerName, mgmtResourceFile.FilePath, blobPrefix: mgmtResourceFile.BlobPrefix, fileMode: mgmtResourceFile.FileMode);
                }


                psResourceFiles.Add(new PSResourceFile(resourceFile));
            }
            return psResourceFiles;
        }

        internal static ElevationLevel? toMgmtElevationLevel(Azure.Batch.Common.ElevationLevel? elevationLevel)
        {
            if (!elevationLevel.HasValue)
            {
                return null;
            }
            return (ElevationLevel)elevationLevel.Value;
        }

        internal static Azure.Batch.Common.ElevationLevel? fromMgmtElevationLevel(ElevationLevel? elevationLevel)
        {
            if (!elevationLevel.HasValue)
            {
                return null;
            }
            return (Azure.Batch.Common.ElevationLevel)elevationLevel.Value;
        }

        internal static AutoUserScope? toMgmtAutoUserScope(Azure.Batch.Common.AutoUserScope? scope)
        {
            if (!scope.HasValue)
            {
                return null;
            }
            return (AutoUserScope)scope.Value;
        }

        internal static Azure.Batch.Common.AutoUserScope fromMgmtAutoUserScope(AutoUserScope? scope)
        {
            return (Azure.Batch.Common.AutoUserScope)scope.Value;
        }

        internal static CachingType? toMgmtCaching(Azure.Batch.Common.CachingType? caching)
        {
            if (!caching.HasValue)
            {
                return null;
            }
            return (CachingType)caching.Value;
        }

        internal static Azure.Batch.Common.CachingType? fromMgmtCaching(CachingType? caching)
        {
            if (!caching.HasValue)
            {
                return null;
            }
            return (Azure.Batch.Common.CachingType)caching.Value;
        }

        internal static StorageAccountType? toMgmtStorageAccountType(Azure.Batch.Common.StorageAccountType? storageAccountType)
        {
            if (!storageAccountType.HasValue)
            {
                return null;
            }
            return (StorageAccountType)storageAccountType.Value;
        }

        internal static Azure.Batch.Common.StorageAccountType? fromMgmtStorageAccountType(StorageAccountType? storageAccountType)
        {
            if (!storageAccountType.HasValue)
            {
                return null;
            }
            return (Azure.Batch.Common.StorageAccountType)storageAccountType.Value;
        }

        internal static DiskEncryptionTarget toMgmtDiskEncryptionTarget(Azure.Batch.Common.DiskEncryptionTarget md)
        {
            return (DiskEncryptionTarget)md;
        }

        internal static Azure.Batch.Common.DiskEncryptionTarget fromMgmtDiskEncryptionTarget(DiskEncryptionTarget md)
        {
            return (Azure.Batch.Common.DiskEncryptionTarget)md;
        }
    }
}