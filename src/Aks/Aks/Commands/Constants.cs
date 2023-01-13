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

namespace Microsoft.Azure.Commands.Aks
{
    public static class Constants
    {
        public const string AksHelpUri = "https://docs.microsoft.com/en-us/powershell/module/?view=azurermps-5.0.0";
        public const string Name = "Name";
        public const string DefaultParameterSet = "defaultParameterSet";
        public const string IdParameterSet = "IdParameterSet";
        public const string GroupNameParameterSet = "GroupNameParameterSet";
        public const string InputObjectParameterSet = "InputObjectParameterSet";
        public const string NameParameterSet = "NameParameterSet";
        public const string ParentNameParameterSet = "ParentNameParameterSet";
        public const string ParentObjectParameterSet = "ParentObjectParameterSet";

        public const string NodePool = "AksNodePool";


        public readonly static IDictionary<string, string> AddOnUserReadNameToServiceNameMapper = new Dictionary<string, string>
        {
            { "HttpApplicationRouting", "httpapplicationrouting" },
            { "Monitoring", "omsagent" },
            { "VirtualNode", "aciConnector" },
            { "AzurePolicy", "azurepolicy " },
            { "KubeDashboard", "kubeDashboard" },
        };
        public const string AddOnNameMonitoring = "Monitoring";
        public const string AddOnNameVirtualNode = "VirtualNode";

        internal const string DotNetApiParameterResourceGroupName = "resourceGroupName";
        internal const string DotNetApiParameterResourceName = "resourceName";
        internal const string DotNetApiParameterAgentPoolName = "agentPoolName";
    }
}