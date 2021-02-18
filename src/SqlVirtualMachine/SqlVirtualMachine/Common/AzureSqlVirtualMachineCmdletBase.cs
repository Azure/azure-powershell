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

using System.Collections.Generic;
using Microsoft.Azure.Commands.ResourceManager.Common;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.Common
{
    /// <summary>
    /// The base class for all Azure Sql virtual machine cmdlets.
    /// </summary>
    /// <typeparam name="M">Type of the model the cmdlet will be working on (e.g. AzureSqlVirtualMachineModel)</typeparam>
    /// <typeparam name="A">Adapter used to call the REST APIs to perform actions on the specified model</typeparam>
    public abstract class AzureSqlVirtualMachineCmdletBase<M, A> : AzureRMCmdlet
    {
        /// <summary>
        /// Adapter used to call the REST APIs to perform actions on the specified model
        /// </summary>
        public A ModelAdapter { get; internal set; }

        /// <summary>
        /// Get the ResourceId property value of the model provided.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        protected virtual string GetResourceId(M model)
        {
            var resource = model as IEnumerable<object>;
            if (resource != null)
            {
                var resourceIdProperty = resource.GetType().GetProperty("ResourceId");
                var resourceIdValue = resourceIdProperty != null ? resourceIdProperty.GetValue(resource) : null;
                string resourceId = resourceIdValue != null ? resourceIdValue.ToString() : "";
                if (!string.IsNullOrEmpty(resourceId))
                {
                    return resourceId;
                }
            }
            return string.Empty;
        }

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

        /// <summary>
        /// Get the name of the action to be displayed in the request of confirmation for this cmdlet
        /// </summary>
        /// <returns>The name of the cmdlet that is being executed</returns>
        protected virtual string GetConfirmActionProcessMessage()
        {
            return MyInvocation.MyCommand.Name.Split('-')[0].ToLower();
        }

        /// <summary>
        /// Parse the input provided to the cmdlet
        /// </summary>
        protected virtual void ParseInput() { }

        /// <summary>
        /// General method that outline which operations should be executed during the execution of a sqlvirtualmachine cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            // Initialize the adapter class that is responsible for the conversion between the powershell resource and the .NET one
            ModelAdapter = InitModelAdapter();
            // Parse the parameter set given as input
            ParseInput();
            // Retrieve the Azure entity the cmdlet is referring to
            M model = GetEntity();
            // Apply the cmdlet to the recovered object
            M updatedModel = ApplyUserInputToModel(model);
            M responseModel = default(M);
            // If the confirmation level requires it, prompt the user for confirmation
            ConfirmAction(GetConfirmActionProcessMessage(), GetResourceId(updatedModel), () =>
            {
                // Apply the changes to the response model
                responseModel = PersistChanges(updatedModel);
            });
            // Convert the response model in a powershell object
            // See Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.generated.format.ps1xml file for more information on the response format
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
