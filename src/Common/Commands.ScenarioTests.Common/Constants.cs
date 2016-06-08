
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

namespace Microsoft.WindowsAzure.Commands.ScenarioTest
{
    public class Category
    {
        // Service
        public const string Service = "Service";

        public const string All = "All";

        public const string Automation = "Automation";

        public const string ServiceBus = "ServiceBus";

        public const string CloudService = "CloudService";

        public const string DiagnosticsExtension = "DiagnosticsExtension";

        public const string Management = "Management";

        public const string MediaServices = "MediaServices";

        public const string Websites = "Websites";

        public const string Storage = "Storage";

        public const string Store = "Store";

        public const string Sql = "Sql";

        public const string ServiceManagement = "ServiceManagement";

        public const string Resources = "Resources";

        public const string Tags = "Tags";

        public const string TrafficManager = "TrafficManager";

        public const string ManagedCache = "ManagedCache";

        public const string Scheduler = "Scheduler";

        public const string KeyVault = "KeyVault";

        public const string Network = "Network";

        public const string DevTestLabs = "DevTestLabs";

        // Owners
        public const string OneSDK = "OneSDK";

        // Acceptance type
        public const string AcceptanceType = "AcceptanceType";

        public const string CIT = "CIT";

        public const string BVT = "BVT";

        public const string CheckIn = "CheckIn";

        // Run Type
        public const string RunType = "RunType";
        public const string LiveOnly = "LiveOnly";
        //Uncomment when we need to tag on only run under mock
        //public const string MockedOnly = "MockedOnly";
       
        // Environment
        public const string Environment = "Environment";

        public const string WAPack = "WAPack";
    }

    public class Variables
    {
        public const string SubscriptionId = "SubscriptionId";

        public const string Username = "Username";

        public const string Tenantd = "Tenantd";
    }
}
