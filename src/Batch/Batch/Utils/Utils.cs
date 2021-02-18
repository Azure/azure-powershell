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
using System;
<<<<<<< HEAD
using System.Collections.Generic;
=======
using System.Collections;
using System.Collections.Generic;
using System.Linq;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
                pool.omObject.CertificateReferences = CreateSyncedList(pool.CertificateReferences,
                (c) =>
                {
                    return ConvertCertificateReference(c);
                });

<<<<<<< HEAD
                pool.omObject.Metadata = CreateSyncedList(pool.Metadata,
                (m) =>
                {
                    MetadataItem metadata = new MetadataItem(m.Name, m.Value);
                    return metadata;
                });
=======
                pool.omObject.Metadata = CreateSyncedDict(pool.Metadata, ConvertMetadataItem);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
<<<<<<< HEAD
                jobSchedule.omObject.Metadata = CreateSyncedList(jobSchedule.Metadata,
                (m) =>
                {
                    MetadataItem metadata = new MetadataItem(m.Name, m.Value);
                    return metadata;
                });
=======
                jobSchedule.omObject.Metadata = CreateSyncedDict(jobSchedule.Metadata, ConvertMetadataItem);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
<<<<<<< HEAD
                job.omObject.Metadata = CreateSyncedList(job.Metadata,
                (m) =>
                {
                    MetadataItem metadata = new MetadataItem(m.Name, m.Value);
                    return metadata;
                });

=======
                job.omObject.Metadata = CreateSyncedDict(job.Metadata, ConvertMetadataItem);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
                specification.omObject.CommonEnvironmentSettings = CreateSyncedList(specification.CommonEnvironmentSettings,
                (e) =>
                {
                    EnvironmentSetting envSetting = new EnvironmentSetting(e.Name, e.Value);
                    return envSetting;
                });
=======
                specification.omObject.CommonEnvironmentSettings = CreateSyncedDict(
                    specification.CommonEnvironmentSettings,
                    ConvertEnvironmentSetting);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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

<<<<<<< HEAD
                specification.omObject.Metadata = CreateSyncedList(specification.Metadata,
                (m) =>
                {
                    MetadataItem metadata = new MetadataItem(m.Name, m.Value);
                    return metadata;
                });
=======
                specification.omObject.Metadata = CreateSyncedDict(specification.Metadata, ConvertMetadataItem);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
<<<<<<< HEAD
                jobManager.omObject.EnvironmentSettings = CreateSyncedList(jobManager.EnvironmentSettings,
                    (e) =>
                    {
                        EnvironmentSetting envSetting = new EnvironmentSetting(e.Name, e.Value);
                        return envSetting;
                    });

                jobManager.omObject.ResourceFiles = CreateSyncedList(jobManager.ResourceFiles,
                    (r) =>
                    {
                        ResourceFile resourceFile = new ResourceFile(r.BlobSource, r.FilePath);
                        return resourceFile;
                    });
