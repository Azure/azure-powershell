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
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Remove, CmdletNoun.AzureRmServiceFabricClientCertificate), OutputType(typeof(PSCluster))]
    public class RemoveAzureRmServiceFabricClientCertificate : AddAzureRmServiceFabricClientCertificate
    {
        public override bool IsAdmin { get; set; }

        public override void ExecuteCmdlet()
        {
            var cluster = SFRPClient.Clusters.Get(
                ResourceGroupName,
                ClusterName);

            switch (ParameterSetName)
            {
                case SingleUpdateWithThumbprintSet:
                case MultipleUpdatesWithThumbprintSet:
                    {
                        var oldCertThumbprints = cluster.ClientCertificateThumbprints.Select(
                            c => c.CertificateThumbprint).ToDictionary(
                                c => c,
                                StringComparer.InvariantCultureIgnoreCase);

                        var toRemoveThumbprints = ParseArgumentsForThumbprint();

                        if (oldCertThumbprints != null)
                        {
                            var notExist = toRemoveThumbprints.SingleOrDefault(
                                c => !oldCertThumbprints.ContainsKey(
                                      c.CertificateThumbprint));

                            if (notExist != null)
                            {
                                throw new PSArgumentException(
                                    string.Format(
                                        ServiceFabricProperties.Resources.CanNodFindCertificateInCluster,
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
                            ClientCertificateThumbprints = thumbprintList
                        };

                        var psCluster = SendPatchRequest(patchRequest);
                        WriteObject(psCluster,true);
                        break;
                    }

                case SingleUpdateWithCommonNameSet:
                case MultipleUpdatesWithCommonNameSet:
                    {
                        var oldCommonNames = cluster.ClientCertificateCommonNames.Select(
                           c => c.CertificateCommonName + c.CertificateIssuerThumbprint).
                           ToDictionary(c => c, StringComparer.InvariantCultureIgnoreCase);

                        var toRemoveCommonName = ParseArgumentsForCommonName(true);

                        if (oldCommonNames != null)
                        {
                            var notExist = toRemoveCommonName.SingleOrDefault(
                                c => !oldCommonNames.ContainsKey(
                                    c.CertificateCommonName + c.CertificateIssuerThumbprint));

                            if (notExist != null)
                            {
                                throw new PSArgumentException(
                                    string.Format(
                                        ServiceFabricProperties.Resources.CanNodFindCommonNameAndIssuer,
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
                                StringComparison.InvariantCultureIgnoreCase));
                        }

                        var patchRequest = new ClusterUpdateParameters
                        {
                            ClientCertificateCommonNames = commonNames
                        };

                        var psCluster = SendPatchRequest(patchRequest);
                        WriteObject(psCluster,true);
                        break;
                    }
            }
        }
    }
}
