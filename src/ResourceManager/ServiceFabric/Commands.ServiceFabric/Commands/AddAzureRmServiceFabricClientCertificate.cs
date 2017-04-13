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
using System.Management.Automation;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Add, CmdletNoun.AzureRmServiceFabricClientCertificate), OutputType(typeof(PsCluster))]
    public class AddAzureRmServiceFabricClientCertificate : ServiceFabricClusterCmdlet
    {
        protected const string SingleUpdateWithCommonNameSet = "SingleUpdateWithCommonName";
        protected const string SingleUpdateWithThumbprintSet = "SingleUpdateWithThumbprint";
        protected const string MultipleUpdatesWithCommonNameSet = "MultipleUpdatesWithCommonName";
        protected const string MultipleUpdatesWithThumbprintSet = "MultipleUpdatesWithThumbprint";

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = MultipleUpdatesWithThumbprintSet,
                   HelpMessage = "Specify client certificate thumbprint and flag")]
        [ValidateNotNullOrEmpty()]
        public Hashtable ThumbprintsAndFlags { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = MultipleUpdatesWithCommonNameSet,
                   HelpMessage = "Specify client common name and issuer thumbprint(use ';' to separate them) and flag")]
        [ValidateNotNullOrEmpty()]
        public Hashtable CommonNameIssuersAndFlags { get; set; }

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
                   HelpMessage = "Specify client certificate issuer thumbprint")]
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
            if (this.ThumbprintsAndFlags != null)
            {
                foreach (var key in ThumbprintsAndFlags.Keys)
                {
                    if (key is string && !string.IsNullOrEmpty((string)key))
                    {
                        var thumbprint = (string)key;
                        var isAdminObj = this.ThumbprintsAndFlags[key];
                        bool isAdmin;
                        if (isAdminObj is string)
                        {
                            if (!bool.TryParse((string)isAdminObj, out isAdmin))
                            {
                                throw new PSArgumentException(ServiceFabricProperties.Resources.CanNotParseValueInThumbprintAndFlags);
                            }
                        }
                        else if (isAdminObj is bool)
                        {
                            isAdmin = (bool)isAdminObj;
                        }
                        else
                        {
                            throw new PSArgumentException(ServiceFabricProperties.Resources.CanNotParseValueInThumbprintAndFlags);
                        }

                        allCertThumbprints.Add(new ClientCertificateThumbprint()
                        {
                            IsAdmin = isAdmin,
                            CertificateThumbprint = thumbprint
                        });

                    }
                    else
                    {
                        throw new PSArgumentException(ServiceFabricProperties.Resources.CanNotParseValueInThumbprintAndFlags);
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
            if (this.CommonNameIssuersAndFlags != null)
            {
                foreach (var key in this.CommonNameIssuersAndFlags.Keys)
                {
                    if (key is string && !string.IsNullOrEmpty((string)key))
                    {
                        var commonNameAndIssuers = (string)key;
                        var result = commonNameAndIssuers.Split(';');
                        if (result.Length != 2 && !ignoreIssuerThumbprint)
                        {
                            throw new PSInvalidOperationException();
                        }

                        var commonName = result[0];
                        var issuer = result[1];

                        var isAdminObj = this.CommonNameIssuersAndFlags[key];
                        bool isAdmin;
                        if (isAdminObj is string)
                        {
                            if (!bool.TryParse((string)isAdminObj, out isAdmin))
                            {
                                throw new PSArgumentException(ServiceFabricProperties.Resources.CanNotParseValueInNameIssuersAndFlags);
                            }
                        }
                        else if (isAdminObj is bool)
                        {
                            isAdmin = (bool)isAdminObj;
                        }
                        else
                        {
                            throw new PSArgumentException(ServiceFabricProperties.Resources.CanNotParseValueInNameIssuersAndFlags);
                        }

                        allCommonNames.Add(new ClientCertificateCommonName()
                        {
                            CertificateCommonName = commonName,
                            CertificateIssuerThumbprint = issuer,
                            IsAdmin = isAdmin
                        });

                    }
                    else
                    {
                        throw new PSArgumentException(ServiceFabricProperties.Resources.CanNotParseValueInNameIssuersAndFlags);
                    }
                }
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
