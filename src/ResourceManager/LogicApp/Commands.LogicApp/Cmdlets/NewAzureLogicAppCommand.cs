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

namespace Microsoft.Azure.Commands.LogicApp.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Globalization;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.LogicApp.Utilities;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System.Collections;

    /// <summary>
    /// Creates a new LogicApp workflow 
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureLogicApp"), OutputType(typeof (object))]
    public class NewAzureLogicAppCommand : LogicAppBaseCmdlet
    {
        #region private Variables

        /// <summary>
        /// Default value for the workflow status parameter
        /// </summary>
        private string _status = Constants.StatusEnabled;

        #endregion private Variables

        #region Input Paramters

        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group for the workflow.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The location of the workflow.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the workflow.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The Plan name.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PlanName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The state of the workflow.")]
        [ValidateSet(Constants.StatusEnabled, Constants.StatusDisabled, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string State
        {
            get { return this._status; }
            set { this._status = value; }
        }

        [Parameter(Mandatory = false, HelpMessage = "The URI link to the workflow definition.", ParameterSetName = ParameterSet.LogicAppWithDefinitionLink)]
        [ValidateNotNullOrEmpty]
        public string DefinitionLinkUri { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The content version of the definition link.", ParameterSetName = ParameterSet.LogicAppWithDefinitionLink)]
        [ValidateNotNullOrEmpty]
        public string DefinitionLinkContentVersion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The definition of the workflow.", ParameterSetName = ParameterSet.LogicAppWithDefinition)]
        [ValidateNotNullOrEmpty]
        public object Definition { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The physical file path of the workflow definition.", ParameterSetName = ParameterSet.LogicAppWithDefinitionFile)]
        [ValidateNotNullOrEmpty]
        public string DefinitionFilePath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The parameters link Uri.")]
        [ValidateNotNullOrEmpty]
        public string ParameterLinkUri { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The parameters link Uri content version.")]
        [ValidateNotNullOrEmpty]
        public string ParameterLinkContentVersion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The parameters parameter for the logic app.")]
        [ValidateNotNullOrEmpty]
        public object Parameters { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The parameter file path.")]
        [ValidateNotNullOrEmpty]
        public string ParameterFilePath { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The SKU name.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SkuName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The Plan Id.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PlanId { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Execute the create new workflow command
        /// </summary>
        public override void ExecuteCmdlet()
        {
            //Validate the input for the definition object and set it from file if file path is specified
            this.ValidateAndSetWorkflowDefinition();

            //Validate the input for the parameter object and set it from file or input object.
            this.ValidateAndSetWorkflowParamters();

            // if SKU planId is not provided then planId is derived using resourcegroup name and the plan name. 
            if (string.IsNullOrEmpty(this.PlanId) && !string.IsNullOrEmpty(this.PlanName) &&
                !string.IsNullOrEmpty(this.ResourceGroupName))
            {
                this.PlanId = string.Format(CultureInfo.InvariantCulture,
                    Properties.Resource.ApplicationServicePlanIdFormat,
                    LogicAppClient.LogicManagementClient.SubscriptionId, this.ResourceGroupName, this.PlanName);
            }

            //Call LogicAppClient to create the workflow.            
            this.WriteObject(LogicAppClient.CreateWorkflow(this.ResourceGroupName, this.Name, new Workflow
            {
                Location = this.Location,
                Definition = this.Definition,
                Parameters = this.Parameters as Dictionary<string, WorkflowParameter>,
                DefinitionLink = string.IsNullOrEmpty(this.DefinitionLinkUri)
                    ? null
                    : new ContentLink
                    {
                        Uri = this.DefinitionLinkUri,
                        ContentVersion = this.DefinitionLinkContentVersion
                    },
                ParametersLink = string.IsNullOrEmpty(this.ParameterLinkUri)
                    ? null
                    : new ContentLink
                    {
                        Uri = this.ParameterLinkUri,
                        ContentVersion = this.ParameterLinkContentVersion
                    },
                State = (WorkflowState) Enum.Parse(typeof (WorkflowState), this.State),
                Sku = new Sku
                {
                    Name = (SkuName)Enum.Parse(typeof(SkuName), this.SkuName),
                    Plan = new ResourceReference
                    {
                        Id = this.PlanId
                    }
                }
            }), true);
        }

        /// <summary>
        /// Validate and set the value of definition object from the file.
        /// </summary>        
        private void ValidateAndSetWorkflowDefinition()
        {
            if (!string.IsNullOrEmpty(this.DefinitionFilePath))
            {
                var fileDefinitionName = this.TryResolvePath(this.DefinitionFilePath);

                if (!(new FileInfo(fileDefinitionName)).Exists)
                {
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, Properties.Resource.FileDoesNotExist, fileDefinitionName));
                }

                this.Definition = JToken.Parse(File.ReadAllText(fileDefinitionName));
            }
            else if (this.Definition != null)
            {
                this.Definition = JToken.Parse(this.Definition.ToString());
            }
        }

        /// <summary>
        /// Validate and Set the parameter collection from file or Custom objects. 
        /// </summary>
        private void ValidateAndSetWorkflowParamters()
        {            
            if (!string.IsNullOrEmpty(this.ParameterFilePath))
            {
                var fileParameterName = this.TryResolvePath(this.ParameterFilePath);

                if (!(new FileInfo(fileParameterName)).Exists)
                {
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, Properties.Resource.FileDoesNotExist, fileParameterName));
                }

                var inputParametersObject = JObject.Parse(File.ReadAllText(fileParameterName));
                var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(inputParametersObject.ToString());

                var inputParameters = new Dictionary<string, WorkflowParameter>();

                foreach (var parameter in values)
                {
                    var workflowParameter = JsonConvert.DeserializeObject<WorkflowParameter>(parameter.Value.ToString());
                    inputParameters.Add(parameter.Key, workflowParameter);
                }

                this.Parameters = inputParameters;
            } else if (this.Parameters is Hashtable)
            {
                var collection = this.Parameters as Hashtable;
                var inputParameters = new Dictionary<string, WorkflowParameter>();

                foreach (var key in collection.Keys)
                {
                    inputParameters.Add(key.ToString(), new WorkflowParameter
                    {
                        Value = collection[key].ToString()
                    });
                }
                this.Parameters = inputParameters;
            }
            else if (this.Parameters is Dictionary<string, WorkflowParameter>)
            {
                this.Parameters = this.Parameters as Dictionary<string, WorkflowParameter>;
            }
        }
    }
}