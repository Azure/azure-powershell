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

namespace Microsoft.Azure.Commands.AzureBackup.Models
{
    public enum AzureBackupVaultStorageType
    {
        GeoRedundant = 1,
        LocallyRedundant,
    }

    public enum AzureBackupContainerTypeInput
    {
        Windows = 1,
        SCDPM,
    }

    public enum AzureBackupContainerStatusInput
    {
        Registering = 1,
        Registered,
    }

    public enum AzureBackupContainerType
    {
        Invalid = 0,

        Unknown,

        // used by fabric adapter to populate discovered VMs
        IaasVMContainer,

        // used by fabric adapter to populate discovered services
        // VMs are child containers of services they belong to
        IaasVMServiceContainer
    }
}
