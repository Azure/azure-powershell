// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DMConfig.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Azure.Commands.DataMigration.Test;
using System;

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
                if(bool.TryParse(GetConfigString(configName), out result))
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
