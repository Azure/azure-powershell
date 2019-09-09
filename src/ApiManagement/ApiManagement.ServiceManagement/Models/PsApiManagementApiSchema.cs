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
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class PsApiManagementApiSchema : PsApiManagementArmResource
    {
        static readonly Regex ApiSchemaIdRegex = new Regex(@"(.*?)/providers/microsoft.apimanagement/service/(?<serviceName>[^/]+)/apis/(?<apiId>[^/]+)/schemas/(?<schemaId>[^/]+)", RegexOptions.IgnoreCase);

        [Ps1Xml(Label = "SchemaId", Target = ViewControl.List)]
        public string SchemaId { get; set; }

        private string apiId;
        [Ps1Xml(Label = "Api Id", Target = ViewControl.List)]
        public string ApiId
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Id))
                {
                    var match = ApiSchemaIdRegex.Match(Id);
                    if (match.Success)
                    {
                        var apiNameGroup = match.Groups["apiId"];
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

        [Ps1Xml(Label = "Schema ContentType", Target = ViewControl.List)]
        public string SchemaDocumentContentType { get; set; }

        [Ps1Xml(Label = "Schema Document", Target = ViewControl.List, ScriptBlock = "if (($_.schemaDocument -ne $null) -and ($_.schemaDocument.Length -gt 40)) { $_.schemaDocument.Substring(0, 40) + \"....\" } elseif ($_.schemaDocument -ne $null) { $_.schemaDocument } else { $null }")]
        public string SchemaDocument { get; set; }

        public PsApiManagementApiSchema() { }

        public PsApiManagementApiSchema(string armResourceId)
        {
            this.Id = armResourceId;

            var match = ApiSchemaIdRegex.Match(Id);
            if (match.Success)
            {
                var apiIdRegex = match.Groups["apiId"];
                if (apiIdRegex != null && apiIdRegex.Success)
                {
                    this.ApiId = apiIdRegex.Value;
                }

                var schemaIdRegex = match.Groups["schemaId"];
                if (schemaIdRegex != null && schemaIdRegex.Success)
                {
                    this.SchemaId = schemaIdRegex.Value;

                    return;
                }
            }

            throw new ArgumentException($"ResourceId {armResourceId} is not a valid Api Schema Id");
        }
    }
}
