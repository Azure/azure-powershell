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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test
{
    public class Category
    {
        public const string Scenario = "AzureRTScenario";
        public const string Functional = "Functional";
        public const string Preview = "Preview";
        public const string Sequential = "Sequential";
        public const string Network = "Network";
        public const string Upload = "AzureRTUpload";
        public const string CleanUp = "AzureRTCleanUp";

        // Acceptance type
        public const string AcceptanceType = "AcceptanceType";
        public const string BVT = "BVT";
        public const string CheckIn = "CheckIn";
    }

    public class LoadBalancerDistribution
    {
        public const string SourceIP = "sourceIP";
        public const string SourceIPProtorol = "sourceIPProtocol";
        public const string None = "none";
    }
}