=======
                jobManager.omObject.EnvironmentSettings = CreateSyncedDict(
                    jobManager.EnvironmentSettings,
                    ConvertEnvironmentSetting);

                jobManager.omObject.ResourceFiles = CreateSyncedList(jobManager.ResourceFiles, ConvertResourceFile);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                jobManager.omObject.ApplicationPackageReferences = CreateSyncedList(jobManager.ApplicationPackageReferences,
                    a =>
                    {
                        ApplicationPackageReference applicationPackageReference = new ApplicationPackageReference
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
<<<<<<< HEAD
                jobPrepTask.omObject.EnvironmentSettings = CreateSyncedList(jobPrepTask.EnvironmentSettings,
                    (e) =>
                    {
                        EnvironmentSetting envSetting = new EnvironmentSetting(e.Name, e.Value);
                        return envSetting;
                    });

                jobPrepTask.omObject.ResourceFiles = CreateSyncedList(jobPrepTask.ResourceFiles,
                    (r) =>
                    {
                        ResourceFile resourceFile = new ResourceFile(r.BlobSource, r.FilePath);
                        return resourceFile;
                    });
=======
                jobPrepTask.omObject.EnvironmentSettings = CreateSyncedDict(
                    jobPrepTask.EnvironmentSettings,
                    ConvertEnvironmentSetting);

                jobPrepTask.omObject.ResourceFiles = CreateSyncedList(jobPrepTask.ResourceFiles, ConvertResourceFile);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            }
        }

        /// <summary>
        /// Syncs the collections on a PSJobReleaseTask with its wrapped OM object
        /// </summary>
        internal static void JobReleaseTaskSyncCollections(PSJobReleaseTask jobReleaseTask)
        {
            if (jobReleaseTask != null)
            {
<<<<<<< HEAD
                jobReleaseTask.omObject.EnvironmentSettings = CreateSyncedList(jobReleaseTask.EnvironmentSettings,
                    (e) =>
                    {
                        EnvironmentSetting envSetting = new EnvironmentSetting(e.Name, e.Value);
                        return envSetting;
                    });

                jobReleaseTask.omObject.ResourceFiles = CreateSyncedList(jobReleaseTask.ResourceFiles,
                    (r) =>
                    {
                        ResourceFile resourceFile = new ResourceFile(r.BlobSource, r.FilePath);
                        return resourceFile;
                    });
=======
                jobReleaseTask.omObject.EnvironmentSettings = CreateSyncedDict(
                    jobReleaseTask.EnvironmentSettings,
                    ConvertEnvironmentSetting);

                jobReleaseTask.omObject.ResourceFiles = CreateSyncedList(jobReleaseTask.ResourceFiles, ConvertResourceFile);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
                spec.omObject.CertificateReferences = CreateSyncedList(spec.CertificateReferences,
                    (c) =>
                    {
                        return ConvertCertificateReference(c);
                    });

<<<<<<< HEAD
                spec.omObject.Metadata = CreateSyncedList(spec.Metadata,
                    (m) =>
                    {
                        MetadataItem metadata = new MetadataItem(m.Name, m.Value);
                        return metadata;
                    });
=======
                spec.omObject.Metadata = CreateSyncedDict(
                    spec.Metadata,
                    ConvertMetadataItem);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

                spec.omObject.ApplicationPackageReferences = CreateSyncedList(spec.ApplicationPackageReferences,
                    (apr) =>
                    {
                        return new ApplicationPackageReference()
                        {
                            ApplicationId = apr.ApplicationId,
                            Version = apr.Version
                        };
                    });

                spec.omObject.UserAccounts = CreateSyncedList(spec.UserAccounts,
                    (user) =>
                    {
                        return new UserAccount(
                            user.Name,
                            user.Password,
                            user.ElevationLevel,
                            user.LinuxUserConfiguration?.omObject);
                    });

                if (spec.StartTask != null)
                {
                    StartTaskSyncCollections(spec.StartTask);
                }
<<<<<<< HEAD
=======

                VirtualMachineConfigurationSyncCollections(spec.VirtualMachineConfiguration);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            }
        }

        /// <summary>
        /// Syncs the collections on a PSCloudTask with its wrapped OM object
        /// </summary>
        internal static void CloudTaskSyncCollections(PSCloudTask task)
        {
            if (task != null)
            {
<<<<<<< HEAD
                task.omObject.EnvironmentSettings = CreateSyncedList(task.EnvironmentSettings,
                    (e) =>
                    {
                        EnvironmentSetting envSetting = new EnvironmentSetting(e.Name, e.Value);
                        return envSetting;
                    });

                task.omObject.ResourceFiles = CreateSyncedList(task.ResourceFiles,
                    (r) =>
                    {
                        ResourceFile resourceFile = new ResourceFile(r.BlobSource, r.FilePath);
                        return resourceFile;
                    });
=======
                task.omObject.EnvironmentSettings = CreateSyncedDict(
                    task.EnvironmentSettings,
                    ConvertEnvironmentSetting);

                task.omObject.ResourceFiles = CreateSyncedList(task.ResourceFiles, ConvertResourceFile);
                task.omObject.OutputFiles = CreateSyncedList(task.OutputFiles, ps => ps.omObject);
                task.omObject.ApplicationPackageReferences = CreateSyncedList(task.ApplicationPackageReferences, ps => ps.omObject);
                ExitConditionsSyncCollections(task.ExitConditions);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
<<<<<<< HEAD
                startTask.omObject.EnvironmentSettings = CreateSyncedList(startTask.EnvironmentSettings,
                    (e) =>
                    {
                        EnvironmentSetting envSetting = new EnvironmentSetting(e.Name, e.Value);
                        return envSetting;
                    });

                startTask.omObject.ResourceFiles = CreateSyncedList(startTask.ResourceFiles,
                    (r) =>
                    {
                        ResourceFile resourceFile = new ResourceFile(r.BlobSource, r.FilePath);
                        return resourceFile;
                    });
=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            }
        }

        /// <summary>
        /// Syncs the collections on a PSMultiInstanceSettings with its wrapped OM object
        /// </summary>
        internal static void MultiInstanceSettingsSyncCollections(PSMultiInstanceSettings multiInstanceSettings)
        {
            if (multiInstanceSettings != null)
            {
<<<<<<< HEAD
                multiInstanceSettings.omObject.CommonResourceFiles = CreateSyncedList(multiInstanceSettings.CommonResourceFiles,
                    (r) =>
                    {
                        ResourceFile resourceFile = new ResourceFile(r.BlobSource, r.FilePath);
                        return resourceFile;
                    });
=======
                multiInstanceSettings.omObject.CommonResourceFiles = CreateSyncedList(multiInstanceSettings.CommonResourceFiles, ConvertResourceFile);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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

<<<<<<< HEAD
=======
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

        /// <summary>
        /// Converts a PSCertificateReference to a CertificateReference
        /// </summary>
        private static MetadataItem ConvertMetadataItem(string key, string value) => new MetadataItem(key, value);

        private static EnvironmentSetting ConvertEnvironmentSetting(string key, string value) => new EnvironmentSetting(key, value);

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        /// <summary>
        /// Converts a PSCertificateReference to a CertificateReference
        /// </summary>
        private static CertificateReference ConvertCertificateReference(PSCertificateReference psCert)
        {
            CertificateReference certReference = new CertificateReference();
            certReference.StoreLocation = psCert.StoreLocation;
            certReference.StoreName = psCert.StoreName;
            certReference.Thumbprint = psCert.Thumbprint;
            certReference.ThumbprintAlgorithm = psCert.ThumbprintAlgorithm;
            certReference.Visibility = psCert.Visibility;
            return certReference;
        }

        /// <summary>
        /// Converts a PSApplicationPackageReference to a ApplicationPackageReference
        /// </summary>
        private static ApplicationPackageReference ConvertApplicationPackageReference(PSApplicationPackageReference psApr)
        {
            ApplicationPackageReference applicationPackageReference = new ApplicationPackageReference()
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
<<<<<<< HEAD
=======

        internal static ResourceFile ConvertResourceFile(PSResourceFile psResourceFile)
        {
            if (!string.IsNullOrEmpty(psResourceFile.AutoStorageContainerName))
            {
                return ResourceFile.FromAutoStorageContainer(
                    psResourceFile.AutoStorageContainerName,
                    filePath: psResourceFile.FilePath,
                    blobPrefix: psResourceFile.BlobPrefix,
                    fileMode: psResourceFile.FileMode);
            }
            else if(!string.IsNullOrEmpty(psResourceFile.StorageContainerUrl))
            {
                return ResourceFile.FromStorageContainerUrl(
                    psResourceFile.StorageContainerUrl,
                    filePath: psResourceFile.FilePath,
                    blobPrefix: psResourceFile.BlobPrefix,
                    fileMode: psResourceFile.FileMode);
            }
            else if(!string.IsNullOrEmpty(psResourceFile.HttpUrl))
            {
                return ResourceFile.FromUrl(
                   psResourceFile.HttpUrl,
                   filePath: psResourceFile.FilePath,
                   fileMode: psResourceFile.FileMode);
            }
            else
            {
                throw new ArgumentException($"ResourceFile missing expected fields");
            }
        }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }
}
