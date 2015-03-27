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

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleLegacyVolumeContainerStatus")]
    public class GetAzureStorSimpleLegacyVolumeContainerStatus : StorSimpleCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = StorSimpleCmdletHelpMessage.MigrationConfigId)]
        public string LegacyConfigId { get; set; }

        [Parameter(Mandatory = false, Position = 1, HelpMessage = StorSimpleCmdletHelpMessage.MigrationLegacyDataContainers)]
        public string[] LegacyContainerNames { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                var taskResult = StorSimpleClient.UpdateDataContainerMigrationStatusSync(LegacyConfigId);
                MigrationDataContainerStatusList migrationDataContainerStatusList = StorSimpleClient.GetDataContainerMigrationStatus(LegacyConfigId);
                List<MigrationDataContainerStatus> migrationStatusSubList = new List<MigrationDataContainerStatus>(migrationDataContainerStatusList.MigrationDataContainerStatuses);

                if (null != LegacyContainerNames && 0 < LegacyContainerNames.Length)
                {
                    List<string> containerNameList = LegacyContainerNames.ToList();
                    migrationStatusSubList = migrationStatusSubList.FindAll(status => containerNameList.Contains(status.DataContainerName));
                }

                DataContainerMigrationStatus migrationStatus = new DataContainerMigrationStatus(LegacyConfigId, migrationStatusSubList);

                WriteObject(migrationStatus);
            }
            catch (Exception except)
            {
                this.HandleException(except);
            }
        }
    }
}