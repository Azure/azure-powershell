//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models
{
    using System.Text.RegularExpressions;

    public class PsApiManagementArmResource
    {
        // resource group regex
        static readonly Regex ResourceGroupRegex = new Regex(@"(.*?)/resourcegroups/(?<rgname>\S+)/providers/(.*?)", RegexOptions.IgnoreCase);

        // service name regex
        static readonly Regex ServiceNameRegex = new Regex(@"(.*?)/providers/microsoft.apimanagement/service/(?<serviceName>[^/]+)", RegexOptions.IgnoreCase);

        /// <summary>
        /// Arm Identifier of the Resource
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Resource Group Name the resource is part of.
        /// </summary>
        public string ResourceGroupName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Id))
                {
                    return null;
                }

                var match = ResourceGroupRegex.Match(Id);
                if (match.Success)
                {
                    var resourceGroupNameGroup = match.Groups["rgname"];
                    if (resourceGroupNameGroup != null && resourceGroupNameGroup.Success)
                    {
                        return resourceGroupNameGroup.Value;
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// Api Management service Name to which the Resource belongs
        /// </summary>
        public string ServiceName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Id))
                {
                    return null;
                }

                var match = ServiceNameRegex.Match(Id);
                if (match.Success)
                {
                    var serviceName = match.Groups["serviceName"];
                    if (serviceName != null && serviceName.Success)
                    {
                        return serviceName.Value;
                    }
                }

                return null;
            }
        }
    }
}
