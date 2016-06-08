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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.Common
{
    public static class Data
    {
        // To Do:
        // Add invalid service/storage account name data: http://social.msdn.microsoft.com/Forums/en-US/windowsazuredevelopment/thread/75b05a42-cd3b-4ab8-aa26-dc8366ede115
        // Add invalid deployment name data
        public static string Subscription1 = "Microsoft Azure Sandbox 9-220";
        public static string SampleSubscription1 = "Sample Subscription 1";

        public static List<string> ValidServiceNames { get; private set; }
        public static List<string> ValidSubscriptionName { get; private set; }
        public static List<string> ValidSubscriptionsData { get; private set; }
        public static List<string> ValidServiceRootNames { get; private set; }
        public static List<string> ValidDeploymentNames { get; private set; }
        public static List<string> ValidStorageNames { get; private set; }
        public static List<string> ValidPublishSettings { get; private set; }
        public static List<string> ValidPublishSettings2 { get; private set; }
        public static List<string> ValidRoleNames { get; private set; }
        public static List<int> ValidRoleInstances { get; private set; }
        public static StorageServiceList ValidStorageService { get; private set; }

        public static List<string> InvalidSubscriptionsData { get; private set; }
        public static List<string> InvalidLocations { get; private set; }
        public static List<string> InvalidSlots { get; private set; }
        public static List<string> InvalidPublishSettings { get; private set; }
        public static List<string> InvalidServiceNames { get; private set; }
        public static List<string> InvalidRoleNames { get; private set; }
        public static List<string> InvalidFileName { get; private set; }
        public static List<string> InvalidPaths { get; private set; }
        public static List<string> InvalidServiceRootName { get; private set; }
        public static List<int> InvalidRoleInstances { get; private set; }
        
        public static string AzureSdkAppDir { get; private set; }
        public static string TestResultDirectory { get; private set; }
        public static string AzureAppDir { get; private set; }

        public static string NodeWebRoleScaffoldingPath = Path.Combine(Resources.NodeScaffolding, RoleType.WebRole.ToString());
        public static string NodeWorkerRoleScaffoldingPath = Path.Combine(Resources.NodeScaffolding, RoleType.WorkerRole.ToString());
        public static string PHPWebRoleScaffoldingPath = Path.Combine(Resources.PHPScaffolding, RoleType.WebRole.ToString());
        public static string PHPWorkerRoleScaffoldingPath = Path.Combine(Resources.PHPScaffolding, RoleType.WorkerRole.ToString());

        static Data()
        {
            AzureAppDir = AzureSession.ProfileDirectory;
            AzureSdkAppDir = Path.Combine(Directory.GetCurrentDirectory(), "Microsoft Azure PowerShell");
            TestResultDirectory = FileUtilities.GetAssemblyDirectory();

            ValidServiceNames = new List<string>();
            InitializeValidServiceNameData();

            ValidSubscriptionName = new List<string>();
            InitializeValidSubscriptionNameData();

            ValidServiceRootNames = new List<string>();
            InitializeValidServiceRootNameData();

            ValidDeploymentNames = new List<string>();
            InitializeValidDeploymentNameData();

            ValidStorageNames = new List<string>();
            InitializeValidStorageNameData();

            ValidPublishSettings = new List<string>();
            InitializeValidPublishSettingsData();

            ValidPublishSettings2 = new List<string>();
            InitializeValidPublishSettings2Data();

            ValidSubscriptionsData = new List<string>();
            InitializeValidSubscriptionsData();

            ValidRoleNames = new List<string>();
            InitializeValidRoleNameData();

            ValidRoleInstances = new List<int>();
            InitializeValidRoleInstancesData();

            ValidStorageService = new StorageServiceList();
            InitializeValidStorageServiceData();

            InvalidServiceRootName = new List<string>();
            InitializeInvalidServiceRootNameData();

            InvalidPublishSettings = new List<string>();
            InitializeInvalidPublishSettingsData();

            InvalidLocations = new List<string>();
            InitializeInvalidLocationData();

            InvalidSlots = new List<string>();
            InitializeInvalidSlotData();

            InvalidServiceNames = new List<string>();
            InitializeInvalidServiceNameData();

            InvalidRoleInstances = new List<int>();
            InitializeInvalidRoleInstancesData();

            InvalidFileName = new List<string>();
            InitializeInvalidFileNameData();

            InvalidPaths = new List<string>();
            InitializeInvalidPathData();

            InvalidSubscriptionsData = new List<string>();
            InitializeInvalidSubscriptionsData();

            InvalidRoleNames = new List<string>();
            InitializeInvalidRoleNameData();
        }

        private static void InitializeValidStorageServiceData()
        {
            StorageService myStore = new StorageService();
            myStore.ServiceName = "mystore";
            myStore.StorageServiceKeys = new StorageServiceKeys();
            myStore.StorageServiceKeys.Primary = "=132321982cddsdsa";
            myStore.StorageServiceKeys.Secondary = "=w8uidjew4378891289";
            myStore.StorageServiceProperties = new StorageServiceProperties();
            myStore.StorageServiceProperties.Location = "North Central US";
            myStore.StorageServiceProperties.Status = "Created";
            ValidStorageService.Add(myStore);

            StorageService testStore = new StorageService();
            testStore.ServiceName = "teststore";
            testStore.StorageServiceKeys = new StorageServiceKeys();
            testStore.StorageServiceKeys.Primary = "=/se23ew2343221";
            testStore.StorageServiceKeys.Secondary = "==0--3210-//121313233290sd";
            testStore.StorageServiceProperties = new StorageServiceProperties();
            testStore.StorageServiceProperties.Location = "East Asia";
            testStore.StorageServiceProperties.Status = "Creating";
            ValidStorageService.Add(testStore);

            StorageService MyCompanyStore = new StorageService();
            MyCompanyStore.ServiceName = "mycompanystore";
            MyCompanyStore.StorageServiceKeys = new StorageServiceKeys();
            MyCompanyStore.StorageServiceKeys.Primary = "121/21dssdsds=";
            MyCompanyStore.StorageServiceKeys.Secondary = "023432dfelfema1=";
            MyCompanyStore.StorageServiceProperties = new StorageServiceProperties();
            MyCompanyStore.StorageServiceProperties.Location = "North Europe";
            MyCompanyStore.StorageServiceProperties.Status = "Suspending";
            ValidStorageService.Add(MyCompanyStore);
        }

        private static void InitializeInvalidPathData()
        {
            foreach (string invalidFolderName in InvalidServiceRootName)
            {
                InvalidPaths.Add(string.Format("{0}\\{1}", Directory.GetCurrentDirectory(), invalidFolderName));
            }
        }

        private static void InitializeInvalidFileNameData()
        {
            char[] invalidFileNameChars = System.IO.Path.GetInvalidFileNameChars();
            
            // Validations that depend on Path.GetFileName fails with these characters. For example:
            // if user entered name for WebRole as "My/WebRole", then Path.GetFileName get file name as WebRole.
            //
            char[] ignoreSet = { ':', '\\', '/' };

            for (int i = 0, j = 0; i < invalidFileNameChars.Length; i++, j++)
            {
                if (ignoreSet.Contains<char>(invalidFileNameChars[i]))
                {
                    continue;
                }
                j %= ValidServiceRootNames.Count - 1;
                StringBuilder invalidFile = new StringBuilder(ValidServiceRootNames[j]);
                invalidFile[invalidFile.Length / 2] = invalidFileNameChars[i];
                InvalidFileName.Add(invalidFile.ToString());
            }
        }

        private static void InitializeInvalidRoleInstancesData()
        {
            InvalidRoleInstances.Add(-1);
            InvalidRoleInstances.Add(-10);
            InvalidRoleInstances.Add(21);
            InvalidRoleInstances.Add(100);
        }

        private static void InitializeValidRoleInstancesData()
        {
            ValidRoleInstances.Add(1);
            ValidRoleInstances.Add(2);
            ValidRoleInstances.Add(10);
            ValidRoleInstances.Add(20);
        }

        private static void InitializeInvalidRoleNameData()
        {
            InvalidRoleNames.AddRange(InvalidServiceRootName);
        }

        private static void InitializeValidRoleNameData()
        {
            ValidRoleNames.Add("WebRole1");
            ValidRoleNames.Add("MyWebRole");
            ValidRoleNames.Add("WorkerRole");
            ValidRoleNames.Add("Node_WebRole");
        }

        private static void InitializeInvalidSlotData()
        {
            InvalidSlots.Add(string.Empty);
            InvalidSlots.Add(null);
            InvalidSlots.Add("Praduction");
            InvalidSlots.Add("Pddqdww");
            InvalidSlots.Add("Stagging");
            InvalidSlots.Add("Sagiang");
        }

        private static void InitializeInvalidLocationData()
        {
            InvalidLocations.Add(string.Empty);
            InvalidLocations.Add(null);
            InvalidLocations.Add("My Home");
            InvalidLocations.Add("AnywhereUS");
            InvalidLocations.Add("USA");
            InvalidLocations.Add("Microsoft");
            InvalidLocations.Add("Near");
            InvalidLocations.Add("Anywhere Africa");
            InvalidLocations.Add("Anywhhere US");
        }

        private static void InitializeInvalidPublishSettingsData()
        {
            InvalidPublishSettings.Add(Testing.GetTestResourcePath("InvalidProfile.PublishSettings"));
        }

        private static void InitializeValidPublishSettingsData()
        {
            ValidPublishSettings.Add(Testing.GetTestResourcePath("ValidProfile.PublishSettings"));
        }

        private static void InitializeValidPublishSettings2Data()
        {
            ValidPublishSettings2.Add(Testing.GetTestResourcePath("ValidProfile2.PublishSettings"));
        }

        /// <summary>
        /// This method must run after InitializeServiceRootNameData()
        /// </summary>
        private static void InitializeInvalidServiceRootNameData()
        {
            char[] invalidPathNameChars = Path.GetInvalidPathChars();

            for (int i = 0, j = 0; i < invalidPathNameChars.Length; i++)
            {
                StringBuilder invalidPath = new StringBuilder(ValidServiceRootNames[j]);
                invalidPath[invalidPath.Length / 2] = invalidPathNameChars[i];
                j %= ValidServiceRootNames.Count;
                InvalidServiceRootName.Add(invalidPath.ToString());
            }
        }

        private static void InitializeValidStorageNameData()
        {
            ValidStorageNames.AddRange(ValidServiceNames);
        }

        private static void InitializeValidDeploymentNameData()
        {
            ValidDeploymentNames.Add("MyDeployment");
            ValidDeploymentNames.Add("Storage deployment");
            ValidDeploymentNames.Add("_deployment name");
            ValidDeploymentNames.Add("deploy service1");
        }

        private static void InitializeValidSubscriptionNameData()
        {
            ValidSubscriptionName.Add("mysub1");
            ValidSubscriptionName.Add("mysub2");
            ValidSubscriptionName.Add(Data.Subscription1);
            ValidSubscriptionName.Add(Data.SampleSubscription1);
            ValidSubscriptionName.Add("TestSubscription1");
            ValidSubscriptionName.Add("TestSubscription2");
        }

        private static void InitializeValidServiceNameData()
        {
            ValidServiceNames.Add("HelloNode");
            ValidServiceNames.Add("node.jsservice");
            ValidServiceNames.Add("node_js_service");
            ValidServiceNames.Add("node-js-service");
            ValidServiceNames.Add("node-js-service123");
            ValidServiceNames.Add("123node-js-service123");
            ValidServiceNames.Add("123node-js2service");
        }

        private static void InitializeInvalidServiceNameData()
        {
            InvalidServiceNames.Add("Hello\\Node");
            InvalidServiceNames.Add("Hello/Node");
            InvalidServiceNames.Add("Node App Sample");
            InvalidServiceNames.Add("My$app");
            InvalidServiceNames.Add("My@app");
            InvalidServiceNames.Add("My#app");
            InvalidServiceNames.Add("My%app");
            InvalidServiceNames.Add("My^app");
            InvalidServiceNames.Add("My&app");
            InvalidServiceNames.Add("My*app");
            InvalidServiceNames.Add("My+app");
            InvalidServiceNames.Add("My=app");
            InvalidServiceNames.Add("My{app");
            InvalidServiceNames.Add("My}app");
            InvalidServiceNames.Add("My(app");
            InvalidServiceNames.Add("My)app");
            InvalidServiceNames.Add("My[app");
            InvalidServiceNames.Add("My]app");
            InvalidServiceNames.Add("My|app");
            InvalidServiceNames.Add("-MyDomain");
            InvalidServiceNames.Add("MyDomain-");
            InvalidServiceNames.Add("-MyDomain-");
            InvalidServiceNames.Add(new string('a', 64));
        }

        private static void InitializeValidServiceRootNameData()
        {
            ValidServiceRootNames.AddRange(ValidServiceNames);
        }

        private static void InitializeValidSubscriptionsData()
        {
            ValidSubscriptionsData.Add(Testing.GetTestResourcePath("subscriptions.xml"));
        }

        private static void InitializeInvalidSubscriptionsData()
        {
            InvalidSubscriptionsData.Add(Testing.GetTestResourcePath("invalidsubscriptions.xml"));
        }
    }
}