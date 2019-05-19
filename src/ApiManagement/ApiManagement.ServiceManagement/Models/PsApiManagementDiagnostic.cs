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

    public class PsApiManagementDiagnostic : PsApiManagementArmResource
    {
        static readonly Regex DiagnosticIdRegex = new Regex(@"(.*?)/providers/microsoft.apimanagement/service/(?<serviceName>[^/]+)/diagnostics/(?<diagnosticsId>[^/]+)", RegexOptions.IgnoreCase);

        static readonly Regex ApiDiagnosticIdRegex = new Regex(@"(.*?)/providers/microsoft.apimanagement/service/(?<serviceName>[^/]+)/apis/(?<apiId>[^/]+)/diagnostics/(?<diagnosticsId>[^/]+)", RegexOptions.IgnoreCase);

        /// <summary>
        /// Gets or sets the DiagnosticId of the resource
        /// </summary>
        public string DiagnosticId { get; set; }

        /// <summary>
        /// Gets or sets the ApiId to which the diagnostic is attached
        /// </summary>
        private string apiId;
        public string ApiId
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Id))
                {
                    var match = ApiDiagnosticIdRegex.Match(Id);
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

        /// <summary>
        /// Gets or sets specifies for what type of messages sampling settings
        /// should not apply. Possible values include: 'allErrors'
        /// </summary>
        public string AlwaysLog { get; set; }

        /// <summary>
        /// Gets or sets resource Id of a target logger.
        /// </summary>        
        public string LoggerId { get; set; }

        /// <summary>
        /// Gets or sets whether to process Correlation Headers coming to Api
        /// Management Service. Only applicable to Application Insights
        /// diagnostics. Default is true.
        /// </summary>
        public bool? EnableHttpCorrelationHeader { get; set; }

        /// <summary>
        /// Gets or sets sampling settings for Diagnostic.
        /// </summary>
        public PsApiManagementSamplingSetting SamplingSetting { get; set; }

        /// <summary>
        /// Gets or sets diagnostic settings for incoming/outgoing HTTP
        /// messages to the Gateway.
        /// </summary>
        public PsApiManagementPipelineDiagnosticSetting FrontendSetting { get; set; }

        /// <summary>
        /// Gets or sets diagnostic settings for incoming/outgoing HTTP
        /// messages to the Backend
        /// </summary>
        public PsApiManagementPipelineDiagnosticSetting BackendSetting { get; set; }

        public PsApiManagementDiagnostic() { }

        public PsApiManagementDiagnostic(string armResourceId)
        {
            this.Id = armResourceId;

            var match = DiagnosticIdRegex.Match(Id);
            if (match.Success)
            {
                var diagnosticIdRegex = match.Groups["diagnosticsId"];
                if (diagnosticIdRegex != null && diagnosticIdRegex.Success)
                {
                    this.DiagnosticId = diagnosticIdRegex.Value;
                    return;
                }                
            }
            else
            {
                match = ApiDiagnosticIdRegex.Match(Id);
                if (match.Success)
                {
                    var apiIdRegex = match.Groups["apiId"];
                    if (apiIdRegex != null && apiIdRegex.Success)
                    {
                        this.ApiId = apiIdRegex.Value;
                    }

                    var diagnosticIdRegex = match.Groups["diagnosticsId"];
                    if (diagnosticIdRegex != null && diagnosticIdRegex.Success)
                    {
                        this.DiagnosticId = diagnosticIdRegex.Value;

                        return;
                    }
                }
            }

            throw new ArgumentException($"ResourceId {armResourceId} is not a valid DiagnosticId");
        }
    }
}
