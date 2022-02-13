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

    public class PsApiManagementCertificate : PsApiManagementArmResource
    {
        static readonly Regex CertificateIdRegex = new Regex(@"(.*?)/providers/microsoft.apimanagement/service/(?<serviceName>[^/]+)/certificates/(?<certificateId>[^/]+)", RegexOptions.IgnoreCase);

        public string CertificateId { get; set; }

        public string Subject { get; set; }

        public string Thumbprint { get; set; }

        public DateTime ExpirationDate { get; set; }

        public PsApiManagementKeyVaultEntity KeyVault { get; set; }

        public PsApiManagementCertificate() { }

        public PsApiManagementCertificate(string armResourceId)
        {
            this.Id = armResourceId;

            var match = CertificateIdRegex.Match(Id);
            if (match.Success)
            {
                var certificateIdRegexResult = match.Groups["certificateId"];
                if (certificateIdRegexResult != null && certificateIdRegexResult.Success)
                {
                    this.CertificateId = certificateIdRegexResult.Value;
                    return;
                }
            }

            throw new ArgumentException($"ResourceId {armResourceId} is not a valid Certificate Id.");
        }
    }
}