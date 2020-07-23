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

using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using System.Threading;

namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Strategies
{
    public class AzureRMAsyncCmdlet : AzureRMCmdlet, IStrategiesCmdletAdapter
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.DefaultInfo(
        Name = @"",
        Description = @"",
        Script = @"(Get-AzContext).Subscription.Id")]
        [Parameter(Mandatory = false)]
        public string SubscriptionId { get; set; }

        public string CorrelationId { get; } = Guid.NewGuid().ToString();

        public string ProcessRecordId { get; set; }

        public InvocationInfo Invocation => MyInvocation;

        public CancellationTokenSource Source { get; } = new CancellationTokenSource();

        public override void ExecuteCmdlet()
        {
            if (Source.IsCancellationRequested) return;
            ProcessRecordId = Guid.NewGuid().ToString();
            base.ExecuteCmdlet();
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
            Source.Cancel();
        }

    }
}
