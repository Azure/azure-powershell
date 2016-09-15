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
using System.Linq;
using Microsoft.Azure.Commands.Sql.Services;

namespace Microsoft.Azure.Commands.Sql.ThreatDetection.Model
{
    /// <summary>
    /// The possible states in which an auditing policy may be in
    /// </summary>
    public enum ThreatDetectionStateType { Enabled, Disabled, New };

    /// <summary>
    /// The possible disable alert types
    /// </summary> 
    public enum DetectionType
    {
        Sql_Injection,
        Sql_Injection_Vulnerability,
        Access_Anomaly,
        Usage_Anomaly,
        None
    };

    /// <summary>
    /// A class representing a database auditing policy
    /// </summary>
    public class BaseThreatDetectionPolicyModel
    {
        /// <summary>
        /// Gets or sets the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the Threat Detection state
        /// </summary>
        public ThreatDetectionStateType ThreatDetectionState { get; internal set; }

        /// <summary>
        /// Gets or sets the Threat Detection Email Addresses
        /// </summary>
        public string NotificationRecipientsEmails { get; internal set; }

        /// <summary>
        /// Gets or sets the whether to email service and co-administrators
        /// </summary>
        public bool EmailAdmins { get; internal set; }

        /// <summary>
        /// Gets or sets the detection types to filter 
        /// </summary>
        public DetectionType[] ExcludedDetectionTypes { get; internal set; }

        /// <summary>
        /// In cases where the user decided to use the shortcut NONE, this method sets the value of the ExcludedDetectionType property to reflect the correct values.
        /// </summary>
        public static DetectionType[] ProcessExcludedDetectionTypes(DetectionType[] excludedDetectionTypes)
        {
            if (excludedDetectionTypes == null || excludedDetectionTypes.Length == 0)
            {
                return excludedDetectionTypes;
            }

            if (excludedDetectionTypes.Length == 1)
            {
                if (excludedDetectionTypes[0] == DetectionType.None)
                {
                    return new DetectionType[] { };
                }
            }
            else
            {
                if (excludedDetectionTypes.Contains(DetectionType.None))
                {
                    throw new Exception(string.Format(Properties.Resources.InvalidExcludedDetectionTypeSet, DetectionType.None));
                }
            }
            return excludedDetectionTypes;
        }

        /// <summary>
        /// Preforms validity checks
        /// </summary>
        public void ValidateContent()
        {
            // Validity checks:
            // 1. Check that EmailAddresses are in correct format 
            bool areEmailAddressesInCorrectFormat = Util.AreEmailAddressesInCorrectFormat(NotificationRecipientsEmails, ';');
            if (!areEmailAddressesInCorrectFormat)
            {
                throw new Exception(Properties.Resources.EmailsAreNotValid);
            }

            // 2. check that EmailAdmins is not False and NotificationRecipientsEmails is not empty
            if (!EmailAdmins && string.IsNullOrEmpty(NotificationRecipientsEmails))
            {
                throw new Exception(Properties.Resources.NeedToProvideEmail);
            }
        }
    }
}