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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Newtonsoft.Json.Linq;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceFabricClusterCertificate", SupportsShouldProcess = true), OutputType(typeof(PSCluster))]
    public class AddAzureRmServiceFabricClusterCertificate : ServiceFabricClusterCertificateCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var clusterResource = GetCurrentCluster();
            var clusterType = GetClusterType(clusterResource);

            if (clusterType == ClusterType.Unsecure)
            {
                throw new PSInvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.AddCertToUnsecureCluster,
                        this.Name));
            }

            if ((this.CertificateCommonName != null && clusterResource.Certificate != null) ||
                (this.CertificateCommonName == null && clusterResource.CertificateCommonNames != null))
            {
                throw new PSInvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.CertificateMixTPAndCN,
                        this.Name));
            }

            if (ShouldProcess(target: this.Name, action: string.Format("Add cluster certificate")))
            {
                var certInformations = base.GetOrCreateCertificateInformation();
                var certInformation = certInformations[0];

                if (this.CertificateCommonName != null && this.CertificateCommonName != certInformation.CertificateCommonName)
                {
                    throw new PSArgumentException(
                        string.Format(ServiceFabricProperties.Resources.CertificateCommonNameMismatch,
                        this.CertificateCommonName,
                        certInformation.CertificateCommonName));
                }

                var addTasks = CreateAddOrRemoveCertVMSSTasks(certInformation, clusterResource.ClusterId, true);

                try
                {
                    WriteClusterAndVmssVerboseWhenUpdate(addTasks, false);
                }
                catch (AggregateException)
                {
                    WriteWarning("Exception while performing operation. Rollingback...");
                    var removeTasks = CreateAddOrRemoveCertVMSSTasks(certInformation, clusterResource.ClusterId, true, false);
                    WriteClusterAndVmssVerboseWhenUpdate(removeTasks, false);
                    WriteWarning("Operation rolled back, the certificate was removed from VMSS model.");
                    throw;
                }

                var patchRequest = new ClusterUpdateParameters();
                if (this.CertificateCommonName != null)
                {
                    string issuerTP = this.CertificateIssuerThumbprint != null ? this.CertificateIssuerThumbprint : String.Empty;
                    patchRequest.CertificateCommonNames = clusterResource.CertificateCommonNames;
                    patchRequest.CertificateCommonNames.CommonNames.Add(new ServerCertificateCommonName(this.CertificateCommonName, issuerTP));
                }
                else
                {
                    patchRequest.Certificate = clusterResource.Certificate;
                    patchRequest.Certificate.ThumbprintSecondary = certInformation.CertificateThumbprint;
                }

                var cluster = SendPatchRequest(patchRequest);
                WriteObject(cluster);
            }
        }
    }
}
