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
using Commands.Storage.ScenarioTest.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Blob;
using MS.Test.Common.MsTestLib;
using StorageTestLib;

namespace Commands.Storage.ScenarioTest.Functional.Blob
{
    /// <summary>
    /// functional tests for Get-AzureStorageContainer
    /// </summary>
    [TestClass]
    public class GetContainer : TestBase
    {
        [ClassInitialize()]
        public static void ClassInit(TestContext testContext)
        {
            TestBase.TestClassInitialize(testContext);
        }

        [ClassCleanup()]
        public static void GetContainerClassCleanup()
        {
            TestBase.TestClassCleanup();
        }

        /// <summary>
        /// get container with its properties and meta data
        /// Positive Functional Cases : 
        ///     7.	Write Metadata to the specific container Get the Metadata from the specific container
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Container)]
        [TestCategory(PsTag.GetContainer)]
        public void GetContainerByNameWithPropertiesAndMetaData()
        {
            //TODO get container only by name
            //create random container
            int count = random.Next(1, 5);
            List<string> containerNames = new List<string>();
            
            for (int i = 0; i < count; i++)
            { 
                containerNames.Add(Utility.GenNameString("container"));
            }
            
            blobUtil.CreateContainer(containerNames);

            try
            {
                List<CloudBlobContainer> containers = blobUtil.GetExistingContainers();

                //list all containers with properties and meta data
                string containerName = string.Empty;

                Test.Assert(agent.GetAzureStorageContainer(containerName), Utility.GenComparisonData("GetAzureStorageContainer", true));
                Test.Assert(agent.Output.Count == containers.Count, String.Format("Create {0} containers, but retrieved {1} containers", containers.Count, agent.Output.Count));

                // Verification for returned values
                agent.OutputValidation(containers);
            }
            finally
            {
                blobUtil.RemoveContainer(containerNames);
            }
        }

        /// <summary>
        /// get container with sas policy
        /// Positive Functional Cases : 
        ///     8.	Get SharedAccessPolicies for a specific container
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Container)]
        [TestCategory(PsTag.GetContainer)]
        public void GetContainerWithSasPolicy()
        {
            string containerName = Utility.GenNameString("container");
            CloudBlobContainer container = blobUtil.CreateContainer(containerName);

            try
            {
                TimeSpan sasLifeTime = TimeSpan.FromMinutes(10);
                BlobContainerPermissions permission = new BlobContainerPermissions();
                int count = random.Next(1, 5);

                for (int i = 0; i < count; i++)
                {
                    permission.SharedAccessPolicies.Add(Utility.GenNameString("saspolicy"), new SharedAccessBlobPolicy
                    {
                        SharedAccessExpiryTime = DateTime.Now.Add(sasLifeTime),
                        Permissions = SharedAccessBlobPermissions.Read,
                    });

                }

                container.SetPermissions(permission);

                Test.Assert(agent.GetAzureStorageContainer(containerName), Utility.GenComparisonData("GetAzureStorageContainer", true));
                Test.Assert(agent.Output.Count == 1, String.Format("Create {0} containers, actually retrieved {1} containers", 1, agent.Output.Count));

                agent.OutputValidation(new List<BlobContainerPermissions>() { permission });
            }
            finally
            {
                blobUtil.RemoveContainer(containerName);
            }
        }
    }
}
