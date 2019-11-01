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
using System.Threading;

namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Strategies
{
    public interface IStrategiesCmdletAdapter
    {
        /// <summary>
        /// The subscription Id for the given cmdlet
        /// </summary>
        string SubscriptionId { get; }

        /// <summary>
        /// The correlation Id fro this cmdlet request
        /// </summary>
        string CorrelationId { get; }


        /// <summary>
        /// The process record id for this cmdlet invocation
        /// </summary>
        string ProcessRecordId { get; }

        /// <summary>
        /// The cmdlet invoication info for this invocation of the cmdlet
        /// </summary>
        InvocationInfo Invocation { get; }

        /// <summary>
        /// Cmdlet Cancellation Token Source - cna be used to cancel via StopProcessing
        /// </summary>
        CancellationTokenSource Source { get; }
    }
}
