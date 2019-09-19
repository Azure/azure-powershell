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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;

namespace Microsoft.Azure.PowerShell.Cmdlets.Compute
{
    public class SubscriptionArgumentCompleter : IArgumentCompleter
    {

        protected IEnumerable<IAzureSubscription> Subscriptions {
            get
            {
               return System.Management.Automation.PowerShell.Create(RunspaceMode.CurrentRunspace).AddScript("Get-AzSubscription").Invoke<IAzureSubscription>();
            }
        }
        public IEnumerable<CompletionResult> CompleteArgument(string commandName, string parameterName, string wordToComplete, CommandAst commandAst, IDictionary fakeBoundParameters)
        {
            return Subscriptions.Select(s => new CompletionResult(s.Id, s.Name, CompletionResultType.ParameterValue, "The subscription to use"));
        }
    }
}
