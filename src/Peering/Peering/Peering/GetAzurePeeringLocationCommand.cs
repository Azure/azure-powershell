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
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    using Newtonsoft.Json;

    /// <summary>
    ///     The get InputObject locations.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzPeeringLocation", DefaultParameterSetName = Constants.ParameterSetNamePeeringByKind)]
    [OutputType(typeof(PSPeeringLocation))]
    public class GetAzurePeeringLocationCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 0,
            ParameterSetName = Constants.ParameterSetNamePeeringByKind,
            HelpMessage = Constants.KindHelp)]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ParameterSetName = Constants.ParameterSetNameLocationByFacilityId,
            HelpMessage = Constants.KindHelp)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter(Constants.Direct, Constants.Exchange)]
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets the peering location.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ParameterSetName = Constants.ParameterSetNamePeeringByKind,
            HelpMessage = Constants.LocationHelp)]
        [ValidateNotNullOrEmpty]
        public string PeeringLocation { get; set; }

        /// <summary>
        /// Gets or sets the peering db facility id.
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 0,
            ParameterSetName = Constants.ParameterSetNameLocationByFacilityId,
            HelpMessage = Constants.PeeringDbFacilityIdHelp)]
        [ValidateNotNullOrEmpty]
        public int PeeringDbFacilityId { get; set; }

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
                if (this.ParameterSetName.Equals(Constants.ParameterSetNamePeeringByKind))
                {
                    this.WriteObject(
                        this.PeeringLocation != null
                            ? this.ListByLocation(peeringLocation, this.PeeringLocation)
                            : this.ConvertToPsObject(peeringLocation),
                        true);
                }

                if (this.ParameterSetName.Equals(Constants.ParameterSetNameLocationByFacilityId))
                {
                    this.WriteObject(this.GetByFacilityId(peeringLocation, this.PeeringDbFacilityId), true);
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

        private object ListByLocation(List<PSPeeringLocation> peeringLocation, string s)
        {
            var newPsPeeringLocations = new List<PSPeeringLocationObject>();
            foreach (var psPeeringLocation in peeringLocation)
            {
                if (this.Kind.Equals(Constants.Exchange, StringComparison.OrdinalIgnoreCase))
                {
                    if (psPeeringLocation.Name.Equals(s, StringComparison.OrdinalIgnoreCase))
                    {
                        var numFacilities = psPeeringLocation.Exchange.PeeringFacilities.Count;
                        for (int i = 0; i < numFacilities; i++)
                        {
                            newPsPeeringLocations.Add(new PSPeeringLocationObject(psPeeringLocation, i));
                        }
                    }
                }

                if (this.Kind.Equals(Constants.Direct, StringComparison.OrdinalIgnoreCase))
                {
                    if (psPeeringLocation.Name.Equals(s, StringComparison.OrdinalIgnoreCase))
                    {
                        var numFacilities = psPeeringLocation.Direct.PeeringFacilities.Count;
                        for (int i = 0; i < numFacilities; i++)
                        {
                            newPsPeeringLocations.Add(new PSPeeringLocationObject(psPeeringLocation, i));
                        }
                    }
                }
            }

            return newPsPeeringLocations;
        }

        /// <summary>
        /// The list by facility id.
        /// </summary>
        /// <param name="peeringLocation">
        /// The peering location.
        /// </param>
        /// <param name="facilityId">
        /// The facility id.
        /// </param>
        /// <returns>
        /// The <see cref="PSPeeringLocationObject"/>.
        /// </returns>
        /// <exception cref="ItemNotFoundException">Item not found </exception>
        private PSPeeringLocationObject GetByFacilityId(List<PSPeeringLocation> peeringLocation, int facilityId)
        {
            foreach (var psPeeringLocation in peeringLocation)
            {
                if (this.Kind.Equals(Constants.Exchange, StringComparison.OrdinalIgnoreCase))
                {
                    var numFacilities = psPeeringLocation.Exchange.PeeringFacilities.Count;
                    for (int i = 0; i < numFacilities; i++)
                    {
                        if (psPeeringLocation.Exchange.PeeringFacilities[i].PeeringDBFacilityId == facilityId)
                        {
                            return new PSPeeringLocationObject(psPeeringLocation, i);
                        }
                    }
                }

                if (this.Kind.Equals(Constants.Direct, StringComparison.OrdinalIgnoreCase))
                {
                    var numFacilities = psPeeringLocation.Direct.PeeringFacilities.Count;
                    for (int i = 0; i < numFacilities; i++)
                    {
                        if (psPeeringLocation.Direct.PeeringFacilities[i].PeeringDBFacilityId == facilityId)
                        {
                            return new PSPeeringLocationObject(psPeeringLocation, i);
                        }
                    }
                }
            }

            throw new ItemNotFoundException(string.Format(Resources.Item_NotFound, "PeeringDbFacilityId", facilityId));
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
        public List<PSPeeringLocation> GetPeeringLocation()
        {
            var icList = this.PeeringLocationClient.List(this.Kind);

            return icList.Select(this.TopSPeeringLocation).ToList();
        }
    }
}