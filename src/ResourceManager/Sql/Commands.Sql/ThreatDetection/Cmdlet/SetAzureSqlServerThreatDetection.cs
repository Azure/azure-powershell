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

using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Commands.Sql.ThreatDetection.Model;
using System;
using System.Linq;
using System.Management.Automation;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Sql.ThreatDetection.Cmdlet
{
    /// <summary>
    /// Sets the auditing policy properties for a specific database.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlServerThreatDetectionPolicy", SupportsShouldProcess = true), OutputType(typeof(ServerThreatDetectionPolicyModel))]
    public class SetAzureSqlServerThreatDetection : SqlServerThreatDetectionCmdletBase
    {
        /// <summary>
        ///  Defines whether the cmdlets will output the model object at the end of its execution
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Gets or sets the Threat Detection Email Addresses
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A semicolon separated list of email addresses to send the alerts to")]
        public string NotificationRecipientsEmails { get; set; }

        /// <summary>
        /// Gets or sets the whether to email administrators
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Defines whether to email administrators")]
        [ValidateNotNullOrEmpty]
        public bool? EmailAdmins { get; set; }

        /// <summary>
        /// Gets or sets the names of the detection types to filter.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Detection types to exclude")]
        public DetectionType[] ExcludedDetectionType { get; set; }

        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out
        /// </summary>
        /// <returns>True if the model object should be written out, False otherwise</returns>
        protected override bool WriteResult() { return PassThru; }

        /// <summary>
        /// Updates the given model element with the cmdlet specific operation 
        /// </summary>
        /// <param name="model">A model object</param>
        protected override ServerThreatDetectionPolicyModel ApplyUserInputToModel(ServerThreatDetectionPolicyModel model)
        {
            base.ApplyUserInputToModel(model);

            model.ThreatDetectionState = ThreatDetectionStateType.Enabled;

            if (NotificationRecipientsEmails != null)
            {
                model.NotificationRecipientsEmails = NotificationRecipientsEmails;
            }

            if (EmailAdmins != null)
            {
                model.EmailAdmins = (bool)EmailAdmins;
            }

            if (ExcludedDetectionType != null)
            {
                model.ExcludedDetectionTypes = BaseThreatDetectionPolicyModel.ProcessExcludedDetectionTypes(ExcludedDetectionType);
            }
            model.ValidateContent();
            return model;
        }
    }
}