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
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [CmdletDeprecation(ReplacementCmdletName = VerbsCommon.Add +
        "-" +
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix +
        "VmssSecret")]
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceFabricApplicationCertificate", SupportsShouldProcess = true), OutputType(typeof(PSKeyVault))]
    public class AddAzureRmServiceFabricApplicationCertificate : ServiceFabricClusterCertificateCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            var clusterResource = GetCurrentCluster();
            var certInformations = base.GetOrCreateCertificateInformation();

            var certInformation = certInformations[0];

            if (ShouldProcess(target: this.Name, action: string.Format("Add application certificate")))
            {
                var addTasks = CreateAddOrRemoveCertVMSSTasks(certInformation, clusterResource.ClusterId, false);

                try
                {
                    WriteClusterAndVmssVerboseWhenUpdate(addTasks, false);
                }
                catch (AggregateException)
                {
                    WriteWarning("Exception while performing operation. Rollingback...");
                    var removeTasks = CreateAddOrRemoveCertVMSSTasks(certInformation, clusterResource.ClusterId, false, false);
                    WriteClusterAndVmssVerboseWhenUpdate(removeTasks, false);
                    WriteWarning("Operation rolled back, the certificate was removed from VMSS model.");
                    throw;
                }
            }

            WriteObject(new PSKeyVault()
            {
                KeyVaultName = certInformation.KeyVault.Name,
                KeyVaultId = certInformation.KeyVault.Id,
                KeyVaultCertificateName = certInformation.CertificateName,
                KeyVaultCertificateId = certInformation.CertificateUrl,
                CertificateThumbprint = certInformation.CertificateThumbprint,
                Certificate = certInformation.Certificate,
                CertificateSavedLocalPath = certInformation.CertificateOutputPath,
                SecretIdentifier = certInformation.SecretUrl
            });
        }
    }
}
