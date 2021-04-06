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
using Microsoft.Azure.Commands.StreamAnalytics.Models;
using Microsoft.Azure.Commands.StreamAnalytics.Properties;
using System.Globalization;
using System.Management.Automation;
using System.Net;
using System.Security.Permissions;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.StreamAnalytics
{
    [GenericBreakingChange("The parameters of Remove-AzStreamAnalyticsJob will be updated in an upcoming breaking change release.", "2.0.0")]
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StreamAnalyticsJob", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureStreamAnalyticsJobCommand : StreamAnalyticsResourceProviderBaseCmdlet
    {
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The azure stream analytics job name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            if (ResourceGroupName != null && string.IsNullOrWhiteSpace(ResourceGroupName))
            {
                throw new PSArgumentNullException("ResourceGroupName");
            }

            this.ConfirmAction(
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.JobRemoving,
                    this.Name,
                    this.ResourceGroupName),
                this.Name,
                this.ExecuteDelete);
        }

        private void ExecuteDelete()
        {
            JobParametersBase parameter = new JobParametersBase()
            {
                ResourceGroupName = ResourceGroupName,
                JobName = Name
            };

            try
            {
                StreamAnalyticsClient.RemovePSJob(parameter);
                WriteObject(true);
            }
            catch
            {
                WriteObject(false);
            }
        }
    }
}
