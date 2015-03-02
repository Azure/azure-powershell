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

using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Security.Cmdlet
{
    /// <summary>
    /// The base class for all Azure Sql cmdlets
    /// </summary>
    public abstract class SqlCmdletBase<M, A> : AzurePSCmdlet 
    {
       
        /// <summary>
        /// Stores the per request session Id for all request made in this cmdlet call.
        /// </summary>
        protected string clientRequestId { get; set; }

        internal SqlCmdletBase()
        {
            this.clientRequestId = Util.GenerateTracingId();
        }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "SQL Database server name.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }
   
       /// <summary>
        /// The PolicyHandler object mapped to this cmdlet
        /// </summary>
        public A ModelAdapter { get;  internal set; }

        /// <summary>
        /// Provides the model element that this cmdlet operates on
        /// </summary>
        /// <returns>A model object</returns>
        protected abstract M GetModel();

        /// <summary>
        /// This method is responsible to call the right API in the communication layer that will eventually send the information in the 
        /// object to the REST endpoint
        /// </summary>
        /// <param name="policy">The model object with the data to be sent to the REST endpoints</param>
        protected virtual void SendModel(M model) { }
         
        /// <summary>
        /// Updates the given model element with the cmdlet specific operation 
        /// </summary>
        /// <param name="model">A model object</param>
        protected virtual M UpdateModel(M model) { return model; }

        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out
        /// </summary>
        /// <returns>True if the model object should be written out, False otherwise</returns>
        protected virtual bool WriteResult() { return true; }

        protected abstract A InitModelAdapter (AzureSubscription subscription);

        
        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ModelAdapter = InitModelAdapter(Profile.Context.Subscription); 
            M model = this.GetModel();
            M updatedModel = this.UpdateModel(model);
            this.SendModel(updatedModel);
            if (WriteResult()) this.WriteObject(updatedModel);
        }
    }
}
