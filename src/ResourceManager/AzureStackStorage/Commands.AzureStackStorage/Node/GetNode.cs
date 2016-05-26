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

using Microsoft.AzureStack.Management.StorageAdmin;
using Microsoft.AzureStack.Management.StorageAdmin.Models;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    /// <summary>
    ///     SYNTAX
    ///          Get-Node [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///             [-SkipCertificateValidation] [-FarmName] {string} [[-NodeName] {string}] [ {CommonParameters}] 
    /// 
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminNode)]
    public sealed class GetAdminNode : AdminCmdlet
    {
        /// <summary>
        ///     Farm Identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 4)]
        [ValidateNotNull]
        public string FarmName { get; set; }

        /// <summary>
        ///     Node name
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, Position = 5)]
        public string NodeName { get; set; }


        protected override void Execute()
        {
            if (string.IsNullOrEmpty(NodeName))
            {
                NodeListResponse nodes = Client.Nodes.List(ResourceGroupName, FarmName);

                WriteObject(nodes.Nodes.Select(_ => new NodeResponse(_)), true);
            }
            else
            {
                NodeGetResponse node = Client.Nodes.Get(ResourceGroupName, FarmName, NodeName);
                WriteObject(new NodeResponse(node.Node));
            }
        }
    }
}
