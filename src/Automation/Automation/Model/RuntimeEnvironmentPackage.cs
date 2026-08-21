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

namespace Microsoft.Azure.Commands.Automation.Model
{
    /// <summary>
    /// The Runtime Environment Package model for Azure Automation.
    /// </summary>
    public class RuntimeEnvironmentPackage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RuntimeEnvironmentPackage"/> class.
        /// </summary>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="automationAccountName">
        /// The automation account name.
        /// </param>
        /// <param name="runtimeEnvironmentName">
        /// The runtime environment name.
        /// </param>
        /// <param name="package">
        /// The Package.
        /// </param>
        public RuntimeEnvironmentPackage(string resourceGroupName, string automationAccountName, string runtimeEnvironmentName, Azure.Management.Automation.Models.Package package)
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("automationAccountName", automationAccountName).NotNull();
            Requires.Argument("runtimeEnvironmentName", runtimeEnvironmentName).NotNull();
            Requires.Argument("package", package).NotNull();

            this.ResourceGroupName = resourceGroupName;
            this.AutomationAccountName = automationAccountName;
            this.RuntimeEnvironmentName = runtimeEnvironmentName;
            this.Name = package.Name;
            this.Version = package.Version;
            this.SizeInBytes = package.SizeInBytes;
            this.ProvisioningState = package.ProvisioningState;
            this.CreationTime = package.CreationTime;
            this.LastModifiedTime = package.LastModifiedTime;

            if (package.ContentLink != null)
            {
                this.ContentUri = package.ContentLink.Uri;
                this.ContentVersion = package.ContentLink.Version;
            }

            if (package.Error != null)
            {
                this.ErrorCode = package.Error.Code;
                this.ErrorMessage = package.Error.Message;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuntimeEnvironmentPackage"/> class.
        /// </summary>
        public RuntimeEnvironmentPackage()
        {
        }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        public string AutomationAccountName { get; set; }

        /// <summary>
        /// Gets or sets the runtime environment name.
        /// </summary>
        public string RuntimeEnvironmentName { get; set; }

        /// <summary>
        /// Gets or sets the package name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the size in bytes.
        /// </summary>
        public long? SizeInBytes { get; set; }

        /// <summary>
        /// Gets or sets the provisioning state.
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets the content URI.
        /// </summary>
        public string ContentUri { get; set; }

        /// <summary>
        /// Gets or sets the content version.
        /// </summary>
        public string ContentVersion { get; set; }

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        public DateTimeOffset? CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the last modified time.
        /// </summary>
        public DateTimeOffset? LastModifiedTime { get; set; }
    }
}
