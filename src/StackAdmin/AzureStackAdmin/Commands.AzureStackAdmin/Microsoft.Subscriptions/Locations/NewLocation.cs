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
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;

    /// <summary>
    /// New managed location cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, Nouns.Location, SupportsShouldProcess = true)]
    [OutputType(typeof(Location))]
    [Alias("New-AzureRmManagedLocation")]
    public class NewLocation : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateLength(1, 128)]
        [ValidateNotNull]
        [ValidatePattern("^[0-9a-z]+$")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateLength(1, 128)]
        [ValidateNotNull]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the latitude of location in signed degrees format.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        [ValidateRange(-90.0, 90.0)]
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of location in signed degrees format.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        [ValidateRange(-180.0, 180.0)]
        public double Longitude { get; set; }

        /// <summary>
        /// Creates a new location
        /// </summary>
        protected override void ExecuteCore()
        {
            if (this.MyInvocation.InvocationName.Equals("New-AzureRmManagedLocation", StringComparison.OrdinalIgnoreCase))
            {
                this.WriteWarning("Alias New-AzureRmManagedLocation will be deprecated in a future release. Please use the cmdlet name New-AzsLocation instead");
            }

            if (ShouldProcess(this.Name, VerbsCommon.New))
            {
                using (var client = this.GetAzureStackClient())
                {
                    this.WriteVerbose(Resources.CreatingNewLocation.FormatArgs(this.Name));
                    var parameters = new ManagedLocationCreateOrUpdateParameters()
                    {
                        Location = new Location()
                        {
                            DisplayName = this.DisplayName,
                            Latitude = this.Latitude.ToString(CultureInfo.InvariantCulture),
                            Longitude = this.Longitude.ToString(CultureInfo.InvariantCulture),
                            Name = this.Name
                        }
                    };

                    if (client.ManagedLocations.List()
                        .Locations.Any(location => location.Name.EqualsInsensitively(parameters.Location.Name)))
                    {
                        throw new PSInvalidOperationException(
                            Resources.LocationAlreadyExists.FormatArgs(parameters.Location.Name));
                    }

                    var result = client.ManagedLocations.CreateOrUpdate(parameters).Location;
                    WriteObject(result);
                }
            }
        }
    }
}
