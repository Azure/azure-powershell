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

using Microsoft.WindowsAzure.Commands.StorSimple.Models;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Confirm, "AzureStorSimpleLegacyVolumeContainerStatus")]
    public class ConfirmAzureStorSimpleLegacyVolumeContainerStatus : StorSimpleCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageMigrationConfigId)]
        public string LegacyConfigId { get; set; }

        [Parameter(Mandatory = false, Position = 1, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageMigrationLegacyDataContainers)]
        public string[] LegacyContainerNames { get; set; }

        [Parameter(Mandatory = true, Position = 2, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageMigrationOperation)]
        public ConfirmMigrationOperation MigrationOperation { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (string.IsNullOrEmpty(LegacyConfigId))
                {
                    WriteVerbose(Resources.MigrationConfigFileNotFound);
                    WriteObject(null);
                    return;
                }

                MigrationConfirmStatusRequest request = new MigrationConfirmStatusRequest();
                request.Operation = (MigrationOperation)MigrationOperation;
                request.DataContainerNameList = (null != LegacyContainerNames) ? LegacyContainerNames.ToList() : new List<string>();
                MigrationJobStatus status = StorSimpleClient.ConfirmLegacyVolumeContainerStatus(LegacyConfigId, request);

                WriteObject(this.GetResultMessage(status));
            }
            catch(Exception except)
            {
                this.HandleException(except);
            }
        }

        /// <summary>
        /// Gets Confirm migration success message to be displayed with error string obtained from service
        /// </summary>
        /// <param name="status">migration job status</param>
        private string GetResultMessage(MigrationJobStatus status)
        {
            StringBuilder builder = new StringBuilder();
            if (null != status.MessageInfoList)
            {
                foreach (HcsMessageInfo msgInfo in status.MessageInfoList)
                {
                    if (string.IsNullOrEmpty(msgInfo.Message))
                    {
                        builder.AppendLine(msgInfo.Message);
                    }
                }
            }

            builder.AppendLine(Resources.ConfirmMigrationSuccessMessage);
            return builder.ToString();
        }
    }
}