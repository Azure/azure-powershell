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

using Microsoft.Azure.Management.Monitor.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.Alerts
{
    /// <summary>
    /// Create an AlertRuleWebhook action
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AlertRuleWebhook"), OutputType(typeof(Management.Monitor.Management.Models.RuleWebhookAction))]
    public class NewAzureRmAlertRuleWebhookCommand : MonitorCmdletBase
    {
        /// <summary>
        /// Gets or sets the ServiceUri of the action
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The service uri of the action")]
        public string ServiceUri { get; set; }

        /// <summary>
        /// Gets or sets the properties dictionary of the action
        /// </summary>
        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The properties of the action in @{Property1 = 'Value1'; ...} format")]
        public Hashtable Property { get; set; }

        /// <summary>
        /// Executes the Cmdlet. This is a callback function to simplify the exception handling
        /// </summary>
        protected override void ProcessRecordInternal()
        { }

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Utilities.ValidateUri(this.ServiceUri, "ServiceUri");

            var dictionary = this.Property == null
                ? new Dictionary<string, string>()
                : this.Property.Keys.Cast<object>().ToDictionary(key => (string)key, key => (string)this.Property[key]);

            var action = new Management.Monitor.Management.Models.RuleWebhookAction
            {
                ServiceUri = this.ServiceUri,
                Properties = dictionary
            };

            WriteObject(action);
        }
    }
}
