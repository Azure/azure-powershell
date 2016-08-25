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
using System;
using System.Collections;
using System.Management.Automation;
using AutomationManagement = Microsoft.Azure.Management.Automation;

namespace Microsoft.Azure.Commands.Automation.Model
{
    /// <summary>
    /// The Job Stream Record.
    /// </summary>
    public class JobStreamRecord : JobStream
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobStreamRecord"/> class.
        /// </summary>
        /// <param name="jobStream">
        /// The job stream.
        /// </param>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="automationAccountName">
        /// The automation account name
        /// </param>
        /// <param name="jobId">
        /// The job Id
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public JobStreamRecord(AutomationManagement.Models.JobStream jobStream, string resourceGroupName, string automationAccountName, Guid jobId) : base(jobStream, resourceGroupName, automationAccountName, jobId)
        {
            this.Value = new Hashtable();
            foreach (var kvp in jobStream.Properties.Value)
            {
                object paramValue;
                try
                {
                    paramValue = ((object)PowerShellJsonConverter.Deserialize(kvp.Value.ToString()));
                }
                catch (CmdletInvocationException exception)
                {
                    if (!exception.Message.Contains("Invalid JSON primitive"))
                        throw;

                    paramValue = kvp.Value;
                }
                this.Value.Add(kvp.Key, paramValue);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobStreamRecord"/> class.
        /// </summary>
        public JobStreamRecord()
        {
        }

        /// <summary>
        /// Gets or sets the stream values.
        /// </summary>
        public Hashtable Value { get; set; }
    }
}
