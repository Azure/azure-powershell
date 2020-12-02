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
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Model
{
    /// <summary>
    /// Represents an Azure Sql Managed Database
    /// </summary>
    public class AzureSqlManagedDatabaseRestoreDetailsResultModel : AzureSqlManagedDatabaseBaseModel
    {
        /// <summary>
        /// Gets or sets the status of the managed database
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets current restoring file name.
        /// </summary>
        public string CurrentRestoringFileName { get; set; }

        /// <summary>
        /// Gets or sets last restored file name.
        /// </summary>
        public string LastRestoredFileName { get; set; }

        /// <summary>
        /// Gets or sets last restored file time.
        /// </summary>
        public string LastRestoredFileTime { get; set; }

        /// <summary>
        /// Gets or sets percent completed.
        /// </summary>
        public double PercentCompleted { get; set; }

        /// <summary>
        /// Gets or sets comma separated list of unrestorable files.
        /// </summary>
        public string UnrestorableFiles { get; set; }

        /// <summary>
        /// Gets or sets number of files detected.
        /// </summary>
        public long NumberOfFilesDetected { get; set; }

        /// <summary>
        /// Gets or sets last uploaded file name.
        /// </summary>
        public string LastUploadedFileName { get; set; }

        /// <summary>
        /// Gets or sets last uploaded file time.
        /// </summary>
        public string LastUploadedFileTime { get; set; }

        /// <summary>
        /// Gets or sets the reason why restore is in Blocked state.
        /// </summary>
        public string BlockReason { get; set; }

        /// <summary>
        /// Construct AzureSqlManagedDatabaseModel
        /// </summary>
        public AzureSqlManagedDatabaseRestoreDetailsResultModel()
        {
        }

        /// <summary>
        /// Construct AzureSqlManagedDatabaseModel
        /// </summary>
        public AzureSqlManagedDatabaseRestoreDetailsResultModel(ManagedDatabaseRestoreDetailsResult result)
        {
            Status = result.Status;
            CurrentRestoringFileName = result.CurrentRestoringFileName;
            LastRestoredFileName = result.LastRestoredFileName;
            LastRestoredFileTime = result.LastRestoredFileTime.ToString();
            PercentCompleted = result.PercentCompleted ?? -1;
            UnrestorableFiles = result.UnrestorableFiles != null && result.UnrestorableFiles.Count > 0
                ? result.UnrestorableFiles.Aggregate((f1, f2) => $"{f1}, {f2}")
                : null;
            NumberOfFilesDetected = result.NumberOfFilesDetected ?? -1;
            LastUploadedFileName = result.LastUploadedFileName;
            LastUploadedFileTime = result.LastUploadedFileTime.ToString();
            BlockReason = result.BlockReason;
        }
    }
}
