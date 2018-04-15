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
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Remove, CmdletNoun.AzureRmServiceFabricClientCertificate, SupportsShouldProcess = true),
     OutputType(typeof (PSCluster))]
    public class RemoveAzureRmServiceFabricClientCertificate : ServiceFabricClientCertificateBase
    {
        public override void ExecuteCmdlet()
        {
            var cluster = GetCurrentCluster();

            if (ShouldProcess(target: this.Name, action: string.Format("Remove a client certificate")))
            {
                switch (ParameterSetName)
                {
                    case SingleUpdateWithThumbprintSet:
                    case MultipleUpdatesWithThumbprintSet:
                    {
                        var oldCertThumbprints = cluster.ClientCertificateThumbprints.Select(
                            c => c.CertificateThumbprint).ToDictionary(
                                c => c,
                                StringComparer.OrdinalIgnoreCase);

                        var toRemoveThumbprints = ParseArgumentsForThumbprint();

                        if (oldCertThumbprints.Any())
                        {
                            var notExist = toRemoveThumbprints.SingleOrDefault(
                                c => !oldCertThumbprints.ContainsKey(
                                    c.CertificateThumbprint));

                            if (notExist != null)
                            {
                                throw new PSArgumentException(
                                    string.Format(
                                        ServiceFabricProperties.Resources.CannotFindCertificateInCluster,
                                        notExist.CertificateThumbprint));
                            }
                        }
                        else
                        {
                            throw new PSArgumentException(
                                string.Format(
                                    ServiceFabricProperties.Resources.NoneCertificateFound));
                        }

                        var thumbprintList = cluster.ClientCertificateThumbprints.ToList();
                        foreach (var thumbprint in toRemoveThumbprints)
                        {
                            thumbprintList.RemoveAll(c => string.Equals(
                                c.CertificateThumbprint,
                                thumbprint.CertificateThumbprint,
                                StringComparison.InvariantCultureIgnoreCase));
                        }

                        var patchRequest = new ClusterUpdateParameters
                        {
                            ClientCertificateThumbprints = thumbprintList ,
                            ClientCertificateCommonNames = cluster.ClientCertificateCommonNames
                        };

                        var psCluster = SendPatchRequest(patchRequest);
                        WriteObject(psCluster, true);
                        break;
                    }

                    case SingleUpdateWithCommonNameSet:
                    case MultipleUpdatesWithCommonNameSet:
                    {
                        var oldCommonNames = cluster.ClientCertificateCommonNames
                            .GroupBy(c => c.CertificateCommonName + c.CertificateIssuerThumbprint,
                                StringComparer.OrdinalIgnoreCase)
                            .ToDictionary(c => c.Key, c => c.First(), StringComparer.OrdinalIgnoreCase);

                        var toRemoveCommonName = ParseArgumentsForCommonName(true);

                        if (oldCommonNames.Any())
                        {
                            var notExist = toRemoveCommonName.SingleOrDefault(
                                c => !oldCommonNames.ContainsKey(
                                    c.CertificateCommonName + c.CertificateIssuerThumbprint));

                            if (notExist != null)
                            {
                                throw new PSArgumentException(
                                    string.Format(
                                        ServiceFabricProperties.Resources.CannotFindCommonNameAndIssuer,
                                        notExist.CertificateCommonName,
                                        notExist.CertificateIssuerThumbprint));
                            }
                        }
                        else
                        {
                            throw new PSArgumentException(string.Format(
                                ServiceFabricProperties.Resources.NoneCertificateFound));
                        }

                        var commonNames = cluster.ClientCertificateCommonNames.ToList();
                        foreach (var commonName in toRemoveCommonName)
                        {
                            commonNames.RemoveAll(c => string.Equals(
                                commonName.CertificateCommonName + commonName.CertificateIssuerThumbprint,
                                c.CertificateCommonName + c.CertificateIssuerThumbprint,
                                StringComparison.OrdinalIgnoreCase));
                        }

                        var patchRequest = new ClusterUpdateParameters
                        {
                            ClientCertificateCommonNames = commonNames,
                            ClientCertificateThumbprints = cluster.ClientCertificateThumbprints
                        };

                        var psCluster = SendPatchRequest(patchRequest);
                        WriteObject(psCluster, true);
                        break;
                    }
                }
            }
        }
    }
}