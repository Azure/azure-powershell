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
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Start, "AzureStorSimpleLegacyVolumeContainerMigrationPlan")]
    public class StartAzureStorSimpleLegacyVolumeContainerMigrationPlan : StorSimpleCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = StorSimpleCmdletHelpMessage.MigrationConfigId)]
        [ValidateNotNullOrEmpty]
        public string LegacyConfigId { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = StorSimpleCmdletParameterSet.MigrateSpecificContainer,
            HelpMessage = StorSimpleCmdletHelpMessage.MigrationLegacyDataContainers)]
        public string[] LegacyContainerNames { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = StorSimpleCmdletParameterSet.MigrateAllContainer,
            HelpMessage = StorSimpleCmdletHelpMessage.MigrationAllContainers)]
        public SwitchParameter All { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                var startMigrationPlanRequest = new MigrationPlanStartRequest();
                startMigrationPlanRequest.ConfigId = LegacyConfigId;
                switch (ParameterSetName)
                {
                    case StorSimpleCmdletParameterSet.MigrateAllContainer:
                        {
                            startMigrationPlanRequest.DataContainerNameList = new List<string>();
                            break;
                        }
                    case StorSimpleCmdletParameterSet.MigrateSpecificContainer:
                        {
                            startMigrationPlanRequest.DataContainerNameList =
                            new List<string>(LegacyContainerNames.ToList().Distinct(
                                StringComparer.InvariantCultureIgnoreCase));
                            break;
                        }
                    default:
                        {
                            // unexpected code path hit.
                            throw new ParameterBindingException(
                                string.Format(Resources.MigrationParameterSetNotFound, ParameterSetName));
                        }
                }

                var status = StorSimpleClient.StartLegacyVolumeContainerMigrationPlan(startMigrationPlanRequest);
                MigrationCommonModelFormatter opFormatter = new MigrationCommonModelFormatter();
                WriteObject(opFormatter.GetResultMessage(Resources.StartMigrationPlanSuccessMessage, status));
            }
            catch (Exception except)
            {
                this.HandleException(except);
            }
        }
    }
}