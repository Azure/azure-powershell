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

using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.Location_Capabilities.Model;
using Microsoft.Azure.Commands.Sql.Location_Capabilities.Services;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.Location_Capabilities.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureSqlLocationCapability cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSqlLocationCapability", 
        ConfirmImpact = ConfirmImpact.None,
        DefaultParameterSetName = _filtered)]
    public class GetAzureSqlLocationCapability : AzurePSCmdlet
    {
        /// <summary>
        /// Parameter set name for when the cmdlet is invoked without specifying -Default
        /// </summary>
        private const string _filtered = "FilterResults";

        /// <summary>
        /// Parameter set name for when the cmdlet is invoked with the -Default switch specified
        /// </summary>
        private const string _default = "DefaultResults";

        /// <summary>
        /// Gets or sets the name of the Location
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the Location for which to get the capabilities")]
        [ValidateNotNullOrEmpty]
        public string LocationName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server version
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the server version for which to get the capabilities",
            ParameterSetName = _filtered)]
        [ValidateNotNullOrEmpty]
        public string ServerVersionName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database edition
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the database edition for which to get the capabilities",
            ParameterSetName = _filtered)]
        [ValidateNotNullOrEmpty]
        public string EditionName { get; set; }

        /// <summary>
        /// Gets or sets the name of the edition service level objective 
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the edition Service Objective for which to get the capabilities",
            ParameterSetName = _filtered)]
        [ValidateNotNullOrEmpty]
        public string ServiceObjectiveName { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Indicates that the results should be filtered such that only defaults are shown",
            ParameterSetName = _default)]
        public SwitchParameter Defaults { get; set; }

        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            AzureSqlLocationCapabilitiesAdapter adapter = new AzureSqlLocationCapabilitiesAdapter(Profile, Profile.Context.Subscription);
            LocationCapabilityModel model = adapter.GetLocationCapabilities(LocationName);

            switch(ParameterSetName)
            {
                case _default:
                    {
                        FilterByDefaults(model);
                    }
                    break;
                case _filtered:
                    {
                        if (this.MyInvocation.BoundParameters.ContainsKey("ServerVersionName"))
                        {
                            FilterByServerVersion(model);
                        }
                        if (this.MyInvocation.BoundParameters.ContainsKey("EditionName"))
                        {
                            FilterByEditionName(model);
                        }
                        if (this.MyInvocation.BoundParameters.ContainsKey("ServiceObjectiveName"))
                        {
                            FilterByServiceObjectiveName(model);
                        }
                    }
                    break;
            }

            this.WriteObject(model);
        }

        /// <summary>
        /// Filter the results based on what is marked as status
        /// </summary>
        /// <param name="model">The model to filter</param>
        private void FilterByDefaults(LocationCapabilityModel model)
        {
            model.SupportedServerVersions = model.SupportedServerVersions.Where(v => { return v.Status == "Default"; }).ToList();
            
            // Get all defaults
            var defaultVersion = model.SupportedServerVersions;
            defaultVersion[0].SupportedEditions = defaultVersion[0].SupportedEditions.Where(v => { return v.Status == "Default"; }).ToList();
            var defaultEdition = defaultVersion[0].SupportedEditions;
            defaultEdition[0].SupportedServiceObjectives = defaultEdition[0].SupportedServiceObjectives.Where(v => { return v.Status == "Default"; }).ToList();
            var defaultServiceObjective = defaultEdition[0].SupportedServiceObjectives;

            // Assign defaults back to model.
            defaultServiceObjective[0].SupportedMaxSizes = defaultServiceObjective[0].SupportedMaxSizes.Where(v => { return v.Status == "Default"; }).ToList();
            defaultEdition[0].SupportedServiceObjectives = defaultServiceObjective;
            defaultVersion[0].SupportedEditions = defaultEdition;
            model.SupportedServerVersions = defaultVersion;
        }

        /// <summary>
        /// Filter the results based on the Service Objective Name
        /// </summary>
        /// <param name="model">The model to filter</param>
        private void FilterByServiceObjectiveName(LocationCapabilityModel model)
        {
            foreach (var version in model.SupportedServerVersions)
            {
                foreach (var edition in version.SupportedEditions)
                {
                    // Remove all service objectives with a name that does not match the desired value
                    edition.SupportedServiceObjectives = 
                        edition.SupportedServiceObjectives
                            .Where(slo => { return slo.ServiceObjectiveName == this.ServiceObjectiveName; })
                            .ToList();
                }

                // Remove editions that have no supported service objectives after filtering
                version.SupportedEditions = version.SupportedEditions.Where(e => e.SupportedServiceObjectives.Count > 0).ToList();
            }

            // Remove server versions that have no supported editions after filtering
            model.SupportedServerVersions = model.SupportedServerVersions.Where(v => v.SupportedEditions.Count > 0).ToList();
        }

        /// <summary>
        /// Filter the results based on the Edition Name
        /// </summary>
        /// <param name="model">The model to filter</param>
        private void FilterByEditionName(LocationCapabilityModel model)
        {
            foreach(var version in model.SupportedServerVersions)
            {
                // Remove all editions that do not match the desired edition name
                version.SupportedEditions = 
                    version.SupportedEditions
                        .Where(e => { return e.EditionName == this.EditionName; })
                        .ToList();
            }

            // Remove server versions that have no supported editions after filtering
            model.SupportedServerVersions = model.SupportedServerVersions.Where(v => v.SupportedEditions.Count > 0).ToList();
        }

        /// <summary>
        /// Filter the results based on the server version name
        /// </summary>
        /// <param name="model">The model to filter</param>
        private void FilterByServerVersion(LocationCapabilityModel model)
        {
            // Remove all server versions that don't match the desired name
            model.SupportedServerVersions = 
                model.SupportedServerVersions
                    .Where(obj => { return obj.ServerVersionName == this.ServerVersionName; })
                    .ToList();
        }
    }
}
