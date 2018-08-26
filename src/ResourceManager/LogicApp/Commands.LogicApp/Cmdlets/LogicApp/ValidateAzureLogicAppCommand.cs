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

namespace Microsoft.Azure.Commands.LogicApp.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.LogicApp.Utilities;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json.Linq;
    using ResourceManager.Common.ArgumentCompleters;

    /// <summary>
    /// Gets the callback URL for a trigger in a workflow
    /// </summary>
    [Cmdlet("Test", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "LogicApp"), OutputType(typeof(void))]
    public class ValidateAzureLogicApp : LogicAppBaseCmdlet
    {
        #region private Variables

        /// <summary>
        /// Default value for the workflow status parameter
        /// </summary>
        private string _status = Constants.StatusEnabled;

        #endregion private Variables

        #region Input Parameters

        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group for the workflow.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the workflow.",
            ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The location of the workflow.", ValueFromPipelineByPropertyName = true)]
        [LocationCompleter("Microsoft.Logic/workflows")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The state of the workflow.")]
        [ValidateSet(Constants.StatusEnabled, Constants.StatusDisabled, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string State
        {
            get { return this._status; }
            set { this._status = value; }
        }

        [Parameter(Mandatory = false, HelpMessage = "The definition of the workflow.",
            ParameterSetName = ParameterSet.LogicAppWithDefinition)]
        [ValidateNotNullOrEmpty]
        public object Definition { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The physical file path of the workflow definition.",
            ParameterSetName = ParameterSet.LogicAppWithDefinitionFile)]
        [ValidateNotNullOrEmpty]
        public string DefinitionFilePath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account id of the workflow.")]
        [ValidateNotNullOrEmpty]
        public string IntegrationAccountId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The parameters parameter for the logic app.")]
        [ValidateNotNullOrEmpty]
        public object Parameters { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The parameter file path.")]
        [ValidateNotNullOrEmpty]
        public string ParameterFilePath { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Validates the workflow 
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.Definition != null)
            {
                this.Definition = JToken.Parse(this.Definition.ToString());
            }

            if (!string.IsNullOrEmpty(this.DefinitionFilePath))
            {
                this.Definition = CmdletHelper.GetDefinitionFromFile(this.TryResolvePath(this.DefinitionFilePath));
            }

            if (this.Parameters != null)
            {
                this.Parameters = CmdletHelper.ConvertToWorkflowParameterDictionary(this.Parameters);
            }

            if (!string.IsNullOrEmpty(this.ParameterFilePath))
            {
                this.Parameters = CmdletHelper.GetParametersFromFile(this.TryResolvePath(this.ParameterFilePath));
            }

            LogicAppClient.ValidateWorkflow(this.ResourceGroupName, this.Location, this.Name, new Workflow
            {
                Location = this.Location,
                Definition = this.Definition,
                Parameters = this.Parameters as Dictionary<string, WorkflowParameter>,
                IntegrationAccount = string.IsNullOrEmpty(this.IntegrationAccountId)
                    ? null
                    : new ResourceReference(this.IntegrationAccountId),
                State = (WorkflowState)Enum.Parse(typeof(WorkflowState), this.State)
            });
        }
    }
}
