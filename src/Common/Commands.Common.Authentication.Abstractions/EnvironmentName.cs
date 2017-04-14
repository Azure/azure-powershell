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

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// Collection of built-in environment names for Azure
    /// </summary>
    public static class EnvironmentName
    {
        /// <summary>
        /// The Azure global cloud
        /// </summary>
        public const string AzureCloud = "AzureCloud";

        /// <summary>
        /// The Azure Cinese Cloud
        /// </summary>
        public const string AzureChinaCloud = "AzureChinaCloud";

        /// <summary>
        /// The Azure sovereign cloud for US Government
        /// </summary>
        public const string AzureUSGovernment = "AzureUSGovernment";

        /// <summary>
        /// The Azure Sovereign Cloud for Germany
        /// </summary>
        public const string AzureGermanCloud = "AzureGermanCloud";
    }
}
