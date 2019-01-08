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

using System;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Location_Capabilities.Model;
using Microsoft.Azure.Commands.Sql.Services;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.Location_Capabilities.Services
{
    public class AzureSqlCapabilitiesAdapter
    {
        /// <summary>
        /// The communicator for interacting with the service APIs
        /// </summary>
        private AzureSqlCapabilitiesCommunicator _communicator;

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a firewall rule adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlCapabilitiesAdapter(IAzureContext context)
        {
            Context = context;
            _communicator = new AzureSqlCapabilitiesCommunicator(Context);
        }

        /// <summary>
        /// Gets the capabilities for the specified location
        /// </summary>
        /// <param name="locationName">The name of the location for which to get the capabilities</param>
        /// <returns></returns>
        public LocationCapabilityModel GetLocationCapabilities(string locationName)
        {
            var resp = _communicator.Get(locationName);
            return CreateLocationCapabilityModel(resp);
        }

        /// <summary>
        /// Converts from an API object to a PowerShell object
        /// </summary>
        /// <param name="resp">The object to transform</param>
        /// <returns>The converted location capability model</returns>
        private LocationCapabilityModel CreateLocationCapabilityModel(Management.Sql.Models.LocationCapabilities resp)
        {
            LocationCapabilityModel model = new LocationCapabilityModel();
            model.LocationName = resp.Name;
            model.Status = resp.Status.ToString();
            model.SupportedServerVersions = resp.SupportedServerVersions.Select(CreateSupportedVersionsModel).ToList();
            return model;
        }

        /// <summary>
        /// Converts from an API object to a PowerShell object
        /// </summary>
        /// <param name="v">The object to transform</param>
        /// <returns>The converted server version capability model</returns>
        private ServerVersionCapabilityModel CreateSupportedVersionsModel(Management.Sql.Models.ServerVersionCapability v)
        {
            ServerVersionCapabilityModel version = new ServerVersionCapabilityModel();
            version.ServerVersionName = v.Name;
            version.Status = v.Status.ToString();
            version.SupportedEditions = v.SupportedEditions.Select(CreateSupportedEditionModel).ToList();
            return version;
        }

        /// <summary>
        /// Converts from an API object to a PowerShell object
        /// </summary>
        /// <param name="e">The object to transform</param>
        /// <returns>The converted database edition capability model</returns>
        private EditionCapabilityModel CreateSupportedEditionModel(Management.Sql.Models.EditionCapability e)
        {
            EditionCapabilityModel edition = new EditionCapabilityModel();
            edition.EditionName = e.Name;
            edition.Status = e.Status.ToString();
            edition.SupportedServiceObjectives = e.SupportedServiceLevelObjectives.Select(CreateSupportedSLOModel).ToList();
            return edition;
        }

        /// <summary>
        /// Converts from an API object to a PowerShell object
        /// </summary>
        /// <param name="s">The object to transform</param>
        /// <returns>The converted edition Service Level Objective capability model</returns>
        private ServiceObjectiveCapabilityModel CreateSupportedSLOModel(Management.Sql.Models.ServiceObjectiveCapability s)
        {
            ServiceObjectiveCapabilityModel slo = new ServiceObjectiveCapabilityModel();

            slo.Id = s.Id;
            slo.ServiceObjectiveName = s.Name;
            slo.Status = s.Status.ToString();
            slo.SupportedMaxSizes = s.SupportedMaxSizes.Select(CreateSupportedMaxSizeModel).ToList();

            return slo;
        }

        /// <summary>
        /// Converts from an API object to a PowerShell object
        /// </summary>
        /// <param name="e">The object to transform</param>
        /// <returns>The converted database max size capability model</returns>
        private MaxSizeRangeCapabilityModel CreateSupportedMaxSizeModel(Management.Sql.Models.MaxSizeRangeCapability m)
        {
            MaxSizeRangeCapabilityModel maxSizeRange = new MaxSizeRangeCapabilityModel();

            maxSizeRange.MinValue = new MaxSizeCapabilityModel
            {
                Limit = m.MinValue.Limit,
                Unit = m.MinValue.Unit
            };

            maxSizeRange.MaxValue = new MaxSizeCapabilityModel()
            {
                Limit = m.MaxValue.Limit,
                Unit = m.MaxValue.Unit
            };
            
            maxSizeRange.ScaleSize = new MaxSizeCapabilityModel()
            {
                Limit = m.ScaleSize.Limit,
                Unit = m.ScaleSize.Unit
            };

            maxSizeRange.Status = m.Status;

            return maxSizeRange;
        }
    }
}
