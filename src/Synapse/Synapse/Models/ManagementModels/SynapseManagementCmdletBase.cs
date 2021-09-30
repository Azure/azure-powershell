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
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynapseManagementCmdletBase : SynapseCmdletBase
    {
        private SynapseAnalyticsManagementClient _synapseAnalyticsManagementClient;

        public SynapseAnalyticsManagementClient SynapseAnalyticsClient
        {
            get
            {
                if (_synapseAnalyticsManagementClient == null)
                {
                    _synapseAnalyticsManagementClient = new SynapseAnalyticsManagementClient(DefaultProfile.DefaultContext);
                }

                return _synapseAnalyticsManagementClient;
            }

            set { _synapseAnalyticsManagementClient = value; }
        }

        protected string ConvertToUnsecureString(System.Security.SecureString securePassword)
        {
            var unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        protected void UpdateProgress(Task task, ProgressRecord progress)
        {
            while (!task.IsCompleted && !task.IsCanceled && !task.IsFaulted)
            {
                if (progress.PercentComplete < 100)
                {
                    progress.PercentComplete++;
                }
                WriteProgress(progress);

                task.Wait(TimeSpan.FromSeconds(15));
            }

            if (progress.PercentComplete < 100)
            {
                progress.PercentComplete = 100;
                WriteProgress(progress);
            }
        }
    }
}
