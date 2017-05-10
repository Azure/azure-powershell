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


using System;
using System.Globalization;
using System.Management.Automation;
using System.Net;
using Microsoft.AzureStack.AzureConsistentStorage;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    /// <summary>
    /// Delete an acquisition by its ID
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, Nouns.AdminAcquisition, SupportsShouldProcess = true)]
    public sealed class DeleteAcquisition : AdminCmdlet
    {
        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string ResourceGroupName { get; set; }

        /// <summary>
        ///     Farm Identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string FarmName { get; set; }

        /// <summary>
        ///     AcquisitionId
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string AcquisitionId { get; set; }

        protected override void Execute()
        {
            if (ShouldProcess(
                    Resources.DeleteAcquisitionVerboseDescription.FormatInvariantCulture(AcquisitionId),
                    Resources.DeleteAcquisitionVerboseWarning.FormatInvariantCulture(AcquisitionId),
                    Resources.ShouldProcessCaption))
            {
                var response = Client.Acquisitions.Delete(ResourceGroupName, FarmName, AcquisitionId);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new AdminException(string.Format(CultureInfo.InvariantCulture, Resources.OperationFailedErrorMessage, response.StatusCode));
                }
            }
        }
    }
}
