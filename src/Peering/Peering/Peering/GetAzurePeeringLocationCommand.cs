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
<<<<<<< HEAD
=======
    using System.Collections;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

<<<<<<< HEAD
    using Newtonsoft.Json;

    /// <summary>
    ///     The get InputObject locations.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzPeeringLocation", DefaultParameterSetName = Constants.ParameterSetNamePeeringByKind)]
=======
    /// <summary>
    ///     The get InputObject locations.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Constants.AzPeeringLocation,
        DefaultParameterSetName = Constants.ParameterSetNameDefault)]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    [OutputType(typeof(PSPeeringLocation))]
    public class GetAzurePeeringLocationCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 0,
<<<<<<< HEAD
            ParameterSetName = Constants.ParameterSetNamePeeringByKind,
=======
            ParameterSetName = Constants.ParameterSetNameDefault,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            HelpMessage = Constants.KindHelp)]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ParameterSetName = Constants.ParameterSetNameLocationByFacilityId,
            HelpMessage = Constants.KindHelp)]
<<<<<<< HEAD
=======
        [Parameter(
            Mandatory = true,
            Position = 0,
            ParameterSetName = Constants.ParameterSetNameLocationByDirectType,
            HelpMessage = Constants.KindHelp)]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter(Constants.Direct, Constants.Exchange)]
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets the peering location.
        /// </summary>
        [Parameter(
            Mandatory = false,
<<<<<<< HEAD
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
=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
<<<<<<< HEAD
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
=======
                this.WriteObject(this.FilterPeeringLocations(peeringLocation));
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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

<<<<<<< HEAD
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
=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
        public List<PSPeeringLocation> GetPeeringLocation()
        {
            var icList = this.PeeringLocationClient.List(this.Kind);

            return icList.Select(this.TopSPeeringLocation).ToList();
=======
        private List<PSPeeringLocationObject> GetPeeringLocation()
        {
            var icList = this.PeeringLocationClient.List(this.Kind, this.DirectPeeringType ?? null);
            return this.ConvertToPsObject(icList.Select(this.TopSPeeringLocation).ToList());
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }
    }
}