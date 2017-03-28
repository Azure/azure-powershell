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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.WindowsAzure.Management.RecoveryServicesVaultUpgrade.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Check vault upgrade prerequisites response.
    /// </summary>
    public enum CheckVaultUpgradePrerequisitesResponse
    {
        /// <summary>
        /// Represents succeeded scenario.
        /// </summary>
        Succeeded,

        /// <summary>
        /// Represents failed scenario.
        /// </summary>
        Failed,

        /// <summary>
        /// Represents succeeded scenario with warnings.
        /// </summary>
        SucceededWithWarnings
    }

    /// <summary>
    /// Represents the error type.
    /// </summary>
    public enum ErrorType
    {
        /// <summary>
        /// Represents that the given error can't be ignored.
        /// </summary>
        Error,

        /// <summary>
        /// Represents that the given error can be ignored.
        /// </summary>
        Warning
    }

    /// <summary>
    /// Azure Site Recovery vault upgrade details.
    /// </summary>
    public class ASRVaultUpgradeDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVaultUpgradeDetails" /> class.
        /// </summary>
        public ASRVaultUpgradeDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVaultUpgradeDetails" /> class with required
        /// parameters.
        /// </summary>
        /// <param name="resourceUpgradeDetails">Resource upgrade details.</param>
        public ASRVaultUpgradeDetails(ResourceUpgradeDetails resourceUpgradeDetails)
        {
            this.OperationId = resourceUpgradeDetails.OperationId;
            this.StartTimeUtc = resourceUpgradeDetails.StartTimeUtc;
            this.LastUpdatedTimeUtc = resourceUpgradeDetails.LastUpdatedTimeUtc;
            this.Status = resourceUpgradeDetails.Status;
        }

        #region Properties
        /// <summary>
        /// Gets or sets Operation ID.
        /// </summary>
        public string OperationId { get; set; }

        /// <summary>
        /// Gets or sets start time.
        /// </summary>
        public DateTime StartTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets last updated time.
        /// </summary>
        public DateTime LastUpdatedTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public string Status { get; set; }
        #endregion
    }

    /// <summary>
    /// Object to be returned after categorizing all the errors properly 
    /// received as part of vault upgrade operations.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class ExceptionDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionDetails" />
        /// class with required parameters.
        /// </summary>
        /// <param name="errorDetails">Error details.</param>
        /// <param name="warningDetails">Warning details.</param>
        /// <param name="errorCodes">List of error code associated with the errors received.</param>
        public ExceptionDetails(string errorDetails, string warningDetails, HashSet<string> errorCodes)
        {
            this.ErrorDetails = errorDetails;
            this.WarningDetails = warningDetails;
            this.ErrorCodes = errorCodes;
        }

        #region Properties
        /// <summary>
        /// Gets or sets the string containing details of all the errors.
        /// </summary>
        public string ErrorDetails { get; set; }

        /// <summary>
        /// Gets or sets the string containing details of all the warnings.
        /// </summary>
        public string WarningDetails { get; set; }

        /// <summary>
        /// Gets or sets the list of error code.
        /// </summary>
        public HashSet<string> ErrorCodes { get; set; }
        #endregion
    }
}