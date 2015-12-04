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
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Compute;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Certificates
{
    /// <summary>
    /// Retrieve a specified service certificate.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureCertificate"), OutputType(typeof(CertificateContext))]
    public class GetAzureCertificate : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Hosted Service Name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Certificate thumbprint algorithm.")]
        [ValidateNotNullOrEmpty]
        public string ThumbprintAlgorithm
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Certificate thumbprint.")]
        [ValidateNotNullOrEmpty]
        public string Thumbprint
        {
            get;
            set;
        }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            if (this.Thumbprint != null)
            {
                if (this.ThumbprintAlgorithm == null)
                {
                    throw new ArgumentNullException("ThumbprintAlgorithm", Resources.MissingThumbprintAlgorithm);
                }

                var parameters = new ServiceCertificateGetParameters
                {
                    ServiceName =  ServiceName,
                    Thumbprint =  Thumbprint,
                    ThumbprintAlgorithm =  ThumbprintAlgorithm
                };
                ExecuteClientActionNewSM(
                    null,
                    CommandRuntime.ToString(),
                    () => this.ComputeClient.ServiceCertificates.Get(parameters),
                    (s, response) => new int[1].Select(i => ContextFactory<ServiceCertificateGetResponse, CertificateContext>(response, s)));
            }
            else
            {
                ExecuteClientActionNewSM(
                    null,
                    CommandRuntime.ToString(),
                    () => this.ComputeClient.ServiceCertificates.List(this.ServiceName),
                    (s, response) => response.Certificates.Select(c =>
                                                                  {
                                                                      var context = ContextFactory<ServiceCertificateListResponse.Certificate, CertificateContext>(c, s);
                                                                      context.ServiceName = this.ServiceName;
                                                                      return context;
                                                                  }));
            }
        }

        public void ExecuteCommand()
        {
            OnProcessRecord();
        }
    }
}