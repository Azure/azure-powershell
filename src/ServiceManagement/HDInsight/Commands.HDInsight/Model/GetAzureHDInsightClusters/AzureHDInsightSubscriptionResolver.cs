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
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.BaseInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters
{


    internal class AzureHDInsightSubscriptionResolver : IAzureHDInsightSubscriptionResolver
    {
        private readonly AzureSMProfile profile;

        public AzureHDInsightSubscriptionResolver(AzureSMProfile profile)
        {
            this.profile = profile;
        }

        public IAzureSubscription ResolveSubscription(string subscription)
        {
            var resolvedSubscription = this.profile.Subscriptions.FirstOrDefault(s => s.Id == subscription);
            if (resolvedSubscription.IsNull())
            {
                resolvedSubscription = this.profile.Subscriptions.FirstOrDefault(s => s.Name == subscription);
            }

            return resolvedSubscription;
        }
    }
}