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

using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.DataContract;
using Microsoft.Azure.Management.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Management.Automation;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// The azure automation base cmdlet.
    /// </summary>
    public abstract class AzureAutomationBaseCmdlet : ResourceManager.Common.AzureRMCmdlet
    {
        /// <summary>
        /// The automation client.
        /// </summary>
        private IAutomationPSClient automationClient;

        /// <summary>
        /// Gets or sets the automation client base.
        /// </summary>
        public IAutomationPSClient AutomationClient
        {
            get
            {
                return this.automationClient = this.automationClient ?? new AutomationPSClient(DefaultProfile.DefaultContext);
            }

            set
            {
                this.automationClient = value;
            }
        }

        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The automation account name.")]
        [ValidateNotNullOrEmpty]
        public string AutomationAccountName { get; set; }

        protected virtual void AutomationProcessRecord()
        {
            // Do nothing.
        }

        public override void ExecuteCmdlet()
        {
            try
            {
                Requires.Argument("ResourceGroupName", this.ResourceGroupName).NotNull();
                Requires.Argument("AutomationAccountName", this.AutomationAccountName).NotNull();
                this.AutomationProcessRecord();
            }
            catch (ErrorResponseException errorResponseException)
            {
                // if errorResponseException.Body.Code is null or empty, check if errorResponseException.Response.Content is available.
                if (string.IsNullOrEmpty(errorResponseException.Body?.Code) && string.IsNullOrEmpty(errorResponseException.Body?.Message))
                {
                    if (!string.IsNullOrEmpty(errorResponseException.Response.Content))
                    {
                        // try to extract the error message from errorResponseException.Response.Content.
                        var message = ParseJson(errorResponseException.Response.Content);
                        if (!string.IsNullOrEmpty(message))
                        {
                            throw new ErrorResponseException(message, errorResponseException);
                        }
                    }
                }

                throw new ErrorResponseException(errorResponseException.Body?.Message, errorResponseException);
            }
        }

        // This function parses two type of Json contents:
        // 1) "{\"error\":{\"code\":\"ResourceGroupNotFound\",\"message\":\"Resource group 'foobar' could not be found.\"}}"
        // 2)            "{\"code\":\"ResourceGroupNotFound\",\"message\":\"Resource group 'foobar' could not be found.\"}"
        private string ParseJson(string value)
        {
            value = value.Trim();
            try
            {
                var nestedError = JsonConvert.DeserializeObject<AzureAutomationErrorResponseMessage>(value);
                return nestedError.Error.Message;
            }
            catch
            {
                // Ignore the parsing error.
            }

            try
            {
                var error = JsonConvert.DeserializeObject<AzureAutomationErrorInfo>(value);
                return error.Message;
            }
            catch
            {
                // Ignore the parsing error.
            }

            return null;
        }

        protected bool GenerateCmdletOutput(object result)
        {
            var ret = true;

            try
            {
                WriteObject(result);
            }
            catch (PipelineStoppedException)
            {
                ret = false;
            }

            return ret;
        }

        protected bool GenerateCmdletOutput(IEnumerable<object> results)
        {
            var ret = true;
            foreach (var result in results)
            {
                try
                {
                    WriteObject(result);
                }
                catch (PipelineStoppedException)
                {
                    ret = false;
                }
            }

            return ret;
        }
    }
}