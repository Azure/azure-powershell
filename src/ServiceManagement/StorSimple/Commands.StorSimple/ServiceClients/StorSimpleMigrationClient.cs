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

using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public partial class StorSimpleClient
    {
        public AzureOperationResponse ImportLegacyApplianceConfig(string configId, LegacyApplianceConfig legacyApplConfig)
        {
            return this.GetStorSimpleClient().MigrateLegacyAppliance.ImportLegacyApplianceConfig(configId, legacyApplConfig, this.GetCustomRequestHeaders());
        }

        public MigrationJobStatus StartLegacyVolumeContainerMigrationPlan(MigrationPlanStartRequest request)
        {
            return this.GetStorSimpleClient().MigrateLegacyAppliance.StartMigrationPlan(request, this.GetCustomRequestHeaders());
        }

        public MigrationJobStatus ConfirmLegacyVolumeContainerStatus(string configId, MigrationConfirmStatusRequest request)
        {
            return this.GetStorSimpleClient().MigrateLegacyAppliance.ConfirmMigration(configId, request, this.GetCustomRequestHeaders());
        }

        public TaskResponse UpdateMigrationPlanAsync(string configId)
        {
            return this.GetStorSimpleClient().MigrateLegacyAppliance.BeginUpdateMigrationPlan(configId, this.GetCustomRequestHeaders());
        }

        public TaskStatusInfo UpdateMigrationPlanSync(string configId)
        {
            return this.GetStorSimpleClient().MigrateLegacyAppliance.UpdateMigrationPlan(configId, this.GetCustomRequestHeaders());
        }

        public MigrationPlanList GetMigrationPlan(string configId)
        {
            return this.GetStorSimpleClient().MigrateLegacyAppliance.GetMigrationPlan(configId, this.GetCustomRequestHeaders());
        }
        public MigrationPlanList GetAllMigrationPlan()
        {
            return this.GetStorSimpleClient().MigrateLegacyAppliance.GetAllMigrationPlan(this.GetCustomRequestHeaders());
        }

        public MigrationJobStatus MigrationImportDataContainer(string configId, MigrationImportDataContainerRequest request)
        {
            return this.GetStorSimpleClient().MigrateLegacyAppliance.MigrationImportDataContainer(configId, request, this.GetCustomRequestHeaders());
        }

        public TaskStatusInfo UpdateDataContainerMigrationStatusSync(string configId)
        {
            return this.GetStorSimpleClient().MigrateLegacyAppliance.UpdateDataContainerMigrationStatus(configId, this.GetCustomRequestHeaders());
        }

        public TaskResponse UpdateDataContainerMigrationStatusAsync(string configId)
        {
            return this.GetStorSimpleClient().MigrateLegacyAppliance.BeginUpdateDataContainerMigrationStatus(configId, this.GetCustomRequestHeaders());
        }

        public MigrationDataContainerStatusList GetDataContainerMigrationStatus(string configId)
        {
            return this.GetStorSimpleClient().MigrateLegacyAppliance.GetDataContainerMigrationStatus(configId, this.GetCustomRequestHeaders());
        }

        public TaskResponse UpdateMigrationConfirmStatusAsync(string configId)
        {
            return this.GetStorSimpleClient().MigrateLegacyAppliance.BeginUpdateMigrationConfirmStatus(configId, this.GetCustomRequestHeaders());
        }

        public TaskStatusInfo UpdateMigrationConfirmStatusSync(string configId)
        {
            return this.GetStorSimpleClient().MigrateLegacyAppliance.UpdateMigrationConfirmStatus(configId, this.GetCustomRequestHeaders());
        }

        public MigrationConfirmStatus GetMigrationConfirmStatus(string configId)
        {
            return this.GetStorSimpleClient().MigrateLegacyAppliance.GetMigrationConfirmStatus(configId, this.GetCustomRequestHeaders());
        }
    }
}