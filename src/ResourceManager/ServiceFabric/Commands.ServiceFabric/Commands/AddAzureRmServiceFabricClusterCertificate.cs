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
using Microsoft.Azure.Management.ServiceFabric.Models;
using Newtonsoft.Json.Linq;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Add, CmdletNoun.AzureRmServiceFabricClusterCertificate), OutputType(typeof(PSCluster))]
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

            if (ShouldProcess(target: this.Name, action: string.Format("Add cluster certificate")))
            {
                var certInformations = base.GetOrCreateCertificateInformation();
                var certInformation = certInformations[0];
                var allTasks = new List<Task>();
                var vmssPages = ComputeClient.VirtualMachineScaleSets.List(this.ResourceGroupName);

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

                    foreach (var vmss in vmssPages)
                    {
                        var ext = FindFabricVmExt(vmss.VirtualMachineProfile.ExtensionProfile.Extensions);

                        var extConfig = (JObject)ext.Settings;
                        var input = string.Format(
                            @"{{""thumbprint"":""{0}"",""x509StoreName"":""{1}""}}",
                            certInformation.Thumbprint,
                            Constants.DefaultCertificateStore);

                        extConfig["certificateSecondary"] = JObject.Parse(input);

                        vmss.VirtualMachineProfile.ExtensionProfile.Extensions.Single(
                            extension =>
                            extension.Name.Equals(ext.Name, StringComparison.OrdinalIgnoreCase)).Settings = extConfig;

                        allTasks.Add(AddCertToVmssTask(vmss, certInformation));
                    }
                } while (!string.IsNullOrEmpty(vmssPages.NextPageLink) &&
                        (vmssPages = ComputeClient.VirtualMachineScaleSets.ListNext(vmssPages.NextPageLink)) != null);

                WriteClusterAndVmssVerboseWhenUpdate(allTasks,false);

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
}