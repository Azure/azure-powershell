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
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Backup.Model;
using Microsoft.Azure.Commands.Sql.Backup.Services;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.Database.Services;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Linq;
using System.Globalization;
using Microsoft.Azure.Commands.Common.Exceptions;
using System;

namespace Microsoft.Azure.Commands.Sql.Database_Backup.Cmdlet
{
    public abstract class AzureSqlDatabaseLongTermRetentionBackupCmdletBase<T> :
        AzureSqlCmdletBase<IEnumerable<T>, AzureSqlDatabaseBackupAdapter>
    {
        /// <summary>
        /// The expected number of segments in a long term retention backup resource id.
        /// </summary>
        private const int LongTermRetentionBackupResourceIdSegmentsLength = 12;

        /// <summary>
        /// The expected number of segments in a long term retention backup resource id.
        /// </summary>
        private const int LongTermRetentionBackupResourceIdWithResourceGroupSegmentsLength = 14;

        /// <summary>
        /// Parse the longTermRetentionBackup resource Id
        /// </summary>
        /// <param name="resourceId"></param>
        protected Dictionary<string, string> ParseLongTermRetentionBackupResourceId(string resourceId)
        {
            Dictionary<string, string> resourceSegments = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            string[] tokens = resourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length != LongTermRetentionBackupResourceIdSegmentsLength
                && tokens.Length != LongTermRetentionBackupResourceIdWithResourceGroupSegmentsLength)
            {
                throw new Exception($"Invalid ResourceId. resourceID: {resourceId}, tokens.Length {tokens.Length}");
            }

            int i = 0;
            string type;
            string name;
            while (i < tokens.Length)
            {
                type = tokens[i++];
                name = tokens[i++];
                resourceSegments[type] = name;
            }

            try
            {
                resourceSegments.ContainsKey("locations");
                resourceSegments.ContainsKey("longTermRetentionServers");
                resourceSegments.ContainsKey("longTermRetentionDatabases");
                resourceSegments.ContainsKey("longTermRetentionBackups");
            }
            catch (KeyNotFoundException)
            {
                throw new AzPSArgumentException(Properties.Resources.InvalidLongTermRetentionBackupResourceIdFormat, "ResourceId");
            }

            return resourceSegments;
        }

        /// <summary>
        /// Initializes the adapter
        /// </summary>
        /// <returns></returns>
        protected override AzureSqlDatabaseBackupAdapter InitModelAdapter()
        {
            return new AzureSqlDatabaseBackupAdapter(DefaultProfile.DefaultContext);
        }

        protected static readonly string[] ListOfRegionsToShowWarningMessageForGeoBackupStorage = { "eastasia", "southeastasia", "brazilsouth", "east asia", "southeast asia", "brazil south" };

        protected void ShowBackupStorageRedundancyWarningIfNeeded(string backupStorageRedundancy, string location)
        {
            if (ListOfRegionsToShowWarningMessageForGeoBackupStorage.Contains(location.ToLower()))
            {
                if (backupStorageRedundancy == null)
                {
                    WriteWarning(string.Format(CultureInfo.InvariantCulture, Properties.Resources.BackupRedundancyNotChosenTakeSourceWarning));
                }
                else if (string.Equals(backupStorageRedundancy, "Geo", System.StringComparison.OrdinalIgnoreCase))
                {
                    WriteWarning(string.Format(CultureInfo.InvariantCulture, Properties.Resources.BackupRedundancyChosenIsGeoWarning));
                }
            }
        }
    }
}
