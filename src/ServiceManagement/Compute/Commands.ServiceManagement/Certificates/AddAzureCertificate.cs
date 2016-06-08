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

using System;
using System.IO;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Certificates
{
    /// <summary>
    /// Upload a service certificate for the specified hosted service.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzureCertificate"), OutputType(typeof(ManagementOperationContext))]
    public class AddAzureCertificate : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Hosted Service Name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "Certificate to deploy.")]
        [ValidateNotNullOrEmpty]
        public object CertToDeploy
        {
            get;
            set;
        }

        [Parameter(HelpMessage = "Certificate password.")]
        public string Password
        {
            get;
            set;
        }

        internal void ExecuteCommand()
        {
            Password = Password ?? string.Empty;

            var certData = GetCertificateData();

            var parameters = new ServiceCertificateCreateParameters
            {
                Data = certData,
                Password = Password,
                CertificateFormat = CertificateFormat.Pfx
            };
            ExecuteClientActionNewSM(
                null, 
                CommandRuntime.ToString(),
                () => this.ComputeClient.ServiceCertificates.Create(this.ServiceName, parameters));
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();
            this.ExecuteCommand();
        }

        private byte[] GetCertificateData()
        {
            if ((CertToDeploy is PSObject) && ((PSObject)CertToDeploy).ImmediateBaseObject is X509Certificate2)
            {
                var cert = ((PSObject)CertToDeploy).ImmediateBaseObject as X509Certificate2;
                return CertUtilsNewSM.GetCertificateData(cert);
            }
            else if (CertToDeploy is X509Certificate2)
            {
                return CertUtilsNewSM.GetCertificateData(CertToDeploy as X509Certificate2);
            }
            else
            {
                var certPath = this.ResolvePath(CertToDeploy.ToString());
                return File.ReadAllBytes(certPath);
            }
        }
    }
}
