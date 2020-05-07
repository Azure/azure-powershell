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
        public static PSSecuritySetting ConvertToPSType1(this Setting value)
        {
            return new PSSecuritySetting()
            {
                Id = value.Id,
                Name = value.Name,
                Kind = "BaseSetting",
            };
        }

        public static PSSecuritySetting ConvertToPSType(this Setting value)
        {
            if (value.GetType().Name == nameof(DataExportSettings))
            {
                return new PSSecurityDataExportSetting()
                {
                    Id = ((DataExportSettings)value).Id,
                    Name = ((DataExportSettings)value).Name,
                    Kind = nameof(DataExportSettings),
                    Type = ((DataExportSettings)value).Type,
                    Enabled = ((DataExportSettings)value).Enabled
                };
            }

            return new PSSecuritySetting()
            {
                Id = value.Id,
                Name = value.Name,
                Kind = nameof(Setting),
                Type = value.Type
            };
        }

        public static List<PSSecuritySetting> ConvertToPSType(this IEnumerable<Setting> value)
        {
            var x = value.First().GetType();
            return value.Select(setting => setting.ConvertToPSType()).ToList();
        }

        public static PSSecurityDataExportSetting ConvertToPSType2(this DataExportSettings value)
        {
            return new PSSecurityDataExportSetting()
            {
                Id = value.Id,
                Name = value.Name,
                Kind = "DataExportSettings",
                Type = value.Type,
                Enabled = value.Enabled
            };
        }

        /*
        public static List<PSSecurityDataExportSetting> ConvertToPSType(this IEnumerable<DataExportSettings> value)
        {
            return value.Select(setting => setting.ConvertToPSType()).ToList();
        }
        */

        public static Setting ConvertToCSType(this PSSecuritySetting value)
        {
            return new Setting(value.Id, value.Name, value.Type);
        }

        public static DataExportSettings ConvertToCSType(this PSSecurityDataExportSetting value)
        {
            return new DataExportSettings(value.Enabled, value.Id, value.Name, value.Type);
        }
    }
}