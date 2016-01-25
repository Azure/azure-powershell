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
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Newtonsoft.Json;
using Microsoft.Azure.Commands.Common.Properties;
using Microsoft.Azure.Commands.Models;
using Microsoft.Azure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Common
{
    public class AzureDataCmdlet : AzurePSCmdlet
    {
        protected override AzureContext DefaultContext
        {
            get
            {
                if (RMProfile != null && RMProfile.Context != null)
                {
                    return RMProfile.Context;
                }

                if (SMProfile == null || SMProfile.Context == null)
                {
                    throw new InvalidOperationException(Resources.NoCurrentContextForDataCmdlet);
                }

                return SMProfile.Context;
            }
        }

        public AzureSMProfile SMProfile
        {
            get { return AzureSMProfileProvider.Instance.GetProfile(DataStore); }
        }

        public AzureRMProfile RMProfile
        {
            get { return GetSessionVariableValue<PSAzureProfile>(AzurePowerShell.ProfileVariable, null); }
        }

        protected override bool IsTelemetryCollectionEnabled
        {
            get
            {
                return false;
            }
        }

        protected override void InitializeQosEvent()
        {
        }
    }
}
