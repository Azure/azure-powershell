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

using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Linq;
using System.Management.Automation;
using Xunit;

namespace Microsoft.Azure.Commands.Profile.Test
{
    /// <summary>
    /// Pins the Change Safety parameter names and help text that Az.Accounts reads from the cmdlet's
    /// BoundParameters (via the pipeline step in <see cref="Microsoft.Azure.Commands.Common.ContextAdapter" />).
    ///
    /// The AutoRest generator hardcodes these same literal strings when it emits the static
    /// -AcquirePolicyToken / -ChangeReference parameters on write-verb cmdlets, and there is no
    /// compile-time link between the generator (powershell/cmdlets/class.ts) and this library. If a name
    /// or help message changes here, these tests fail as a reminder to update the generator to match and
    /// regenerate the modules; otherwise the header would silently stop being stamped.
    /// </summary>
    public class ChangeSafetyParameterContractTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ParameterNamesMatchGeneratorLiterals()
        {
            Assert.Equal("AcquirePolicyToken", ChangeSafetyParameters.AcquirePolicyTokenParamName);
            Assert.Equal("ChangeReference", ChangeSafetyParameters.ChangeReferenceParamName);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ParameterHelpTextMatchesGeneratorLiterals()
        {
            var dict = new RuntimeDefinedParameterDictionary();
            ChangeSafetyParameters.AddChangeSafetyParameters(dict);

            Assert.Equal(
                "Acquire an Azure Policy token automatically for this resource operation.",
                GetHelpMessage(dict, ChangeSafetyParameters.AcquirePolicyTokenParamName));
            Assert.Equal(
                "The change reference resource ID for this resource operation.",
                GetHelpMessage(dict, ChangeSafetyParameters.ChangeReferenceParamName));
        }

        private static string GetHelpMessage(RuntimeDefinedParameterDictionary dict, string name)
        {
            var attribute = dict[name].Attributes.OfType<ParameterAttribute>().First();
            return attribute.HelpMessage;
        }
    }
}
