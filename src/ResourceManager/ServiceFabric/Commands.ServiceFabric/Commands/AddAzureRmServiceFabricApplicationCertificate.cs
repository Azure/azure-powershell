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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Add, CmdletNoun.AzureRmServiceFabricApplicationCertificate, SupportsShouldProcess = true), OutputType(typeof(PSKeyVault))]
    public class AddAzureRmServiceFabricApplicationCertificate : ServiceFabricClusterCertificateCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var certInformations = base.GetOrCreateCertificateInformation();

            var certInformation = certInformations[0];

            if (ShouldProcess(target: this.Name, action: string.Format("Add application certificate")))
            {
                var allTasks = new List<Task>();
                var vmssPages = this.ComputeClient.VirtualMachineScaleSets.List(this.ResourceGroupName);

                if (vmssPages == null || !vmssPages.Any())
                {
                    throw new PSArgumentException(string.Format(
                        ServiceFabricProperties.Resources.NoneNodeTypeFound,
                        this.ResourceGroupName));
                }

                do
                {
                    if (!vmssPages.Any())
                    {
                        break;
                    }

                    allTasks.AddRange(vmssPages.Select(vmss => AddCertToVmssTask(vmss, certInformation)));

                } while (!string.IsNullOrEmpty(vmssPages.NextPageLink) &&
                         (vmssPages = this.ComputeClient.VirtualMachineScaleSets.ListNext(vmssPages.NextPageLink)) != null);

                WriteClusterAndVmssVerboseWhenUpdate(allTasks, false);
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