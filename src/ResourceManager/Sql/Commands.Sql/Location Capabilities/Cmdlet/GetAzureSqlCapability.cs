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

using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Sql.Location_Capabilities.Model;
using Microsoft.Azure.Commands.Sql.Location_Capabilities.Services;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.Location_Capabilities.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureRmSqlCapability cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlCapability",
        ConfirmImpact = ConfirmImpact.None,
        DefaultParameterSetName = _filtered, SupportsShouldProcess = true)]
    public class GetAzureSqlCapability : AzureRMCmdlet
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
            AzureSqlCapabilitiesAdapter adapter = new AzureSqlCapabilitiesAdapter(DefaultProfile.Context);
            LocationCapabilityModel model = adapter.GetLocationCapabilities(LocationName);
            int depth = 0;

            switch (ParameterSetName)
            {
                case _default:
                    {
                        FilterByDefaults(model);
                        depth = 3;
                    }
                    break;
                case _filtered:
                    {
                        if (this.MyInvocation.BoundParameters.ContainsKey("ServerVersionName"))
                        {
                            FilterByServerVersion(model);
                            depth = 1;
                        }
                        if (this.MyInvocation.BoundParameters.ContainsKey("EditionName"))
                        {
                            FilterByEditionName(model);
                            depth = 2;
                        }
                        if (this.MyInvocation.BoundParameters.ContainsKey("ServiceObjectiveName"))
                        {
                            FilterByServiceObjectiveName(model);
                            depth = 3;
                        }
                    }
                    break;
            }

            if (depth > 0)
            {
                model.ExpandedDetails = CreateExpandedDetails(model, depth);
            }

            this.WriteObject(model, true);
        }

        /// <summary>
        /// Given a <see cref="LocationCapabilityModel"/> constructs a formatted string of its expanded details to the desired depth.
        /// </summary>
        /// <param name="model">The model details</param>
        /// <param name="depth">The depth to expand to</param>
        /// <returns>The formatted string containing the model details</returns>
        private string CreateExpandedDetails(LocationCapabilityModel model, int depth)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var version in model.SupportedServerVersions)
            {
                string versionInfo = GetVersionInformation(version);

                if (depth > 1)
                {
                    ExpandEdition(depth, builder, version, versionInfo);
                }
                else
                {
                    builder.AppendLine(versionInfo);
                }
            }

            return builder.ToString();
        }

        /// <summary>
        /// Formats all the supported editions in <paramref name="version"/> as strings prefixed with <paramref name="prefix"/>
        /// and appends them to the <paramref name="builder"/>
        /// </summary>
        /// <param name="depth">How deep to expand the information</param>
        /// <param name="builder">The string builder to append the information</param>
        /// <param name="version">The version object to expand and format</param>
        /// <param name="prefix">The prefix to apply to the information strings</param>
        private void ExpandEdition(int depth, StringBuilder builder, ServerVersionCapabilityModel version, string prefix)
        {
            foreach (var edition in version.SupportedEditions)
            {
                string editionInfo = GetEditionInformation(prefix, edition);

                if (depth > 2)
                {
                    ExpandServiceObjective(builder, edition, editionInfo);
                }
                else
                {
                    builder.AppendLine(editionInfo);
                }
            }
        }

        /// <summary>
        /// Formats all the supported service objectives in <paramref name="edition"/> as strings prefixed with <paramref name="prefix"/>
        /// and appends them to the <paramref name="builder"/>
        /// </summary>
        /// <param name="builder">The string building to add the formatted string to</param>
        /// <param name="edition">The edition containing the supported service objectives</param>
        /// <param name="prefix">The prefix for the formatted string</param>
        private void ExpandServiceObjective(StringBuilder builder, EditionCapabilityModel edition, string prefix)
        {
            foreach (var slo in edition.SupportedServiceObjectives)
            {
                string serviceObjectiveInfo = GetServiceObjectiveInformation(prefix, slo);

                builder.AppendLine(serviceObjectiveInfo);
            }
        }

        /// <summary>
        /// Gets the string formatting of the server version object
        /// </summary>
        /// <param name="version">The server version information to format as a string</param>
        /// <returns>The formatted string containing the server version information</returns>
        private string GetVersionInformation(ServerVersionCapabilityModel version)
        {
            return string.Format("Version: {0} ({1})", version.ServerVersionName, version.Status);
        }

        /// <summary>
        /// Gets the string formatting of the edition object
        /// </summary>
        /// <param name="baseString">The prefix before the edition information</param>
        /// <param name="edition">The edition information to format and append to the end of the baseString</param>
        /// <returns>The formatted string containing the edition information</returns>
        private string GetEditionInformation(string baseString, EditionCapabilityModel edition)
        {
            return string.Format("{0} -> Edition: {1} ({2})", baseString, edition.EditionName, edition.Status);
        }

        /// <summary>
        /// Gets the string formatting of the service objective object
        /// </summary>
        /// <param name="baseString">The prefix before the service objective information</param>
        /// <param name="objective">The service objective information to append</param>
        /// <returns>The formatted string containing the service objective information</returns>
        private string GetServiceObjectiveInformation(string baseString, ServiceObjectiveCapabilityModel objective)
        {
            return string.Format("{0} -> Service Objective: {1} ({2})", baseString, objective.ServiceObjectiveName, objective.Status);
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
            foreach (var version in model.SupportedServerVersions)
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
