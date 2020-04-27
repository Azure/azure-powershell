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
namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.PeerAsn
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <inheritdoc />
    /// <summary>
    ///     New Azure InputObject Command-let
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove,
        Constants.AzPeerAsn,
        SupportsShouldProcess = true,
        DefaultParameterSetName = Constants.ParameterSetNameByName)]
    [OutputType(typeof(bool))]
    public class RemoveAzurePeerAsnCommand : PeeringBaseCmdlet
    {
        /// <summary>
        ///     Gets or sets The InputObject name
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = Constants.PeerAsnHelp,
            ParameterSetName = Constants.ParameterSetNameInputObject)]
        [ValidateNotNullOrEmpty]
        public PSPeerAsn InputObject { get; set; }

        /// <summary>
        ///     Gets or sets The InputObject name
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNameByName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource id.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.ResourceIdHelp,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ParameterSetNameByResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        ///  Gets or sets the Force the execution of the command.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = Constants.ForceHelp)]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets or sets the pass thru.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = Constants.PassThruHelp)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        ///     The AsJob parameter to run in the background.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelp)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        ///     The inherited Execute function.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            try
            {
                string name = null;
                if (this.ParameterSetName.Equals(Constants.ParameterSetNameInputObject, StringComparison.OrdinalIgnoreCase))
                {
                    name = this.InputObject.Name;
                }
                else if (this.ParameterSetName.Equals(Constants.ParameterSetNameByName, StringComparison.OrdinalIgnoreCase))
                {
                    name = this.Name;
                }
                else if (this.ParameterSetName.Equals(Constants.ParameterSetNameByResourceId, StringComparison.OrdinalIgnoreCase))
                {
                    name = this.ResourceId.Split('/').Last();
                }

                if (!string.IsNullOrEmpty(name))
                {
                    this.ConfirmAction(
                        this.Force,
                        string.Format(Resources.ContinueMessage, name),
                        string.Format(Resources.ProcessMessage, name),
                        name,
                        () => this.RemovePeerAsn(name));
                }
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException(string.Format(Resources.Error_Mapping, mapException));
            }
            catch (ErrorResponseException ex)
            {
                var error = this.GetErrorCodeAndMessageFromArmOrErm(ex);
                throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error.Code, error.Message));
            }
        }

        /// <summary>
        /// The remove peer asn.
        /// </summary>
        [SuppressMessage(
            "StyleCop.CSharp.DocumentationRules",
            "SA1650:ElementDocumentationMustBeSpelledCorrectly",
            Justification = "Reviewed. Suppression is OK here.")]
        private void RemovePeerAsn(string name)
        {
            try
            {
                this.PeerAsnClient.Delete(name);
                if (this.PassThru) this.WriteObject(true);
            }
            catch
            {
                if (this.PassThru) { this.WriteObject(false); }
                else { throw new ItemNotFoundException(); };
            }
        }
    }
}