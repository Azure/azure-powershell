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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.CloudService
{
    class ServiceSettingsTestData
    {
        // To Do: Add bad cases for ServiceSettings
        public List<ServiceSettings> Good;
        public List<ServiceSettings> Bad;
        public Dictionary<ServiceSettingsState, ServiceSettings> Data;
        private static ServiceSettingsTestData instance;

        public static ServiceSettingsTestData Instance { get { if (instance == null) instance = new ServiceSettingsTestData(); return instance; } }

        private ServiceSettingsTestData()
        {
            InitializeGood();
            InitializeBad();
            InitializeData();
        }

        private void InitializeData()
        {
            ServiceSettings settings;

            Data = new Dictionary<ServiceSettingsState, ServiceSettings>();
            Data.Add(ServiceSettingsState.Default, new ServiceSettings());
            
            settings = new ServiceSettings();
            settings.Location = "South Central US";
            settings.Slot = DeploymentSlotType.Production;
            settings.StorageServiceName = "mystore";
            settings.Subscription = "TestSubscription2";
            Data.Add(ServiceSettingsState.Sample1, settings);

            settings = new ServiceSettings();
            settings.Location = "South Central US";
            settings.Slot = DeploymentSlotType.Production;
            settings.StorageServiceName = "mystore";
            settings.Subscription = "Does not exist subscription";
            Data.Add(ServiceSettingsState.DoesNotExistSubscription, settings);
        }

        private void InitializeGood()
        {
            Good = new List<ServiceSettings>();
        }

        private void InitializeBad()
        {
            Bad = new List<ServiceSettings>();
        }
    }

    enum ServiceSettingsState
    {
        Default,
        Sample1,
        DoesNotExistSubscription
    }
}