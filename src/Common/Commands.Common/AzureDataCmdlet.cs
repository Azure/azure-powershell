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
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.Common
{
    public class AzureDataCmdlet : AzurePSCmdlet
    {
        protected override Azure.Common.Authentication.Models.AzureContext DefaultContext
        {
            get
            {
                if (RMProfile != null && RMProfile.Context != null)
                {
                    return RMProfile.Context;
                }

                if (SMProfile == null || SMProfile.Context == null)
                {
                    throw new InvalidOperationException("There is no current context, please log in using Login-AzureRmAccount for Azure Resource Manager or Add-AzureAccount for Azure Service Management.");
                }

                return SMProfile.Context;
            }
        }

        public AzureSMProfile SMProfile
        {
            get { return AzureSMProfileProvider.Instance.Profile; }
        }

        public AzureRMProfile RMProfile
        {
            get { return AzureRmProfileProvider.Instance.Profile; }
        }

        public static void ClearCurrentStorageAccount()
        {
            var RMProfile = AzureRmProfileProvider.Instance.Profile;
            if (RMProfile != null && RMProfile.Context != null && 
                RMProfile.Context.Subscription != null)
            {
                RMProfile.Context.Subscription.SetProperty(AzureSubscription.Property.StorageAccount, null);
            }

            var SMProfile = AzureSMProfileProvider.Instance.Profile;
            if (SMProfile != null && SMProfile.Context != null && SMProfile.Context.Subscription != null)
            {
                SMProfile.Context.Subscription.SetProperty(AzureSubscription.Property.StorageAccount, null);
            }
        }

        protected override void SaveDataCollectionProfile()
        {
        }

        protected override void PromptForDataCollectionProfileIfNotExists()
        {
        }

        protected override void InitializeQosEvent()
        {
        }
    }
}
