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

using System;
using System.Globalization;
using System.Management.Automation;
using System.Net;
using Microsoft.AzureStack.AzureConsistentStorage;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    /// <summary>
    ///     SYNTAX
    ///         Remove-ACSQuota [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-Location] {string} 
    ///             [-Name] {string} [-SkipCertificateValidation] [ {CommonParameters}] 
    /// 
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, Nouns.AdminQuota, SupportsShouldProcess = true)]
    public sealed class RemoveQuota : AdminCmdlet
    {
        /// <summary>
        /// Location
        /// </summary>
        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string Location { get; set; }

        /// <summary>
        ///  Quota Name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 4)]
        [ValidateNotNull]
        public string Name { get; set; }

        protected override void Execute()
        {
            if (ShouldProcess(
                    Resources.DeleteQuotaDescription.FormatInvariantCulture(Name),
                    Resources.DeleteQuotaWarning.FormatInvariantCulture(Name),
                    Resources.ShouldProcessCaption))
            {
                var response = Client.Quotas.Delete(Location, Name);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new AdminException(string.Format(CultureInfo.InvariantCulture, Resources.OperationFailedErrorMessage, response.StatusCode));
                }
            }
        }
    }
}
