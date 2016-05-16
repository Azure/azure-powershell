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

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Recovery Services Client Helper Methods class
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Converts the Parameter set string of Replication Frequency in seconds to UShort.
        /// </summary>
        /// <param name="replicationFrequencyString">Replication frequency in seconds.</param>
        /// <returns>A UShort corresponding to the value.</returns>
        public static ushort ConvertReplicationFrequencyToUshort(string replicationFrequencyString)
        {
            if (replicationFrequencyString == null)
            {
                return 0;
            }

            ushort replicationFrequency;

            if (!ushort.TryParse(replicationFrequencyString, out replicationFrequency))
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.InvalidReplicationFrequency,
                    replicationFrequencyString));
            }

            return replicationFrequency;
        }

        /// <summary>
        /// Validates if the time span object has a valid value.
        /// </summary>
        /// <param name="timeSpan">Time span object to be validated</param>
        public static void ValidateReplicationStartTime(TimeSpan? timeSpan)
        {
            if (timeSpan == null)
            {
                return;
            }

            if (TimeSpan.Compare(timeSpan.Value, new TimeSpan(24, 0, 0)) == 1)
            {
                throw new InvalidOperationException(
                    string.Format(Properties.Resources.ReplicationStartTimeInvalid));
            }
        }
    }
}
