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

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Peering
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <summary>
    ///     The get InputObject locations.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Constants.AzPeeringLocation,
        DefaultParameterSetName = Constants.ParameterSetNameDefault)]
    [OutputType(typeof(PSPeeringLocation))]
    public class GetAzurePeeringLocationCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 0,
            ParameterSetName = Constants.ParameterSetNameDefault,
            HelpMessage = Constants.KindHelp)]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ParameterSetName = Constants.ParameterSetNameLocationByFacilityId,
            HelpMessage = Constants.KindHelp)]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ParameterSetName = Constants.ParameterSetNameLocationByDirectType,
            HelpMessage = Constants.KindHelp)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter(Constants.Direct, Constants.Exchange)]
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets the peering location.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ParameterSetName = Constants.ParameterSetNameDefault,
            HelpMessage = Constants.LocationHelp)]
        [Parameter(
            Mandatory = false,
            ParameterSetName = Constants.ParameterSetNameLocationByDirectType,
            HelpMessage = Constants.LocationHelp)]
        public string PeeringLocation { get; set; }

        /// <summary>
        /// Gets or sets the Direct Peering Type
        /// </summary>
        [Parameter(
            Mandatory = false,
            ParameterSetName = Constants.ParameterSetNameLocationByDirectType,
            HelpMessage = Constants.DirectPeeringTypeHelp)]
        [PSArgumentCompleter(Constants.Edge, Constants.Transit, Constants.CDN)]
        [PSDefaultValue(Value = Constants.Edge)]
        [ValidateNotNullOrEmpty]
        public string DirectPeeringType { get; set; }

        /// <summary>
        /// Gets or sets the peering db facility id.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ParameterSetName = Constants.ParameterSetNameLocationByFacilityId,
            HelpMessage = Constants.PeeringDbFacilityIdHelp)]
        [Parameter(
            Mandatory = false,
            ParameterSetName = Constants.ParameterSetNameLocationByDirectType,
            HelpMessage = Constants.PeeringDbFacilityIdHelp)]
        [ValidateNotNullOrEmpty]
        public int? PeeringDbFacilityId { get; set; }

        /// <inheritdoc />
        /// <summary>
        ///     The base execute method.
        /// </summary>
        public override void Execute()
        {
            try
            {
                base.Execute();
                var peeringLocation = this.GetPeeringLocation();
                this.WriteObject(this.FilterPeeringLocations(peeringLocation));
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
        /// Filters the peering location.
        /// </summary>
        /// <param name="peeringLocation"></param>
        /// <returns></returns>
        private List<PSPeeringLocationObject> FilterPeeringLocations(List<PSPeeringLocationObject> peeringLocation)
        {
            IEnumerable<PSPeeringLocationObject> peeringLocationFiltered = null;
            if (this.PeeringLocation != null)
            {

                peeringLocationFiltered = peeringLocation.Where(x => x.PeeringLocation.StartsWith(this.PeeringLocation, StringComparison.InvariantCultureIgnoreCase) || x.PeeringLocation.Contains(this.PeeringLocation));
            }

            if (this.PeeringDbFacilityId != null)
            {
                peeringLocationFiltered = (peeringLocationFiltered ?? peeringLocation).Where(x => x.PeeringDBFacilityId.Equals(this.PeeringDbFacilityId));
            }

            if (this.PeeringLocation == null && this.PeeringDbFacilityId == null)
            {
                return peeringLocation;
            }

            return peeringLocationFiltered.ToList();
        }

        private List<PSPeeringLocationObject> ConvertToPsObject(List<PSPeeringLocation> peeringLocation)
        {
            var newPsPeeringLocations = new List<PSPeeringLocationObject>();
            foreach (var location in peeringLocation)
            {
                if (location.Direct != null && location.Kind.Equals(Constants.Direct, StringComparison.OrdinalIgnoreCase))
                {
                    var numFacilities = location.Direct.PeeringFacilities.Count;
                    for (int i = 0; i < numFacilities; i++)
                    {
                        newPsPeeringLocations.Add(new PSPeeringLocationObject(location, i));
                    }
                }

                if (location.Exchange != null && location.Kind.Equals(Constants.Exchange, StringComparison.OrdinalIgnoreCase))
                {
                    var numFacilities = location.Exchange.PeeringFacilities.Count;
                    for (int i = 0; i < numFacilities; i++)
                    {
                        newPsPeeringLocations.Add(new PSPeeringLocationObject(location, i));
                    }
                }
            }

            return newPsPeeringLocations;
        }

        /// <summary>
        ///     Gets the InputObject location.
        /// </summary>
        /// <returns>List of InputObject locations.</returns>
        private List<PSPeeringLocationObject> GetPeeringLocation()
        {
            var icList = this.PeeringLocationClient.List(this.Kind, this.DirectPeeringType ?? null);
            return this.ConvertToPsObject(icList.Select(this.TopSPeeringLocation).ToList());
        }
    }
}