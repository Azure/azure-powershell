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
using Microsoft.Azure.Commands.Automation.Properties;
using System;

namespace Microsoft.Azure.Commands.Automation.Model
{
    public class CredentialInfo
    {
         /// <summary>
        /// Initializes a new instance of the <see cref="CredentialInfo"/> class.
        /// </summary>
        /// <param name="Credential">
        /// The Credential.
        /// </param>
        public CredentialInfo(string accountAcccountName, WindowsAzure.Management.Automation.Models.Credential credential)
        {
            Requires.Argument("credential", credential).NotNull();
            this.AutomationAccountName = accountAcccountName;
            this.Name = credential.Name;

            if (credential.Properties == null) return;

            this.Description = credential.Properties.Description;
            this.CreationTime = credential.Properties.CreationTime.ToLocalTime();
            this.LastModifiedTime = credential.Properties.LastModifiedTime.ToLocalTime();
            this.UserName = credential.Properties.UserName;
        }

         /// <summary>
        /// Initializes a new instance of the <see cref="CredentialInfo"/> class.
        /// </summary>
        public CredentialInfo()
        {
        }

        /// <summary>
        /// Gets or sets the automaiton account name.
        /// </summary>
        public string AutomationAccountName { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreationTime { get; set; }

        public DateTimeOffset LastModifiedTime { get; set; }
    }
}
