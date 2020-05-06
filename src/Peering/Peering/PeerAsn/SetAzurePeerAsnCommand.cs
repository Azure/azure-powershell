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
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <summary>
    ///     New Azure InputObject Command-let
    /// </summary>
    [Cmdlet(
        VerbsCommon.Set,
        Constants.AzPeerAsn,
        DefaultParameterSetName = Constants.ParameterSetNameInputObject,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSPeerAsn))]
    public class SetAzurePeerAsn : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the legacy InputObject.
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = Constants.PeerAsnHelp,
            ParameterSetName = Constants.ParameterSetNameInputObject)]
        public PSPeerAsn InputObject { get; set; }

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
            try
            {
                base.Execute();
                this.WriteObject(UpdatePeerContactInfo());
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException(string.Format(Resources.Error_Mapping, mapException));
            }
            catch (ErrorResponseException ex)
            {
                var error = GetErrorCodeAndMessageFromArmOrErm(ex);
                throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error.Code, error.Message));
            }
        }

        /// <summary>
        /// The update peer contact info.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private object UpdatePeerContactInfo()
        {
            try
            {
                var peerAsn = this.PeerAsnClient.CreateOrUpdate(this.InputObject.Name, PeeringResourceManagerProfile.Mapper.Map<PeerAsn>(this.InputObject));
                return PeeringResourceManagerProfile.Mapper.Map<PSPeerAsn>(peerAsn);
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
    }
}