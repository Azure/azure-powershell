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

using System.Management.Automation;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    /// <summary>
    /// Represents base class for Resource Manager cmdlets
    /// </summary>
    public abstract class AzureRMCmdlet : AzurePSCmdlet
    {
        /// <summary>
        /// Static constructor for AzureRMCmdlet.
        /// </summary>
        static AzureRMCmdlet()
        {
            if (AzureSession.DataStore == null)
            {
                AzureSession.DataStore = new DiskDataStore();
            }
            if (Profile == null)
            {
                Profile = new AzureRMProfile();
            }
        }

        /// <summary>
        /// Gets or sets the global profile for ARM cmdlets.
        /// </summary>
        public static AzureRMProfile DefaultProfile { get; set; }

        /// <summary>
        /// Gets the current default context.
        /// </summary>
        protected override AzureContext DefaultContext
        {
            get
            {
                if (DefaultProfile == null || DefaultProfile.DefaultContext == null)
                {
                    throw new PSInvalidOperationException("Run Login-AzureRMAccount to logic with profile.");
                }

                return DefaultProfile.DefaultContext;
            }
        }

        public virtual void ExecuteCmdlet()
        {
            // Do nothing.
        }

        protected override void ProcessRecord()
        {
            try
            {
                base.ProcessRecord();
                ExecuteCmdlet();
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }
    }
}
