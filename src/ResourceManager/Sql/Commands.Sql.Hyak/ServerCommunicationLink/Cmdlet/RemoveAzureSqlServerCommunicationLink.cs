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

using Microsoft.Azure.Commands.Sql.ServerCommunicationLink.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServerCommunicationLink.Cmdlet
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmSqlServerCommunicationLink",
        SupportsShouldProcess = true), OutputType(typeof(AzureSqlServerCommunicationLinkModel))]
    public class RemoveAzureSqlServerCommunicationLink : AzureSqlServerCommunicationLinkCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the server communication link to remove.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL server communication link to remove.")]
        [ValidateNotNullOrEmpty]
        public string LinkName { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlServerCommunicationLinkModel> GetEntity()
        {
            return new List<AzureSqlServerCommunicationLinkModel>() {
                ModelAdapter.GetServerCommunicationLink(this.ResourceGroupName, this.ServerName, this.LinkName)
            };
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlServerCommunicationLinkModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerCommunicationLinkModel> model)
        {
            return model;
        }

        /// <summary>
        /// Persist removal to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlServerCommunicationLinkModel> PersistChanges(IEnumerable<AzureSqlServerCommunicationLinkModel> entity)
        {
            ModelAdapter.RemoveServerCommunicationLink(this.ResourceGroupName, this.ServerName, this.LinkName);
            return entity;
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!Force.IsPresent && !ShouldProcess(
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlServerCommunicationLinkDescription, this.LinkName, this.ServerName),
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlServerCommunicationLinkWarning, this.LinkName, this.ServerName),
               Microsoft.Azure.Commands.Sql.Properties.Resources.ShouldProcessCaption))
            {
                return;
            }

            base.ProcessRecord();
        }
    }
}
