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

using System.Globalization;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.AlertsManagement;
using Microsoft.Azure.Management.AlertsManagement.Models;

namespace Microsoft.Azure.Commands.AlertsManagement
{
    public abstract class AlertsManagementBaseCmdlet : AzureRMCmdlet
    {
        #region Client Declaration
        private IAlertsManagementClient alertsManagementClient;

        /// <summary>
        /// Gets the monitorManagementClient to use in the Cmdlet
        /// </summary>
        public IAlertsManagementClient AlertsManagementClient
        {
            // The premise is that a command to establish a context (like Connect-AzAccount) has
            //   been called before this command in order to have a correct CurrentContext
            get
            {
                if (this.alertsManagementClient == null)
                {
                    this.alertsManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<AlertsManagementClient>(DefaultProfile.DefaultContext, AzureEnvironment.Endpoint.ResourceManager);
                }

                return this.alertsManagementClient;
            }
            set { this.alertsManagementClient = value; }
        }
        #endregion

        /// <summary>
        /// Executes the Cmdlet. This is a callback function to simplify the exception handling
        /// </summary>
        protected abstract void ProcessRecordInternal();

        /// <summary>
        /// Gets a string with the name of the cmdlet defined by the type t
        /// </summary>
        /// <returns>A string with the name of the cmdlet defined by the type t or a message indicating the name of the class t is the CmdletAttribute is not found in t</returns>
        protected string GetCmdletName()
        {
            Type t = this.GetType();
            CmdletAttribute cmdletAttribute = (CmdletAttribute)Attribute.GetCustomAttribute(t, typeof(CmdletAttribute));
            if (cmdletAttribute == null)
            {
                return string.Format(CultureInfo.InvariantCulture, "Unknown cmdlet name. Type: {0}", t.Name);
            }
            else
            {
                return string.Format(CultureInfo.InvariantCulture, "{0}-{1}", cmdletAttribute.VerbName, cmdletAttribute.NounName);
            }
        }

        /// <summary>
        /// Writes a warning message with the name of the cmdlet, a topic and the message itself
        /// </summary>
        /// <param name="cmdletName">The name of the cmdlet.</param>
        /// <param name="topic">The topic, i.e. short description/category, of the message</param>
        /// <param name="message">The message itself</param>
        /// <param name="withTimeStamp">true if the message should include a timestamp, false (default) it no timestamp should be included</param>
        protected void WriteIdentifiedWarning(string cmdletName, string topic, string message, bool withTimeStamp = false)
        {
            string formattedMessage = string.Format(
                CultureInfo.InvariantCulture,
                "[{0}] {1}: {2}",
                cmdletName,
                topic,
                message);

            if (withTimeStamp)
            {
                WriteWarningWithTimestamp(formattedMessage);
            }
            else
            {
                WriteWarning(formattedMessage);
            }
        }

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            this.ProcessRecordInternal();
        }
    }
}
