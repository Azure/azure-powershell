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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using System;
using System.Text;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Azure VM specific backup policy class.
    /// </summary>
    public class AzureVmPolicy : AzurePolicy
    {
        /// <summary>
        /// Object defining the retention days for a snapshot
        /// </summary>
        public int? SnapshotRetentionInDays { get; set; }

        /// <summary>
        /// Object defining the number of associated items for the policy
        /// </summary>
        public int? ProtectedItemsCount { get; set; }

        /// <summary>
        /// object defining the RG Name to store Restore Points
        /// </summary>
        public string AzureBackupRGName { get; set; }

        /// <summary>
        /// object defining the RG Name suffix to store Restore Points
        /// </summary>
        public string AzureBackupRGNameSuffix { get; set; }

        /// <summary>
        /// Type of the AzureVM policy : Standard, Enhanced
        /// </summary>
        public PSPolicyType PolicySubType { get; set; }

        /// <summary>
        /// Smart tiering settings 
        /// </summary>
        public TieringPolicy TieringPolicy { get; set; }

        /// <summary>
        ///  Gets or sets SnapshotConsistencyType. Possible values include: OnlyCrashConsistent.
        /// </summary>
        public string SnapshotConsistencyType { get; set; }

    }

    /// <summary>
    /// Smart tiering settings
    /// </summary>
    public class TieringPolicy
    {
        /// <summary>
        /// Target tier where the recovery point will be automatically moved
        /// </summary>
        public RecoveryPointTier TargetTier = RecoveryPointTier.VaultArchive;

        /// <summary>
        /// Tiering mode to control what RPs will be moved. Allowed values - TierRecommended, TierAllEligible, DoNotTier
        /// </summary>
        public TieringMode TieringMode { get; set; }

        /// <summary>
        /// Duration after which to move to Archive
        /// </summary>
        public int? TierAfterDuration { get; set; }

        /// <summary>
        /// Duration type. Acceptable values: Days, Months
        /// </summary>
        public string TierAfterDurationType { get; set; }

        /// <summary>
        /// Converts the object into string.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine(string.Format("TargetTier: {0}, TieringMode: {1}, TierAfterDuration: {2}, TierAfterDurationType: {3}", this.TargetTier.ToString(),
                                    this.TieringMode.ToString(), this.TierAfterDuration, this.TierAfterDurationType));

            return sb.ToString();
        }
                
        public void Validate()
        {         
            if(TieringMode == TieringMode.DoNotTier || TieringMode == TieringMode.TierRecommended)
            {
                if((TierAfterDuration != null || TierAfterDurationType != null) && TierAfterDuration > 0 && TierAfterDurationType != "Invalid")
                {
                    throw new ArgumentException(Resources.InvalidParameterTierAfterDuration);
                }                
            }
            else if(TieringMode == TieringMode.TierAllEligible)
            {
                if (TierAfterDuration == null || TierAfterDurationType == null || (TierAfterDurationType.ToLower() != "days" && TierAfterDurationType.ToLower() != "months"))
                {
                    throw new ArgumentException(Resources.MissingParameterTierAfterDuration);                    
                }                    
            }
        }
    }
}