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
using System.Globalization;
using System.Management.Automation;
using System.Net;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    /// <summary>
    ///     SYNTAX
    ///          Enable-Node [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///             [-SkipCertificateValidation] [-FarmName] {string} [[-NodeName] {string}] [ {CommonParameters}] 
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Enable, Nouns.AdminNode, SupportsShouldProcess = true)]
    public sealed class EnableAdminNode : AdminCmdlet
    {
        /// <summary>
        ///     Farm Identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 4)]
        [ValidateNotNullOrEmpty]
        public string FarmName { get; set; }

        /// <summary>
        ///     Node name
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, Position = 5)]
        [ValidateNotNullOrEmpty]
        public string NodeName { get; set; }

        protected override void Execute()
        {
            if (ShouldProcess(
                    Resources.EnableNodeVerboseDescription.FormatInvariantCulture(NodeName, FarmName),
                    Resources.EnableNodeVerboseWarning.FormatInvariantCulture(NodeName, FarmName),
                    Resources.ShouldProcessCaption))
            {
                var response = Client.Nodes.Enable(ResourceGroupName, FarmName, NodeName);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new AdminException(string.Format(CultureInfo.InvariantCulture, Resources.OperationFailedErrorMessage, response.StatusCode));
                }
            }
        }
    }
}
