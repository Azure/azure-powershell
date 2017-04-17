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

using System.Collections;
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
    [Cmdlet(VerbsCommon.Add, CmdletNoun.AzureRmServiceFabricClientCertificate), OutputType(typeof(PSCluster))]
    public class AddAzureRmServiceFabricClientCertificate : ServiceFabricClusterCmdlet
    {
        protected const string SingleUpdateWithCommonNameSet = "SingleUpdateWithCommonName";
        protected const string SingleUpdateWithThumbprintSet = "SingleUpdateWithThumbprint";
        protected const string MultipleUpdatesWithCommonNameSet = "MultipleUpdatesWithCommonName";
        protected const string MultipleUpdatesWithThumbprintSet = "MultipleUpdatesWithThumbprint";

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = SingleUpdateWithCommonNameSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = SingleUpdateWithThumbprintSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = MultipleUpdatesWithCommonNameSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = MultipleUpdatesWithThumbprintSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = SingleUpdateWithCommonNameSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = SingleUpdateWithThumbprintSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = MultipleUpdatesWithCommonNameSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = MultipleUpdatesWithThumbprintSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster")]
        [ValidateNotNullOrEmpty()]
        public override string ClusterName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = MultipleUpdatesWithThumbprintSet,
                   HelpMessage = "Specify client certificate thumbprint and authentication type")]
        [ValidateNotNullOrEmpty()]
        [Alias("ThumbprintsAndAuthenticationTypes")]
        public Hashtable ThumbprintsAndTypes { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = MultipleUpdatesWithCommonNameSet,
                   HelpMessage = "Specify client common name , issuer thumbprint and authentication type")]
        [ValidateNotNullOrEmpty()]
        public PSClientCertificateCommonName[] CommonNames { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = SingleUpdateWithThumbprintSet,
                   HelpMessage = "Specify client certificate thumbprint")]
        [ValidateNotNullOrEmpty()]
        [Alias("ClientCertificateThumbprint")]
        public string Thumbprint { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = SingleUpdateWithCommonNameSet,
                   HelpMessage = "Specify client certificate common name")]
        [ValidateNotNullOrEmpty()]
        public string CommonName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = SingleUpdateWithCommonNameSet,
                   HelpMessage = "Specify thumbprint of client certificate's issuer")]
        [ValidateNotNullOrEmpty()]
        public string IssuerThumbprint { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = SingleUpdateWithThumbprintSet,
                   HelpMessage = "Client authentication type")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = SingleUpdateWithCommonNameSet,
                   HelpMessage = "Client authentication type")]
        [ValidateNotNullOrEmpty()]
        public virtual bool IsAdmin { get; set; }

        public override void ExecuteCmdlet()
        {
            var cluster = SFRPClient.Clusters.Get(ResourceGroupName, ClusterName);
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
                            ClientCertificateThumbprints = allCertThumbprints
                        };

                        var psCluster = SendPatchRequest(patchRequest);
                        WriteObject(psCluster,true);
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
                            ClientCertificateCommonNames = allNewCommonNames
                        };

                        var psCluster = SendPatchRequest(patchRequest);
                        WriteObject(psCluster,true);
                        break;
                    }
            }
        }

        protected List<ClientCertificateThumbprint> ParseArgumentsForThumbprint()
        {
            var allCertThumbprints = new List<ClientCertificateThumbprint>();
            if (this.ThumbprintsAndTypes != null)
            {
                foreach (var key in ThumbprintsAndTypes.Keys)
                {
                    if (key is string && !string.IsNullOrEmpty((string)key))
                    {
                        var thumbprint = (string)key;
                        var isAdminObj = this.ThumbprintsAndTypes[key];
                        bool isAdmin;
                        if (isAdminObj is string)
                        {
                            if (!bool.TryParse((string)isAdminObj, out isAdmin))
                            {
                                throw new PSArgumentException(
                                    ServiceFabricProperties.Resources.CanNotParseValueInThumbprintAndFlags);
                            }
                        }
                        else if (isAdminObj is bool)
                        {
                            isAdmin = (bool)isAdminObj;
                        }
                        else
                        {
                            throw new PSArgumentException(
                                ServiceFabricProperties.Resources.CanNotParseValueInThumbprintAndFlags);
                        }

                        allCertThumbprints.Add(new ClientCertificateThumbprint()
                        {
                            IsAdmin = isAdmin,
                            CertificateThumbprint = thumbprint
                        });

                    }
                    else
                    {
                        throw new PSArgumentException(
                            ServiceFabricProperties.Resources.CanNotParseValueInThumbprintAndFlags);
                    }
                }
            }
            else
            {
                allCertThumbprints.Add(
                    new ClientCertificateThumbprint()
                    {
                        IsAdmin = this.IsAdmin,
                        CertificateThumbprint = this.Thumbprint
                    });
            }

            return allCertThumbprints;
        }

        protected List<ClientCertificateCommonName> ParseArgumentsForCommonName(bool ignoreIssuerThumbprint)
        {
            var allCommonNames = new List<ClientCertificateCommonName>();
            if (this.CommonNames != null)
            {
                allCommonNames = this.CommonNames.Select(
                    c=> new ClientCertificateCommonName(
                        c.IsAdmin,
                        c.CertificateCommonName,
                        c.CertificateIssuerThumbprint)).ToList();
            }
            else
            {
                allCommonNames.Add(
                    new ClientCertificateCommonName()
                    {
                        CertificateCommonName = this.CommonName,
                        CertificateIssuerThumbprint = this.IssuerThumbprint,
                        IsAdmin = this.IsAdmin
                    });
            }

            return allCommonNames;
        }
    }
}