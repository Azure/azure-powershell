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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleLegacyVolumeContainerMigrationPlan")]
    public class GetAzureStorSimpleLegacyVolumeContainerMigrationPlan : StorSimpleCmdletBase
    {
        [Parameter(Mandatory = false, Position = 0, HelpMessage = StorSimpleCmdletHelpMessage.MigrationConfigId)]
        public string LegacyConfigId { get; set; }

        [Parameter(Mandatory = false, Position = 1, HelpMessage = StorSimpleCmdletHelpMessage.MigrationLegacyDataContainers)]
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
                        WriteVerbose(Resources.MigrationPlanNoConfigs);
                    }
                    else
                    {
                        WriteVerbose(Resources.MigrationPlanConfigList);
                        foreach (var migrationPlan in migrationPlanList.MigrationPlans)
                        {
                            var migrationPlanConfig = new MigrationPlanConfig(migrationPlan);
                            WriteObject(migrationPlanConfig);
                        }
                    }
                }
                else
                {
                    var taskResult = StorSimpleClient.UpdateMigrationPlanSync(LegacyConfigId);
                    var migrationPlanList = StorSimpleClient.GetMigrationPlan(LegacyConfigId);
                    WriteVerbose(string.Format("Request Id : {0}, HttpResponse {1}", migrationPlanList.RequestId, migrationPlanList.StatusCode));

                    if (migrationPlanList.MigrationPlans.Count == 0)
                    {
                        WriteVerbose(Resources.MigrationPlanNotFound);
                    }

                    else
                    {
                        WriteVerbose(Resources.VolumeContainerList);

                        MigrationPlan migrationPlan = migrationPlanList.MigrationPlans[0];
                        var filteredMigrationPlanInfos = new List<MigrationPlanInfo>();
                        
                        if (LegacyContainerNames == null)
                        {
                            filteredMigrationPlanInfos = new List<MigrationPlanInfo>(migrationPlan.MigrationPlanInfo);
                        }
                        else
                        {
                            var legacyContainerNamesList = new List<string>(LegacyContainerNames.ToList().Distinct());
                            foreach (var migrationPlanInfo in migrationPlan.MigrationPlanInfo)
                            {
                                if (legacyContainerNamesList.Contains(migrationPlanInfo.DataContainerName))
                                {
                                    filteredMigrationPlanInfos.Add(migrationPlanInfo);
                                }
                            }
                        }

                        migrationPlanList.MigrationPlans[0].MigrationPlanInfo = filteredMigrationPlanInfos;
                        var migrationPlanMsg = new MigrationPlanMsg(migrationPlanList.MigrationPlans[0]);
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