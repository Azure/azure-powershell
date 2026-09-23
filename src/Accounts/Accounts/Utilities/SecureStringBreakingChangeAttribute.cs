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

using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Attribute to mark a breaking change that is specific for SecureString.
    /// Only applies to cmdlets that do not already have the -AsSecureString parameter.
    /// </summary>
    internal class SecureStringBreakingChangeAttribute : GenericBreakingChangeWithVersionAttribute
    {
        public SecureStringBreakingChangeAttribute(string changeDescription, string changeVersion, string breakingChangeVersion) : base(changeDescription, changeVersion, breakingChangeVersion)
        {
        }

        public override bool IsApplicableToInvocation(InvocationInfo invocation)
        {
            return !invocation.BoundParameters.ContainsKey(nameof(GetAzureRmAccessTokenCommand.AsSecureString));
        }
    }
}
