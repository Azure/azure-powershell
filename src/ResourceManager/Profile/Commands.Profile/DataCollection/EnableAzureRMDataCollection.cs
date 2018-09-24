﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile
{
    [Cmdlet("Enable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataCollection", SupportsShouldProcess = true), OutputType(typeof(void))]
    public class EnableAzureRmDataCollectionCommand : AzureRMCmdlet
    {
        protected override void BeginProcessing()
        {
            // do not call begin processing there is no context needed for this cmdlet
        }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Resources.EnableDataCollection, Resources.DataCollectionEnabledWarning, 
                string.Empty))
            {

                SetDataCollectionProfile(true);
            }
        }

        protected void SetDataCollectionProfile(bool enable)
        {
            var profile = _dataCollectionProfile;
            profile.EnableAzureDataCollection = enable;
            var session = AzureSession.Instance;
            DataCollectionController.WritePSDataCollectionProfile(session, profile);
            AzureSession.Instance.RegisterComponent(DataCollectionController.RegistryKey, () => DataCollectionController.Create(profile), true);
        }
    }
}
