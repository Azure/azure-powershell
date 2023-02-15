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

using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Azure.Commands.Shared.Config;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Authentication.Config.Definitions
{
    /// <summary>
    /// Definition of the config to control the display of breaking change warning messages.
    /// </summary>
    internal class DisplayBreakingChangeWarningsConfig : TypedConfig<bool>
    {
        public override object DefaultValue => true;

        public override string Key => ConfigKeys.DisplayBreakingChangeWarning;

        public override string HelpMessage => Resources.HelpMessageOfDisplayBreakingChangeWarnings;

        public override string ParseFromEnvironmentVariables(IReadOnlyDictionary<string, string> environmentVariables)
        {
            if (environmentVariables.TryGetValue(BreakingChangeAttributeHelper.SUPPRESS_ERROR_OR_WARNING_MESSAGE_ENV_VARIABLE_NAME, out string suppressString) && bool.TryParse(suppressString, out bool suppress))
            {
                return (!suppress).ToString(); // suppress = do not display
            }
            return null;
        }
    }
}
