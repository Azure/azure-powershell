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
using System.Runtime.ConstrainedExecution;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;

namespace Microsoft.Azure.Commands.Batch.Utils
{
    /// <summary>
    /// Helper class
    /// </summary>
    internal static class Utils
    {
        /// <summary>
        /// Syncs the collections on a PSJobSpecification with its wrapped OM object
        /// </summary>
        internal static void JobSpecificationSyncCollections(PSJobSpecification specification)
        {
            if (specification != null)
            {
                if (specification.JobManager != null)
                {
                    JobManagerSyncCollections(specification.JobManager);   
                }
            }
        }

        /// <summary>
        /// Syncs the collections on a PSJobManager with its wrapped OM object
        /// </summary>
        internal static void JobManagerSyncCollections(PSJobManager jobManager)
        {
            if (jobManager != null)
            {
                jobManager.omObject.EnvironmentSettings = CreateSyncedList(jobManager.EnvironmentSettings, 
                    (e) =>
                    {
                        IEnvironmentSetting envSetting = new EnvironmentSetting(e.Name, e.Value);
                        return envSetting;
                    });

                jobManager.omObject.ResourceFiles = CreateSyncedList(jobManager.ResourceFiles,
                    (r) =>
                    {
                        IResourceFile resourceFile = new ResourceFile(r.BlobSource, r.FilePath);
                        return resourceFile;
                    });
            }
        }

        /// <summary>
        /// Syncs the collections on a PSJobManager with its wrapped OM object
        /// </summary>
        internal static void JobExecutionEnvironmentSyncCollections(PSJobExecutionEnvironment executionEnvironment)
        {
            if (executionEnvironment != null)
            {
                if (executionEnvironment.AutoPoolSpecification != null)
                {
                    AutoPoolSpecificationSyncCollections(executionEnvironment.AutoPoolSpecification);
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
                        ICertificateReference certReference = new CertificateReference();
                        certReference.StoreLocation = c.StoreLocation;
                        certReference.StoreName = c.StoreName;
                        certReference.Thumbprint = c.Thumbprint;
                        certReference.ThumbprintAlgorithm = c.ThumbprintAlgorithm;
                        certReference.Visibility = c.Visibility;
                        return certReference;
                    });

                spec.omObject.Metadata = CreateSyncedList(spec.Metadata, 
                    (m) =>
                    {
                        IMetadataItem metadata = new MetadataItem(m.Name, m.Value);
                        return metadata;
                    });

                if (spec.StartTask != null)
                {
                    StartTaskSyncCollections(spec.StartTask);
                }
            }
        }

        /// <summary>
        /// Syncs the collections on a PSStartTask with its wrapped OM object
        /// </summary>
        internal static void StartTaskSyncCollections(PSStartTask startTask)
        {
            if (startTask != null)
            {
                startTask.omObject.EnvironmentSettings = CreateSyncedList(startTask.EnvironmentSettings,
                    (e) =>
                    {
                        IEnvironmentSetting envSetting = new EnvironmentSetting(e.Name, e.Value);
                        return envSetting;
                    });

                startTask.omObject.ResourceFiles = CreateSyncedList(startTask.ResourceFiles,
                    (r) =>
                    {
                        IResourceFile resourceFile = new ResourceFile(r.BlobSource, r.FilePath);
                        return resourceFile;
                    });
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
        private static IList<Tom> CreateSyncedList<Tps, Tom>(IList<Tps> psList, Func<Tps, Tom> mappingFunction)
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
    }
}
