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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using MS.Test.Common.MsTestLib;

namespace Commands.Storage.ScenarioTest
{
    public abstract class Agent
    {
        /// <summary>
        /// output data returned after agent operation
        /// </summary>   
        public Collection<Dictionary<string, object>> Output { get { return _Output; } }

        /// <summary>
        /// error messages returned after agent operation
        /// </summary>   
        public Collection<string> ErrorMessages { get { return _ErrorMessages; } }

        public bool UseContextParam
        {
            set {_UseContextParam = value;}
            get {return _UseContextParam;}
        }

        /// <summary>
        /// Return true if succeed otherwise return false
        /// </summary>   
        public abstract bool NewAzureStorageContainer(string ContainerName);

        /// <summary>
        /// Parameters:
        ///     ContainerName:
        ///         1. Could be empty if no Container parameter specified
        ///         2. Could contain wildcards
        /// </summary>
        public abstract bool GetAzureStorageContainer(string ContainerName);
        public abstract bool GetAzureStorageContainerByPrefix(string Prefix);
        public abstract bool SetAzureStorageContainerACL(string ContainerName, BlobContainerPublicAccessType PublicAccess, bool PassThru = true);
        public abstract bool RemoveAzureStorageContainer(string ContainerName, bool Force = true);
        /// <summary>
        /// For pipeline, new/remove a list of container names
        /// </summary>
        public abstract bool NewAzureStorageContainer(string[] ContainerNames);
        public abstract bool RemoveAzureStorageContainer(string[] ContainerNames, bool Force = true);

        public abstract bool NewAzureStorageQueue(string QueueName);
        /// <summary>
        /// Parameters:
        ///     ContainerName:
        ///         1. Could be empty if no Queue parameter specified
        ///         2. Could contain wildcards
        /// </summary>
        public abstract bool GetAzureStorageQueue(string QueueName);
        public abstract bool GetAzureStorageQueueByPrefix(string Prefix);
        public abstract bool RemoveAzureStorageQueue(string QueueName, bool Force = true);

        /// <summary>
        /// For pipeline, new/remove a list of queue names
        /// </summary>
        public abstract bool NewAzureStorageQueue(string[] QueueNames);
        public abstract bool RemoveAzureStorageQueue(string[] QueueNames, bool Force = true);

        /// <summary>
        /// Parameters:
        ///     Block:
        ///         true for BlockBlob, false for PageBlob
        ///     ConcurrentCount:
        ///         -1 means use the default value
        /// </summary>
        public abstract bool SetAzureStorageBlobContent(string FileName, string ContainerName, BlobType Type, string BlobName = "",
            bool Force = true, int ConcurrentCount = -1, Hashtable properties = null, Hashtable metadata = null);
        public abstract bool GetAzureStorageBlobContent(string Blob, string FileName, string ContainerName,
            bool Force = true, int ConcurrentCount = -1);
        public abstract bool GetAzureStorageBlob(string BlobName, string ContainerName);
        public abstract bool GetAzureStorageBlobByPrefix(string Prefix, string ContainerName);

        /// <summary>
        /// 
        /// Remarks:
        ///     currently there is no Force param, may add it later on
        /// </summary>
        public abstract bool RemoveAzureStorageBlob(string BlobName, string ContainerName, bool onlySnapshot = false, bool force = true);
      
        public abstract bool NewAzureStorageTable(string TableName);
        public abstract bool NewAzureStorageTable(string[] TableNames);
        public abstract bool GetAzureStorageTable(string TableName);
        public abstract bool GetAzureStorageTableByPrefix(string Prefix);
        public abstract bool RemoveAzureStorageTable(string TableName, bool Force = true);
        public abstract bool RemoveAzureStorageTable(string[] TableNames, bool Force = true);

        public abstract bool NewAzureStorageContext(string StorageAccountName, string StorageAccountKey, string endPoint = "");
        public abstract bool NewAzureStorageContext(string ConnectionString);

        public abstract bool StartAzureStorageBlobCopy(string sourceUri, string destContainerName, string destBlobName, object destContext, bool force = true);
        public abstract bool StartAzureStorageBlobCopy(string srcContainerName, string srcBlobName, string destContainerName, string destBlobName, object destContext = null, bool force = true);
        public abstract bool StartAzureStorageBlobCopy(ICloudBlob srcBlob, string destContainerName, string destBlobName, object destContext = null, bool force = true);

        public abstract bool GetAzureStorageBlobCopyState(string containerName, string blobName, bool waitForComplete);
        public abstract bool GetAzureStorageBlobCopyState(ICloudBlob blob, object context, bool waitForComplete);
        public abstract bool StopAzureStorageBlobCopy(string containerName, string blobName, string copyId, bool force);

