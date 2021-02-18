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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ManagedInstance.Cmdlet
{
    /// <summary>
    /// Definest Invoke-AzSqlInstanceFailover
    /// </summary>
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceFailover", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class InvokeAzureSqlManagedInstanceFailover : ManagedInstanceCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the managed instance to failover.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Managed Instance to failover.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [Alias("ManagedInstanceName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        ///  Defines whether the cmdlets will output a boolean at the end of its execution
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of failover managed instance confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// String to indicate failover on primary replica of instance
        /// </summary>
        public const string PrimaryReplica = "Primary";

        /// <summary>
        /// String to indicate failover on readable secondary replica of instance
        /// </summary>
        public const string ReadableSecondaryReplica = "ReadableSecondary";

        /// <summary>
        /// Defines whether to failover the readable secondary
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Failover the readable secondary replica instead of the default primary replica")]
        public SwitchParameter ReadableSecondary { get; set; }

        protected override IEnumerable<Model.AzureSqlManagedInstanceModel> GetEntity()
        {
            return new List<Model.AzureSqlManagedInstanceModel>()
            {
                ModelAdapter.GetManagedInstance(this.ResourceGroupName, this.Name)
            };
        }

        /// <summary>
        /// Apply user input.  Here nothing to apply
        /// </summary>
        /// <param name="model">The result of GetEntity</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<Model.AzureSqlManagedInstanceModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlManagedInstanceModel> model)
        {
            return model;
        }

        /// <summary>
        /// Deletes the instance.
        /// </summary>
        /// <param name="entity">The instance being deleted</param>
        /// <returns>The instance that was deleted</returns>
        protected override IEnumerable<Model.AzureSqlManagedInstanceModel> PersistChanges(IEnumerable<Model.AzureSqlManagedInstanceModel> entity)
        {
            string replicaType = this.ReadableSecondary.IsPresent ? ReadableSecondaryReplica : PrimaryReplica;
            ModelAdapter.FailoverManagedInstance(this.ResourceGroupName, this.Name, replicaType);
            return entity;
        }

        /// <summary>
        /// Returns false so the model object that was constructed by this cmdlet is not written out
        /// </summary>
        /// <returns>False since the model object should not be written out</returns>
        protected override bool WriteResult() { return false; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!this.Force.IsPresent && !base.ShouldProcess(
                string.Format(CultureInfo.InvariantCulture,
                Microsoft.Azure.Commands.Sql.Properties.Resources.FailoverAzureSqlInstanceDescription, this.Name),
                string.Format(CultureInfo.InvariantCulture,
                    Microsoft.Azure.Commands.Sql.Properties.Resources.FailoverAzureSqlInstanceWarning, this.Name),
                Microsoft.Azure.Commands.Sql.Properties.Resources.ShouldProcessCaption))
            {
                return;
            }
            
            base.ExecuteCmdlet();

            if (this.PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
