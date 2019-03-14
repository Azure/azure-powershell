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

using System;
using Microsoft.Azure.Commands.DataMigration.Test;

namespace Microsoft.Azure.Commands
{
    public static class DataMigrationConfig
    {
        public static string GetConfigString(string configName)
        {
            return DataMigrationAppSettings.Instance.GetValue(configName);
        }

        public static bool GetConfigBool(string configName)
        {
            bool result = false;

            try
            {
                if (bool.TryParse(GetConfigString(configName), out result))
                {
                    // Do nothing here as value can be True/False
                }
            }
            catch (Exception)
            {
                // Do nothing
            }

            return result;
        }

        public static int GetConfigInt(string configName)
        {
            return int.Parse(GetConfigString(configName));
        }
    }
}
