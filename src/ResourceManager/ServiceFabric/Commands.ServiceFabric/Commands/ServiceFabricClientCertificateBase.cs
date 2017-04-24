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
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = SingleUpdateWithCommonNameSet, ValueFromPipeline = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = SingleUpdateWithThumbprintSet, ValueFromPipeline = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = MultipleUpdatesWithCommonNameSet, ValueFromPipeline = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = MultipleUpdatesWithThumbprintSet, ValueFromPipeline = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = SingleUpdateWithCommonNameSet, ValueFromPipeline = true,
            HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = SingleUpdateWithThumbprintSet, ValueFromPipeline = true,
            HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = MultipleUpdatesWithCommonNameSet, ValueFromPipeline = true,
            HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = MultipleUpdatesWithThumbprintSet, ValueFromPipeline = true,
            HelpMessage = "Specify the name of the cluster")]
        [ValidateNotNullOrEmpty()]
        public override string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = MultipleUpdatesWithThumbprintSet,
                   HelpMessage = "Specify client certificate thumbprint which only has admin permission")]
        [ValidateNotNullOrEmpty()]
        public string[] AdminClientThumbprints { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = MultipleUpdatesWithThumbprintSet,
                  HelpMessage = "Specify client certificate thumbprint which only has read only permission")]
        [ValidateNotNullOrEmpty()]
        public string[] ReadonlyClientThumbprints { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = MultipleUpdatesWithCommonNameSet,
                   HelpMessage = "Specify client common name , issuer thumbprint and authentication type")]
        [ValidateNotNullOrEmpty()]
        public PSClientCertificateCommonName[] CommonNames { get; set; }

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

                        if ((this.AdminClientThumbprints == null || !this.AdminClientThumbprints.Any()) &&
                            (this.ReadonlyClientThumbprints == null) || !this.ReadonlyClientThumbprints.Any())
                        {
                            throw new PSArgumentException(
                                "Both AdminClientThumbprints and ReadonlyClientThumbprints are empty");
                        }

                        if (this.AdminClientThumbprints != null && this.AdminClientThumbprints.Any())
                        {
                            allCertThumbprints.AddRange(
                                this.AdminClientThumbprints.Select(t => new ClientCertificateThumbprint()
                                {
                                    CertificateThumbprint = t,
                                    IsAdmin = true
                                }));
                        }

                        if (this.ReadonlyClientThumbprints != null && this.ReadonlyClientThumbprints.Any())
                        {
                            allCertThumbprints.AddRange(
                                this.ReadonlyClientThumbprints.Select(t => new ClientCertificateThumbprint()
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
                        allCommonNames = this.CommonNames.Select(
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
