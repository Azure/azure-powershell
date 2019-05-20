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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;
    using Microsoft.Rest.Azure;

    using Newtonsoft.Json;

    /// <inheritdoc />
    /// <summary>
    ///     New Azure InputObject Command-let
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove,
        "AzPeerAsn",
        SupportsShouldProcess = true,
        DefaultParameterSetName = Constants.ParameterSetNameDefault)]
    [OutputType(typeof(bool))]
    public class RemoveAzurePeerAsn : PeeringBaseCmdlet
    {
        /// <summary>
        ///     Gets or sets The InputObject name
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = Constants.PeerAsnHelp,
            ParameterSetName = Constants.ParameterSetNameDefault)]
        [ValidateNotNullOrEmpty]
        public PSPeerAsn InputObject { get; set; }

        /// <summary>
        ///     Gets or sets The InputObject name
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNameByName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

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
                if (this.ParameterSetName.Equals(Constants.ParameterSetNameDefault, StringComparison.OrdinalIgnoreCase))
                {
                    this.ConfirmAction(
                        this.Force,
                        string.Format(Resources.ContinueMessage, this.InputObject.Name),
                        string.Format(Resources.ContinueMessage, this.InputObject.Name),
                        this.InputObject.Name,
                        this.RemovePeerAsn);
                }

                if (this.ParameterSetName.Equals(Constants.ParameterSetNameByName, StringComparison.OrdinalIgnoreCase))
                {
                    this.ConfirmAction(
                        this.Force,
                        string.Format(Resources.ContinueMessage, this.Name),
                        string.Format(Resources.ProcessMessage, this.Name),
                        this.Name,
                        this.RemovePeerAsn);
                }
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException(string.Format(Resources.Error_Mapping, mapException));
            }
            catch (ErrorResponseException ex)
            {
                var error = ex.Response.Content.Contains("\"error\\\":") ? JsonConvert.DeserializeObject<Dictionary<string, ErrorResponse>>(JsonConvert.DeserializeObject(ex.Response.Content).ToString()).FirstOrDefault().Value : JsonConvert.DeserializeObject<ErrorResponse>(ex.Response.Content);
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
        private void RemovePeerAsn()
        {
            if (this.ParameterSetName.Equals(Constants.ParameterSetNameDefault, StringComparison.OrdinalIgnoreCase))
            {
                this.PeeringManagementClient.PeerAsns.Delete(this.InputObject.Name);
                if (this.PassThru) this.WriteObject(true);
            }

            if (this.ParameterSetName.Equals(Constants.ParameterSetNameByName, StringComparison.OrdinalIgnoreCase))
            {
                this.PeeringManagementClient.PeerAsns.Delete(this.Name);
                if (this.PassThru) this.WriteObject(true);
            }
        }
    }
}
