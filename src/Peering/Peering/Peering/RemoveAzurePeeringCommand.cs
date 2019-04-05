// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Microsoft" file="RemoveAzurePeeringCommand.cs">
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

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Peering
{
    using System;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <inheritdoc />
    /// <summary>
    ///     The Remove InputObject cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzPeering", SupportsShouldProcess = true)]
    [OutputType(typeof(PSPeering))]
    public class RemoveAzurePeeringCommand : PeeringBaseCmdlet
    {
        /// <summary>
        ///     The ResourceGroupName
        /// </summary>
        [Parameter(
            Position = Constants.PositionPeeringZero,
            Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelp)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        /// <summary>
        ///     The InputObject name.
        /// </summary>
        [Parameter(
            Position = Constants.PositionPeeringOne,
            Mandatory = true,
            HelpMessage = Constants.PeeringNameHelp)]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        /// <summary>
        ///     Force the execution of the command.
        /// </summary>
        [Parameter]
        public virtual SwitchParameter Force { get; set; }

        /// <summary>
        ///     The AsJob parameter to run in the background.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelp)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        ///     Execute Override for powershell cmdlet
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
                    this.Name,
                    this.RemovePeering);
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
        ///     Removes the InputObject Resource.
        /// </summary>
        /// <returns></returns>
        public void RemovePeering()
        {
            this.PeeringClient.Delete(this.ResourceGroupName, this.Name);
            this.WriteObject($"InputObject {this.Name} Resource Removed.");
        }
    }
}