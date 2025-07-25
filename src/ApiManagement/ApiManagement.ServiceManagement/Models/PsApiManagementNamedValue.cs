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

using System;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models
{
    public class PsApiManagementNamedValue : PsApiManagementArmResource
    {
        static readonly Regex NamedvalueIdRegex = new Regex(@"(.*?)/providers/microsoft.apimanagement/service/(?<serviceName>[^/]+)/namedvalues/(?<certificateId>[^/]+)", RegexOptions.IgnoreCase);

        public string NamedValueId { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public string[] Tags { get; set; }

        public bool Secret { get; set; }

        public PsApiManagementKeyVaultEntity KeyVault { get; set; }

        public PsApiManagementNamedValue() { }

        public PsApiManagementNamedValue(string armResourceId)
        {
            this.Id = armResourceId;

            var match = NamedvalueIdRegex.Match(Id);
            if (match.Success)
            {
                var certificateIdRegexResult = match.Groups["certificateId"];
                if (certificateIdRegexResult != null && certificateIdRegexResult.Success)
                {
                    this.NamedValueId = certificateIdRegexResult.Value;
                    return;
                }
            }

            throw new ArgumentException($"ResourceId {armResourceId} is not a valid NamedValue Id.");
        }
    }
}