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

using Microsoft.Azure.Commands.Common.Authentication.Config;
using Microsoft.Azure.PowerShell.Common.Config;
using Microsoft.Azure.Commands.Shared.Config;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Authentication.Config.Definitions
{
    /// <summary>
    /// Enables acquisition and attachment of Azure Policy Change Safety tokens for write operations
    /// when the user opts in and supplies -AcquirePolicyToken or -ChangeReference parameters (implemented
    /// in the shared base cmdlet in azure-powershell-common). This repository only contributes the
    /// configuration surface; functionality becomes active when the updated common library is present.
    /// </summary>
    internal class EnablePolicyTokenConfig : TypedConfig<bool>
    {
        public override object DefaultValue => false;

        public override string Key => ConfigKeys.EnablePolicyToken;

        public override string HelpMessage => "Enables acquisition and attachment of Azure Policy change-safety tokens on write operations when -AcquirePolicyToken or -ChangeReference are specified.";

        public override IReadOnlyCollection<AppliesTo> CanApplyTo => new[] { AppliesTo.Az };
    }
}
