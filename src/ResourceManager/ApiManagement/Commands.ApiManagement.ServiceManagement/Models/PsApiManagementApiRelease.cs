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
    using System.Text.RegularExpressions;

    public class PsApiManagementApiRelease : PsApiManagementArmResource
    {
        // resource group regex
        static readonly Regex ApiNameRegex = new Regex(@"(.*?)/apis/(?<apiName>\S+)/releases/(.*?)", RegexOptions.IgnoreCase);

        public string ReleaseId { get; set; }

        private string apiId;
        public string ApiId
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Id))
                {
                    var match = ApiNameRegex.Match(Id);
                    if (match.Success)
                    {
                        var apiNameGroup = match.Groups["apiName"];
                        if (apiNameGroup != null && apiNameGroup.Success)
                        {
                            return apiNameGroup.Value;
                        }
                    }
                }

                return this.apiId;                
            }

            set
            {
                this.apiId = value;
            }
        }

        public DateTime? CreatedDateTime { get; private set; }

        public DateTime? UpdatedDateTime { get; private set; }

        public string Notes { get; set; }
    }
}
