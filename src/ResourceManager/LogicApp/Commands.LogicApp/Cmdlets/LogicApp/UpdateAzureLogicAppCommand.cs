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

using System.Globalization;

namespace Microsoft.Azure.Commands.LogicApp.Cmdlets
{
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.LogicApp.Utilities;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Updates a LogicApp workflow 
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmLogicApp", SupportsShouldProcess = true, DefaultParameterSetName = "Consumption"), OutputType(typeof (object))]
    public class UpdateAzureLogicAppCommand : LogicAppBaseCmdlet
    {
        #region private Variables

        /// <summary>
        /// Default value for the workflow status parameter
        /// </summary>
        private string _status = Constants.StatusEnabled;

        /// <summary>
        /// Default value for the workflow definition
        /// </summary>
        private object _definition = string.Empty;

        /// <summary>
        /// Default value for the workflow parameters
        /// </summary>
        private object _parameters = string.Empty;

        #endregion private Variables

        #region Input Paramters

        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group for the workflow.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the workflow.")]
        [Alias("ResourceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "App service plan name.", ValueFromPipelineByPropertyName = true, ParameterSetName = "HostingPlan")]
        [ValidateNotNullOrEmpty]
        public string AppServicePlan { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Use consumption based model.", ParameterSetName = "Consumption")]
        public SwitchParameter UseConsumptionModel { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The state of the workflow.")]
        [ValidateSet(Constants.StatusEnabled, Constants.StatusDisabled, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string State
        {
            get { return this._status; }
            set { this._status = value; }
        }

        [Parameter(Mandatory = false, HelpMessage = "The definition of the workflow.")]
        public object Definition
        {
            get { return this._definition; }
            set { this._definition = value; }
        }

        [Parameter(Mandatory = false, HelpMessage = "The physical file path of the workflow definition.")]
        [ValidateNotNullOrEmpty]
        public string DefinitionFilePath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account id of the workflow.")]
        [ValidateNotNullOrEmpty]
        public string IntegrationAccountId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The parameters parameter for the logic app.")]
        public object Parameters
        {
            get { return this._parameters; }
            set { this._parameters = value; }
        }

        [Parameter(Mandatory = false, HelpMessage = "The parameter file path.")]
        [ValidateNotNullOrEmpty]
        public string ParameterFilePath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Execute the create new workflow command
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var workflow = LogicAppClient.GetWorkflow(this.ResourceGroupName, this.Name);

            if (this.Definition == null)
            {
                workflow.Definition = null;
            }
            else if (this.Definition.ToString() != string.Empty)
            {
                workflow.Definition = JToken.Parse(this.Definition.ToString());
            }

            if (!string.IsNullOrEmpty(this.DefinitionFilePath))
            {
                workflow.Definition = CmdletHelper.GetDefinitionFromFile(this.TryResolvePath(this.DefinitionFilePath));
            }

            if (!string.IsNullOrEmpty(this.IntegrationAccountId))
            {
                workflow.IntegrationAccount = new ResourceReference(this.IntegrationAccountId);
            }

            if (this.Parameters == null)
            {
                workflow.Parameters = null;
            }
            else if (this.Parameters.ToString() != string.Empty)
            {
                workflow.Parameters = CmdletHelper.ConvertToWorkflowParameterDictionary(this.Parameters);
            }

            if (!string.IsNullOrEmpty(this.ParameterFilePath))
            {
                workflow.Parameters = CmdletHelper.GetParametersFromFile(this.TryResolvePath(this.ParameterFilePath));
            }

            if (!string.IsNullOrEmpty(this.State))
            {
                workflow.State = (WorkflowState) Enum.Parse(typeof (WorkflowState), this.State);
            }

            if (UseConsumptionModel.IsPresent)
            {
                workflow.Sku = null;
            }
            else if (!string.IsNullOrEmpty(this.AppServicePlan))
            {
                var servicePlan = WebsitesClient.GetAppServicePlan(this.ResourceGroupName, this.AppServicePlan);
                workflow.Sku = new Sku
                {
                    Name = (SkuName) Enum.Parse(typeof (SkuName), servicePlan.Sku.Tier),
                    Plan = new ResourceReference
                    {
                        Id = servicePlan.Id
                    }
                };
            }

            if (workflow.Definition == null)
            {
                throw new PSArgumentException(Properties.Resource.DefinitionMissingWarning);
            }

            ConfirmAction(Force.IsPresent,
                string.Format(CultureInfo.InvariantCulture, Properties.Resource.UpdateResourceWarning,
                    "Microsoft.Logic/workflows", this.Name),
                string.Format(CultureInfo.InvariantCulture, Properties.Resource.UpdateResourceMessage,
                    "Microsoft.Logic/workflows", this.Name),
                Name,
                () =>
                {
                    this.WriteObject(LogicAppClient.UpdateWorkflow(this.ResourceGroupName, this.Name, workflow), true);
                },
                null);
        }
    }
}