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
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.Utilities.Profile
{
    /// <summary>
    /// Base class for cmdlets that manipulate the
    /// azure subscription, provides common support
    /// for the SubscriptionDataFile parameter.
    /// </summary>
    public abstract class SubscriptionCmdletBase : AzurePSCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "File storing subscription data, if not set uses default.")]
        public string SubscriptionDataFile { get; set; }

        private readonly bool _saveProfile;

        protected SubscriptionCmdletBase(bool saveProfile)
        {
            this._saveProfile = saveProfile;
        }

        protected override void BeginProcessing()
        {
            if (!string.IsNullOrEmpty(SubscriptionDataFile))
            {
                ProfileClient = new ProfileClient(SubscriptionDataFile);
            }
            else
            {
                ProfileClient = new ProfileClient();
            }
            ProfileClient.WarningLog = WriteWarning;
            ProfileClient.DebugLog = WriteDebug;
        }

        protected override void EndProcessing()
        {
            if (_saveProfile)
            {
                ProfileClient.Profile.Save();
            }
        }

        public ProfileClient ProfileClient { get; set; }
    }
}