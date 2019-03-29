// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Microsoft" file="RemoveAzurePeerAsnCommand.cs">
//   Licensed under the Apache License, Version 2.0 (the "License");
//   //   you may not use this file except in compliance with the License.
//   //   You may obtain a copy of the License at
//   //   http://www.apache.org/licenses/LICENSE-2.0
//   //   Unless required by applicable law or agreed to in writing, software
//   //   distributed under the License is distributed on an "AS IS" BASIS,
//   //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   //   See the License for the specific language governing permissions and
//   //   limitations under the License.
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.PeerAsn
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Management.Automation;

    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <inheritdoc />
    /// <summary>
    ///     New Azure Peering Command-let
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove,
        "AzPeerAsn", SupportsShouldProcess = true)]
    [OutputType(typeof(PSPeerAsn))]
    public class RemoveAzurePeerAsn : PeeringBaseCmdlet
    {
        /// <summary>
        ///     Gets or sets The Peering name
        /// </summary>
        [Parameter(
            Position = Constants.PositionPeeringZero,
            Mandatory = true,
            HelpMessage = Constants.PeeringNameHelp)]
        [ValidateNotNullOrEmpty]
        public virtual string PeerName { get; set; }

        /// <summary>
        ///  Gets or sets the Force the execution of the command.
        /// </summary>
        [Parameter]
        public virtual SwitchParameter Force { get; set; }

        /// <summary>
        ///     The inherited Execute function.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            try
            {
                this.ConfirmAction(
                    this.Force,
                    Constants.ContinueMessage,
                    Constants.ProcessMessage,
                    this.PeerName,
                    this.RemovePeerAsn);
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException($"Failed to map object {mapException}");
            }
            catch (ErrorResponseException ex)
            {
                throw new ErrorResponseException($"Error:{ex.Response.ReasonPhrase} reason:{ex.Body.Code} message:{ex.Body.Message}");
            }
        }

        /// <summary>
        /// The remove peer asn.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private void RemovePeerAsn()
        {
            this.PeeringManagementClient.PeerAsns.Delete(this.PeerName);
            this.WriteObject($"Peer Asn {this.PeerName} Resource Removed.");
        }
    }
}
