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

using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Security.Models;

namespace Microsoft.Azure.Commands.Security.Models.Settings
{
    public static class PSSecuritySettingConverters
    {
        public static PSSecuritySetting ConvertToPSType(this Setting value)
        {
            if (value.GetType().Name == nameof(DataExportSettings))
            {
                return new PSSecurityDataExportSetting()
                {
                    Id = value.Id,
                    Name = value.Name,
                    Type = value.Type,
                    Enabled = ((DataExportSettings)value).Enabled
                };
            }

            if (value.GetType().Name == nameof(AlertSyncSettings))
            {
                return new PSSecurityAlertSyncSettings()
                {
                    Id = value.Id,
                    Name = value.Name,
                    Type = value.Type,
                    Enabled = ((AlertSyncSettings)value).Enabled
                };
            }

            return new PSSecuritySetting()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type
            };
        }

        public static List<PSSecuritySetting> ConvertToPSType(this IEnumerable<Setting> value)
        {
            return value.Select(setting => setting.ConvertToPSType()).ToList();
        }

        public static Setting ConvertToCSType(this PSSecuritySetting value)
        {
            if (value.GetType().Name == nameof(PSSecurityDataExportSetting))
            {
                return new DataExportSettings(((PSSecurityDataExportSetting)value).Enabled, value.Id, value.Name, value.Type);
            }

            if (value.GetType().Name == nameof(PSSecurityAlertSyncSettings))
            {
                return new AlertSyncSettings(((PSSecurityAlertSyncSettings)value).Enabled, value.Id, value.Name, value.Type);
            }

            return new Setting(value.Id, value.Name, value.Type);
        }
    }
}