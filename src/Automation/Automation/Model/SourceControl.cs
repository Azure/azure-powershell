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

using Microsoft.Azure.Commands.Automation.Common;
using System;
using System.Collections;

namespace Microsoft.Azure.Commands.Automation.Model
{
    using AutomationManagement = Azure.Management.Automation;

    /// <summary>
    /// The Source Control.
    /// </summary>
    public class SourceControl : BaseProperties
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SourceControl"/> class.
        /// </summary>
        /// <param name="sourceControl">
        /// The sourceControl.
        /// </param>
        /// <param name="automationAccoutName">
        /// The automation account name.
        /// </param>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public SourceControl(
            AutomationManagement.Models.SourceControl sourceControl,
            string automationAccoutName,
            string resourceGroupName)
        {
            Requires.Argument("accountName", automationAccoutName).NotNull();
            Requires.Argument("resourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("sourceControl", sourceControl).NotNull();

            this.AutomationAccountName = automationAccoutName;
            this.ResourceGroupName = resourceGroupName;
            this.Name = sourceControl.Name;
            this.RepoUrl = sourceControl.RepoUrl;
            this.SourceType = sourceControl.SourceType;
            this.FolderPath = sourceControl.FolderPath;
            this.AutoSync = sourceControl.AutoSync ?? false;
            this.PublishRunbook = sourceControl.PublishRunbook ?? false;
            this.Branch = (sourceControl.Branch != null) ? sourceControl.Branch : null;
            this.Description = (sourceControl.Description != null) ? sourceControl.Description : null;
            this.CreationTime = sourceControl.CreationTime.ToLocalTime();
            this.LastModifiedTime = sourceControl.LastModifiedTime.ToLocalTime();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceControl"/> class.
        /// </summary>
        public SourceControl()
        {
        }

        /// <summary>
        /// Gets or sets the repoUrl.
        /// </summary>
        public string RepoUrl { get; set; }

        /// <summary>
        /// Gets or sets the branch.
        /// </summary>
        public string Branch { get; set; }

        /// <summary>
        /// Gets or sets the folderPath.
        /// </summary>
        public string FolderPath { get; set; }

        /// <summary>
        /// Gets or sets the sourceType.
        /// </summary>
        public string SourceType { get; set; }

        /// <summary>
        /// Gets or sets autoSync.
        /// </summary>
        public bool AutoSync { get; set; }

        /// <summary>
        /// Gets or sets publishRunbook.
        /// </summary>
        public bool PublishRunbook { get; set; }
    }
}
