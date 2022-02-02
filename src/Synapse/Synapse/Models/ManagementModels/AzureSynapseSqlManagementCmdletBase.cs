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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    /// <summary>
    /// The base class for all Azure Synapse Sql management cmdlets
    /// </summary>
    public abstract class AzureSynapseSqlManagementCmdletBase<M, A> : SynapseManagementCmdletBase
    {
        protected virtual string GetResourceId(M model)
        {
            var workspaceNameProperty = model.GetType().GetProperty(SynapseConstants.WorkspaceName);
            var workspaceName = (workspaceNameProperty == null)? string.Empty: workspaceNameProperty.GetValue(model).ToString();

            var sqlPoolNameProperty = model.GetType().GetProperty(SynapseConstants.SqlPoolName);
            var sqlPoolName = (sqlPoolNameProperty == null) ? string.Empty : sqlPoolNameProperty.GetValue(model).ToString();

            if (!string.IsNullOrEmpty(workspaceName))
            {
                if (!string.IsNullOrEmpty(sqlPoolName))
                {
                    return string.Format("{0}.{1}", workspaceName, sqlPoolName);
                }
                return workspaceName;
            }
            if (!string.IsNullOrEmpty(sqlPoolName))
            {
                return sqlPoolName;
            }
            return string.Empty;
        }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        /// <summary>
        /// The ModelAdapter object used by this cmdlet
        /// </summary>
        public A ModelAdapter { get; internal set; }

        /// <summary>
        /// Gets an entity from the service
        /// </summary>
        /// <returns>A model object</returns>
        protected abstract M GetEntity();

        /// <summary>
        /// Updates the given model element with the cmdlet specific operation 
        /// </summary>
        /// <param name="model">A model object</param>
        protected virtual M ApplyUserInputToModel(M model) { return model; }

        /// <summary>
        /// This method is responsible to call the right API in the communication layer that will eventually send the information in the 
        /// object to the REST endpoint
        /// </summary>
        /// <param name="entity">The model object with the data to be sent to the REST endpoints</param>
        protected virtual M PersistChanges(M entity) { return default(M); }

        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out
        /// </summary>
        /// <returns>True if the model object should be written out, False otherwise</returns>
        protected virtual bool WriteResult() { return true; }

        /// <summary>
        /// Creation and initialization of the ModelAdapter object
        /// </summary>
        /// <returns>An initialized and ready to use ModelAdapter object</returns>
        protected abstract A InitModelAdapter();

        /// <summary>
        /// Transforms the given model object to be an object that is written out
        /// </summary>
        /// <param name="model">The about to be written model object</param>
        /// <returns>The prepared object to be written out</returns>
        protected virtual object TransformModelToOutputObject(M model)
        {
            return model;
        }

        protected virtual string GetConfirmActionProcessMessage()
        {
            return Properties.Resources.BaseConfirmActionProcessMessage;
        }

        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ModelAdapter = InitModelAdapter();
            M model = GetEntity();
            M updatedModel = ApplyUserInputToModel(model);
            M responseModel = default(M);
            ConfirmAction(GetConfirmActionProcessMessage(), GetResourceId(updatedModel), () =>
            {
                responseModel = PersistChanges(updatedModel);
            });

            if (responseModel != null)
            {
                if (WriteResult())
                {
                    WriteObject(TransformModelToOutputObject(responseModel), true);
                }
            }
            else
            {
                if (WriteResult())
                {
                    WriteObject(TransformModelToOutputObject(updatedModel));
                }
            }
        }
    }
}
