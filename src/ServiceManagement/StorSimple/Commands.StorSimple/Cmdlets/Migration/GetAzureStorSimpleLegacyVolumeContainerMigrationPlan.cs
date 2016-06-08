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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleLegacyVolumeContainerMigrationPlan"),
     OutputType(typeof(MigrationConfig), typeof(MigrationPlanMsg))]
    public class GetAzureStorSimpleLegacyVolumeContainerMigrationPlan : StorSimpleCmdletBase
    {
        [Parameter(Mandatory = false, Position = 0, HelpMessage = StorSimpleCmdletHelpMessage.MigrationConfigId)]
        [ValidateNotNullOrEmpty]
        public string LegacyConfigId { get; set; }

        [Parameter(Mandatory = false, Position = 1,
            HelpMessage = StorSimpleCmdletHelpMessage.MigrationLegacyDataContainers)]
        public string[] LegacyContainerNames { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (string.IsNullOrEmpty(LegacyConfigId))
                {
                    var migrationPlanList = StorSimpleClient.GetAllMigrationPlan();
                    if (migrationPlanList.MigrationPlans.Count == 0)
                    {
                        WriteWarning(Resources.MigrationPlanNoConfigs);
                    }
                    else
                    {
                        foreach (var migrationPlan in migrationPlanList.MigrationPlans)
                        {
                            var migrationPlanConfig = new MigrationConfig(migrationPlan);
                            WriteObject(migrationPlanConfig);
                        }
                    }
                }
                else
                {
                    StorSimpleClient.UpdateMigrationPlanSync(LegacyConfigId);
                    var migrationPlanList = StorSimpleClient.GetMigrationPlan(LegacyConfigId);
                    if (0 >= migrationPlanList.MigrationPlans.Count)
                    {
                        throw new ArgumentException(Resources.MigrationPlanNotFound);
                    }
                    else
                    {
                        MigrationPlan migrationPlan = migrationPlanList.MigrationPlans.First();
                        if (null != LegacyContainerNames)
                        {
                            var legacyContainerNamesList = LegacyContainerNames.ToList();
                            migrationPlan.MigrationPlanInfo =
                                migrationPlan.MigrationPlanInfo.ToList().FindAll(
                                    plan =>
                                        legacyContainerNamesList.Contains(plan.DataContainerName,
                                            StringComparer.InvariantCultureIgnoreCase));
                        }

                        var migrationPlanMsg = new MigrationPlanMsg(migrationPlan);
                        WriteObject(migrationPlanMsg);
                    }
                }
            }
            catch (Exception except)
            {
                this.HandleException(except);
            }
        }
    }
}