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
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    public class PsApiManagementGateway : PsApiManagementArmResource
    {
        static readonly Regex GatewayIdRegex = new Regex(@"(.*?)/providers/microsoft.apimanagement/service/(?<serviceName>[^/]+)/gateways/(?<gatewayId>[^/]+)", RegexOptions.IgnoreCase);

        public string GatewayId { get; set; }

        public string Description { get; set; }

        public PsApiManagementResourceLocation LocationData { get; set; }


        public PsApiManagementGateway() {  }

        public PsApiManagementGateway(string armResourceId)
        {
            this.Id = armResourceId;

            var match = GatewayIdRegex.Match(Id);
            if (match.Success)
            {
                var gatewayIdRegexResult = match.Groups["gatewayId"];
                if (gatewayIdRegexResult != null && gatewayIdRegexResult.Success)
                {
                    this.GatewayId = gatewayIdRegexResult.Value;
                    return;
                }
            }

            throw new ArgumentException($"ResourceId {armResourceId} is not a valid Gateway Id.");
        }
    }
}