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

using Microsoft.Azure.Commands.Automation.Common;
using System;

namespace Microsoft.Azure.Commands.Automation.Model
{
    public class CertificateInfo : BaseProperties
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateInfo"/> class.
        /// </summary>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="accountAcccountName">
        /// The account name.
        /// </param>
        /// <param name="certificate">
        /// The connection.
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public CertificateInfo(string resourceGroupName, string accountAcccountName, Azure.Management.Automation.Models.Certificate certificate)
        {
            Requires.Argument("certificate", certificate).NotNull();
            this.AutomationAccountName = accountAcccountName;
            this.ResourceGroupName = resourceGroupName;
            this.Name = certificate.Name;

            if (certificate.Properties == null) return;

            this.Description = certificate.Properties.Description;
            this.CreationTime = certificate.Properties.CreationTime.ToLocalTime();
            this.LastModifiedTime = certificate.Properties.LastModifiedTime.ToLocalTime();
            this.ExpiryTime = certificate.Properties.ExpiryTime.ToLocalTime();
            this.Thumbprint = certificate.Properties.Thumbprint;
            this.Exportable = certificate.Properties.IsExportable;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateInfo"/> class.
        /// </summary>
        public CertificateInfo()
        {
        }

        public string Thumbprint { get; set; }

        public bool Exportable { get; set; }

        public DateTimeOffset ExpiryTime { get; set; }
    }
}
