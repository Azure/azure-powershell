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
using System.Collections;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Profile.Properties;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Saves Microsoft Azure profile.
    /// </summary>
    [Cmdlet(VerbsData.Save, "AzureProfile"), OutputType(typeof(AzureSMProfile))]
    public class SaveAzureProfileCommand : AzurePSCmdlet
    {
        [Parameter(Mandatory = false, Position = 0, ValueFromPipelineByPropertyName = true)]
        public AzureRMProfile Profile { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        public string Path { get; set; }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void ExecuteCmdlet()
        {
            if (Profile != null)
            {
                Profile.Save(Path);
            }
            else
            {
                if (AzureRMCmdlet.DefaultProfile == null)
                {
                    throw new ArgumentException(Resources.AzureProfileMustNotBeNull);
                }
                AzureRMCmdlet.DefaultProfile.Save(Path);
            }

            WriteVerbose(string.Format("Profile saved to: {0}.", Path));
        }

        protected override AzureContext DefaultContext
        {
            get
            {
                return null;
            }
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
