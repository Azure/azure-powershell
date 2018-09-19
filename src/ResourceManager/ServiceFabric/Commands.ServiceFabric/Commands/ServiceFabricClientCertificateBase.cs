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
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    public class ServiceFabricClientCertificateBase : ServiceFabricClusterCmdlet
    {
        protected const string SingleUpdateWithCommonNameSet = "SingleUpdateWithCommonName";
        protected const string SingleUpdateWithThumbprintSet = "SingleUpdateWithThumbprint";
        protected const string MultipleUpdatesWithCommonNameSet = "MultipleUpdatesWithCommonName";
        protected const string MultipleUpdatesWithThumbprintSet = "MultipleUpdatesWithThumbprint";

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = SingleUpdateWithCommonNameSet,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = SingleUpdateWithThumbprintSet,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = MultipleUpdatesWithCommonNameSet,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = MultipleUpdatesWithThumbprintSet,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = SingleUpdateWithCommonNameSet,
            HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = SingleUpdateWithThumbprintSet,
            HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = MultipleUpdatesWithCommonNameSet,
            HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = MultipleUpdatesWithThumbprintSet,
            HelpMessage = "Specify the name of the cluster")]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterName")]
        public override string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = MultipleUpdatesWithThumbprintSet,
                   HelpMessage = "Specify client certificate thumbprint which only has admin permission")]
        [ValidateNotNullOrEmpty()]
        public string[] AdminClientThumbprint { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = MultipleUpdatesWithThumbprintSet,
                  HelpMessage = "Specify client certificate thumbprint which only has read only permission")]
        [ValidateNotNullOrEmpty()]
        public string[] ReadonlyClientThumbprint { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = MultipleUpdatesWithCommonNameSet,
                   HelpMessage = "Specify client common name , issuer thumbprint and authentication type")]
        [ValidateNotNullOrEmpty()]
        [Alias("CertCommonName")]
        public PSClientCertificateCommonName[] ClientCertificateCommonName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = SingleUpdateWithThumbprintSet,
                   HelpMessage = "Specify client certificate thumbprint")]
        [ValidateNotNullOrEmpty()]
        [Alias("ClientCertificateThumbprint")]
        public string Thumbprint { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = SingleUpdateWithCommonNameSet,
                   HelpMessage = "Specify client certificate common name")]
        [ValidateNotNullOrEmpty()]
        public string CommonName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = SingleUpdateWithCommonNameSet,
                   HelpMessage = "Specify thumbprint of client certificate's issuer")]
        [ValidateNotNullOrEmpty()]
        public string IssuerThumbprint { get; set; }

        protected virtual bool IsAdmin { get; }

        protected List<ClientCertificateThumbprint> ParseArgumentsForThumbprint()
        {
            var allCertThumbprints = new List<ClientCertificateThumbprint>();
            switch (ParameterSetName)
            {
                case MultipleUpdatesWithThumbprintSet:
                    {

                        if ((this.AdminClientThumbprint == null || !this.AdminClientThumbprint.Any()) &&
                           (this.ReadonlyClientThumbprint == null || !this.ReadonlyClientThumbprint.Any()))
                        {
                            throw new PSArgumentException(
                                "Both AdminClientThumbprints and ReadonlyClientThumbprints are empty");
                        }

                        if (this.AdminClientThumbprint != null && this.AdminClientThumbprint.Any())
                        {
                            allCertThumbprints.AddRange(
                                this.AdminClientThumbprint.Select(t => new ClientCertificateThumbprint()
                                {
                                    CertificateThumbprint = t,
                                    IsAdmin = true
                                }));
                        }

                        if (this.ReadonlyClientThumbprint != null && this.ReadonlyClientThumbprint.Any())
                        {
                            allCertThumbprints.AddRange(
                                this.ReadonlyClientThumbprint.Select(t => new ClientCertificateThumbprint()
                                {
                                    CertificateThumbprint = t,
                                    IsAdmin = false
                                }));
                        }

                        return allCertThumbprints;
                    }

                case SingleUpdateWithThumbprintSet:

                    {
                        allCertThumbprints.Add(new ClientCertificateThumbprint()
                        {
                            CertificateThumbprint = this.Thumbprint,
                            IsAdmin = this.IsAdmin
                        });
                        return allCertThumbprints;
                    }
            }

            throw new PSArgumentException("Invalid ParameterSet");
        }

        protected List<ClientCertificateCommonName> ParseArgumentsForCommonName(bool ignoreIssuerThumbprint)
        {
            var allCommonNames = new List<ClientCertificateCommonName>();

            switch (ParameterSetName)
            {
                case MultipleUpdatesWithCommonNameSet:
                    {
                        allCommonNames = this.ClientCertificateCommonName.Select(
                            c => new ClientCertificateCommonName(
                                c.IsAdmin,
                                c.CertificateCommonName,
                                c.CertificateIssuerThumbprint)).ToList();
                        break;
                    }
                case SingleUpdateWithCommonNameSet:

                    {
                        allCommonNames.Add(
                            new ClientCertificateCommonName()
                            {
                                CertificateCommonName = this.CommonName,
                                CertificateIssuerThumbprint = this.IssuerThumbprint,
                                IsAdmin = this.IsAdmin
                            });
                        break;
                    }
            }

            return allCommonNames;
        }
    }
}
