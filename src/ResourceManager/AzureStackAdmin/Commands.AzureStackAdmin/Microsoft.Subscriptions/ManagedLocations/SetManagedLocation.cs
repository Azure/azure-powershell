﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.AzureStack.Commands
{
    using System;
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;

    /// <summary>
    /// Set managed location cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, Nouns.Location)]
    [OutputType(typeof(Location))]
    public class SetManagedLocation : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the managed location.
        /// </summary>
        [Parameter(ValueFromPipeline = true, Mandatory = true)]
        [ValidateNotNull]
        public Location Location { get; set; }

        /// <summary>
        /// Gets or sets the subscription id.
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateGuidNotEmpty]
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// Updates the managed location with new values
        /// </summary>
        protected override object ExecuteCore()
        {
            using (var client = this.GetAzureStackClient(this.SubscriptionId))
            {
                this.WriteVerbose(Resources.UpdatingManagedLocation.FormatArgs(this.Location.Name));
                var parameters = new ManagedLocationCreateOrUpdateParameters(this.Location);
                return client.ManagedLocations.CreateOrUpdate(parameters).Location;
            }
        }
    }
}
