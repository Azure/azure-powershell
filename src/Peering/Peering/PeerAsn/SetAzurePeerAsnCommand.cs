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
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;
    using Microsoft.Rest.Azure;

    using Newtonsoft.Json;

    /// <summary>
    ///     New Azure InputObject Command-let
    /// </summary>
    [Cmdlet(
        VerbsCommon.Set,
        "AzPeerAsn",
        DefaultParameterSetName = Constants.ParameterSetNameByName,
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
            ParameterSetName = Constants.ParameterSetNameDefault)]
        public PSPeerAsn InputObject { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNameByName)]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the Email
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.EmailsHelp,
            ParameterSetName = Constants.ParameterSetNameDefault)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.EmailsHelp,
            ParameterSetName = Constants.ParameterSetNameByName)]
        public string[] Email { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.PhoneHelp,
            ParameterSetName = Constants.ParameterSetNameDefault)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.PhoneHelp,
            ParameterSetName = Constants.ParameterSetNameByName)]
        public string[] Phone { get; set; }

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
                this.WriteObject(
                    this.ParameterSetName.Equals(Constants.ParameterSetNameByName)
                        ? this.ToPeeringAsnPs(this.GetAndSetContactInformation())
                        : this.ToPeeringAsnPs(this.UpdatePeerContactInfo()));
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
        /// The update peer contact info.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private object UpdatePeerContactInfo()
        {
            // Get old and verify its the same
            var oldPeerAsn = this.PeeringManagementClient.PeerAsns.Get(this.InputObject.Name);
            if (oldPeerAsn.Name == this.InputObject.Name
                && oldPeerAsn.PeerAsnProperty == this.InputObject.PeerAsnProperty
                && oldPeerAsn.PeerName == this.InputObject.PeerName)
            {
                var update = this.InputObject;
                if (this.Email != null)
                {
                    foreach (var email in this.Email)
                    {
                        if (HelperExtensionMethods.IsValidEmail(email))
                            update.PeerContactInfo.Emails.Add(email);
                    }
                }

                if (this.Phone == null)
                    return this.PeeringManagementClient.PeerAsns.CreateOrUpdate(
                        oldPeerAsn.Name,
                        this.ToPeeringAsn(update));
                foreach (var s in this.Phone)
                {
                    update.PeerContactInfo.Phone.Add(s);
                }

                return this.PeeringManagementClient.PeerAsns.CreateOrUpdate(oldPeerAsn.Name, this.ToPeeringAsn(update));
            }

            throw new Exception($"Only contact information can be changed");
        }

        private object GetAndSetContactInformation()
        {
            // Get old and verify its the same
            var oldPeerAsn = this.PeeringManagementClient.PeerAsns.Get(this.Name);
            if (oldPeerAsn != null)
            {
                var update = (PSPeerAsn)this.ToPeeringAsnPs(oldPeerAsn);
                if (this.Email != null)
                {
                    foreach (var email in this.Email)
                    {
                        update.PeerContactInfo.Emails.Add(email);
                    }
                }

                if (this.Phone == null)
                    return this.PeeringManagementClient.PeerAsns.CreateOrUpdate(
                        oldPeerAsn.Name,
                        this.ToPeeringAsn(update));
                foreach (var s in this.Phone)
                {
                    update.PeerContactInfo.Phone.Add(s);
                }

                return this.PeeringManagementClient.PeerAsns.CreateOrUpdate(oldPeerAsn.Name, this.ToPeeringAsn(update));
            }

            throw new Exception($"Only contact information can be changed");
        }
    }
}
