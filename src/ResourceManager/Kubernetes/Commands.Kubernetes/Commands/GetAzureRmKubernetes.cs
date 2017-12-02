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
using System.Management.Automation;
using Microsoft.Azure.Commands.Kubernetes.Generated;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Kubernetes
{
    [Cmdlet(VerbsCommon.Get, KubeNounStr)]
    [OutputType(typeof(PSObject), typeof(List<PSObject>))]
    public class Get : KubeCmdletBase
    {
        private const string ResourceGroupParameterSet = "ResourceGroupParameterSet";
        private const string NameParameterSet = "NameParameterSet";

        /// <summary>
        /// Cluster name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = NameParameterSet,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of your managed Kubernetes cluster")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = false,
            ParameterSetName = ResourceGroupParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource group name")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = NameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource group name")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                switch (ParameterSetName)
                {
                    case NameParameterSet:
                        var kubeCluster = Client.ManagedClusters.Get(ResourceGroupName, Name);
                        WriteObject(kubeCluster);
                        break;
                    case ResourceGroupParameterSet:
                        var kubeClusters = string.IsNullOrEmpty(ResourceGroupName)
                            ? Client.ManagedClusters.List()
                            : Client.ManagedClusters.ListByResourceGroup(ResourceGroupName);
                        WriteObject(kubeClusters);
                        break;
                    default:
                        throw new ArgumentException("Bad parameterset name. This is a bug and should be reported.");
                }
            });
        }
    }
}