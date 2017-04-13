﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Newtonsoft.Json.Linq;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Add, CmdletNoun.AzureRmServiceFabricClusterCertificate), OutputType(typeof(PsCluster))]
    public class AddAzureRmServiceFabricClusterCertificate : ServiceFabricClusterCertificateCmdlet
    {
        public override void ExecuteCmdlet()
        {
            var clusterResource = GetCurrentCluster();
            var clusterType = GetClusterType(clusterResource);

            if (clusterType == ClusterType.Unsecure)
            {
                throw new PSInvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.AddCertToUnsecureCluster,
                        this.ClusterName));
            }

            var certInformation = base.GetOrCreateCertificateInformation();

            foreach (var vmss in ComputeClient.VirtualMachineScaleSets.List(this.ResourceGroupName))
            {
                var ext = FindFabricVmExt(vmss.VirtualMachineProfile.ExtensionProfile.Extensions);

                var extConfig = (JObject)ext.Settings;
                var input = string.Format(
                    @"{{""thumbprint"":""{0}"",""x509StoreName"":""{1}""}}",
                    certInformation.Thumbprint,
                    "My");

                extConfig["certificateSecondary"] = JObject.Parse(input);

                vmss.VirtualMachineProfile.
                    ExtensionProfile.
                    Extensions.
                    First().
                    Settings = extConfig;

                bool existing = false;
                if (vmss.VirtualMachineProfile.OsProfile.Secrets != null)
                {
                    foreach (var vaultSecretGroup in vmss.VirtualMachineProfile.OsProfile.Secrets)
                    {
                        if (string.Compare(
                            vaultSecretGroup.SourceVault.Id,
                            certInformation.KeyVault.Id,
                            StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            vaultSecretGroup.VaultCertificates.Add(
                                new VaultCertificate(certInformation.SecretUrl, Constants.DefaultCertificateStore));

                            existing = true;
                        }
                    }
                }

                if (!existing)
                {
                    vmss.VirtualMachineProfile.OsProfile.Secrets.Add(
                       new VaultSecretGroup(
                           new SubResource(certInformation.KeyVault.Id),
                           new[]
                           {
                            new VaultCertificate(certInformation.SecretUrl, Constants.DefaultCertificateStore)
                           }));
                }

                ComputeClient.VirtualMachineScaleSets.CreateOrUpdate(
                    ResourceGroupName,
                    vmss.Name,
                    vmss);
            }
            var patchRequest = new ClusterUpdateParameters
            {
                Certificate = clusterResource.Certificate
            };
            
            patchRequest.Certificate.ThumbprintSecondary = certInformation.Thumbprint;
            var cluster = SendPatchRequest(patchRequest);
            WriteObject(cluster);
        }
    }
}