        /// <summary>
        /// Compare the output collection data with comp
        /// 
        /// Parameters:
        ///     comp: comparsion data
        /// </summary> 
        public void OutputValidation(Collection<Dictionary<string, object>> comp)
        {
            Test.Info("Validate Dictionary objects");
            Test.Assert(comp.Count == Output.Count, "Comparison size: {0} = {1} Output size", comp.Count, Output.Count);
            if (comp.Count != Output.Count)
                return;

            // first check whether Key exists and then check value if it's not null
            for (int i = 0; i < comp.Count; ++i)
            {
                foreach (string str in comp[i].Keys)
                {
                    Test.Assert(Output[i].ContainsKey(str), "{0} should be in the ouput columns", str);

                    switch(str)
                    {
                        case "Context":
                            break;
                    
                        case "CloudTable":
                            Test.Assert(Utility.CompareEntity((CloudTable)comp[i][str], (CloudTable)Output[i][str]),
                                "CloudTable Column {0}: {1} = {2}", str, comp[i][str], Output[i][str]);
                            break;
                        
                        case "CloudQueue":
                            Test.Assert(Utility.CompareEntity((CloudQueue)comp[i][str], (CloudQueue)Output[i][str]),
                                "CloudQueue Column {0}: {1} = {2}", str, comp[i][str], Output[i][str]);
                            break;
                        
                        case "CloudBlobContainer":
                            Test.Assert(Utility.CompareEntity((CloudBlobContainer)comp[i][str], (CloudBlobContainer)Output[i][str]),
                                "CloudBlobContainer Column {0}: {1} = {2}", str, comp[i][str], Output[i][str]);
                            break;
                        
                        case "ICloudBlob":
                            Test.Assert(Utility.CompareEntity((ICloudBlob)comp[i][str], (ICloudBlob)Output[i][str]),
                                "ICloudBlob Column {0}: {1} = {2}", str, comp[i][str], Output[i][str]);
                            break;
                        
                        case "Permission":
                            Test.Assert(Utility.CompareEntity((BlobContainerPermissions)comp[i][str], (BlobContainerPermissions)Output[i][str]),
                                "Permission Column {0}: {1} = {2}", str, comp[i][str], Output[i][str]);
                            break;
                        
                        default:
                        
                            if(comp[i][str] == null)
                            {
                                Test.Assert(Output[i][str] == null, "Column {0}: {1} = {2}", str, comp[i][str], Output[i][str]);
                            }
                            else
                            {
                                Test.Assert(comp[i][str].Equals(Output[i][str]), "Column {0}: {1} = {2}", str, comp[i][str], Output[i][str]);
                            }
                            
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Compare the output collection data with containers
        /// 
        /// Parameters:
        ///     containers: comparsion data
        /// </summary> 
        public void OutputValidation(IEnumerable<CloudBlobContainer> containers)
        {
            Test.Info("Validate CloudBlobContainer objects");
            Test.Assert(containers.Count() == Output.Count, "Comparison size: {0} = {1} Output size", containers.Count(), Output.Count);
            if (containers.Count() != Output.Count)
                return;

            int count = 0;
            foreach (CloudBlobContainer container in containers)
            {
                container.FetchAttributes();
                Test.Assert(Utility.CompareEntity(container, (CloudBlobContainer)Output[count]["CloudBlobContainer"]), "container equality checking: {0}", container.Name);
                ++count;
            }
        }

        /// <summary>
        /// Compare the output collection data with container permissions
        /// </summary> 
        /// <param name="containers">a list of cloudblobcontainer objects</param>
        public void OutputValidation(IEnumerable<BlobContainerPermissions> permissions)
        {
            Test.Info("Validate BlobContainerPermissions");
            Test.Assert(permissions.Count() == Output.Count, "Comparison size: {0} = {1} Output size", permissions.Count(), Output.Count);
            if (permissions.Count() != Output.Count)
                return;

            int count = 0;
            foreach (BlobContainerPermissions permission in permissions)
            {
                Test.Assert(Utility.CompareEntity(permission, (BlobContainerPermissions)Output[count]["Permission"]), "container permision equality checking ");
                ++count;
            }
        }

        /// <summary>
        /// Compare the output collection data with ICloudBlob
        /// </summary> 
        /// <param name="containers">a list of cloudblobcontainer objects</param>
        public void OutputValidation(IEnumerable<ICloudBlob> blobs)
        {
            Test.Info("Validate ICloudBlob objects");
            Test.Assert(blobs.Count() == Output.Count, "Comparison size: {0} = {1} Output size", blobs.Count(), Output.Count);
            if (blobs.Count() != Output.Count)
                return;

            int count = 0;
            foreach (ICloudBlob blob in blobs)
            {
                Test.Assert(Utility.CompareEntity(blob, (ICloudBlob)Output[count]["ICloudBlob"]), string.Format("ICloudBlob equality checking for blob '{0}'", blob.Name));
                ++count;
            }
        }


        /// <summary>
        /// Compare the output collection data with queues
        /// 
        /// Parameters:
        ///     queues: comparsion data
        /// </summary> 
        public void OutputValidation(IEnumerable<CloudQueue> queues)
        {
            Test.Info("Validate CloudQueue objects");
            Test.Assert(queues.Count() == Output.Count, "Comparison size: {0} = {1} Output size", queues.Count(), Output.Count);
            if (queues.Count() != Output.Count)
                return;

            int count = 0;
            foreach (CloudQueue queue in queues)
            {
                queue.FetchAttributes();
                Test.Assert(Utility.CompareEntity(queue, (CloudQueue)Output[count]["CloudQueue"]), "queue equality checking: {0}", queue.Name);
                ++count;
            }
        }

        /// <summary>
        /// Compare the output collection data with tables
        /// 
        /// Parameters:
        ///     tables: comparsion data
        /// </summary> 
        public void OutputValidation(IEnumerable<CloudTable> tables)
        {
            Test.Info("Validate CloudTable objects");
            Test.Assert(tables.Count() == Output.Count, "Comparison size: {0} = {1} Output size", tables.Count(), Output.Count);
            if (tables.Count() != Output.Count)
                return;

            int count = 0;
            foreach (CloudTable table in tables)
            {
                Test.Assert(Utility.CompareEntity(table, (CloudTable)Output[count]["CloudTable"]), "table equality checking: {0}", table.Name);
                ++count;
            }
        }

        protected static Random _random = new Random((int)(DateTime.Now.Ticks));    // for generating random object names
        protected Collection<Dictionary<string, object>> _Output = new Collection<Dictionary<string, object>>();
        protected Collection<string> _ErrorMessages = new Collection<string>();
        protected bool _UseContextParam = true;  // decide whether to specify the Context parameter
    }
}
