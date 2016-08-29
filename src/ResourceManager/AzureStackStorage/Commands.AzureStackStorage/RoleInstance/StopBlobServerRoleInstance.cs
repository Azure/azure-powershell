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


using Microsoft.AzureStack.Management.StorageAdmin;
using System.Globalization;
using System.Management.Automation;
using System.Net;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    /// <summary>
    ///     SYNTAX
    ///          Stop-BlobServerRoleInstance [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///             [-SkipCertificateValidation] [-FarmName] {string} [-InstanceId] {string} [ {CommonParameters}] 
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, Nouns.AdminBlobServerRoleInstance, SupportsShouldProcess = true)]
    public sealed class StopBlobServerRoleInstance : AdminCmdlet
    {
        /// <summary>
        /// farm identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 4)]
        [ValidateNotNullOrEmpty]
        public string FarmName
        {
            get;
            set;
        }

        /// <summary>
        /// instance identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 5)]
        [ValidateNotNullOrEmpty]
        public string InstanceId
        {
            get;
            set;
        }

        protected override void Execute()
        {
            if (ShouldProcess(
                Resources.StopBlobServerRoleInstanceVerboseDescription.FormatInvariantCulture(InstanceId),
                Resources.StopBlobServerRoleInstanceVerboseWarning.FormatInvariantCulture(InstanceId),
                Resources.ShouldProcessCaption))
            {
                var response = Client.BlobServerInstances.Stop(ResourceGroupName, FarmName, InstanceId);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new AdminException(string.Format(CultureInfo.InvariantCulture,
                        Resources.OperationFailedErrorMessage, response.StatusCode));
                }
            }
        }
    }
}
