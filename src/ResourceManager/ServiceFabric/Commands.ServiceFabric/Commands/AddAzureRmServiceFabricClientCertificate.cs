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

using System.Management.Automation;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Add, CmdletNoun.AzureRmServiceFabricClientCertificate, SupportsShouldProcess = true), OutputType(typeof(PSCluster))]
    public class AddAzureRmServiceFabricClientCertificate : ServiceFabricClientCertificateBase
    {
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = SingleUpdateWithThumbprintSet,
                   HelpMessage = "Client authentication type")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = SingleUpdateWithCommonNameSet,
                   HelpMessage = "Client authentication type")]
        public SwitchParameter Admin { get; set; }

        protected override bool IsAdmin
        {
            get { return this.Admin.IsPresent; }
        }

        public override void ExecuteCmdlet()
        {
            var cluster = GetCurrentCluster();

            if (ShouldProcess(target: this.Name, action: string.Format("Add client certificate")))
            {
                switch (ParameterSetName)
                {
                    case SingleUpdateWithThumbprintSet:
                    case MultipleUpdatesWithThumbprintSet:
                        {
                            var oldCertThumbprints = cluster.ClientCertificateThumbprints;
                            var allCertThumbprints = ParseArgumentsForThumbprint();

                            if (oldCertThumbprints != null)
                            {
                                allCertThumbprints.AddRange(oldCertThumbprints);
                            }

                            var patchRequest = new ClusterUpdateParameters
                            {
                                ClientCertificateThumbprints = allCertThumbprints,
                                ClientCertificateCommonNames = cluster.ClientCertificateCommonNames
                            };

                            var psCluster = SendPatchRequest(patchRequest);
                            WriteObject(psCluster, true);
                            break;
                        }

                    case SingleUpdateWithCommonNameSet:
                    case MultipleUpdatesWithCommonNameSet:
                        {
                            var oldCommonNames = cluster.ClientCertificateCommonNames;
                            var allNewCommonNames = ParseArgumentsForCommonName(false);

                            if (oldCommonNames != null)
                            {
                                allNewCommonNames.AddRange(oldCommonNames);
                            }

                            var patchRequest = new ClusterUpdateParameters
                            {
                                ClientCertificateCommonNames = allNewCommonNames,
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