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

using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Start, "AzureStorSimpleLegacyVolumeContainerMigrationPlan")]
    public class StartAzureStorSimpleLegacyVolumeContainerMigrationPlan : StorSimpleCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = StorSimpleCmdletHelpMessage.MigrationConfigId)]
        [ValidateNotNullOrEmpty]
        public string LegacyConfigId { get; set; }

        [Parameter(Mandatory = false, Position = 1, HelpMessage = StorSimpleCmdletHelpMessage.MigrationLegacyDataContainers)]
        public string[] LegacyContainerNames { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                MigrationPlanStartRequest request = new MigrationPlanStartRequest();
                request.ConfigId = LegacyConfigId;
                request.DataContainerNameList = (null != LegacyContainerNames) ? LegacyContainerNames.ToList() : new List<string>();
                
                MigrationJobStatus status = StorSimpleClient.StartLegacyVolumeContainerMigrationPlan(request);
                WriteObject(this.GetResultMessage(status));
            }
            catch(Exception except)
            {
                this.HandleException(except);
            }
        }

        /// <summary>
        /// Gets Start Migration status job success message to be displayed with error string obtained from service
        /// </summary>
        /// <param name="status">migration job status</param>
        private string GetResultMessage(MigrationJobStatus status)
        {
            StringBuilder builder = new StringBuilder();
            if(null != status.MessageInfoList)
            {
                foreach(HcsMessageInfo msgInfo in status.MessageInfoList)
                {
                    if(string.IsNullOrEmpty(msgInfo.Message))
                    {
                        builder.AppendLine(msgInfo.Message);
                    }
                }
            }

            builder.AppendLine(Resources.StartMigrationPlanSuccessMessage);
            return builder.ToString();
        }
    }
}