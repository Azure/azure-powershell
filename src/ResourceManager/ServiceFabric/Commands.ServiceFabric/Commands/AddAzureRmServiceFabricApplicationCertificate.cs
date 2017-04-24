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
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Add, CmdletNoun.AzureRmServiceFabricApplicationCertificate, SupportsShouldProcess = true), OutputType(typeof(PSKeyVault))]
    public class AddAzureRmServiceFabricApplicationCertificate : ServiceFabricClusterCertificateCmdlet
    {
        public override void ExecuteCmdlet()
        {
            var certInformation = base.GetOrCreateCertificateInformation();
            var vmssPages = ComputeClient.VirtualMachineScaleSets.List(this.ResourceGroupName);

            var allTasks = new List<Task>();
            if (ShouldProcess(target: this.Name, action: string.Format("Add application certificate to {0}", this.Name)))
            {
                do
                {
                    if (vmssPages == null || !vmssPages.Any())
                    {
                        throw new PSArgumentException(string.Format(
                            ServiceFabricProperties.Resources.NoneNodeTypeFound,
                            this.ResourceGroupName));
                    }

                    foreach (var vmss in vmssPages)
                    {
                        var secretGroup = vmss.VirtualMachineProfile.OsProfile.Secrets.SingleOrDefault(
                            s =>
                                s.SourceVault.Id.Equals(certInformation.KeyVault.Id, StringComparison.OrdinalIgnoreCase));
                        if (secretGroup == null)
                        {
                            vmss.VirtualMachineProfile.OsProfile.Secrets.Add(
                                new VaultSecretGroup()
                                {
                                    SourceVault = new SubResource()
                                    {
                                        Id = certInformation.KeyVault.Id
                                    },
                                    VaultCertificates = new List<VaultCertificate>()
                                    {
                                        new VaultCertificate()
                                        {
                                            CertificateStore = Constants.DefaultCertificateStore,
                                            CertificateUrl = certInformation.SecretUrl
                                        }
                                    }
                                });
                        }
                        else
                        {
                            if (secretGroup.VaultCertificates != null)
                            {
                                var exsit =
                                    secretGroup.VaultCertificates.Any(
                                        cert =>
                                            cert.CertificateUrl.Equals(certInformation.SecretUrl,
                                                StringComparison.OrdinalIgnoreCase));

                                if (!exsit)
                                {
                                    secretGroup.VaultCertificates.Add(
                                        new VaultCertificate()
                                        {
                                            CertificateStore = Constants.DefaultCertificateStore,
                                            CertificateUrl = certInformation.SecretUrl
                                        });
                                }
                            }
                            else
                            {
                                secretGroup.VaultCertificates = new List<VaultCertificate>()
                                {
                                    new VaultCertificate()
                                    {
                                        CertificateStore = Constants.DefaultCertificateStore,
                                        CertificateUrl = certInformation.SecretUrl
                                    }
                                };
                            }
                        }

                        allTasks.Add(
                            ComputeClient.VirtualMachineScaleSets.CreateOrUpdateAsync(
                                this.ResourceGroupName,
                                vmss.Name,
                                vmss));
                    }
                } while (!string.IsNullOrEmpty(vmssPages.NextPageLink) &&
                         (vmssPages = ComputeClient.VirtualMachineScaleSets.ListNext(vmssPages.NextPageLink)) != null);

                Task.WaitAll(allTasks.ToArray());
            }

            WriteObject(new PSKeyVault()
            {
                Certificate = certInformation.Certificate,
                KeyVaultName = certInformation.KeyVault.Name,
                KeyVaultCertificateName = certInformation.KeyVault.Name,
                KeyVaultSecretName = certInformation.SecretName,
                KeyVaultSecretVersion = certInformation.Version
            });

        }
    }
}